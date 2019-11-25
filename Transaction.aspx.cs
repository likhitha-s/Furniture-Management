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
    public partial class WebForm3 : System.Web.UI.Page
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
                string sql = "select * from [Transaction]";
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
                string sql = "select * from [Transaction] where TransNo like '%" + txtSearch.Text + "%'";
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
            string sql = "INSERT INTO [Transaction](TransNo,ClientID,CardNo,FurnitureID,Date,Quantity,Amount)" +
            "VALUES (@TransNo,@ClientID,@CardNo,@FurnitureID,@Date,@Quantity,@Amount)";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@TransNo", long.Parse(txtTransNo.Text));
                    cmd.Parameters.AddWithValue("@ClientID", long.Parse(txtClientID.Text));
                    cmd.Parameters.AddWithValue("@CardNo", long.Parse(txtCardNo.Text));
                    cmd.Parameters.AddWithValue("@FurnitureID", long.Parse(txtFurnitureID.Text));
                    cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                    cmd.Parameters.AddWithValue("@Quantity", long.Parse(txtQuantity.Text));
                    cmd.Parameters.AddWithValue("@Amount", long.Parse(txtAmount.Text));
                    cmd.ExecuteNonQuery();
                }
            }

            refreshdata();
            Clear();
         }

           public void Clear()
           {
            txtTransNo.Text = "";
            txtClientID.Text = "";
            txtCardNo.Text = "";
            txtFurnitureID.Text = "";
            txtDate.Text = "";
            txtDate.Text="";
            txtQuantity.Text="";
            txtAmount.Text="";
           }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                txtTransNo.Text = row.Cells[0].Text;
                txtClientID.Text = row.Cells[1].Text;
                txtCardNo.Text = row.Cells[2].Text;
                txtFurnitureID.Text = row.Cells[3].Text;
                txtDate.Text = row.Cells[4].Text;
                txtQuantity.Text = row.Cells[5].Text;
                txtAmount.Text = row.Cells[6].Text;

            }

            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string sql = "delete from [Transaction] where TransNo = @TransNo";

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TransNo", row.Cells[0].Text);
                        cmd.ExecuteNonQuery();

                    }
                }
                refreshdata();
                Clear();
            }
        }

         protected void btnDelete_Click(object sender, EventArgs e)
         {
            string sql = "delete from [Transaction] where TransNo=@TransNo";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TransNo", txtTransNo.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
         }

    protected void Update_Click(object sender, EventArgs e)
    {
          string sql = "update [Transaction] set Quantity=@Quantity where TransNo=@TransNo";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TransNo", txtTransNo.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
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

    protected void Button1_Click(object sender, EventArgs e)
    {
            Response.Redirect("Furniture");
    }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage");
        }
    }
}