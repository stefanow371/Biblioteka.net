<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="Bibliot.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
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
                                <h2>Loguj jako administrator</h2>
                            </div>
                        </div>
                        <div class="row">
                            <div style="text-align:center" class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div style="text-align:center" class="col">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"
                                        runat="server" placeholder="Login"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2"
                                        runat="server" placeholder="Hasło" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-primary btn-block" ID ="Button1"
                                        runat="server" Text="Zaloguj" OnClick="Button1_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="StronaGłówna.aspx"></a><br /><br />
            </div>
        </div>
    </div>
</asp:Content>
