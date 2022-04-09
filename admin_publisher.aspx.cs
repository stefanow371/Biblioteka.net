using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliot
{
    public partial class admin_publisher : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkPublisherExist())
            {
                Response.Write("<script>alert('Wydawca z tym ID już istnieje!');</script>");
            }
            else
            {
                addPublisher();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkPublisherExist())
            {
                updatePublisher();
                

            }
            else
            {
                Response.Write("<script>alert('Wydawca nie istnieje');</script>");
            }

        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            if (checkPublisherExist())
            {
                deletePublisher();

            }
            else
            {
                Response.Write("<script>alert('Wydawca nie istnieje');</script>");
            }
        }
         

        // GO button click
        protected void Button1_Click1(object sender, EventArgs e)
        {
           
                if (checkPublisherExist())
                {
                    getPublisherByID();

                }
                else
                {
                    Response.Write("<script>alert('Wydawca nie istnieje');</script>");
                }
            
        }

        void getPublisherByID()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_table where publisher_id='" + TextBox1.Text.Trim() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Niepoprawne ID wydawcy');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void deletePublisher()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from publisher_table WHERE publisher_id='" + TextBox1.Text.Trim() + "'", connection);

                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Usunięto wydawcę');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updatePublisher()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_table SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox1.Text.Trim() + "'", connection);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Zaktualizowano wydawcę');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addPublisher()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_table" +
                    "(publisher_id,publisher_name)" +
                    " values(@publisher_id,@publisher_name)", connection);
                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Dodano wydawcę');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool checkPublisherExist()
        {
            try
            {
                SqlConnection connnection = new SqlConnection(strconnection);
                if (connnection.State == ConnectionState.Closed)
                {
                    connnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_table where publisher_id='" + TextBox1.Text.Trim() + "';", connnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>('" + ex.Message + "');</script>");
                return false;
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

       
    }
}