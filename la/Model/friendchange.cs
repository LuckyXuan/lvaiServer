using System;
namespace la.Model
{
	/// <summary>
	/// 好友之间可能进行删除操作，数据库本身并不删除，只是修改好友之间的状态关系。
	/// </summary>
	[Serializable]
	public partial class friendchange
	{
		public friendchange()
		{}
		#region Model
		private int _friendchange_id;
		private int _friend_id;
		private string _user_telphone;
		private DateTime? _friendchange_time;
		private string _friendchange_op;
		private string _friendchange_comment;
		/// <summary>
		/// 关系变更ID
		/// </summary>
		public int friendchange_ID
		{
			set{ _friendchange_id=value;}
			get{return _friendchange_id;}
		}
		/// <summary>
		/// 好友关系ID
		/// </summary>
		public int friend_id
		{
			set{ _friend_id=value;}
			get{return _friend_id;}
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
		/// 关系变更时间
		/// </summary>
		public DateTime? friendchange_time
		{
			set{ _friendchange_time=value;}
			get{return _friendchange_time;}
		}
		/// <summary>
		/// 关系变更操作
		/// </summary>
		public string friendchange_op
		{
			set{ _friendchange_op=value;}
			get{return _friendchange_op;}
		}
		/// <summary>
		/// 关系变更备注
		/// </summary>
		public string friendchange_comment
		{
			set{ _friendchange_comment=value;}
			get{return _friendchange_comment;}
		}
		#endregion Model

	}
}

