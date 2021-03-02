<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageReply.aspx.cs" Inherits="MessageBoard.MessageReply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!--minify-->
    <link href="https://unpkg.com/nes.css@2.3.0/css/nes.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>REPLY TO THE THREAD</h1>
            
            標題<asp:TextBox ID="Reply_Header" runat="server"></asp:TextBox>
            <p>
                暱稱<asp:TextBox ID="Reply_Name" runat="server"></asp:TextBox>
            </p>
            內容<asp:TextBox ID="Reply_Main" runat="server" Height="427px" Width="928px" TextMode="MultiLine"></asp:TextBox>
            <br/>
            <asp:Button ID="Confirm" runat="server" Text="Reply" OnClick="Confirm_Click"  />
            <input id="Reset1" type="reset" value="Reset Reply" />
            <asp:Label ID="Message" runat="server" Text="" ForeColor="red"></asp:Label>

        </div>
    </form>
</body>
</html>
