using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP3851B.Views.User.Campus
{
    public partial class CampusAchievement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAchievement();
        }

        void loadAchievement()
        {
            string DbConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DbConnect);

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select top (15) [acheivName], [acheivImage] from [campusAchievment] Order By achievID desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            LVAchievement.DataSource = dt;
            LVAchievement.DataBind();
            con.Close();
        }
    }
}