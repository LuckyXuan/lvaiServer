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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace la.Web.friendchange
{
    public partial class Modify : Page
    {       

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
		this.txtfriendchange_time.Text=model.friendchange_time.ToString();
		this.txtfriendchange_op.Text=model.friendchange_op;
		this.txtfriendchange_comment.Text=model.friendchange_comment;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtfriendchange_time.Text))
			{
				strErr+="关系变更时间格式错误！\\n";	
			}
			if(this.txtfriendchange_op.Text.Trim().Length==0)
			{
				strErr+="关系变更操作不能为空！\\n";	
			}
			if(this.txtfriendchange_comment.Text.Trim().Length==0)
			{
				strErr+="关系变更备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int friendchange_ID=int.Parse(this.lblfriendchange_ID.Text);
			int friend_id=int.Parse(this.lblfriend_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			DateTime friendchange_time=DateTime.Parse(this.txtfriendchange_time.Text);
			string friendchange_op=this.txtfriendchange_op.Text;
			string friendchange_comment=this.txtfriendchange_comment.Text;


			la.Model.friendchange model=new la.Model.friendchange();
			model.friendchange_ID=friendchange_ID;
			model.friend_id=friend_id;
			model.user_telphone=user_telphone;
			model.friendchange_time=friendchange_time;
			model.friendchange_op=friendchange_op;
			model.friendchange_comment=friendchange_comment;

			la.BLL.friendchange bll=new la.BLL.friendchange();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
