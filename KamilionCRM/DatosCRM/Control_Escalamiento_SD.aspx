<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Control_Escalamiento_SD.aspx.vb" Inherits="digitacion.Control_Escalamiento_SD" %>
<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>
<!DOCTYPE html>
<%--	© 2016 Crisitan Duarte C1477	--%>
<%--	© 12-2016 Gerson Sánchez C1555	--%>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Kamilion CRM</title>
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
                    </asp:Panel>
                    <article>
                        <section>
                            <div class="text-center Subtitulos">Seleccionar Agente/Ingeniero</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Agente</div>
                                        <asp:DropDownList ID="Drl_Agente" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="btn-group btn-group-justified">
                                        <div class="btn-group">
                                            <asp:Button ID="Btn_Liberar" Text="Liberar Agente" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                        </div>
                                        <div class="btn-group">
                                            <asp:Button ID="Btn_Lib_Mas" Text="Liberar Todo" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <section>
                            <div class="text-center Subtitulos">Filtros de Consulta</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="Txt_Top" ValidationGroup="Buscar" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9]{0,100}$">El campo Cantidad de Casos es de tipo numerico!</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cantidad de Casos</div>
                                        <asp:TextBox ID="Txt_Top" MaxLength="7" runat="server" CssClass="form-control" />
                                    </div>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="Txt_Caso" ValidationGroup="Buscar" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9]{0,100}$">El campo Caso Individual es de tipo numerico!</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Caso Individual</div>
                                        <asp:TextBox ID="Txt_Caso" MaxLength="15" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Estado SD</div>
                                        <asp:DropDownList ID="Drl_EstadoSD" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Bandeja</div>
                                        <asp:DropDownList ID="Drl_Bandeja" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="input-group"> 
                                        <div class="input-group-addon">Respuesta</div>
                                        <asp:DropDownList ID="Drl_Respuesta" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0" Text="- Seleccione -" />
                                            <asp:ListItem Value="SI" Text="SI" />
                                            <asp:ListItem Value="NO" Text="NO" />
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_FRegBandejaIni" ValidationGroup="Buscar" SetFocusOnError="True" Type="Date" MaximumValue="01/01/3000" MinimumValue="01/01/1900">Verifique las fechas, ya que el rango o el formato no es el correcto!</asp:RangeValidator>
                                    <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_FRegBandejaFin" ValidationGroup="Buscar" SetFocusOnError="True" Type="Date" MaximumValue="01/01/3000" MinimumValue="01/01/1900">Verifique las fechas, ya que el rango o el formato no es el correcto!</asp:RangeValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Registro Bandeja</div>
                                        <asp:TextBox ID="Txt_FRegBandejaIni" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                        <div class="input-group-addon">-</div>
                                        <asp:TextBox ID="Txt_FRegBandejaFin" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                    </div>
                                    <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_FRegSdIni" ValidationGroup="Buscar" SetFocusOnError="True" Type="Date" MaximumValue="01/01/3000" MinimumValue="01/01/1900">Verifique las fechas, ya que el rango o el formato no es el correcto!</asp:RangeValidator>
                                    <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_FRegSdFin" ValidationGroup="Buscar" SetFocusOnError="True" Type="Date" MaximumValue="01/01/3000" MinimumValue="01/01/1900">Verifique las fechas, ya que el rango o el formato no es el correcto!</asp:RangeValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Registro SD</div>
                                        <asp:TextBox ID="Txt_FRegSdIni" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                        <div class="input-group-addon">-</div>
                                        <asp:TextBox ID="Txt_FRegSdFin" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                    </div>
                                    <br />
                                    <asp:Button ID="Btn_Buscar" ValidationGroup="Buscar" Text="Buscar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                    <asp:Button ID="Btn_Limpiar" ValidationGroup="Buscar" Text="Limpiar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                    <asp:Button ID="Btn_Asignar" Text="Asignar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                    <asp:Button ID="Btn_Exportar" Text="Exportar" CssClass="btn btn-primary" runat="server" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="bordes">
                                        <asp:GridView ID="Dtg_Estad" runat="server" AllowPaging="True" PageSize="12" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                            <Columns>
                                                <asp:BoundField DataField="Nombre" HeaderText="Agente" />
                                                <asp:BoundField DataField="Casos" HeaderText="Casos" />
                                            </Columns>
                                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <div class="Leyendas">
                            Casos Encontrados: <asp:Label ID="Lbl_Cuenta" runat="server">0</asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="Dtg_General" runat="server" AllowPaging="True" PageSize="100" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Caso" HeaderText="Caso" />
                                    <asp:BoundField DataField="fcregserv" HeaderText="Fecha Registro SD" />
                                    <asp:BoundField DataField="Min" HeaderText="Min" />
                                    <asp:BoundField DataField="tickler" HeaderText="SD" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado SD" />
                                    <asp:BoundField DataField="Fc_Reg" HeaderText="Fecha Registro Bandeja" />
                                    <asp:BoundField DataField="idusuarioserv" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Bandeja" HeaderText="Bandeja" />
                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
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
                <Triggers>
                    <asp:PostBackTrigger ControlID="Btn_Exportar" />
                </Triggers>
            </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>
<%--	© 2016 Crisitan Duarte C1477	--%>