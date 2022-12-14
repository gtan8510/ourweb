using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP3851B.Views.Admin.FoodTour
{
    public partial class EditFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string DbConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DbConnect);
            con.Open();
            SqlCommand comm = new SqlCommand("Update localFood set foodName = '" + TextBox9.Text + "', foodLoc = '" + TextBox11.Text + "', foodRecLvl = '" + TextBox12.Text + "', foodPrice = '" + TextBox13.Text + "', foodDesc = '" + TextBox10.Text + "' where foodID = '" + TextBox1.Text + "'", con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully updated');", true);
            LoadRecord();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string DbConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DbConnect);
            con.Open();
            SqlCommand comm = new SqlCommand("Delete localFood where foodID = '" + TextBox1.Text + "'", con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully deleted');", true);
            LoadRecord();
        }

        void LoadRecord()
        {
            string DbConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DbConnect);
            SqlCommand comm = new SqlCommand("select * from localFood", con);
            SqlDataAdapter d = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            string DbConnect = ConfigurationManager.ConnectionStrings["FunUniversityConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(DbConnect);
            con.Open();
            SqlCommand comm = new SqlCommand("select * from localFood where foodID = '" + TextBox1.Text + "'", con);
            SqlDataReader r = comm.ExecuteReader();
            while (r.Read())
            {
                TextBox9.Text = r.GetValue(1).ToString(); //Name
                TextBox11.Text = r.GetValue(3).ToString(); //Location
                TextBox12.Text = r.GetValue(4).ToString(); //Recommendation Level
                TextBox13.Text = r.GetValue(5).ToString(); //Food Price
                TextBox10.Text = r.GetValue(6).ToString(); //Description
            }
        }
    }
}