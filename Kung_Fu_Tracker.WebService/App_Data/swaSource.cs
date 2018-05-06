using System;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Reflection;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using NLog;
namespace ControllerLibrary
{
public class patternlines 
 { 
 public string Rank { get; set;} 
 public int? Order { get; set;} 
 public string Feet { get; set;} 
 public string LeftHand { get; set;} 
 public string RightHand { get; set;} 
}
static public class DbUtil 

{
static public string message;
	static public SqlConnection GetConnection() {
		string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		SqlConnection con = new SqlConnection(conStr);
DbUtil.message = "";
con.InfoMessage += delegate(object sender, SqlInfoMessageEventArgs e)
{
if (DbUtil.message.Length > 0) DbUtil.message +=  "\n";
DbUtil.message +=  e.Message;
};
		return con;        
	}
}

    public static class DbExtensions
    {
        public static List<T> ToListCollection<T>(this DataTable dt)
        {
            List<T> lst = new System.Collections.Generic.List<T>();
            Type tClass = typeof(T);
            PropertyInfo[] pClass = tClass.GetProperties();
            List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
            T cn;
            foreach (DataRow item in dt.Rows)
            {
                cn = (T)Activator.CreateInstance(tClass);
                foreach (PropertyInfo pc in pClass)
                {
                    // Can comment try catch block. 
                    try
                    {
                        DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                        if (d != null && item[pc.Name] != DBNull.Value)
                            pc.SetValue(cn, item[pc.Name], null);
                    }
                    catch (Exception ex)
                    {
                       throw ex;
                    }
                }
                lst.Add(cn);
            }
            return lst;
        }
    }
        
public class patternlinesController:ApiController 
{
	 private static Logger logger = LogManager.GetCurrentClassLogger();
   public HttpResponseMessage Delete( int? ID = null)
 	{
	using(SqlConnection con = DbUtil.GetConnection()) {
		SqlCommand com = new SqlCommand("API_patternlines_delete",con);
		com.CommandType = CommandType.StoredProcedure;
		SqlParameter RetVal = com.Parameters.Add("RetVal", SqlDbType.Int);
		RetVal.Direction = ParameterDirection.ReturnValue;
	com.Parameters.Add("ID", SqlDbType.Int).Value = ID;
		con.Open();
		com.ExecuteNonQuery();
	logger.Info("patternlines_delete:@ID={0}, return={1}",ID,  RetVal.Value );
	if (0 == (int) RetVal.Value)
		 RetVal.Value = 200;
	if (200 == (int) RetVal.Value || 201 == (int)RetVal.Value)  
	{
		var response = Request.CreateResponse((HttpStatusCode)RetVal.Value, "null");
		return response;
	}
	if (DbUtil.message.Length > 0) 
		return Request.CreateErrorResponse((HttpStatusCode)RetVal.Value, DbUtil.message);
	else
		return Request.CreateResponse((HttpStatusCode)RetVal.Value);
		}

	}


   public IEnumerable<patternlines> Get()
	{
	using(SqlConnection con = DbUtil.GetConnection()) {
		SqlCommand com = new SqlCommand("API_patternlines_get",con);
		com.CommandType = CommandType.StoredProcedure;
		SqlParameter RetVal = com.Parameters.Add("RetVal", SqlDbType.Int);
		RetVal.Direction = ParameterDirection.ReturnValue;
		SqlDataAdapter da = new SqlDataAdapter(com);
		con.Open();
		DataSet ds = new DataSet();
		da.Fill(ds);
		da.Dispose();
	logger.Info("patternlines_get:, return={0}", RetVal.Value );
		DataTable dt = ds.Tables[0];
		List<patternlines> ret = dt.ToListCollection<patternlines>();
		return ret.AsEnumerable<patternlines>();
		}

	}


   public patternlines Get( int? ID )
	{
	using(SqlConnection con = DbUtil.GetConnection()) {
		SqlCommand com = new SqlCommand("API_patternlines_get",con);
		com.CommandType = CommandType.StoredProcedure;
		SqlParameter RetVal = com.Parameters.Add("RetVal", SqlDbType.Int);
		RetVal.Direction = ParameterDirection.ReturnValue;
	com.Parameters.Add("ID", SqlDbType.Int).Value = ID;
		SqlDataAdapter da = new SqlDataAdapter(com);
		con.Open();
		DataSet ds = new DataSet();
		da.Fill(ds);
		da.Dispose();
	logger.Info("patternlines_get:@ID={0}, return={1}",ID,  RetVal.Value );
		if ( ds.Tables.Count == 0)
			throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
		DataTable dt = ds.Tables[0];
		if (dt.Rows.Count > 0) 
			return  dt.ToListCollection<patternlines>()[0];
		else 
			throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
		}

	}


