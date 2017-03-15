<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsignacion.aspx.vb" Inherits="digitacion.ControlAsignacion" %>

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
                </asp:Panel>
                <article>
                    <%--- Seccion de Consulta ---%>
                    <section>
                        <div class="text-center Subtitulos">Control Operación</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="DrlEstado" AutoPostBack="true" TabIndex="6" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:LinkButton ID="BtnBusca" TabIndex="8" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Consulta
                                </asp:LinkButton>
                                <asp:LinkButton ID="Btnexportar" TabIndex="9" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-save"></span> Exportar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:Panel runat="server" ID="PnlProgramado" Visible="false">
                                    <div class="input-group">
                                        <div class="input-group-addon">Estado Programado</div>
                                        <asp:DropDownList ID="DrlProgramado" AutoPostBack="true" TabIndex="2" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">- Seleccione -</asp:ListItem>
                                            <asp:ListItem Value="1">CADUCADO</asp:ListItem>
                                            <asp:ListItem Value="2">VIGENTE</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                        <%-- Primera Grid --%>
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="Lblcampaña"></asp:Label>
                            <div class="bordes" style="overflow: auto; min-height: 0px; max-height: 400px; width: 100%;">
                                <asp:GridView ID="DtgControl" runat="server" AllowPaging="false" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="false">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                    <Columns>
                                        <asp:BoundField DataField="Ingeniero" HeaderText="Ingeniero" runat="server"></asp:BoundField>
                                        <asp:ButtonField DataTextField="DATOS" HeaderText="DATOS" CommandName="DATOS" runat="server"></asp:ButtonField>
                                        <asp:ButtonField DataTextField="DESACTIVACION" HeaderText="DESAC"
                                            CommandName="DESAC" runat="server"></asp:ButtonField>
                                        <asp:ButtonField DataTextField="DILO" HeaderText="DILO" CommandName="DILO"
                                            runat="server"></asp:ButtonField>
                                        <asp:ButtonField DataTextField="BSCS" HeaderText="BSCS" CommandName="BSCS"
                                            runat="server"></asp:ButtonField>
                                        <asp:ButtonField DataTextField="TSF - PQR" HeaderText="TSF - PQR" CommandName="TSF" runat="server"></asp:ButtonField>
                                        <asp:ButtonField DataTextField="TOTAL" HeaderText="TOTAL" CommandName="TOTAL" runat="server"></asp:ButtonField>
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
                    <%--segunda GRilla--%>
                    <div class="Leyendas">
                        <asp:Label runat="server" ID="lblcuenta"></asp:Label>
                        <div class="Form">
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:LinkButton ID="BtnExportar2" TabIndex="9" Visible="false" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-save"></span> Exportar Registros
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="bordes">
                        <asp:GridView ID="dtggeneral" PageSize="20" runat="server" AllowPaging="false" AutoGenerateColumns="true" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="false">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
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
                <asp:PostBackTrigger ControlID="Btnexportar" />
                <asp:PostBackTrigger ControlID="BtnExportar2" />
            </Triggers>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>
