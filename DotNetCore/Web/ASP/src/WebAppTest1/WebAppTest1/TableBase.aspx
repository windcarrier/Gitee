<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableBase.aspx.cs" Inherits="WebAppTest1.TableBase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

   <head id="Head1" runat="server">
      <title>
         Untitled Page
      </title>
   </head>

   <body>
      <form id="form1" runat="server">

         <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                 DataKeyNames="ID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                        ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="AuthorFirstName" HeaderText="AuthorFirstName" 
                        SortExpression="AuthorFirstName" />
                    <asp:BoundField DataField="AuthorLastName" HeaderText="AuthorLastName" 
                        SortExpression="AuthorLastName" />
                </Columns>
            </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:ASPDotNetStepByStepConnectionString2 %>" 
                 ProviderName="<%$ ConnectionStrings:ASPDotNetStepByStepConnectionString2.ProviderName %>" 
                 SelectCommand="SELECT [ID], [Title], [AuthorFirstName], [AuthorLastName] FROM [ASPDotNetStepByStep]">
             </asp:SqlDataSource>
             <asp:AccessDataSource ID="AccessDataSource1" runat="server">
             </asp:AccessDataSource>
         </div>

      </form>
   </body>

</html>
