<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Bibliot.viewaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div style="text-align:center" class="col">
                           <h4>Lista książek</h4>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiblioDBConnectionString %>" SelectCommand="SELECT * FROM [book_table]"></asp:SqlDataSource>
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="book_id">
                            <Columns>
                                <asp:BoundField DataField="book_id" HeaderText="ID książki" SortExpression="book_id" ReadOnly="True" />
                                <asp:BoundField DataField="book_name" HeaderText="Tytuł" SortExpression="book_name" />
                                <asp:BoundField DataField="genre" HeaderText="Gatunek" SortExpression="genre" />
                                <asp:BoundField DataField="author_name" HeaderText="Autor" SortExpression="author_name" />
                                <asp:BoundField DataField="publisher_name" HeaderText="Wydawca" SortExpression="publisher_name" />
                                <asp:BoundField DataField="publish_date" HeaderText="Data publikacji" SortExpression="publish_date" />
                                <asp:BoundField DataField="book_cost" HeaderText="Koszt książki" SortExpression="book_cost" />
                                
                                <asp:BoundField DataField="no_of_pages" HeaderText="Liczba stron" SortExpression="no_of_pages" />
                                <asp:BoundField DataField="book_description" HeaderText="Opis" SortExpression="book_description" />
                                
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
</asp:Content>
