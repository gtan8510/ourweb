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
    public partial class CampusEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadEvent();
        }

        void loadEvent()
        {
            string DbConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DbConnect);

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select top(15) [eventName], [eventImage], [eventDesc], [eventLoc], [eventDate], [eventBeginTime], [eventEndTime] from [campusEvent]  Order By eventDate";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            LVEvent.DataSource = dt;
            LVEvent.DataBind();
            con.Close();
        }
    }
}