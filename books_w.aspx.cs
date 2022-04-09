using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Bibliot
{
    public partial class books_w : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // issue book

        protected void Button2_Click1(object sender, EventArgs e)
            {
                if (checkBookExist() && checkMemberExist())
                {

                    if (checkIssueExist())
                    {
                        Response.Write("<script>alert('Pomyślnie wypożyczono');</script>");
                     
                }
                    else
                    {
                        issueBook();
                    }
                GridView1.DataBind();
            }
                else
                {
                    Response.Write("<script>alert('Złe ID książki lub użytkownika');</script>");
                }
            }
            
     
        // return book
        
            protected void Button4_Click1(object sender, EventArgs e)
            {
                if (checkBookExist() && checkMemberExist())
                {

                    if (checkIssueExist())
                    {
                        returnBook();
                        GridView1.DataBind();
                }
                    else
                    {
                        Response.Write("<script>alert('Nie istnieje');</script>");
                    }
                GridView1.DataBind();
            }
                else
                {
                    Response.Write("<script>alert('Złe ID książki lub użytkownika');</script>");
                }
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }

        // user defined function

        void returnBook()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from user_table WHERE book_id='" + TextBox1.Text.Trim() + "' AND member_id='" + TextBox2.Text.Trim() + "'", connection);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                    cmd = new SqlCommand("update book_table WHERE book_id='" + TextBox1.Text.Trim() + "'", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    Response.Write("<script>alert('Pomyślnie zwrócono książkę');</script>");
                    GridView1.DataBind();

                    connection.Close();

                }
                else
                {
                    Response.Write("<script>alert('Niepoprawne dane');</script>");
                }
               

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void issueBook()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO user_table(member_id,book_id,username,book_name,p_date,k_date) values(@member_id,@book_id,@username,@book_name,@p_date,@k_date)", connection);

                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@username", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@p_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@k_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                connection.Close();
                Response.Write("<script>alert('Wypożyczono pomyślnie');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkBookExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_table WHERE book_id='" + TextBox1.Text.Trim() + "'", connection);
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
                return false;
            }

        }

        bool checkMemberExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from member_table WHERE username='" + TextBox2.Text.Trim() + "'", connection);
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
                return false;
            }

        }

        bool checkIssueExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from user_table WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id='" + TextBox1.Text.Trim() + "'", connection);
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
                return false;
            }

        }



        void getNames()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from book_table WHERE book_id='" + TextBox1.Text.Trim() + "'", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Niepoprawne ID książki');</script>");
                }

                cmd = new SqlCommand("select full_name from member_table WHERE username='" + TextBox2.Text.Trim() + "'", connection);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Niepoprawne ID użytkownika');</script>");
                }


            }
            catch (Exception ex)
            {

            }
        }

    }
}
  