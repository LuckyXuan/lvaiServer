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
namespace la.Web.enshrine
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int enshrine_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					enshrine_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				int travle_ID = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					travle_ID=(Convert.ToInt32(Request.Params["id1"]));
				}
				string user_telphone = "";
				if (Request.Params["id2"] != null && Request.Params["id2"].Trim() != "")
				{
					user_telphone= Request.Params["id2"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(enshrine_id,travle_ID,user_telphone);
			}
		}
		
	private void ShowInfo(int enshrine_id,int travle_ID,string user_telphone)
	{
		la.BLL.enshrine bll=new la.BLL.enshrine();
		la.Model.enshrine model=bll.GetModel(enshrine_id,travle_ID,user_telphone);
		this.lblenshrine_id.Text=model.enshrine_id.ToString();
		this.lbltravle_ID.Text=model.travle_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblenshrine_time.Text=model.enshrine_time.ToString();
		this.lblenshrine_islvalid.Text=model.enshrine_islvalid?"是":"否";

	}


    }
}
