using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bibliot
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Proszę zalogować się ponownie');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        // update button click

            protected void Button1_Click1(object sender, EventArgs e)
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Proszę zalogować się ponownie');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    updateUserPersonalDetails();

                }
            }
          
     



        // user defined function


        void updateUserPersonalDetails()
        {
     
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }


                SqlCommand cmd = new SqlCommand("update member_table set full_name=@full_name, date=@date, phone_number=@phone_number, e_mail=@e_mail,city=@city,street_no=@street_no WHERE username='" + Session["username"].ToString().Trim() + "'", connection);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_number", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@e_mail", TextBox4.Text.Trim()); 
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@street_no", TextBox5.Text.Trim());
                

                int result = cmd.ExecuteNonQuery();
                connection.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    getUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_table where username='" + Session["username"].ToString() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["date"].ToString();
                TextBox3.Text = dt.Rows[0]["phone_number"].ToString();
                TextBox4.Text = dt.Rows[0]["e_mail"].ToString();
                TextBox5.Text = dt.Rows[0]["city"].ToString();
                TextBox6.Text = dt.Rows[0]["street_no"].ToString();
                TextBox6.Text = dt.Rows[0]["username"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getUserBookData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from user_table where member_id='" + Session["username"].ToString() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}
