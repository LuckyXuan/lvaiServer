using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using la.BLL;
using la.Model;
using System.Web;

namespace la.DataServer
{
    /// <summary>
    /// 用户信息相关数据服务，主要包括个人中心中的
    /// 个人资料，小车资料，登录日志，签到日志。
    /// </summary>
    public class UserInfoServer
    {

        /// <summary>
        /// 登录方法。
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="pwd"></param>
        /// <returns>JSON串</returns>
        public static string login(string tel, string pwd)
        {
            //List<la.Model.user_tb> ul;
            la.Model.user_tb u;
            string result = "{\"status\":";

            if (Util.validSqlInsert(tel) || Util.validSqlInsert(pwd))
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"含有非法攻击字符\",";
                result = result + "\"data\":{}}";
                return result;
            }

            try
            {
               u=new la.BLL.user_tb().GetModel(tel);
            }
            catch (Exception e)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"" + e.Message + "\",";
                result = result + "\"data\":{}}";
                return result;
            }
            if (u == null )
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"该手机未注册\",";
                result = result + "\"data\":{}}";
                return result;
            }
            if (u.user_pwd != pwd)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"该手机未注册或者密码错误\",";
                result = result + "\"data\":{}}";
                return result;
            }
            result = result + "\"success\",";
            result = result + "\"msg\":\"\",";
            result = result + "\"data\":";
            string jsentri = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(u);
           // jsentri.Replace("\\/Date(","");
          //  jsentri.Replace(")\\/", "");
            result = result + jsentri+"}";
            return result;
        }

       



    }
}
