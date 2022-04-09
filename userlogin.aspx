<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="Bibliot.userlogin" %>
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
                                <h2>Loguj jako użytkownik</h2>
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

                                <div class="form-group">
                                    <a href="usersignup.aspx"><input class="btn btn-info btn-block" id="Button2" type="button" value="Zarejestruj się " />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
