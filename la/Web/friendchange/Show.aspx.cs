using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace la.Web.friendchange
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int friendchange_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					friendchange_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				int friend_id = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					friend_id=(Convert.ToInt32(Request.Params["id1"]));
				}
				string user_telphone = "";
				if (Request.Params["id2"] != null && Request.Params["id2"].Trim() != "")
				{
					user_telphone= Request.Params["id2"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(friendchange_ID,friend_id,user_telphone);
			}
		}
		
	private void ShowInfo(int friendchange_ID,int friend_id,string user_telphone)
	{
		la.BLL.friendchange bll=new la.BLL.friendchange();
		la.Model.friendchange model=bll.GetModel(friendchange_ID,friend_id,user_telphone);
		this.lblfriendchange_ID.Text=model.friendchange_ID.ToString();
		this.lblfriend_id.Text=model.friend_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblfriendchange_time.Text=model.friendchange_time.ToString();
		this.lblfriendchange_op.Text=model.friendchange_op;
		this.lblfriendchange_comment.Text=model.friendchange_comment;

	}


    }
}
