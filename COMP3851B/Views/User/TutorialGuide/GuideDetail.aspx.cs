using COMP3851B.BBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP3851B.Views.User.TutorialGuide
{
    public partial class GuideDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["GdeID2Details"]);
            Guide gde = new Guide();
            gde = gde.GetOneGuide(id);
            lbltest.Text = gde.gdeDesc;
            lblTitle.Text = gde.gdeTitle;
        }
    }
}