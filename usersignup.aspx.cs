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
    public partial class signup : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //kliknięcie rejestracji:
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkMemberExists())
            {
                Response.Write("<script>alert('Taki użytkownik już istnieje, musisz wybrać inną.');</script>");
            }
            else
            {
                signUpNewUser();
            }
           
        }
        bool checkMemberExists()
        {
            try
            {
                SqlConnection connnection = new SqlConnection(strconnection);
                if (connnection.State == ConnectionState.Closed)
                {
                    connnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_table where username='" + TextBox7.Text.Trim() + "';", connnection);
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        //
        void signUpNewUser()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_table" +
                    "(full_name,date,phone_number,e_mail,city,street_no,username,password)" +
                    " values(@full_name,@date,@phone_number,@e_mail,@city,@street_no,@username,@password)", connection);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_number", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@e_mail", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@street_no", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@username", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox8.Text.Trim());

                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Pomyślnie zarejestrowano! Teraz możesz się zalogować.');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}