   public HttpResponseMessage  Post(patternlines res ,  string LHand = null,  string RHand = null)
 	{ 
	if (res == null) { 
		logger.Fatal("patternlines_post: Cannot parse resource. Check parameters" );
		throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
	}
	 int? NewId = null;
	using(SqlConnection con = DbUtil.GetConnection()) {
		SqlCommand com = new SqlCommand("API_patternlines_post",con);
		com.CommandType = CommandType.StoredProcedure;
		SqlParameter RetVal = com.Parameters.Add("RetVal", SqlDbType.Int);
		RetVal.Direction = ParameterDirection.ReturnValue;
	com.Parameters.Add("Rank", SqlDbType.VarChar, 255).Value = res.Rank;
	com.Parameters.Add("Order", SqlDbType.Int).Value = res.Order;
	com.Parameters.Add("Feet", SqlDbType.VarChar, 255).Value = res.Feet;
	com.Parameters.Add("LHand", SqlDbType.VarChar, 255).Value = LHand;
	com.Parameters.Add("RHand", SqlDbType.VarChar, 255).Value = RHand;
	com.Parameters.Add("NewId", SqlDbType.Int).Value = NewId;
	com.Parameters["NewId"].Direction = ParameterDirection.Output; 
	try {
		con.Open();
		com.ExecuteNonQuery();
		} catch (Exception ex) {
	logger.Info("patternlines_post:@Rank={0}, @Order={1}, @Feet={2}, @LHand={3}, @RHand={4}, @NewId={5}, return={6}",res.Rank,res.Order,res.Feet,LHand,RHand,NewId,  RetVal.Value );
			logger.Fatal("patternlines_post: SqlException:" + ex.Message  );
			 return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
		} 
	logger.Info("patternlines_post:@Rank={0}, @Order={1}, @Feet={2}, @LHand={3}, @RHand={4}, @NewId={5}, return={6}",res.Rank,res.Order,res.Feet,LHand,RHand,NewId,  RetVal.Value );
	if (0 == (int) RetVal.Value)
		 RetVal.Value = 200;
	if (200 == (int) RetVal.Value || 201 == (int)RetVal.Value)  
	{
		var response = Request.CreateResponse((HttpStatusCode)RetVal.Value, "null");
		string uri=Url.Link("DefaultApi", new { id = com.Parameters["NewID"].Value.ToString() });
		response.Headers.Location = new Uri(uri);
		return response;
	}
	if (DbUtil.message.Length > 0) 
		return Request.CreateErrorResponse((HttpStatusCode)RetVal.Value, DbUtil.message);
	else
		return Request.CreateResponse((HttpStatusCode)RetVal.Value);
		}

	}


   public HttpResponseMessage Put(patternlines res ,  int? ID = null,  string LHand = null,  string RHand = null)
 	{
	using(SqlConnection con = DbUtil.GetConnection()) {
		SqlCommand com = new SqlCommand("API_patternlines_put",con);
		com.CommandType = CommandType.StoredProcedure;
		SqlParameter RetVal = com.Parameters.Add("RetVal", SqlDbType.Int);
		RetVal.Direction = ParameterDirection.ReturnValue;
	com.Parameters.Add("ID", SqlDbType.Int).Value = ID;
	com.Parameters.Add("Rank", SqlDbType.VarChar, 255).Value = res.Rank;
	com.Parameters.Add("Order", SqlDbType.Int).Value = res.Order;
	com.Parameters.Add("Feet", SqlDbType.VarChar, 255).Value = res.Feet;
	com.Parameters.Add("LHand", SqlDbType.VarChar, 255).Value = LHand;
	com.Parameters.Add("RHand", SqlDbType.VarChar, 255).Value = RHand;
	con.Open();
	com.ExecuteNonQuery();
	logger.Info("patternlines_put:@ID={0}, @Rank={1}, @Order={2}, @Feet={3}, @LHand={4}, @RHand={5}, return={6}",ID,res.Rank,res.Order,res.Feet,LHand,RHand,  RetVal.Value );
	if (0 == (int) RetVal.Value)
		 RetVal.Value = 200;
	if (200 == (int) RetVal.Value || 201 == (int)RetVal.Value)  
	{
		var response = Request.CreateResponse((HttpStatusCode)RetVal.Value, "null");
		return response;
	}
	if (DbUtil.message.Length > 0) 
		return Request.CreateErrorResponse((HttpStatusCode)RetVal.Value, DbUtil.message);
	else
		return Request.CreateResponse((HttpStatusCode)RetVal.Value);
		}

	}


}
}

