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
namespace la.Web.looksindex
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int looksindex_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					looksindex_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(looksindex_id,user_telphone);
			}
		}
		
	private void ShowInfo(int looksindex_id,string user_telphone)
	{
		la.BLL.looksindex bll=new la.BLL.looksindex();
		la.Model.looksindex model=bll.GetModel(looksindex_id,user_telphone);
		this.lbllooksindex_id.Text=model.looksindex_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lbllooksindex_change_value.Text=model.looksindex_change_value.ToString();
		this.lbllooksindex_change_time.Text=model.looksindex_change_time.ToString();
		this.lbllooksindex_change_comment.Text=model.looksindex_change_comment;
		this.lbllooksindex_result.Text=model.looksindex_result.ToString();
		this.lbllooksindex_change_type.Text=model.looksindex_change_type;

	}


    }
}
