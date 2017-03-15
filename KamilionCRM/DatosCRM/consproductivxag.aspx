<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="consproductivxag.aspx.vb" Inherits="digitacion.consproductivxag" %>

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
                                <%--  <asp:RegularExpressionValidator Font-Size="10px" runat="server" ControlToValidate="TxtCodigoFiltro" Display="Dynamic" SetFocusOnError="True" ValidationExpression="((MT)?(MT)?)*([0-9]{4,4})*">Codigo mal escrito, Ejemplo(MT0000)</asp:RegularExpressionValidator>--%>

                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="txtfcdesden3" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Gestión</div>
                                    <asp:TextBox ID="txtfcdesden3" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado Caso</div>
                                    <asp:DropDownList ID="drlestado" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:LinkButton ID="Btn_Filtrar" TabIndex="9" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Filtrar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="txtfchastan3" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Gestión</div>
                                    <asp:TextBox ID="txtfchastan3" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>                       
                    </section>
                     <div class="bordes">
                            <div class="Leyendas">
                                <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                            </div>
                        </div>
                        <asp:GridView ID="dtggeneral" runat="server" AllowPaging="false" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="idcrm" HeaderText="ID" />
                                <asp:BoundField DataField="idcaso" HeaderText="Caso" />
                                <asp:BoundField DataField="fcreg" HeaderText="Fecha Gestión" />
                                <asp:BoundField DataField="idusuario" HeaderText="Agente" />
                                <asp:BoundField DataField="tipificacion" HeaderText="Tipificación" />
                            </Columns>
                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                        </asp:GridView>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>





