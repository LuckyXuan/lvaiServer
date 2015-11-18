using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:friend
	/// </summary>
	public partial class friend
	{
		public friend()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("friend_id", "friend"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int friend_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from friend");
			strSql.Append(" where friend_id=@friend_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@friend_id", SqlDbType.Int,4)			};
			parameters[0].Value = friend_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.friend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into friend(");
			strSql.Append("friend_id,friend_from,friend_to,friend_time,friend_state,friend_comment)");
			strSql.Append(" values (");
			strSql.Append("@friend_id,@friend_from,@friend_to,@friend_time,@friend_state,@friend_comment)");
			SqlParameter[] parameters = {
					new SqlParameter("@friend_id", SqlDbType.Int,4),
					new SqlParameter("@friend_from", SqlDbType.VarChar,20),
					new SqlParameter("@friend_to", SqlDbType.VarChar,20),
					new SqlParameter("@friend_time", SqlDbType.DateTime),
					new SqlParameter("@friend_state", SqlDbType.VarChar,20),
					new SqlParameter("@friend_comment", SqlDbType.VarChar,200)};
			parameters[0].Value = model.friend_id;
			parameters[1].Value = model.friend_from;
			parameters[2].Value = model.friend_to;
			parameters[3].Value = model.friend_time;
			parameters[4].Value = model.friend_state;
			parameters[5].Value = model.friend_comment;

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
		public bool Update(la.Model.friend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update friend set ");
			strSql.Append("friend_from=@friend_from,");
			strSql.Append("friend_to=@friend_to,");
			strSql.Append("friend_time=@friend_time,");
			strSql.Append("friend_state=@friend_state,");
			strSql.Append("friend_comment=@friend_comment");
			strSql.Append(" where friend_id=@friend_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@friend_from", SqlDbType.VarChar,20),
					new SqlParameter("@friend_to", SqlDbType.VarChar,20),
					new SqlParameter("@friend_time", SqlDbType.DateTime),
					new SqlParameter("@friend_state", SqlDbType.VarChar,20),
					new SqlParameter("@friend_comment", SqlDbType.VarChar,200),
					new SqlParameter("@friend_id", SqlDbType.Int,4)};
			parameters[0].Value = model.friend_from;
			parameters[1].Value = model.friend_to;
			parameters[2].Value = model.friend_time;
			parameters[3].Value = model.friend_state;
			parameters[4].Value = model.friend_comment;
			parameters[5].Value = model.friend_id;

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
		public bool Delete(int friend_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend ");
			strSql.Append(" where friend_id=@friend_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@friend_id", SqlDbType.Int,4)			};
			parameters[0].Value = friend_id;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string friend_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend ");
			strSql.Append(" where friend_id in ("+friend_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public la.Model.friend GetModel(int friend_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 friend_id,friend_from,friend_to,friend_time,friend_state,friend_comment from friend ");
			strSql.Append(" where friend_id=@friend_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@friend_id", SqlDbType.Int,4)			};
			parameters[0].Value = friend_id;

			la.Model.friend model=new la.Model.friend();
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
		public la.Model.friend DataRowToModel(DataRow row)
		{
			la.Model.friend model=new la.Model.friend();
			if (row != null)
			{
				if(row["friend_id"]!=null && row["friend_id"].ToString()!="")
				{
					model.friend_id=int.Parse(row["friend_id"].ToString());
				}
				if(row["friend_from"]!=null)
				{
					model.friend_from=row["friend_from"].ToString();
				}
				if(row["friend_to"]!=null)
				{
					model.friend_to=row["friend_to"].ToString();
				}
				if(row["friend_time"]!=null && row["friend_time"].ToString()!="")
				{
					model.friend_time=DateTime.Parse(row["friend_time"].ToString());
				}
				if(row["friend_state"]!=null)
				{
					model.friend_state=row["friend_state"].ToString();
				}
				if(row["friend_comment"]!=null)
				{
					model.friend_comment=row["friend_comment"].ToString();
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
			strSql.Append("select friend_id,friend_from,friend_to,friend_time,friend_state,friend_comment ");
			strSql.Append(" FROM friend ");
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
			strSql.Append(" friend_id,friend_from,friend_to,friend_time,friend_state,friend_comment ");
			strSql.Append(" FROM friend ");
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
			strSql.Append("select count(1) FROM friend ");
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
				strSql.Append("order by T.friend_id desc");
			}
			strSql.Append(")AS Row, T.*  from friend T ");
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
			parameters[0].Value = "friend";
			parameters[1].Value = "friend_id";
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

