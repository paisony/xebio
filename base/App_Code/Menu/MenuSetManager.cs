// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Web;
using System.IO;
using System.Data;
using System.Configuration;
using Com.Fujitsu.SmartBase.Base.Web.Menu;
using Com.Fujitsu.SmartBase.Base.Web.Menu.MenuGenerator;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Systems.VO;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Role;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Collections;
using Com.Fujitsu.SmartBase.Library.Log;
using System.Web.Caching;

namespace Com.Fujitsu.SmartBase.Base.Web.Menu
{
	/// <summary>
	///	���j���[�Z�b�g�̍쐬�폜���Ǘ�������N���X�ł��B
	/// </summary>
	public class MenuSetManager
	{
		/// <summary>
		/// ���O�o��
		/// </summary>
		private static ILogger logger = LogManager.GetLogger();

		#region ���j���[�Z�b�g�̊Ǘ�
		#region CheckMenuSet
		/// <summary>
		/// ���j���[HTML���`�F�b�N���܂��B
		/// �Ȃ���΃��j���[HTML�𐶐����܂��B
		/// </summary>
		/// <returns>���j���[�̃t�@�C�����A���s�����null</returns>
		public static string GetMenuSetString()
		{
			bool CacheFlag = false;
			if (ConfigurationManager.AppSettings[WebConstantUtil.MENU_CACHE_APPLICATION] == null
						|| Convert.ToBoolean(ConfigurationManager.AppSettings[WebConstantUtil.MENU_CACHE_APPLICATION]) == true)
			{
				CacheFlag = true;
			}

			string language = LoginUserContext.Language;
			//�c�a���烁�j���[�Z�b�g�L���b�V�����擾
			MenuService service = new MenuService();

			MenuSetCacheKey key = new MenuSetCacheKey();
			if (LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
			{
				key.LoginId = LoginUserContext.LoginId;
			}
			else
			{
				key.LoginId = LoginUserContext.MenuPtnCd;
			}
			key.MenuLanguage = language;
			string html;
			if (CacheFlag)
			{
				//�Ăяo�����@
				if (HttpContext.Current.Cache[key.LoginId] == null)
				{
					if (LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
					{
						html = GetSystemMgrMenu();
					}
					else
					{
						html = GetGeneralMenu();
					}
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Cache.Remove(key.LoginId);
					HttpContext.Current.Cache.Insert(key.LoginId, html, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);
					HttpContext.Current.Application.UnLock();
					//��������HTML�f�[�^��Ԃ��B
					return html;
				}
				else
				{
					return Convert.ToString(HttpContext.Current.Cache.Get(key.LoginId));
				}
			}
			else
			{
				//HTML�𐶐�
				if (LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
				{
					html = GetSystemMgrMenu();
				}
				else
				{
					html = GetGeneralMenu();
				}
				HttpContext.Current.Application.Lock();
				HttpContext.Current.Cache.Remove(key.LoginId);
				HttpContext.Current.Cache.Insert(key.LoginId, html, null, DateTime.Now.AddMinutes(SystemSettings.CacheValidDuration), Cache.NoSlidingExpiration);
				HttpContext.Current.Application.UnLock();
				//��������HTML�f�[�^��Ԃ��B
				return html;
			}
		}

		#endregion

		#region DeleteMenuSetCache
		/// <summary>
		/// ���j���[�Z�b�g�L���b�V�����폜����
		/// </summary>
		public void DeleteMenuSetCache(string companyId, string loginId, string language)
		{
			MenuService service = new MenuService();

			MenuSetCacheKey key = new MenuSetCacheKey();
			key.LoginId = loginId;
			key.MenuLanguage = language;

			service.DeleteMenuSetCache(key);
		}

		/// <summary>
		/// ���ׂẴ��j���[�Z�b�g�L���b�V�����폜����
		/// </summary>
		/// <returns></returns>
		public void DeleteAllMenuSetCache()
		{
			try
			{
				MenuService service = new MenuService();
				service.DeleteAllMenuSetCache();
			}
			catch (Exception)
			{
			}
		}
		#endregion

		#endregion

		#region private

		/// <summary>
		/// ��ʃ��[�U���j���[�𐶐�
		/// </summary>
		/// <returns></returns>
		private static string GetGeneralMenu()
		{
			if (logger.IsDebugEnabled)
			{
				logger.Debug("��ʃ��[�U���j���[�𐶐�����܂���");
			}
			//���j���[�����擾����B
			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			infoVO.LoginId = LoginUserContext.LoginId;
			RoleService roleService = new RoleService(infoVO);
			DataResult<List<string>> res2 = null;
			res2 = roleService.GetSystemAuthorizationByLoginUser(LoginUserContext.UserType);
			if (!res2.IsSuccess)
			{
				throw new ApplicationException("���[���g�p�����擾�Ɏ��s���܂����B");
			}

			////HTML�𐶐�����B
			GenerateMenuSetVO menuSetVO = new GenerateMenuSetVO();
			foreach (string solutionId in res2.ResultData)
			{
				DataTable viewDt = FunctionViewMst.GetFunctionView(solutionId, 1, false);
				foreach (DataRow row in viewDt.Rows)
				{
					GenerateMenuVO menuVO = new GenerateMenuVO(row);
					menuSetVO.GenerateMenuVOs.Add(menuVO);
					SetMenuVO(menuVO);
				}
			}

			//�\���ݒ�
			SetMenuVisible(menuSetVO);

			return MenuSetGenerator.Render(menuSetVO);
		}

		/// <summary>
		/// �V�X�e���Ǘ��҃��j���[�𐶐�
		/// </summary>
		/// <returns></returns>
		private static string GetSystemMgrMenu()
		{
			//���j���[�����擾����B
			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			infoVO.LoginId = LoginUserContext.LoginId;
			////HTML�𐶐�����B
			GenerateMenuSetVO menuSetVO = new GenerateMenuSetVO();
			DataTable dt = SolutionMst.GetAllSolution();
			//�\�����[�V�������Ń\�[�g(����)
			DataView dv = new DataView(dt);
			dv.Sort = "SOLUTION_ID";

			//�d�����폜
			List<string> solList = new List<string>();
			foreach (DataRowView solRow in dv)
			{
				string solutionId = Convert.ToString(solRow["SOLUTION_ID"]);
				if (!solList.Contains(solutionId))
					solList.Add(solutionId);
			}
			//���j���[�u�n���Z�b�g
			foreach (string solutionId in solList)
			{
				DataTable viewDt = FunctionViewMst.GetFunctionView(solutionId, 1, true);
				foreach (DataRow row in viewDt.Rows)
				{
					GenerateMenuVO menuVO = new GenerateMenuVO(row);
					menuSetVO.GenerateMenuVOs.Add(menuVO);
					SetMenuVO(menuVO);
				}
			}

			//�\���ݒ�
			SetMenuVisible(menuSetVO);

			return MenuSetGenerator.Render(menuSetVO);
		}

		private static void SetMenuVO(GenerateMenuVO vo)
		{
			DataTable dt = FunctionViewMst.GetChilds(vo.SolutionId, vo.FunctionViewId);
			foreach (DataRow row in dt.Rows)
			{
				GenerateMenuVO childVO = new GenerateMenuVO(row);
				vo.GenerateMenuVOs.Add(childVO);
				SetMenuVO(childVO);
			}
			return;
		}

		private static void SetMenuVisible(GenerateMenuSetVO vo)
		{
			foreach (GenerateMenuVO menuVO in vo.GenerateMenuVOs)
			{
				SetMenuVisible(menuVO);
				DeleteOfflineMenu(menuVO);
			}
		}

		private static bool SetMenuVisible(GenerateMenuVO vo)
		{
			bool visible = false;
			if (!string.IsNullOrEmpty(vo.FunctionID))
			{
				string systemType = FunctionMst.GetFunctionSystemType(vo.SolutionId, vo.FunctionID);
				if (systemType == ConstantUtil.SUBSYSTEM_TYPE_WEB)
				{
					if (!LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
					{
						if (LoginUserContext.RoleIds.Count == 0)
						{
							visible = false;
						}
						else
						{
							//�@�\�g�p�����`�F�b�N
							foreach (string roleId in LoginUserContext.RoleIds)
							{
								visible = FunctionAuthorizationMst.CheckFunctionAuthorization(roleId, vo.SolutionId, vo.FunctionID);
								if (visible)
									break;
							}
						}
					}
					else
						visible = true;
				}
				else
					visible = false;
			}
			else
			{
				//�q�K�w��\���ݒ�
				foreach (GenerateMenuVO menuVO in vo.GenerateMenuVOs)
				{
					visible = SetMenuVisible(menuVO) || visible;
				}
			}
			vo.Visible = visible;
			return visible;
		}


		private static bool DeleteOfflineMenu(GenerateMenuVO vo)
		{
			//�����疳���ȏꍇ�͂Ȃɂ����Ȃ��B
			if (vo.Visible == false)
				return false;

			bool visible = false;
			if (!string.IsNullOrEmpty(vo.FunctionID))
			{
				//�@�\��ނ��`�F�b�N
				visible = FunctionMst.GetFunctionSystemType(vo.SolutionId, vo.FunctionID) == ConstantUtil.SUBSYSTEM_TYPE_WEB;
			}
			else
			{
				//�q�K�w��\���ݒ�
				foreach (GenerateMenuVO menuVO in vo.GenerateMenuVOs)
				{
					visible = DeleteOfflineMenu(menuVO) || visible;
				}
			}
			vo.Visible = visible;
			return visible;
		}
		#endregion
	}
}
