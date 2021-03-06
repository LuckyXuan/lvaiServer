﻿using System;
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
namespace la.Web.comment_dic
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txt评价字典编号.Text))
			{
				strErr+="评价字典编号格式错误！\\n";	
			}
			if(this.txt评价字典内容.Text.Trim().Length==0)
			{
				strErr+="评价字典内容不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txt对应分值.Text))
			{
				strErr+="对应分值格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int 评价字典编号=int.Parse(this.txt评价字典编号.Text);
			string 评价字典内容=this.txt评价字典内容.Text;
			int 对应分值=int.Parse(this.txt对应分值.Text);

			la.Model.comment_dic model=new la.Model.comment_dic();
			model.评价字典编号=评价字典编号;
			model.评价字典内容=评价字典内容;
			model.对应分值=对应分值;

			la.BLL.comment_dic bll=new la.BLL.comment_dic();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
