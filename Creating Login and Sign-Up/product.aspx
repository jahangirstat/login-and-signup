<%@ Page Title="New Page Of All" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Creating_Login_and_Sign_Up.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
       
       <table class="auto-style4">
           <tr>
               <td>Name</td>
               <td>
                   <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>Cloth Type</td>
               <td>
                   <asp:TextBox ID="txtCType" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>Color</td>
               <td>
                   <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>Quantity</td>
               <td>
                   <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>Price</td>
               <td>
                   <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:HiddenField ID="HiddenField1" runat="server" />
                   <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                   <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
               </td>
               <td>&nbsp;</td>
           </tr>
           
       </table>
      
       
   </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Brand" HeaderText="Brand" />
                <asp:BoundField DataField="ClothType" HeaderText="ClothType" />
                <asp:BoundField DataField="Color" HeaderText="Color" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="E" CommandArgument='<%# Eval("ID") %>'>Edit</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Del" CommandArgument='<%# Eval("ID") %>'>Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
