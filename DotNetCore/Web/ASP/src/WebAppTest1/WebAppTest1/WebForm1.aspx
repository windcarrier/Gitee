<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppTest1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div dir="ltr" style="height: 463px; width: 701px">

            Enter your name:
            <br />
            <asp:TextBox ID="TextBox1" runat="server"   ontextchanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            <br />
            <asp:Label ID="Label1" runat="server"/>

            <asp:Panel ID="Panel1" runat="server" Height="363px" 
                style="margin-left: 0px; margin-top: 41px" Width="245px">
                <asp:TreeView ID="TreeView1" runat="server" 
                    onselectednodechanged="TreeView1_SelectedNodeChanged">
                    <Nodes>
                        <asp:TreeNode Text="Boot" Value="Boot">
                            <asp:TreeNode Text="111111" Value="111111">
                                <asp:TreeNode Text="2222" Value="2222">
                                    <asp:TreeNode Text="新建节点" Value="新建节点">
                                        <asp:TreeNode Text="新建节点" Value="新建节点">
                                            <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                                        </asp:TreeNode>
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="2222222" Value="2222222"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Text="1111111" Value="1111111">
                                <asp:TreeNode Text="22222" Value="22222"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Text="11111111" Value="11111111">
                                <asp:TreeNode Text="2222" Value="2222"></asp:TreeNode>
                                <asp:TreeNode Text="222222" Value="222222"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Text="111111" Value="111111"></asp:TreeNode>
                            <asp:TreeNode Text="111" Value="111"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                </asp:TreeView>
                <asp:TextBox ID="txtmessage" runat="server" Height="70px"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:Panel>

         </div>
    </form>
</body>
</html>
