using COMP3851B.BBL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace COMP3851B.DAL
{
    public class GuideDAO
    {
        //Guide Category CRUD + Search
        public int InsertCategory(Guide gde)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "IF NOT EXISTS(SELECT gdeCatID FROM tutorialGuideCategory WHERE gdeCatName = @paragname) BEGIN INSERT INTO tutorialGuideCategory(gdeCatName) VALUES (@paragname) END ELSE BEGIN RETURN END";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paragname", gde.gdeCatName);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
        public List<Guide> GetAllGuideCategories()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT gdeCatID, gdeCatName FROM tutorialGuideCategory ORDER BY gdeCatID ASC";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Guide> gList = new List<Guide>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                gList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int gdeid = Convert.ToInt32(row["gdeCatID"]);
                    string gdename = row["gdeCatName"].ToString();

                    Guide objRate = new Guide(gdeid, gdename);
                    gList.Add(objRate);
                }
            }
            return gList;
        }
        public List<Guide> GetAllGuideCategoriesOrdered()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT gdeCatID, gdeCatName FROM tutorialGuideCategory ORDER BY gdeCatName ASC";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Guide> gList = new List<Guide>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                gList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int gdeid = Convert.ToInt32(row["gdeCatID"]);
                    string gdename = row["gdeCatName"].ToString();

                    Guide objRate = new Guide(gdeid, gdename);
                    gList.Add(objRate);
                }
            }
            return gList;
        }

        public Guide GetOneCategory(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT gdeCatID, gdeCatName FROM tutorialGuideCategory WHERE gdeCatID = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            Guide gde = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int catid = Convert.ToInt32(row["gdeCatID"].ToString());
                string name = Convert.ToString(row["gdeCatName"]);

                gde = new Guide(catid, name);
            }
            return gde;
        }

        public int UpdateCategory(String name, int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE tutorialGuideCategory SET gdeCatName = @paraname WHERE gdeCatID = @paraid";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraid", id);
            sqlCmd.Parameters.AddWithValue("@paraname", name);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int DeleteCategory(int gdecatid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Delete tutorialGuideCategory where gdeCatID = @paraid";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@paraid", gdecatid);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Guide> SearchFor(string substring)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * FROM tutorialGuideCategory where gdeCatName LIKE @query";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@query", "%" + substring + "%");

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Guide> gdeList = new List<Guide>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                gdeList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["gdeCatID"]);
                    string name = row["gdeCatName"].ToString();

                    Guide objRate = new Guide(id, name);
                    gdeList.Add(objRate);
                }
            }
            return gdeList;
        }

        //Guide CRUD + Search
        public int InsertGuide(Guide gde)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "IF NOT EXISTS(SELECT 1 FROM tutorialGuide WHERE gdeTitle = @paragdetitle AND gdeCatID = @paracatid AND gdeThumbnail = @paraimagepath) BEGIN INSERT INTO tutorialGuide(gdeTitle, gdeDesc, gdeCatID, gdeThumbnail) VALUES (@paragdetitle, @gdedesc, @paracatid, @paraimagepath) END ELSE BEGIN RETURN END";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paracatid", gde.gdeCatID);
            sqlCmd.Parameters.AddWithValue("@paragdetitle", gde.gdeTitle);
            sqlCmd.Parameters.AddWithValue("@gdedesc", gde.gdeDesc);
            sqlCmd.Parameters.AddWithValue("@paraimagepath", gde.gdeThumbnail);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
        
        public List<Guide> GetAllGuides()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT gdeTitle, gdeDesc, gdeThumbnail, tgc.gdeCatName, tg.gdeCatID, tg.gdeID FROM tutorialGuide tg INNER JOIN tutorialGuideCategory tgc on tgc.gdeCatID = tg.gdeCatID";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Guide> gList = new List<Guide>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                gList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["gdeID"]);
                    int catid = Convert.ToInt32(row["gdeCatID"]);
                    string title = row["gdeTitle"].ToString();
                    string thumbnail = row["gdeThumbnail"].ToString();
                    string catname = row["gdeCatName"].ToString();
                    string desc = row["gdeDesc"].ToString();

                    Guide objRate = new Guide(id, title, desc, thumbnail, catid, catname);
                    gList.Add(objRate);
                }
            }
            return gList;
        }
        

        public List<Guide> GetAllByCategory(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT gdeID, gdeTitle, gdeDesc, gdeThumbnail FROM tutorialGuide WHERE gdeCatID = @paraid ORDER BY gdeTitle ASC ";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Guide> gList = new List<Guide>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                gList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int gdeid = Convert.ToInt32(row["gdeID"]);
                    string title = row["gdeTitle"].ToString();
                    string desc = row["gdeDesc"].ToString();
                    string thumbnail = row["gdeThumbnail"].ToString();

                    Guide objRate = new Guide(gdeid, title, desc, thumbnail);
                    gList.Add(objRate);
                }
            }
            return gList;
        }

        public Guide GetOneGuide(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT gdeID, gdeTitle, gdeThumbnail, gdeDesc, tg.gdeCatID, gdeCatName FROM tutorialGuide tg INNER JOIN tutorialGuideCategory tgc ON tgc.gdeCatID = tg.gdeCatID WHERE gdeID = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            Guide gde = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int gdeid = Convert.ToInt32(row["gdeID"].ToString());
                string title = Convert.ToString(row["gdeTitle"]);
                string desc = Convert.ToString(row["gdeDesc"]);
                string imagepath = Convert.ToString(row["gdeThumbnail"]);
                int catid = Convert.ToInt32(row["gdeCatID"].ToString());
                string catname = Convert.ToString(row["gdeCatName"]);

                gde = new Guide(gdeid, title, desc, imagepath, catid, catname);
            }
            return gde;
        }

        public int UpdateGuide(Guide gde, int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE tutorialGuide SET gdeCatID = @paracatid, gdeTitle = @paratitle, gdeDesc = @paradesc, gdeThumbnail = @parathumbnail WHERE gdeID = @paraid";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paracatid", gde.gdeCatID);
            sqlCmd.Parameters.AddWithValue("@paratitle", gde.gdeTitle);
            sqlCmd.Parameters.AddWithValue("@paradesc", gde.gdeDesc);
            sqlCmd.Parameters.AddWithValue("@parathumbnail", gde.gdeThumbnail);
            sqlCmd.Parameters.AddWithValue("@paraid", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int DeleteGuide(int gdeid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Delete tutorialGuide where gdeID = @paraid";

            int result = 0;    // Execute NonQuery return an integer value

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@paraid", gdeid);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Guide> SearchForGuide(Guide gde)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * FROM tutorialGuide tg INNER JOIN tutorialGuideCategory tgc on tgc.gdeCatID = @query WHERE tg.gdeCatid LIKE @query AND tg.gdeTitle LIKE @query2 ";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@query", gde.gdeCatID);
            da.SelectCommand.Parameters.AddWithValue("@query2", "%" + gde.gdeTitle + "%");

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Guide> gdeList = new List<Guide>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                gdeList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["gdeID"]);
                    int catid = Convert.ToInt32(row["gdeCatID"]);
                    string title = row["gdeTitle"].ToString();
                    string thumbnail = row["gdeThumbnail"].ToString();
                    string catname = row["gdeCatName"].ToString();
                    string desc = row["gdeDesc"].ToString();

                    Guide objRate = new Guide(id, title, desc, thumbnail, catid, catname);
                    gdeList.Add(objRate);
                }
            }
            return gdeList;
        }
        public List<Guide> SearchUserGuide(int catid, string title)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * FROM tutorialGuide WHERE gdeCatid = @paracatid AND gdeTitle LIKE @paratitle";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paracatid", catid);
            da.SelectCommand.Parameters.AddWithValue("@paratitle", "%" + title + "%");

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Guide> gdeList = new List<Guide>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                gdeList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["gdeCatID"]);
                    string name = row["gdeTitle"].ToString();
                    string image = row["gdeThumbnail"].ToString();

                    Guide objRate = new Guide(name, image, id);
                    gdeList.Add(objRate);
                }
            }
            return gdeList;
        }

    }
}