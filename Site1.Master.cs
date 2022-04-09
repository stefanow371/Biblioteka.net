using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bibliot
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; //log in
                    LinkButton2.Visible = true; // sign up
                    LinkButton3.Visible = false; // log out
                    LinkButton7.Visible = false; // hello user!

                    LinkButton6.Visible = true; // footer admin

                  
                    LinkButton11.Visible = false; // admin authors
                    LinkButton12.Visible = false; //publishers
                    LinkButton10.Visible = false; // admin users control
                    LinkButton8.Visible = false; // books 
                    LinkButton9.Visible = false; // wyp




                }

                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //log in
                    LinkButton2.Visible = false; // sign up
                    LinkButton3.Visible = true; // log out
                    LinkButton7.Visible = true; // hello user!
                    LinkButton7.Text = "Hello, " + Session["username"].ToString(); // hello user!

                    LinkButton6.Visible = true; // footer admin


                    LinkButton11.Visible = false; // admin authors
                    LinkButton12.Visible = false; //publishers
                    LinkButton10.Visible = false; // admin users control
                    LinkButton8.Visible = false; // books 
                    LinkButton9.Visible = false; // wyp
                }

                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //log in
                    LinkButton2.Visible = false; // sign up
                    LinkButton3.Visible = true; // log out
                    LinkButton7.Visible = true; // hello user!
                    LinkButton7.Text = "Hello, ADMIN ";// hello user!

                    LinkButton6.Visible = false; // footer admin


                    LinkButton11.Visible = true; // admin authors
                    LinkButton12.Visible = true; //publishers
                    LinkButton10.Visible = true; // admin users control
                    LinkButton8.Visible = true; // books 
                    LinkButton9.Visible = true; // wyp
                }
            }
            catch
            {

            }
            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_author.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_publisher.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("books_store.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("books_w.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_management.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("view.aspx"); 
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["full_name"] = "";
            Session["role"] = "";

            LinkButton1.Visible = true; //log in
            LinkButton2.Visible = true; // sign up
            LinkButton3.Visible = false; // log out
            LinkButton7.Visible = false; // hello user!

            LinkButton6.Visible = true; // footer admin


            LinkButton11.Visible = false; // admin authors
            LinkButton12.Visible = false; //publishers
            LinkButton10.Visible = false; // admin users control
            LinkButton8.Visible = false; // books 
            LinkButton9.Visible = false; // wyp

            Response.Redirect("StronaGłówna.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}