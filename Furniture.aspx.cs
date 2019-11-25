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
    public partial class WebForm4 : System.Web.UI.Page
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
                string sql = "select * from Furniture";
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
                string sql = "select * from Furniture where FurnitureID like '%" + txtSearch.Text + "%'";
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

            string sql = "INSERT INTO Furniture(FurnitureID,Description,Price)" +
            "VALUES (@FurnitureID,@Description,@Price)";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@FurnitureID", long.Parse(txtFurnitureID.Text));
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Price", long.Parse(txtPrice.Text));
                    cmd.ExecuteNonQuery();
                }
            }

            refreshdata();
            Clear();
        }

        public void Clear()
        {
            txtFurnitureID.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                txtFurnitureID.Text = row.Cells[0].Text;
                txtDescription.Text = row.Cells[1].Text;
                txtPrice.Text = row.Cells[2].Text;

            }

            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string sql = "delete from Furniture where FurnitureID = @FurnitureID";

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FurnitureID", row.Cells[0].Text);
                        cmd.ExecuteNonQuery();

                    }
                }
                refreshdata();
                Clear();
            }
        }

        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from Furniture where FurnitureID=@FurnitureID";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FurnitureID", txtFurnitureID.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string sql = "update Furniture set Price=@Price where FurnitureId=@FurnitureID";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FurnitureID", txtFurnitureID.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
        }

          protected void Button6_Click(object sender, EventArgs e)
          {
            Response.Redirect("Delivery");
          }

    protected void Button2_Click(object sender, EventArgs e)
    {
            Response.Redirect("Transaction");
    }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage");
        }
    }
}