using System;
namespace NBAHUPU.Model
{
	/// <summary>
	/// Division:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Division
	{
        public Division()
        { }
        #region Model
        private int _Divisionid;
        private string _Divisionname;
        private int _Associationid;
        /// <summary>
        /// 
        /// </summary>
        public int DivisionId
        {
            set { _Divisionid = value; }
            get { return _Divisionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DivisionName
        {
            set { _Divisionname = value; }
            get { return _Divisionname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AssociationId
        {
            set { _Associationid = value; }
            get { return _Associationid; }
        }
        #endregion Model

	}
}

