using System;
namespace NBAHUPU.Model
{
    /// <summary>
    /// Team:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
	public class Team
	{
		public Team()
		{}
		#region Model
		private int _Teamid;
		private string _teamname;
        private int _teamsize;
		private int _Divisionid;
		/// <summary>
		/// 
		/// </summary>
		public int TeamId
        {
			set{ _Teamid = value;}
			get{return _Teamid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeamName
        {
			set{ _teamname = value;}
			get{return _teamname; }
		}

        public int TeamSize
        {
            set { _teamsize = value; }
            get { return _teamsize; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int DivisionId
		{
			set{ _Divisionid=value;}
			get{return _Divisionid;}
		}
		#endregion Model

	}
}

