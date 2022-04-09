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
    public partial class userlogin : System.Web.UI.Page
    {
        string strconnection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_table where username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Response.Write("<script>alert('"+dr.GetValue(6).ToString()+"');</script>");
                        Session["username"] = dr.GetValue(6).ToString();
                        Session["full_name"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        
                    }
                    Response.Redirect("StronaGłówna.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Niepoprawne dane');</script>");
                }
            }
            catch
            {

            }
        }
    }
}