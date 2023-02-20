// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;

using Com.Fujitsu.SmartBase.Base.Common.Model.VO;

namespace Com.Fujitsu.SmartBase.Base.OperationTimeSettings.VO
{
	#region 主キーオブジェクト

	/// <summary>
	/// エンティティBS_OPERATION_TIMEの主キーを表すクラス
	/// </summary>
    [Serializable]
	public class OperationTimeSettingsKey : IPrimaryKey
	{
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します
		/// </summary>
		public OperationTimeSettingsKey()
		{
		}

		/// <summary>
		/// すべての列を明示的に初期化します。
		/// </summary>
        /// <param name="day_type">列「DAY_TYPE」の値</param>
        public OperationTimeSettingsKey(
			string dayType
			)
		{
            this.dayType = dayType;
		}
		#endregion
		
		#region フィールド

		/// <summary>
        /// 列「DAY_TYPE(DAY_TYPE)」の値
		/// </summary>
        protected string dayType;

		#endregion

		#region プロパティ

		/// <summary>
        /// 列「DAY_TYPE」の値を取得または設定する
		/// </summary>
		public string DayTYPE
		{
			get
			{
                return dayType;
			}
			set
			{
                dayType = value;
			}
		}
		#endregion

		#region IPrimaryKey メンバ

		/// <summary>
		/// Entityの主キー列の列名と値のペアを取得します。
		/// </summary>
		/// <returns>主キー列名/値の配列</returns>
		public KeyValuePair<string, object>[] GetPrimayKeyValues()
		{
			return new KeyValuePair<string, object>[]{
				new KeyValuePair<string, object>("DAY_TYPE",dayType),
			};
		}

		#endregion
	}

	#endregion

	#region エンティティVO

	/// <summary>
    ///  エンティティBS_OPERATION_TIMEに対応したValueObjectです。
	/// </summary>
    [Serializable]
    public class OperationTimeSettingsVO : OperationTimeSettingsKey
    {
        #region フィールド

        /// <summary>
        /// 列「START_TIME(START_TIME)」の値
        /// </summary>
        private string starttime;

        /// <summary>
        /// 列「STOP_TIME」の値
        /// </summary>
        private string stoptime;

        #endregion

        #region プロパティ

        /// <summary>
        /// 列「START_TIME」の値を取得または設定する
        /// </summary>
        public string STARTTime 
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }
        }

        /// <summary>
        /// 列「PC_NAME」の値を取得または設定する
        /// </summary>
        public string STOPTime
        {
            get
            {
                return stoptime;
            }
            set
            {
                stoptime = value;
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
		/// インスタンスを生成します
		/// </summary>
        public OperationTimeSettingsVO()
		{
		}

		#endregion
		
		#region メソッド
		/// <summary>
        /// 現在のOperationTimeSettingsVOを表すSystem.Stringを返します。
		/// </summary>
        /// <returns>現在のOperationTimeSettingsVOを表すSystem.String。</returns>
		public override string ToString()
		{
			StringBuilder sb=new StringBuilder();

            sb.Append("day_type:").Append(this.dayType).AppendLine();
            sb.Append("START_Time:").Append(this.starttime.ToString()).AppendLine();
            sb.Append("STOP_Time:").Append(this.stoptime.ToString()).AppendLine();

			return sb.ToString();
		}

		/// <summary>
		/// VOのコピーを返します。
		/// </summary>
        /// <returns>OperationTimeSettingsVO</returns>
        public OperationTimeSettingsVO Copy()
		{
            OperationTimeSettingsVO vo = new OperationTimeSettingsVO();
            vo.DayTYPE = this.DayTYPE;
            vo.STARTTime = this.STARTTime;
            vo.STOPTime = this.STOPTime;

			return vo;
        }

		#endregion

	}

	#endregion
}

