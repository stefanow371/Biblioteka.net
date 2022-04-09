<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="member_management.aspx.cs" Inherits="Bibliot.member_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
         //datatable function
         $(document).ready(function () {

             //$(document).ready(function () {
             //$('.table').DataTable();
             // });

             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
             //$('.table1').DataTable();
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
                           <h4>Dane użytkownika</h4>
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
                     <div class="col-md-3">
                        <label>Użytkownik</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Użytkownik"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" Width="16px"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Imię i nazwisko</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Imię i nazwisko" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>     
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>Data urodzenia</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Data urodzenia" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Numer telefonu</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Numer telefonu" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Adres e-mail</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="e-mail" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                    
                      <div class="col-md-4">
                        <label>Miasto</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Miasto" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>

                      <div class="col-md-4">
                        <label>Ulica i numer domu</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Ulica" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
       
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Usuń użytkownika" OnClick="Button2_Click" />
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

                           <h4>Lista użytkowników</h4>

                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiblioDBConnectionString %>" SelectCommand="SELECT * FROM [member_table]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="username" HeaderText="Nazwa użytkownika" ReadOnly="True" SortExpression="username" />
                                <asp:BoundField DataField="full_name" HeaderText="Imię i nazwisko" SortExpression="full_name" />
                                <asp:BoundField DataField="date" HeaderText="Data urodzenia" SortExpression="date" />
                                <asp:BoundField DataField="phone_number" HeaderText="Numer telefonu" SortExpression="phone_number" />
                                <asp:BoundField DataField="e_mail" HeaderText="e-mail" SortExpression="e_mail" />
                                <asp:BoundField DataField="city" HeaderText="Miasto" SortExpression="city" />
                                <asp:BoundField DataField="street_no" HeaderText="Ulica i nr domu" SortExpression="street_no" />
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
