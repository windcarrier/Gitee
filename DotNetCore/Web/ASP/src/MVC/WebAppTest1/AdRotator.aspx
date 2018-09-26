<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdRotator.aspx.cs" Inherits="WebAppTest1.AdRotator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>File Upload Test</h3>
    <br />
    <br />
    <asp:FileUpload ID = "fileUpload1" runat="server" />
    <br />
    <br />
    <asp:Button ID = "btnSave" runat = "server"  OnClick="btnSave_Click" Text= "Save" style = "width:85px" />
    <br />
    <asp:Label ID = "Message" runat = "server"  />
    </div>
    </form>
</body>
</html>
