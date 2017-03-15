﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Consulta_Falla_Des.aspx.vb" Inherits="digitacion.Consulta_Falla_Des" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>

<!DOCTYPE html>
<%--	© 2016 Crisitan Duarte C1477	--%>
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
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <article>
                    <section>
                        <div class="text-center Subtitulos">Filtros de consulta</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txtcaso" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">El campo caso debe ser de tipo numerico!</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Caso</div>
                                    <asp:TextBox ID="txtcaso" MaxLength="12" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txtmin" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">El campo min debe ser de tipo numerico!</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Min</div>
                                    <asp:TextBox ID="txtmin" MaxLength="10" CssClass="form-control" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="drltipificacionll" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="- Seleccione -" />
                                    </asp:DropDownList>
                                </div><h4></h4>
                                <asp:Button ID="BtnBuscar" Text="Buscar" CssClass="btn btn-primary" runat="server" />
                                <asp:Button ID="btnxls" Text="Exportar" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txtCasoClaro" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">El campo caso claro debe ser de tipo numerico!</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Caso Claro</div>
                                    <asp:TextBox ID="txtCasoClaro" MaxLength="12" CssClass="form-control" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Bandeja</div>
                                    <asp:DropDownList ID="drlBandeja" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0" Text="- Seleccione -" />
                                    </asp:DropDownList>
                                </div>
                                <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="TxtFc_Ini" SetFocusOnError="True" Type="Date" MaximumValue="01/01/2020" MinimumValue="01/01/2000">Por favor verifique el rango de fechas!</asp:RangeValidator>
                                <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="TxtFc_Fin" SetFocusOnError="True" Type="Date" MaximumValue="01/01/2020" MinimumValue="01/01/2000">Por favor verifique el rango de fechas!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Registro</div>
                                    <asp:TextBox ID="TxtFc_Ini" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" runat="server" />
                                    <div class="input-group-addon">-</div>
                                    <asp:TextBox ID="TxtFc_Fin" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" runat="server" />
                                </div>
                            </div>
                        </div>
                    </section>
                     <div class="Leyendas">
                            <asp:Label runat="server" ID="lblcuenta"></asp:Label>
                        </div>
                        <%--<h4><em style="color: #8F9E45">Resultados Desactivación: </em>
                            <asp:Label ID="lblcuenta" runat="server" ForeColor="#8F9E45"></asp:Label>
                        </h4>--%>
                        <div class="bordes" style="overflow: auto; min-height: 0px; width: 100%;">
                            <asp:GridView ID="DtgGeneral" runat="server" AllowPaging="True" PageSize="80" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                     <div class="Leyendas">
                            <asp:Label runat="server" ID="lblcuentaSeguimiento"></asp:Label>
                        </div>
                        <%--<h4 style="color: #8F9E45;"><em></em>
                            <asp:Label ID="lblcuentaSeguimiento" runat="server"></asp:Label></h4>
                        <div class="bordes">--%>
                            <asp:GridView ID="DtgGestion" runat="server" AllowPaging="True" PageSize="500" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
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
                <asp:PostBackTrigger ControlID="btnxls" />
            </Triggers>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>
<%--	© 2016 Crisitan Duarte C1477	--%>