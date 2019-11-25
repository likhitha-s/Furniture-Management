using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My__First_App
{
    public partial class WebForm2 : System.Web.UI.Page
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
                string sql = "select * from CardDetails";
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
                string sql = "select * from CardDetails where ClientID like '%" + txtSearch.Text + "%'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    int v = sda.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
    }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO CardDetails(ClientID, CardNo, Bank, CreditLimit, Balance)" +
           "VALUES (@ClientID,@CardNo,@Bank,@CreditLimit,@Balance)";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@ClientID", long.Parse(txtClientID.Text));
                    cmd.Parameters.AddWithValue("@CardNo", long.Parse(txtCardNo.Text));
                     cmd.Parameters.AddWithValue("@Bank", txtBank.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", long.Parse(txtCreditLimit.Text));
                    cmd.Parameters.AddWithValue("@Balance", long.Parse(txtBalance.Text));
                    cmd.ExecuteNonQuery();
                }
            }

            refreshdata();
            Clear();
    }

            public void Clear()
            {
                txtClientID.Text = "";
                txtCardNo.Text = "";
                txtBank.Text = "";
                txtCreditLimit.Text = "";
                txtBalance.Text = "";
            }


     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                txtClientID.Text = row.Cells[0].Text;
                txtCardNo.Text = row.Cells[1].Text;
                txtBank.Text = row.Cells[2].Text;
                txtCreditLimit.Text = row.Cells[3].Text;
                txtBalance.Text = row.Cells[4].Text;

            }

            if (e.CommandName == "Delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string sql = "delete from CardDetails where ClientID = @ClientID";

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
             string sql = "delete from CardDetails where ClientID=@ClientID";

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
            string sql = "update CardDetails set CreditLimit=@CreditLimit where ClientId=@ClientID";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientID", txtClientID.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", long.Parse(txtCreditLimit.Text));
                    cmd.ExecuteNonQuery();

                }
            }

            string sql1 = "update CardDetails set Bank=@Bank where ClientId=@ClientID";

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql1, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientID", txtClientID.Text);
                    cmd.Parameters.AddWithValue("@Bank", txtBank.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            refreshdata();
            Clear();
        }

          protected void Button6_Click(object sender, EventArgs e)
          {
            Response.Redirect("Transaction");
          }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage");
        }
    }
}
