<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="regdotacion.aspx.vb" Inherits="digitacion.regdotacion" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ERP Kamilion </title>
    <link rel="icon" href="~/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
    <script type="text/javascript" src="../Css2/jquery.min.js"></script>
    <script type="text/javascript" src="../Css2/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Css2/jquery-ui-timepiker.js"></script>
    <script type="text/javascript" src="../Css2/scripts.js"></script>
    <!--#########Estilos############-->
    <link type="text/css" rel="Stylesheet" href="~/Css2/Boot/css/bootstrap.min.css" />
    <link type="text/css" rel="Stylesheet" href="~/Css2/jquery-ui.css" />
    <link type="text/css" rel="Stylesheet" href="~/Css2/Kamilion.css" />
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <Control:Header ID="Header" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="Pnl_Message" runat="server">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>    
                </asp:Panel>
                <article>
                    <section>
                        <div class="text-center Subtitulos">Filtro</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Código</div>
                                    <asp:TextBox ID="txtcod" CssClass="form-control" runat="server" MaxLength="6" />
                                </div>

                                <asp:LinkButton ID="Btn_Validar" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Validar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Nombre</div>
                                    <asp:Label ID="lblnombre" ReadOnly="true" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>
                    </section>
                    <section>
                        <div class="text-center Subtitulos">Filtro</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Carné                                       
                                    </div>
                                    <asp:RadioButtonList CssClass="form-control" ID="rdbcarne" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="Si">SI</asp:ListItem>
                                        <asp:ListItem Value="No">NO</asp:ListItem>
                                        <asp:ListItem Value="Pr">PROVISIONAL</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Diadema                                      
                                    </div>
                                    <asp:RadioButtonList CssClass="form-control" ID="rdbdiadema" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="Si">SI</asp:ListItem>
                                        <asp:ListItem Value="No">NO</asp:ListItem>
                                        <asp:ListItem>NA</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Locker                                   
                                    </div>
                                     <asp:Panel runat="server" ID="PnlLocker" Visible="true">
                                        <asp:TextBox ID="TxtLocker" CssClass="form-control" PLACEHOLDER="Numero Locker" runat="server" MaxLength="6" />
                                    </asp:Panel>
                                    

                                    <span class="input-group-btn"></span>
                                   <asp:CheckBox CssClass="form-control" AutoPostBack="true" value="NA" RepeatDirection="Horizontal" ID="chklocker" runat="server" Text="No Aplica" />
                                </div>
                                <asp:LinkButton ID="Btn_Guardar" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Guardar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Chaleco
                                         <%--   <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" runat="server" ControlToValidate="txtnumalt" ValidationGroup="VG_Registrar" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>--%>
                                        <%-- <asp:RegularExpressionValidator ID="telefono" runat="server" ErrorMessage="*" ValidationExpression="^[\w \# \. \: \- \s]{10,200}$" ControlToValidate="txtnumalt" Display="Dynamic" ValidationGroup="VG_Registrar" CssClass="textoError" />--%>
                                    </div>
                                    <asp:RadioButtonList CssClass="form-control" ID="rdbchaleco" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="Si">SI</asp:ListItem>
                                        <asp:ListItem Value="No">NO</asp:ListItem>
                                        <asp:ListItem>NA</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Uniforme                                    
                                    </div>
                                    <asp:RadioButtonList CssClass="form-control" ID="rdbuniforme" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="Si">SI</asp:ListItem>
                                        <asp:ListItem Value="No">NO</asp:ListItem>
                                        <asp:ListItem>NA</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                    </section>
                    <div class="bordes">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                        </div>
                        <asp:GridView ID="dtggeneral" runat="server" AllowPaging="false" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                <asp:BoundField DataField="codigo" HeaderText="Código" />
                                <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                <asp:BoundField DataField="apellidos" HeaderText="Apellido" />
                                <asp:BoundField DataField="nombreproyecto" HeaderText="Proyecto" />
                                <asp:BoundField DataField="area" HeaderText="Área" />
                                <asp:BoundField DataField="carne" HeaderText="Carné" />
                                <asp:BoundField DataField="chaleco" HeaderText="Chaleco" />
                                <asp:BoundField DataField="diadema" HeaderText="Diadema" />
                                <asp:BoundField DataField="locker" HeaderText="Locker" />
                                <asp:BoundField DataField="uniforme" HeaderText="Uniforme" />
                            </Columns>
                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>





