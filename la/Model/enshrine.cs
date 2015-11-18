using System;
namespace la.Model
{
	/// <summary>
	/// 收藏发布的旅行
	/// </summary>
	[Serializable]
	public partial class enshrine
	{
		public enshrine()
		{}
		#region Model
		private int _enshrine_id;
		private int _travle_id;
		private string _user_telphone;
		private DateTime? _enshrine_time;
		private bool _enshrine_islvalid;
		/// <summary>
		/// 收藏ID
		/// </summary>
		public int enshrine_id
		{
			set{ _enshrine_id=value;}
			get{return _enshrine_id;}
		}
		/// <summary>
		/// 旅行ID
		/// </summary>
		public int travle_ID
		{
			set{ _travle_id=value;}
			get{return _travle_id;}
		}
		/// <summary>
		/// 用户Phone
		/// </summary>
		public string user_telphone
		{
			set{ _user_telphone=value;}
			get{return _user_telphone;}
		}
		/// <summary>
		/// 收藏时间
		/// </summary>
		public DateTime? enshrine_time
		{
			set{ _enshrine_time=value;}
			get{return _enshrine_time;}
		}
		/// <summary>
		/// 收藏是否有效
		/// </summary>
		public bool enshrine_islvalid
		{
			set{ _enshrine_islvalid=value;}
			get{return _enshrine_islvalid;}
		}
		#endregion Model

	}
}

