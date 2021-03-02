<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageIndex.aspx.cs" Inherits="MessageBoard.MessageIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Test Message Board</title>
    <!-- minify -->
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="https://unpkg.com/nes.css@2.3.0/css/nes.min.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

    <%--<link href="Content/all.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">

        <%--學長的簡單作法 --%>
        <%--先拉一個button，把TEXT內文改成"我要留言"--%>

        <asp:Button ID="Button1" runat="server" Text="我要留言" OnClick="Button1_Click" />

        <%--再拉個Gridview然後連接資料庫--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:TemplateField HeaderText="編號">
                        <ItemTemplate>
                           <%-- 在編號欄的template field 加上"行號索引" : Container.DataItemIndex +1, 因索引從0開始--%>
                            <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="標題" SortExpression="Header">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Header") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "MessageMain.aspx?id="+Eval("id") %>' Text='<%#Bind("Name") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="發表人" SortExpression="Name" />
                <asp:BoundField DataField="InitDate" HeaderText="留言日期" SortExpression="InitDate" />
                <asp:TemplateField HeaderText="回應">

                    <ItemTemplate>
                        <asp:Label ID="RepCount" runat="server" Text='<%#Eval("回應") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </form>
</body>
</html>

