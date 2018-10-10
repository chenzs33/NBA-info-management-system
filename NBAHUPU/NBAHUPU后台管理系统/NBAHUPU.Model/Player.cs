using System;
namespace NBAHUPU.Model
{
	/// <summary>
	/// Player:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class Player
	{
        #region Model
        private string _Playerno;
        private string _Playername;
        private string _PlayerEngname;
        private int _teamid;
        private string _age;
        private DateTime _birthday;
        private string _height;
        private string _weight;
        private string _location;
        private string _photo;

        /// <summary>
        /// 
        /// </summary>
        public string PlayerNo
        {
            set { _Playerno = value; }
            get { return _Playerno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlayerName
        {
            set { _Playername = value; }
            get { return _Playername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlayerEngName
        {
            set { _PlayerEngname = value; }
            get { return _PlayerEngname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TeamId
        {
            set { _teamid = value; }
            get { return _teamid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Weight
        {
            set { _weight = value; }
            get { return _weight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Location
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        
        #endregion Model

	}
}

