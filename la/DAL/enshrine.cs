using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace la.DAL
{
	/// <summary>
	/// 数据访问类:enshrine
	/// </summary>
	public partial class enshrine
	{
		public enshrine()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("enshrine_id", "enshrine"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int enshrine_id,int travle_ID,string user_telphone)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from enshrine");
			strSql.Append(" where enshrine_id=@enshrine_id and travle_ID=@travle_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@enshrine_id", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = enshrine_id;
			parameters[1].Value = travle_ID;
			parameters[2].Value = user_telphone;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(la.Model.enshrine model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into enshrine(");
			strSql.Append("enshrine_id,travle_ID,user_telphone,enshrine_time,enshrine_islvalid)");
			strSql.Append(" values (");
			strSql.Append("@enshrine_id,@travle_ID,@user_telphone,@enshrine_time,@enshrine_islvalid)");
			SqlParameter[] parameters = {
					new SqlParameter("@enshrine_id", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20),
					new SqlParameter("@enshrine_time", SqlDbType.DateTime),
					new SqlParameter("@enshrine_islvalid", SqlDbType.Bit,1)};
			parameters[0].Value = model.enshrine_id;
			parameters[1].Value = model.travle_ID;
			parameters[2].Value = model.user_telphone;
			parameters[3].Value = model.enshrine_time;
			parameters[4].Value = model.enshrine_islvalid;

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
		public bool Update(la.Model.enshrine model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update enshrine set ");
			strSql.Append("enshrine_time=@enshrine_time,");
			strSql.Append("enshrine_islvalid=@enshrine_islvalid");
			strSql.Append(" where enshrine_id=@enshrine_id and travle_ID=@travle_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@enshrine_time", SqlDbType.DateTime),
					new SqlParameter("@enshrine_islvalid", SqlDbType.Bit,1),
					new SqlParameter("@enshrine_id", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)};
			parameters[0].Value = model.enshrine_time;
			parameters[1].Value = model.enshrine_islvalid;
			parameters[2].Value = model.enshrine_id;
			parameters[3].Value = model.travle_ID;
			parameters[4].Value = model.user_telphone;

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
		public bool Delete(int enshrine_id,int travle_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from enshrine ");
			strSql.Append(" where enshrine_id=@enshrine_id and travle_ID=@travle_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@enshrine_id", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = enshrine_id;
			parameters[1].Value = travle_ID;
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
		public la.Model.enshrine GetModel(int enshrine_id,int travle_ID,string user_telphone)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 enshrine_id,travle_ID,user_telphone,enshrine_time,enshrine_islvalid from enshrine ");
			strSql.Append(" where enshrine_id=@enshrine_id and travle_ID=@travle_ID and user_telphone=@user_telphone ");
			SqlParameter[] parameters = {
					new SqlParameter("@enshrine_id", SqlDbType.Int,4),
					new SqlParameter("@travle_ID", SqlDbType.Int,4),
					new SqlParameter("@user_telphone", SqlDbType.VarChar,20)			};
			parameters[0].Value = enshrine_id;
			parameters[1].Value = travle_ID;
			parameters[2].Value = user_telphone;

			la.Model.enshrine model=new la.Model.enshrine();
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
		public la.Model.enshrine DataRowToModel(DataRow row)
		{
			la.Model.enshrine model=new la.Model.enshrine();
			if (row != null)
			{
				if(row["enshrine_id"]!=null && row["enshrine_id"].ToString()!="")
				{
					model.enshrine_id=int.Parse(row["enshrine_id"].ToString());
				}
				if(row["travle_ID"]!=null && row["travle_ID"].ToString()!="")
				{
					model.travle_ID=int.Parse(row["travle_ID"].ToString());
				}
				if(row["user_telphone"]!=null)
				{
					model.user_telphone=row["user_telphone"].ToString();
				}
				if(row["enshrine_time"]!=null && row["enshrine_time"].ToString()!="")
				{
					model.enshrine_time=DateTime.Parse(row["enshrine_time"].ToString());
				}
				if(row["enshrine_islvalid"]!=null && row["enshrine_islvalid"].ToString()!="")
				{
					if((row["enshrine_islvalid"].ToString()=="1")||(row["enshrine_islvalid"].ToString().ToLower()=="true"))
					{
						model.enshrine_islvalid=true;
					}
					else
					{
						model.enshrine_islvalid=false;
					}
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
			strSql.Append("select enshrine_id,travle_ID,user_telphone,enshrine_time,enshrine_islvalid ");
			strSql.Append(" FROM enshrine ");
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
			strSql.Append(" enshrine_id,travle_ID,user_telphone,enshrine_time,enshrine_islvalid ");
			strSql.Append(" FROM enshrine ");
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
			strSql.Append("select count(1) FROM enshrine ");
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
			strSql.Append(")AS Row, T.*  from enshrine T ");
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
			parameters[0].Value = "enshrine";
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

