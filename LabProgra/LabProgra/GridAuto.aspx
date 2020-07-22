<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="GridAuto.aspx.cs" Inherits="LabProgra.GridAuto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cuerpoHTML" runat="server">
    
            <asp:GridView ID="gridAutos" 
                runat="server" 
                CellPadding="4" 
                ForeColor="#333333" 
                GridLines="None"
                AutoGenerateColumns="false"
                DataKeyNames = "IdCarro"
                OnRowCommand ="gridAutos_RowCommand"
                OnRowEditing ="gridAutos_RowEditing"
                OnRowCancelingEdit = "gridAutos_RowCancelingEdit"
                OnRowUpdating = "gridAutos_RowUpdating"
                OnRowDeleting ="gridAutos_RowDeleting"
                ShowHeaderWhenEmpty ="false"
                ShowFooter ="true"
                >

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#242628" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#242628" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />



                
                <Columns>
                    
                 
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("IdCarro")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdCarro" Text='<%# Eval("IdCarro")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtIdcarropie" Text='<%# Eval("IdCarro")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    
                     <asp:TemplateField HeaderText="Marca">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Marca")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMarca" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMarcaPie" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Modelo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Modelo")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModelo" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtModeloPie" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Pais">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Pais")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPais" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPaispie" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                   
                     <asp:TemplateField HeaderText="Costo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Costo")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCosto" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCostoPie" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
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
            <asp:Label runat="server" ID="labExito" ForeColor="Green"></asp:Label>
            <asp:Label runat="server" ID="labError" ForeColor="Red"></asp:Label>

</asp:content> 



