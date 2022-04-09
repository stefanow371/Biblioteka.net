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
    public partial class member_management : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //delete user
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMember();
        }
        //member id fill
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMember();
        }

        bool checkMemberExist()
        {
            try
            {
                SqlConnection connnection = new SqlConnection(strconnection);
                if (connnection.State == ConnectionState.Closed)
                {
                    connnection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_table where username='" + TextBox1.Text.Trim() + "';", connnection);
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

        void deleteMember()
        {
            if(TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Nie znaleziono użytkownika');</script>");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(strconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from member_table WHERE username='" + TextBox1.Text.Trim() + "'", connection);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    Response.Write("<script>alert('Usunięto Użytkownika');</script>");
                    clearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
           
        }

        void getMember()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_table where username='" + TextBox1.Text.Trim() + "'", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox8.Text = dr.GetValue(1).ToString();
                        TextBox3.Text = dr.GetValue(2).ToString();
                        TextBox4.Text = dr.GetValue(3).ToString();
                        TextBox10.Text = dr.GetValue(4).ToString();
                        TextBox5.Text = dr.GetValue(5).ToString();
                        TextBox1.Text = dr.GetValue(6).ToString();

                    }
                   
                }
                else
                {
                    Response.Write("<script>alert('Nie znaleziono użytkownika ');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        
        void clearForm()
        {

            TextBox2.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox10.Text = "";
            TextBox5.Text = "";
            TextBox1.Text = "";
        }


    }
   
}