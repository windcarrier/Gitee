<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLRead.aspx.cs" Inherits="WebAppTest1.SQLRead" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <title>
         Untitled Page
      </title>
   </head>

   <body>
      <form id="form1" runat="server">
         <div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
               ConnectionString= "<%$ ConnectionStrings:ASPDotNetStepByStepConnectionString %>" 
               ProviderName= "<%$ ConnectionStrings:ASPDotNetStepByStepConnectionString.ProviderName %>" 
               
                 SelectCommand="SELECT [Title], [AuthorFirstName], [AuthorLastName], [Topic] FROM [ASPDotNetStepByStep]">
            </asp:SqlDataSource>

            <asp:GridView ID="GridView1" runat="server" 
               AutoGenerateColumns="False" CellPadding="3" 
               DataSourceID="SqlDataSource1" ForeColor="Black" 
               GridLines="Vertical" BackColor="White" BorderColor="#999999" 
                 BorderStyle="Solid" BorderWidth="1px">

               <Columns>
                  <asp:BoundField DataField="Title" HeaderText="Title" 
                     SortExpression="Title" />
                  <asp:BoundField DataField="AuthorFirstName" 
                     HeaderText="AuthorFirstName" SortExpression="AuthorFirstName" />
                  <asp:BoundField DataField="AuthorLastName" 
                     HeaderText="AuthorLastName" SortExpression="AuthorLastName" />
                  <asp:BoundField DataField="Topic" 
                     HeaderText="Topic" SortExpression="Topic" />
               </Columns>
               <FooterStyle BackColor="#CCCCCC" />
               <PagerStyle BackColor="#999999" 
                  ForeColor="Black" HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#000099" 
                  Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="Black" Font-Bold="True"  
                  ForeColor="White" />
               <AlternatingRowStyle BackColor="#CCCCCC" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
         </div>
      </form>
   </body>
</html>
