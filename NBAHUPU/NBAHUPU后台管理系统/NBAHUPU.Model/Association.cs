using System;
namespace NBAHUPU.Model
{
	/// <summary>
	/// Association:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Association
	{
        public Association()
        { }
        #region Model
        private int _Associationid;
        private string _Associationname;
        /// <summary>
        /// 
        /// </summary>
        public int AssociationId
        {
            set { _Associationid = value; }
            get { return _Associationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AssociationName
        {
            set { _Associationname = value; }
            get { return _Associationname; }
        }

        #endregion Model

	}
}

