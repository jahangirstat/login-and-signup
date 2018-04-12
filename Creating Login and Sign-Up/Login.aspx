<%@ Page Title="Log In Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Creating_Login_and_Sign_Up.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<asp:Login ID="Login1"  runat="server" CreateUserText="Sign Up for New Account" CreateUserUrl="~/Registration.aspx" DestinationPageUrl="~/Reviews.aspx" OnLoggedIn="Login1_LoggedIn" style="text-align: left; margin-left: 61px; margin-top: 0px;" Width="304px" Height="161px">

    </asp:Login>
</asp:Content>
