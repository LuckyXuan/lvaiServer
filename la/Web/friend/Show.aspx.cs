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
namespace la.Web.friend
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int friend_id=(Convert.ToInt32(strid));
					ShowInfo(friend_id);
				}
			}
		}
		
	private void ShowInfo(int friend_id)
	{
		la.BLL.friend bll=new la.BLL.friend();
		la.Model.friend model=bll.GetModel(friend_id);
		this.lblfriend_id.Text=model.friend_id.ToString();
		this.lblfriend_from.Text=model.friend_from;
		this.lblfriend_to.Text=model.friend_to;
		this.lblfriend_time.Text=model.friend_time.ToString();
		this.lblfriend_state.Text=model.friend_state;
		this.lblfriend_comment.Text=model.friend_comment;

	}


    }
}
