<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageAdd.aspx.cs" Inherits="MessageBoard.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>標題<asp:TextBox ID="Message_Header" runat="server" required="標題必填" aria-required="true" oninvalid ="setCustomValidity('標題必填')"></asp:TextBox></p>
    <p>暱稱<asp:TextBox ID="Message_Name" runat="server"></asp:TextBox></p>
    <asp:TextBox ID="Message_Main" runat="server" Height="477px" Width="596px" TextMode="MultiLine" ></asp:TextBox>
    <br/>
    <br/>
    <p>
    <asp:Button ID="Confirm" runat="server" Text="Leave a message" OnClick="Confirm_Click" />
    <input id="Reset1" type="reset" value="Rewrite the message" />
    </p>
</asp:Content>
