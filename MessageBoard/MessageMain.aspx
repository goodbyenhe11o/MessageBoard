<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageMain.aspx.cs" Inherits="MessageBoard.MessageMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Reply" runat="server" Text="Comment To Thread" OnClick="Reply_Click" />
            <asp:Button ID="Revert" runat="server" Text="Go Back" OnClick="Revert_Click" />

            <br/>
            <br/>
            <asp:Label ID="Message_Header" runat="server" Text=""></asp:Label>
            <asp:Label ID="Message_Name" runat="server" Text=""></asp:Label>
            <asp:Label ID="Message_Time" runat="server" Text=""></asp:Label>
            <asp:Label ID="Main" runat="server" Text="Label"></asp:Label>

        </div>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <asp:Label ID="Respondent" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                <asp:Label ID="ReplyMain" runat="server" Text='<%# Bind("main") %>'></asp:Label>
            </ItemTemplate>

        </asp:Repeater>
        
    </form>
</body>
</html>
