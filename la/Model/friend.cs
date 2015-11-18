using System;
namespace la.Model
{
	/// <summary>
	/// 一个人可以有多个好友
	/// </summary>
	[Serializable]
	public partial class friend
	{
		public friend()
		{}
		#region Model
		private int _friend_id;
		private string _friend_from;
		private string _friend_to;
		private DateTime? _friend_time;
		private string _friend_state;
		private string _friend_comment;
		/// <summary>
		/// 好友关系ID
		/// </summary>
		public int friend_id
		{
			set{ _friend_id=value;}
			get{return _friend_id;}
		}
		/// <summary>
		/// 好友FROM
		/// </summary>
		public string friend_from
		{
			set{ _friend_from=value;}
			get{return _friend_from;}
		}
		/// <summary>
		/// 好友TO
		/// </summary>
		public string friend_to
		{
			set{ _friend_to=value;}
			get{return _friend_to;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? friend_time
		{
			set{ _friend_time=value;}
			get{return _friend_time;}
		}
		/// <summary>
		/// 关系状态
		/// </summary>
		public string friend_state
		{
			set{ _friend_state=value;}
			get{return _friend_state;}
		}
		/// <summary>
		/// 关系备注
		/// </summary>
		public string friend_comment
		{
			set{ _friend_comment=value;}
			get{return _friend_comment;}
		}
		#endregion Model

	}
}

