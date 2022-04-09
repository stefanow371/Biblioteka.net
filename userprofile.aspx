<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="Bibliot.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
      <div class="row">
         <div class="col-md-5   ">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div style="text-align:center" class="col">      
                         <img width="150px" src="imgs/login_icon.png" />
                     </div>
                  </div>
                  <div class="row">
                     <div style="text-align:center" class="col">         
                           <h4>Twoje konto</h4>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Imię i nazwisko </label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Imię i nazwisko"></asp:TextBox>
                        </div>
                     </div>

                     <div class="col-md-6">
                        <label>Data urodzenia</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-6">
                        <label>Numer telefonu</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Numer telefonu" TextMode="Phone"></asp:TextBox>
                        </div>
                     </div>

                     <div class="col-md-6">
                        <label>Adres e-mail</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Adres e-mail" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-6">
                        <label>Miasto</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Miasto"></asp:TextBox>
                        </div>
                     </div>

                     <div class="col-md-6">
                        <label>Ulica i numer domu</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Ulica i numer domu"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-7 mx-auto">            
                           <div style="text-align:center" class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Zaktualizuj dane" OnClick="Button1_Click1" />
                           </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Twoje książki</h4>
                            <asp:Label class="badge badge-info" ID="Label" runat="server" Text="Tutaj możesz sprawdzić stan wypożyczonych książek"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiblioDBConnectionString %>" SelectCommand="SELECT * FROM [user_table]"></asp:SqlDataSource>
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                       <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id">
                           <Columns>
                               <asp:BoundField DataField="member_id" HeaderText="member_id" ReadOnly="True" SortExpression="member_id" />
                               <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                               <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                               <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                               <asp:BoundField DataField="p_date" HeaderText="p_date" SortExpression="p_date" />
                               <asp:BoundField DataField="k_date" HeaderText="k_date" SortExpression="k_date" />
                           </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
