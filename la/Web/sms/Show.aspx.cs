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
namespace la.Web.sms
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int sms_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					sms_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(sms_id,user_telphone);
			}
		}
		
	private void ShowInfo(int sms_id,string user_telphone)
	{
		la.BLL.sms bll=new la.BLL.sms();
		la.Model.sms model=bll.GetModel(sms_id,user_telphone);
		this.lblsms_id.Text=model.sms_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblsms_content.Text=model.sms_content;
		this.lblsms_time.Text=model.sms_time.ToString();
		this.lblsms_comment.Text=model.sms_comment;
		this.lblsms_ispay.Text=model.sms_ispay?"是":"否";

	}


    }
}
