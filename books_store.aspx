<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="books_store.aspx.cs" Inherits="Bibliot.books_store" %>
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
                           <h4>Książki</h4>
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
                        <label>ID książki</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID książki"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" Text="Idź" OnClick="LinkButton4_Click"></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9">
                        <label>Tytuł</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Tytuł"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">                  
                     <div class="col-md-4">
                        <label>Autor</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                           </asp:DropDownList>
                        </div>
                        <label>Data publikacji</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Data" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                           <div class="col-md-4">
                        <label>Wydawca</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="A1" Value="a1" />
                              <asp:ListItem Text="a2" Value="a2" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Gatunek</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Akcja" Value="Akca" />
                              <asp:ListItem Text="Przygodowe" Value="Przygodowe" />
                              <asp:ListItem Text="Komiks" Value="Komiks" />
                              <asp:ListItem Text="Motywacyjne" Value="Motywacyjne" />
                              <asp:ListItem Text="Zdrowa żywność" Value="Zdrowa Żywność" />
                              <asp:ListItem Text="Kryminalne" Value="Kryminalne" />
                              <asp:ListItem Text="Dramat" Value="Dramat" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poezja" Value="Poezja" />
                              <asp:ListItem Text="Romanse" Value="Romanse" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Encyklopedie" Value="Encyklopedie" />
                              <asp:ListItem Text="Historia" Value="Historia" />
                              <asp:ListItem Text="Nauka" Value="Nauka" />
                           </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">  
                     <div class="col-md-4">
                        <label>Koszt książki</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Koszt" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Ilość stron</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Ilość stron" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                   
                  <div class="row">
                     <div class="col-12">
                        <label>Opis książki</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Opis" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                      <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-outline-primary" runat="server" Text="Dodaj" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-outline-info" runat="server" Text="Zmień" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-outline-danger" runat="server" Text="Usuń" OnClick="Button2_Click" />
                     </div>
                  </div>
               </div>
            
            <br>
         </div>
          </div>
         <div class="col-md-7">
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
  </div>

</asp:Content>
