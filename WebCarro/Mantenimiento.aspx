<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mantenimiento.aspx.cs" Inherits="WebCarro.Mantenimiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <asp:GridView ID="gridCarro" 
                runat="server" 
                CellPadding="4" 
                ForeColor="#333333" 
                GridLines="None"
                AutoGenerateColumns="false"
                DataKeyNames = "IDCARRO"
                OnRowEditing ="gridCarro_RowEditing"
                OnRowCancelingEdit = "gridCarro_RowCancelingEdit"
                OnRowUpdating = "gridCarro_RowUpdating"
                OnRowDeleting ="gridCarro_RowDeleting"
                ShowHeaderWhenEmpty ="false"
                ShowFooter ="true"
                >

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                <Columns>
                    <asp:TemplateField HeaderText="MARCA">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("MARCA")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMarca" Text='<%# Eval("MARCA")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMarcaPie" Text='<%# Eval("MARCA")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="MODELO">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("MODELO")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModelo" Text='<%# Eval("MODELO")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtModeloPie" Text='<%# Eval("MODELO")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PAIS">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PAIS")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPais" Text='<%# Eval("PAIS")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPaisPie" Text='<%# Eval("PAIS")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="COSTO">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("COSTO")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCosto" Text='<%# Eval("COSTO")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCostoPIe" Text='<%# Eval("COSTO")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                           <asp:ImageButton ImageUrl="~/Imagenes/editar.png" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Imagenes/delete2.png" runat="server" CommandName="Delete" ToolTip="Borrar" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Imagenes/guardar.png" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Imagenes/cancel2.png"   runat="server" CommandName="Delete" ToolTip="Cancelar" Width="20px" Height="20px" />                           
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Imagenes/nuevo.png"   runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />                           
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br/>
            <br/>
            <asp:Label runat="server" ID="lblExito" ForeColor="Green"></asp:Label>
            <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>

        </div>
    </form>
</body>
</html>
