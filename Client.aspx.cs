using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace My__First_App
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["App Connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                refreshdata();
            }
        }

        public void refreshdata()
        {
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                string sql = "select * from Client";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                }

            }
        }

        protected void BtnSearch_Click1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                string sql = "select * from Client where FirstName like '%" + txtSearch.Text + "%'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Client(ClientID, FirstName, LastName, Address,Email)" +
           "VALUES (@ClientID,@FirstName,@LastName,@Address,@Email)";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@ClientID", long.Parse(txtClientID.Text));
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.ExecuteNonQuery();

                    refreshdata();
                    Clear();

                }

            }

        }

            public void Clear()
            {
                txtClientID.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
            }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                txtClientID.Text = row.Cells[0].Text;
                txtFirstName.Text = row.Cells[1].Text;
                txtLastName.Text = row.Cells[2].Text;
                txtAddress.Text = row.Cells[3].Text;
                txtEmail.Text = row.Cells[4].Text;

            }

            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string sql = "delete from Client where ClientID = @ClientID";

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClientID", row.Cells[0].Text);
                        cmd.ExecuteNonQuery();

                    }
                }
                refreshdata();
                Clear();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from Client where ClientID=@ClientID";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientID", txtClientID.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string sql = "update Client set Address=@Address where ClientId=@ClientID";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientID", txtClientID.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("CardDetails");
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage");
        }
    }
}