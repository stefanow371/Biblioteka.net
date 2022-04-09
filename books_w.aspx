<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="books_w.aspx.cs" Inherits="Bibliot.books_w" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div style="text-align:center" class="col">         
                           <h4>Wypożyczone książki</h4>
                     </div>
                  </div>
                  <div class="row">
                     <div style="text-align:center" class="col">
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">

                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Użytkownik" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">

                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID książki"></asp:TextBox>
                              <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="" OnClick="Button1_Click" />
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Nazwa użytkownika" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                    
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Nazwa książki" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Data wypożyczenia" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Termin oddania" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-6">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Wypożycz" OnClick="Button2_Click1" />
                     </div>
                     <div class="col-6">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="Zwróć" OnClick="Button4_Click1" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="StronaGłówna.aspx">Wróć na stronę główną</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div style="text-align:center" class="col">                     
                           <h4>Lista wypożyczeń</h4>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiblioDBConnectionString %>" SelectCommand="SELECT * FROM [user_table]"></asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="member_id">
                             <Columns>
                                 <asp:BoundField DataField="member_id" HeaderText="Użytkownik" ReadOnly="True" SortExpression="member_id" />
                                 <asp:BoundField DataField="book_id" HeaderText="ID książki" SortExpression="book_id" />
                                 <asp:BoundField DataField="username" HeaderText="Imię i nazwisko" SortExpression="username" />
                                 <asp:BoundField DataField="book_name" HeaderText="Tytuł" SortExpression="book_name" />
                                 <asp:BoundField DataField="p_date" HeaderText="Wypożyczono" SortExpression="p_date" />
                                 <asp:BoundField DataField="k_date" HeaderText="Termin oddania" SortExpression="k_date" />
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
