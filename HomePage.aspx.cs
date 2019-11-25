using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My__First_App
{
    public partial class BHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Client_Click(object sender, EventArgs e)
        {
            Response.Redirect("Client");
        }

        protected void Card_Click(object sender, EventArgs e)
        {
            Response.Redirect("CardDetails");
        }

        protected void Transaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transaction");
        }

        protected void Furniture_Click(object sender, EventArgs e)
        {
            Response.Redirect("Furniture");
        }

        protected void Delivery_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delivery");
        }
    }
}