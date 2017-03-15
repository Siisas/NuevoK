<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConsultaEscalados.aspx.vb" Inherits="digitacion.ConsultaEscalados" %>
<%@ Register src="~/Controles/Header.ascx" tagname="Header" tagprefix="Control" %>

<!DOCTYPE html>
<%--	© 2016 Crisitan Duarte C1477	--%>
<html>
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Consulta Escalados | Kamilion ERP</title>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <article>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                    <section>
                        <div class="text-center Subtitulos">Filtros - Consulta General de Escalados</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Caso</div>
                                    <asp:TextBox ID="Txt_Caso" MaxLength="15" TabIndex="1" CssClass="form-control" runat="server" />
                                </div>                                
                                <div class="input-group">
                                    <div class="input-group-addon">Escalado</div>
                                    <asp:DropDownList ID="Drl_Escalado" TabIndex="3" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="- Seleccione" />
                                        <asp:ListItem Text="SI" />
                                        <asp:ListItem Text="NO" />
                                    </asp:DropDownList>
                                </div><h3></h3>
                                <asp:Button ID="Btn_Buscar" Text="Buscar" TabIndex="6" CssClass="btn btn-primary" runat="server" />
                                <asp:Button ID="Btn_Exportar" Text="Exportar" TabIndex="7" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Area Escalamiento</div>
                                    <asp:DropDownList ID="Drl_Escalamiento" TabIndex="2" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="- Seleccione" />
                                        <asp:ListItem Text="Informatica" />
                                        <asp:ListItem Text="Tecnica" />
                                    </asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Registro</div>
                                    <asp:TextBox ID="Txt_Fc_Ini" MaxLength="10" TabIndex="4" Placeholder="DD/MM/YYYY"  CssClass="form-control Fecha" runat="server" />
                                    <div class="input-group-addon">-</div>
                                    <asp:TextBox ID="Txt_Fc_Fin" MaxLength="10" TabIndex="5" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server" />
                                </div>
                            </div>
                        </div><br />
                        <div class="Leyendas">
                            <asp:Label ID="Lbl_Cuenta" runat="server"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="DtgGeneral" runat="server" AllowPaging="True" PageSize="40" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Caso" HeaderText="Caso" />
                                    <asp:BoundField DataField="Usuario Registra" HeaderText="Usuario Registra" />
                                    <asp:BoundField DataField="FC Registro" HeaderText="FC Registro" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="CPD/SD" HeaderText="CPD/SD" />
                                    <asp:BoundField DataField="Usuario CPD/SD" HeaderText="Usuario CPD/SD" />
                                    <asp:BoundField DataField="FC Reg CPD/SD" HeaderText="FC Reg CPD/SD" />
                                    <asp:BoundField DataField="Area Escalamiento" HeaderText="Area Escalamiento" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </section>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Btn_Exportar" />
                    </Triggers>
                </asp:UpdatePanel>
            </article>
            <footer></footer>
        </form>
    </body>
</html>
<%--	© 2016 Crisitan Duarte C1477	--%>