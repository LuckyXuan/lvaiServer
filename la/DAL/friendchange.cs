using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:friendchange
	/// </summary>
	public partial class friendchange
	{
		public friendchange()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("friendchange_ID", "friendchange"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int friendchange_ID,int friend_id,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from friendchange");
			strSql.Append(" where friendchange_ID=@friendchange_ID and friend_id=@friend_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@friendchange_ID", SqlDbType.Int,4),
					new SqlParameter("@friend_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = friendchange_ID;
			parameters[1].Value = friend_id;
			parameters[2].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.friendchange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into friendchange(");
			strSql.Append("friendchange_ID,friend_id,user_telphone,friendchange_time,friendchange_op,friendchange_comment)");
			strSql.Append(" values (");
			strSql.Append("@friendchange_ID,@friend_id,@user_telphone,@friendchange_time,@friendchange_op,@friendchange_comment)");
			SqlParameter[] parameters = {
					new SqlParameter("@friendchange_ID", SqlDbType.Int,4),
					new SqlParameter("@friend_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@friendchange_time", SqlDbType.DateTime),
					new SqlParameter("@friendchange_op", SqlDbType.VarChar,20),
					new SqlParameter("@friendchange_comment", SqlDbType.VarChar,100)};
			parameters[0].Value = model.friendchange_ID;
			parameters[1].Value = model.friend_id;
			parameters[2].Value = model.user_telphone;
			parameters[3].Value = model.friendchange_time;
			parameters[4].Value = model.friendchange_op;
			parameters[5].Value = model.friendchange_comment;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(la.Model.friendchange model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update friendchange set ");
			strSql.Append("friendchange_time=@friendchange_time,");
			strSql.Append("friendchange_op=@friendchange_op,");
			strSql.Append("friendchange_comment=@friendchange_comment");
			strSql.Append(" where friendchange_ID=@friendchange_ID and friend_id=@friend_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@friendchange_time", SqlDbType.DateTime),
					new SqlParameter("@friendchange_op", SqlDbType.VarChar,20),
					new SqlParameter("@friendchange_comment", SqlDbType.VarChar,100),
					new SqlParameter("@friendchange_ID", SqlDbType.Int,4),
					new SqlParameter("@friend_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.friendchange_time;
			parameters[1].Value = model.friendchange_op;
			parameters[2].Value = model.friendchange_comment;
			parameters[3].Value = model.friendchange_ID;
			parameters[4].Value = model.friend_id;
			parameters[5].Value = model.user_telphone;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int friendchange_ID,int friend_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friendchange ");
			strSql.Append(" where friendchange_ID=@friendchange_ID and friend_id=@friend_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@friendchange_ID", SqlDbType.Int,4),
					new SqlParameter("@friend_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = friendchange_ID;
			parameters[1].Value = friend_id;
			parameters[2].Value = user_telphone;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public la.Model.friendchange GetModel(int friendchange_ID,int friend_id,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 friendchange_ID,friend_id,user_telphone,friendchange_time,friendchange_op,friendchange_comment from friendchange ");
			strSql.Append(" where friendchange_ID=@friendchange_ID and friend_id=@friend_id and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@friendchange_ID", SqlDbType.Int,4),
					new SqlParameter("@friend_id", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = friendchange_ID;
			parameters[1].Value = friend_id;
			parameters[2].Value = user_telphone;

			la.Model.friendchange model=new la.Model.friendchange();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public la.Model.friendchange DataRowToModel(DataRow row)
		{
			la.Model.friendchange model=new la.Model.friendchange();
			if (row != null)
			{
				if(row["friendchange_ID"]!=null && row["friendchange_ID"].ToString()!="")
				{
					model.friendchange_ID=int.Parse(row["friendchange_ID"].ToString());
				}
				if(row["friend_id"]!=null && row["friend_id"].ToString()!="")
				{
					model.friend_id=int.Parse(row["friend_id"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["friendchange_time"]!=null && row["friendchange_time"].ToString()!="")
				{
					model.friendchange_time=DateTime.Parse(row["friendchange_time"].ToString());
				}
				if(row["friendchange_op"]!=null)
				{
					model.friendchange_op=row["friendchange_op"].ToString();
				}
				if(row["friendchange_comment"]!=null)
				{
					model.friendchange_comment=row["friendchange_comment"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select friendchange_ID,friend_id,user_telphone,friendchange_time,friendchange_op,friendchange_comment ");
			strSql.Append(" FROM friendchange ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" friendchange_ID,friend_id,user_telphone,friendchange_time,friendchange_op,friendchange_comment ");
			strSql.Append(" FROM friendchange ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM friendchange ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.user_telphone desc");
			}
			strSql.Append(")AS Row, T.*  from friendchange T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "friendchange";
			parameters[1].Value = "user_telphone";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

