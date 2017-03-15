<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inventario.aspx.vb" Inherits="digitacion.Inventario" %>

<%@ Register src="~/Controles/Header.ascx" tagname="Header" tagprefix="Control" %>

<!DOCTYPE html>
<html>
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Kamilion CRM</title>
        <link rel="icon" href="~/favicon.ico" type="image/x-icon"/>              
        <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>     
        <script type="text/javascript" src="../Css2/jquery.min.js"></script>
        <script type="text/javascript" src="../Css2/jquery-ui.min.js"></script>
        <script type="text/javascript" src="../Css2/jquery-ui-timepiker.js"></script>
        <script type="text/javascript" src="../Css2/scripts.js"></script>
        <!--#########Estilos############-->
        <link type="text/css" rel="Stylesheet" href="~/Css2/Boot/css/bootstrap.min.css"/>   
        <link type="text/css" rel="Stylesheet" href="~/Css2/jquery-ui.css"/>   
        <link type="text/css" rel="Stylesheet" href="~/Css2/Kamilion.css"/>
    </head>
    <body>
        <form runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <Control:Header ID="Header" runat="server"/>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Panel id="Pnl_Message" runat="server">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </asp:Panel>
                    <article>
                        <section>
                            <div class="text-center Subtitulos">REGISTRO</div>
                            <div class="text-center Sub-Subtitulo">Módulo</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Letra</div>
                                        <asp:TextBox ID="TxtLetra" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha de adquisición</div>
                                        <asp:TextBox ID="Txt_Fc_Adq" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    </div>                                
                                    <asp:Button ID="Btn_RegMod" runat="server" CssClass="btn btn-primary Desplegar_Loading" Text="Guardar" />
                                    <asp:Button ID="Btn_Limpiar_RegMod" runat="server" CssClass="btn btn-primary" Text="Limpiar" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Numero</div>
                                        <asp:TextBox ID="TxtNumero" CssClass="form-control" runat="server" MaxLength="4"></asp:TextBox>
                                    </div>    
                                    <div class="input-group">
                                        <div class="input-group-addon">Área</div>
                                        <asp:DropDownList ID="Drl_Area_Modulo" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center Sub-Subtitulo">Dispositivo</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Dispositivo</div>
                                        <asp:DropDownList ID="Drl_Dispositivo_RegDisp" runat="server" CssClass="form-control" AutoPostBack="True" />
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Modelo</div>
                                        <asp:TextBox ID="Txt_Modelo_RegDisp" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Empresa</div>
                                        <asp:DropDownList ID="Drl_Empresa_RegDisp" CssClass="form-control" runat="server" AutoPostBack="True">
                                            <asp:ListItem>DYNAMIC</asp:ListItem>
                                            <asp:ListItem>KAMILION</asp:ListItem>
                                            <asp:ListItem>Otro</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox Width="50%" ID="Txt_Empresa_RegDisp" CssClass="form-control" runat="server"  Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Modulo</div>
                                        <asp:DropDownList ID="Drl_Moulo_RegDisp" CssClass="form-control" runat="server" />
                                    </div>
                                    <asp:Button ID="Btn_RegDisp" runat="server" CssClass="btn btn-primary Desplegar_Loading" Text="Guardar" />
                                    <asp:Button ID="Btn_Limpiar_RegDisp" runat="server" CssClass="btn btn-primary" Text="Limpiar" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Marca</div>
                                        <asp:DropDownList ID="Drl_Marca_RegDisp" runat="server" AutoPostBack="True" CssClass="form-control">
                                            <asp:ListItem>AOC</asp:ListItem>
                                            <asp:ListItem>Compaq</asp:ListItem>
                                            <asp:ListItem>Dell</asp:ListItem>
                                            <asp:ListItem>Generico</asp:ListItem>
                                            <asp:ListItem>Genius</asp:ListItem>
                                            <asp:ListItem>Hewlett Packard (HP)</asp:ListItem>
                                            <asp:ListItem>Lenovo</asp:ListItem>
                                            <asp:ListItem>Microsoft</asp:ListItem>
                                            <asp:ListItem>Samsung</asp:ListItem>
                                            <asp:ListItem>Otro</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="Txt_Marca_RegDisp" runat="server" Width="50%" CssClass="form-control" Visible="false" ></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Serial</div>
                                        <asp:TextBox ID="Txt_Serial_RegDisp" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Panel runat="server" ID="Pnl_Txt_SerialK_RegDisp" cssclass="input-group">
                                        <div class="input-group-addon">Serial Kamilion</div>
                                        <asp:TextBox ID="Txt_SerialK_RegDisp" CssClass="form-control" runat="server"></asp:TextBox>
                                    </asp:Panel>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha de adquisición</div>
                                        <asp:TextBox ID="Txt_FechAdqui_RegDisp" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <section>
                            <div class="text-center Subtitulos">CONSULTAR INVENTARIO</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Modulo</div>
                                        <asp:DropDownList ID="drlModuloConsultas" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Marca</div>
                                        <asp:DropDownList ID="Drl_Marca_Cons" CssClass="form-control" runat="server"
                                            AutoPostBack="True">
                                            <asp:ListItem Value="1">- Seleccione -</asp:ListItem>
                                            <asp:ListItem>AOC</asp:ListItem>
                                            <asp:ListItem>Compaq</asp:ListItem>
                                            <asp:ListItem>Dell</asp:ListItem>
                                            <asp:ListItem>Generico</asp:ListItem>
                                            <asp:ListItem>Genius</asp:ListItem>
                                            <asp:ListItem>Hewlett Packard (HP)</asp:ListItem>
                                            <asp:ListItem>Lenovo</asp:ListItem>
                                            <asp:ListItem>Microsoft</asp:ListItem>
                                            <asp:ListItem>Samsung</asp:ListItem>
                                            <asp:ListItem>Otro</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="TxtMarcaConsulta" Width="50%" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Modelo 
                                        </div>
                                        <asp:TextBox ID="TxtModeloConsulta" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha de Adquisición</div>
                                        <asp:TextBox ID="Txt_Consuta_Adquisicion" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="Btn_Consultar_Inventario" runat="server" CssClass="btn btn-primary Desplegar_Loading" Text="Consultar" />
                                    <asp:Button ID="Btn_Limpiar_Cons" runat="server" CssClass="btn btn-primary" Text="Limpiar" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Serial</div>
                                        <asp:TextBox ID="TxtSerialConsulta" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Serial Kamilion</div>
                                        <asp:TextBox ID="TxtSerialKamilionConsulta" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Empresa</div>
                                        <asp:DropDownList ID="Drl_Empresa_Cons" Width="50%" CssClass="form-control" runat="server"
                                            AutoPostBack="True">
                                            <asp:ListItem Value="">- Seleccione -</asp:ListItem>
                                            <asp:ListItem>DYNAMIC</asp:ListItem>
                                            <asp:ListItem>KAMILION</asp:ListItem>
                                            <asp:ListItem>Otro</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="Txt_Empresa_Cons" Width="50%" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Área
                                        </div>
                                        <asp:DropDownList ID="Drl_Area_Cons" CssClass="form-control" runat="server" ></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <asp:Panel runat="server" ID="Pnl_Dtg_ConsInv">
                            <div class="Leyendas ">
                                Numero de registros:<asp:Label ID="Lbl_ConsInv" runat="server">0</asp:Label>
                            </div>
                            <div class="bordes">
                                <asp:GridView ID="Dtg_ConsInv" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="90" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="Cod_Inventario" HeaderText="Código" />
                                        <asp:BoundField DataField="Dispositivo" HeaderText="Tipo" />
                                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                        <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                        <asp:BoundField DataField="Serial_Kamilion" HeaderText="Serial Kamilion" />
                                        <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                        <asp:BoundField DataField="Area" HeaderText="Área" />
                                        <asp:BoundField DataField="Modulo" HeaderText="Modulo" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario Registra" />
                                        <asp:BoundField DataField="FcReg_Invent" HeaderText="Fecha Registro" />
                                        <asp:BoundField DataField="Fc_Adquisicion" HeaderText="Fecha Adquisición" />
                                    </Columns>
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </article>
                </ContentTemplate>
            </asp:UpdatePanel>
            <footer></footer>
        </form>
    </body>
</html>
