using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using la.DAL;

namespace la.DataServer
{
    public class VideoServer
    {
        /// <summary>
        /// 根据用户手机号。。获取用户最后上传的语音对象
        /// </summary>
        /// <param name="tel">电话号码</param>
        /// <returns></returns>
        public static Model.video getLastVideo(string tel)
        {
            return new DAL.video().getLastVideo(tel);
        }
    }
}
