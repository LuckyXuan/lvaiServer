using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using la.DAL;

namespace la.DataServer
{
    public class AudioServer
    {
        /// <summary>
        /// 根据用户手机号。。获取用户最后上传的语音对象
        /// </summary>
        /// <param name="tel">电话号码</param>
        /// <returns></returns>
        public static Model.audio getLastAudio(string tel)
        {
            return new DAL.audio().getLastAudio(tel); 
        }
    }
}
