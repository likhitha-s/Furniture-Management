using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My__First_App
{
    public partial class WebForm5 : System.Web.UI.Page
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
                string sql = "select * from Delivery";
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
                string sql = "select * from Delivery where DeliveryNo like '%" + txtSearch.Text + "%'";
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

            string sql = "INSERT INTO Delivery(ClientID,DeliveryNo,Date,Address)" +
            "VALUES (@ClientID,@DeliveryNo,@Date,@Address)";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@ClientID", long.Parse(txtClientID.Text));
                    cmd.Parameters.AddWithValue("@DeliveryNo", long.Parse(txtDeliveryNo.Text));
                    cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();
                }
            }

            refreshdata();
            Clear();
        }

        public void Clear()
        {
            txtClientID.Text = "";
            txtDeliveryNo.Text = "";
            txtDate.Text = "";
            txtAddress.Text = "";
        }
        
         protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
         {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                txtClientID.Text = row.Cells[0].Text;
                txtDeliveryNo.Text = row.Cells[1].Text;
                txtDate.Text = row.Cells[2].Text;
                txtAddress.Text = row.Cells[3].Text;
            }

            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string sql = "delete from Delivery where DeliveryNo = @DeliveryNo";

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@DeliveryNo", row.Cells[0].Text);
                        cmd.ExecuteNonQuery();

                    }
                }
                refreshdata();
                Clear();
            }
         }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from Delivery where DeliveryNo=@DeliveryNo";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeliveryNo", txtDeliveryNo.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string sql = "update Delivery set Address=@Address where ClientId=@ClientID";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientID", txtClientID.Text);
                    cmd.Parameters.AddWithValue("@DeliveryNo", txtDeliveryNo.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
        }

         protected void Button6_Click(object sender, EventArgs e)
         {
            Response.Redirect("Furniture");
         }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage");
        }
    }
}