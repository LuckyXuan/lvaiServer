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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtfriendchange_ID.Text))
			{
				strErr+="关系变更ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfriend_id.Text))
			{
				strErr+="好友关系ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int friendchange_ID=int.Parse(this.txtfriendchange_ID.Text);
			int friend_id=int.Parse(this.txtfriend_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
