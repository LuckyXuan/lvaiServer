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
namespace la.Web.enshrine
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtenshrine_id.Text))
			{
				strErr+="收藏ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttravle_ID.Text))
			{
				strErr+="旅行ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtenshrine_time.Text))
			{
				strErr+="收藏时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int enshrine_id=int.Parse(this.txtenshrine_id.Text);
			int travle_ID=int.Parse(this.txttravle_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
			DateTime enshrine_time=DateTime.Parse(this.txtenshrine_time.Text);
			bool enshrine_islvalid=this.chkenshrine_islvalid.Checked;

			la.Model.enshrine model=new la.Model.enshrine();
			model.enshrine_id=enshrine_id;
			model.travle_ID=travle_ID;
			model.user_telphone=user_telphone;
			model.enshrine_time=enshrine_time;
			model.enshrine_islvalid=enshrine_islvalid;

			la.BLL.enshrine bll=new la.BLL.enshrine();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
