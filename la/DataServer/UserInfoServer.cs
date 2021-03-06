﻿using System;
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


        /// <summary>
        /// 生成随机昵称
        /// </summary>
        /// <returns>随机昵称</returns>
        public static string NikeNameCreate()
        {
            string nameList = "繁华似锦|赢了爱情|痛定思痛|似水柔情|月光倾城|流绪微梦|残花败柳|夏花依旧|演绎轮回|一抹红尘|悲欢自饮|稚气未脱|离经叛道|两重心事|心安勿忘|悲欢离合|无处安放|残缺韵律|眼神调情|安然放心|内心深处|负面情绪|心有所属|时间在流|流年开花|守住时间|静待死亡|梦绕魂牵|半世晨晓|惜你若命|单独隔离|寂寞盘旋|放心不下|往事随风|年少无知|内心世界|沧桑笑容|微光倾城|乱试佳人|散场电影|折现浪漫|梦回旧景|今非昔比|淡忘如思|眼角笑意|痴心绝对|魂不附体|回眸的笑|落荒而逃|网名大全|黑白年代|忠贞罘渝|空城旧梦|浮生若梦|夕夏温存|醉生梦死|旧事重提|浮生如梦|沦陷的痛|徒增伤悲|尘缘而已|血色玫瑰|泄气的爱|真的爱你|安之若素|随遇而安|本末倒置|杳无音信|浮光掠影|不即不离|相濡以沫|浅尝辄止|哀而不伤|尘埃未定|毫无代价|视而不见|终生守之|地老天荒|玉颜粉骨|几番轮回|岁月更迭|经年未变|流光易断|情自阑珊|闲云清烟|若即若离|望眼欲穿|风情万种|烟花沼泽|盛世流光|云中谁忆|凡尘清心|一尾流莺|半生情缘|似念似恋|日之夕矣|试看春残|轻描淡写|满城灯火|冷暖自知|安之若素|念念不忘|甜到悲伤|烟花易冷|等个旧人|没有结局|零落浮华|微笑向暖|无双未央|只若初见|一纸乱言|流水妄言|不似经年|时光若止|不知不觉|不痛不痒|灰色天空|痴心易碎|撕心裂肺|不哭不闹|虚情假意|宁缺毋滥|覆水难收|时光流离|日光倾城|冷暖自知|漫不经心|不痒不痛|无可取代|浮华落尽|浅怀感伤|余音未散|半个灵魂|诠释悲伤|朝朝暮暮|浅末年华|若如初见|花落半歌|虚情假意|潜移默化|无门有缘|凌波微步|深秋无痕|沉鱼落雁|往事如烟|岁月如歌|如梦如幻|临窗观景|昨日悲喜|闭月羞花|痴人说梦|庸人自扰|作茧自缚|一笔荒芜|重拾旧梦|孤峰无伴|水清天蓝|邀月对影|余音未散|烟花寂凉|温暖慕城|旧人不覆|愚人码头|无可置疑|乱了思绪|热带岛屿|醉后余欢|事与愿违|回眸最初|消失殆尽|物是人非|旧事惘然|大声告白|逝去的爱|世界末日|最后一天|一生一世|如花似玉|寂寞好了|人亦已歌|顾影自怜|红颜多祸|黑发尤物|戏如人生|北极以北|半世倾尘|黑白棋局|乱世惊梦|东京爱过|强颜欢笑|俯瞰天空|夏夜暖风|空洞角落|闲云清烟|香椿丛林|倾国倾城|素子花开|封情舞韵|归去如风|森林散布|和风戏雨|复制回忆|怒默语晨|肤浅世人|以烟代食|上世笑眸|容颜殆尽|放慢心跳|撕心裂肺|风中凌乱|独草孤花|新不了情|独守空城|热情腐朽|半夏时光|八月未央";
            string[] arr = nameList.Split('|');
            Random r = new Random();
            return arr[r.Next(0, arr.Length)];
        }
       



    }
}
