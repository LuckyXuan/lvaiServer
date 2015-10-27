using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Collections.Generic;


namespace la.Web
{
    /// <summary>
    /// UploadHandler 的摘要说明。
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        /// <summary>
        /// 调用的方法。(1)uploadHeadPhoto.上传头像方法。
        ///               参数为:tel
        ///             (2)uploadVideo。上传验证视频。
        ///              参数为:tel
        ///             (3)uploadCarPhoto.上传小车图片。
        ///              参数为：tel  电话号码
        ///                     index 第几张汽车图片。
        ///             (4)uploadVideo 上传视频。
        ///              参数：tel
        ///            （5）uploadAudio 上传音频。
        ///              参数：tel
        ///            （6）uploadBg 上传背景图片。
        ///              参数：tel 
        /// </summary>
        private string Action="";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Action = context.Request.Form["Action"].ToString();
            if (Action == "uploadHeadPhoto")
            {
                UploadHeadPhoto(context);
            }
            if (Action == "uploadCarPhoto")
            {
                UploadCarPhoto(context);
            }
            if (Action == "uploadHeadPhoto0")
            {
                UploadHeadPhoto0(context);
            }
            if (Action == "uploadCarPhoto0")
            {
                UploadCarPhoto0(context);
            }
        }

        /// <summary>
        /// 上传音频。
        /// </summary>
        /// <param name="context"></param>
        private void UploadUserAudio(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string base64 = context.Request.Form["base64"].ToString();

            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/UserVideo/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".mp4";
            string filePath = dirPath + fileName;//file.FileName;

            BLL.video vBLL = new BLL.video();
            Model.video v = new Model.video();
            v.user_telphone = tel;
            v.video_state = "未审核";
            v.video_uploadtime = DateTime.Now;
            v.video_url = filePath;
            vBLL.Add(v);
            string Pic_Path = filePath;
            try
            {
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64);
                        bw.Write(data);
                        bw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}");
            }
            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + u.user_photo + "\"}";
            context.Response.Write(result); 
        
        }

        /// <summary>
        /// 上传用户个人中心背景。
        /// </summary>
        private void UploadUserCenterBg(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/UserCenterBg/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
            string filePath = dirPath + fileName;//file.FileName;

            BLL.user_tb ubll = new BLL.user_tb();
            Model.user_tb u = ubll.GetModel(tel);
            u.personcenter_bg = "/UploadFile/UserCenterBg/" + fileName;
            ubll.Update(u);

            string Pic_Path = filePath;
            try
            {
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64);
                        bw.Write(data);
                        bw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}");
            }
            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + u.user_photo + "\"}";
            context.Response.Write(result); 
        
        }

        /// <summary>
        /// 上传视频。
        /// </summary>
        private void UploadVideo(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string base64 = context.Request.Form["base64"].ToString();

            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/UserVideo/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".mp4";
            string filePath = dirPath + fileName;//file.FileName;

            BLL.video vBLL = new BLL.video();
            Model.video v = new Model.video();
            v.user_telphone = tel;
            v.video_state = "未审核";
            v.video_uploadtime = DateTime.Now;
            v.video_url = filePath;
            vBLL.Add(v);
            string Pic_Path = filePath;
            try
            {
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64);
                        bw.Write(data);
                        bw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}");
            }
            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + u.user_photo + "\"}";
            context.Response.Write(result); 
        
        
        }
        /// <summary>
        /// 上传用户头像base64编码形式。
        /// liu
        /// </summary>
        private void UploadHeadPhoto0(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string base64 = context.Request.Form["base64"].ToString();

            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/HeadPhoto/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
            string filePath = dirPath + fileName;//file.FileName;

            BLL.user_tb ubll = new BLL.user_tb();
            Model.user_tb u = ubll.GetModel(tel);
            u.user_photo = "/UploadFile/HeadPhoto/" + fileName;
            ubll.Update(u);

            string Pic_Path = filePath;
            try
            {
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64);
                        bw.Write(data);
                        bw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}"); 
            }


            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + u.user_photo + "\"}";
            context.Response.Write(result); 
        }
         /// <summary>
        /// 上传车辆图片0。
        /// </summary>
        private void UploadCarPhoto0(HttpContext context)
        {
            string thumbDirPath = context.Server.MapPath("~/UploadFile/CarPhoto/");
            string  dirPath = context.Server.MapPath("~/UploadFile/CarPhoto/thumbCarPhoto/");
            string tel = context.Request.Form["tel"].ToString();
            string photoindex = context.Request.Form["index"].ToString();
            
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                if (!Directory.Exists(thumbDirPath))
                {
                    Directory.CreateDirectory(thumbDirPath);
                }
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                //保存缩略图
                HttpPostedFile file = context.Request.Files[0];
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                string filePath = dirPath + "thumb_"  +fileName;//file.FileName;
                file.SaveAs(filePath);
                //保存原图
                HttpPostedFile thumbFile = context.Request.Files[1];
                string thumbFileName =  fileName;
                string thumbFilePath = thumbDirPath + thumbFileName;//file.FileName;
                thumbFile.SaveAs(thumbFilePath);
                //更新数据库
                BLL.carInfo bll = new BLL.carInfo();
                List<Model.carInfo> carList = bll.GetModelList(" user_telphone='" + tel + "'");
                if (carList == null || carList.Count == 0)
                {
                    Model.carInfo info = new Model.carInfo();
                    info.user_telphone = tel;
                    if (photoindex == "1")
                    {
                        info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + "thumb_" + thumbFileName;
                    }
                    if (photoindex == "2")
                    {
                        info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + "thumb_" + thumbFileName;
                    }
                    if (photoindex == "3")
                    {
                        info.car_photo3 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + "thumb_" + thumbFileName;
                    }
                    bll.Add(info);
                }
                else
                {
                    Model.carInfo info = carList[0];
                    if (photoindex == "1")
                    {
                        info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + "thumb_" + thumbFileName;
                    }
                    if (photoindex == "2")
                    {
                        info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + "thumb_" + thumbFileName;
                    }
                    if (photoindex == "3")
                    {
                        info.car_photo3 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + "thumb_" + thumbFileName;
                    }
                    bll.Update(info);
                }
                string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":" + "\"/UploadFile/CarPhoto/thumbCarPhoto/thumb_" + thumbFileName + "\"}";
                context.Response.Write(result);
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，" + e.Message + "\",\"data\":{}}";
                context.Response.Write(result);
            }
        }

        /// <summary>
        /// 上传车辆图片。
        /// </summary>
        private void UploadCarPhoto(HttpContext context)
        {
            string dirPath = context.Server.MapPath("~/UploadFile/CarPhoto/");
            string tel = context.Request.Form["tel"].ToString();
            string photoindex = context.Request.Form["index"].ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = context.Request.Files[i];
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                        string filePath = dirPath + fileName;//file.FileName;
                        file.SaveAs(filePath);
                        DataServer.Util.MakeThumbnail(filePath, dirPath + "thumbCarPhoto/thumb_" + fileName, 160, 120, "W", "jpg");
                        
                        BLL.carInfo bll=new BLL.carInfo();
                        List<Model.carInfo> carList=bll.GetModelList(" user_telphone='"+tel+"'");
                        if(carList==null||carList.Count==0)
                        {
                            Model.carInfo info = new Model.carInfo();
                            info.user_telphone = tel;
                            if (photoindex == "1")
                            {
                                info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_"  +fileName;
                            }
                            if (photoindex == "2")
                            {
                                info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" +fileName;
                            }
                            if (photoindex == "3")
                            {
                                info.car_photo3 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_"  +fileName;
                            }
                            bll.Add(info);
                       
                        }else
                        {
                            Model.carInfo info = carList[0];
                            if (photoindex == "1")
                            {
                                info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_"  +fileName;
                            }
                            if (photoindex == "2")
                            {
                                info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" +fileName;
                            }
                            if (photoindex == "3")
                            {
                                info.car_photo3 = "/UploadFile/CarPhoto/"+ "thumbCarPhoto/thumb_" +  fileName;
                            }
                            bll.Update(info);
                        }
                    }
                }
                string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";
                context.Response.Write(result);
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，" + e.Message + "\",\"data\":{}}";
                context.Response.Write(result);
            }
        }

        /// <summary>
        /// 上传用户头像。
        /// </summary>
        private void UploadHeadPhoto(HttpContext context)
        {
            string dirPath = context.Server.MapPath("~/UploadFile/HeadPhoto/");
            string tel=context.Request.Form["tel"].ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = context.Request.Files[i];
                        string fileName= DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                        string filePath = dirPath +fileName;//file.FileName;
                        file.SaveAs(filePath);
                        DataServer.Util.MakeThumbnail(filePath, dirPath + "thumbHeadPhoto/thumb_" + fileName, 160, 120, "HW", "jpg");
                        BLL.user_tb ubll=new BLL.user_tb();
                        Model.user_tb u = ubll.GetModel(tel);
                        u.user_photo = "/UploadFile/HeadPhoto/" + fileName;
                        ubll.Update(u); 
                    }
                }
                string result="{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";  
                context.Response.Write(result);               
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，"+e.Message+"\",\"data\":{}}";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void Write(string path, string content)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}

/*  可以获得客户端的手机型号。
for (int j = 0; j < context.Request.Params.Keys.Count; j++)
{
                            
    object key = context.Request.Params.Keys[j];
    Write(context.Server.MapPath("~/Temp/")+"log.txt", key.ToString() + ":");
    Write(context.Server.MapPath("~/Temp/") + "log.txt", context.Request.Params[key.ToString()].ToString() + ";");
}
 * */