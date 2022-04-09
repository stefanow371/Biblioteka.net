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
    
    public partial class admin_author : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkAuthorExist())
            {
                Response.Write("<script>alert('Autor z tym ID już istnieje!');</script>");
            }
            else
            {
                addAuthor();
            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (checkAuthorExist())
            {
                updateAuthor();
              

            }
            else
            {
                Response.Write("<script>alert('Autor nie istnieje');</script>");
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExist())
            {
                deleteAuthor();

            }
            else
            {
                Response.Write("<script>alert('Autor nie istnieje');</script>");
            }
        }
        // GO button click
        protected void Button1_Click1(object sender, EventArgs e)
        {
            

                if (checkAuthorExist())
                {
                    getAuthorByID();

                }
                else
                {
                    Response.Write("<script>alert('Autor nie istnieje');</script>");
                }
            
        }

        void getAuthorByID()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_table where author_id='" + TextBox1.Text.Trim() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Niepoprawne ID autora');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void deleteAuthor()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from author_table WHERE author_id='" + TextBox1.Text.Trim() + "'", connection);

                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Usunięto Autora');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateAuthor()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_table SET author_name=@author_name WHERE author_id='" + TextBox1.Text.Trim() + "'", connection);

                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Zaktualizowano autora');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addAuthor()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_table" +
                    "(author_id,author_name)" +
                    " values(@author_id,@author_name)", connection);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Dodano autora');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool checkAuthorExist()
        {
            try
            {
                SqlConnection connnection = new SqlConnection(strconnection);
                if (connnection.State == ConnectionState.Closed)
                {
                    connnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_table where author_id='" + TextBox1.Text.Trim() + "';", connnection);
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