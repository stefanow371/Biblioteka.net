<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="Bibliot.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div style="text-align:center" class="col">      
                         <img width="150px" src="imgs/login_icon.png" />
                     </div>
                  </div>
                  <div class="row">
                     <div style="text-align:center" class="col">         
                           <h4>Zarejestruj się</h4>
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
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Data" TextMode="Date"></asp:TextBox>
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
                       <div class="col-md-6">
                        <label>Nazwa użytkownika</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Nazwa użytkownika"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-6">
                        <label>Hasło</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Hasło" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  

                  <div class="row">
                     <div class="col-6 mx-auto">            
                           <div style="text-align:center" class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Zarejestruj" OnClick="Button1_Click" />
                           </div>
                     </div>
                  </div>
               </div>
            </div>
            <a href="StronaGłówna.aspx">Wróć do strony głównej</a><br><br>
         </div>
      </div>
   </div>
 
</asp:Content>
