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
namespace la.Web.friend
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int friend_id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(friend_id);
				}
			}
		}
			
	private void ShowInfo(int friend_id)
	{
		la.BLL.friend bll=new la.BLL.friend();
		la.Model.friend model=bll.GetModel(friend_id);
		this.lblfriend_id.Text=model.friend_id.ToString();
		this.txtfriend_from.Text=model.friend_from;
		this.txtfriend_to.Text=model.friend_to;
		this.txtfriend_time.Text=model.friend_time.ToString();
		this.txtfriend_state.Text=model.friend_state;
		this.txtfriend_comment.Text=model.friend_comment;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtfriend_from.Text.Trim().Length==0)
			{
				strErr+="好友FROM不能为空！\\n";	
			}
			if(this.txtfriend_to.Text.Trim().Length==0)
			{
				strErr+="好友TO不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtfriend_time.Text))
			{
				strErr+="添加时间格式错误！\\n";	
			}
			if(this.txtfriend_state.Text.Trim().Length==0)
			{
				strErr+="关系状态不能为空！\\n";	
			}
			if(this.txtfriend_comment.Text.Trim().Length==0)
			{
				strErr+="关系备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int friend_id=int.Parse(this.lblfriend_id.Text);
			string friend_from=this.txtfriend_from.Text;
			string friend_to=this.txtfriend_to.Text;
			DateTime friend_time=DateTime.Parse(this.txtfriend_time.Text);
			string friend_state=this.txtfriend_state.Text;
			string friend_comment=this.txtfriend_comment.Text;


			la.Model.friend model=new la.Model.friend();
			model.friend_id=friend_id;
			model.friend_from=friend_from;
			model.friend_to=friend_to;
			model.friend_time=friend_time;
			model.friend_state=friend_state;
			model.friend_comment=friend_comment;

			la.BLL.friend bll=new la.BLL.friend();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
