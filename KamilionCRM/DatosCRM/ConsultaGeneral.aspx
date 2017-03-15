<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConsultaGeneral.aspx.vb" Inherits="digitacion.ConsultaGeneral" %>
<%@ Register src="~/Controles/Header.ascx" tagname="Header" tagprefix="Control" %>

<!DOCTYPE html>
<%--	© 2016 Crisitan Duarte C1477	--%>
<html>
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Consulta General | Kamilion ERP</title>
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
                        <div class="text-center Subtitulos">Consulta General</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Min
                                        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txt_min" ValidationGroup="buscar" SetFocusOnError="True" ValidationExpression="^[0-9]{10}$">*</asp:RegularExpressionValidator>
                                    </div>
                                    <asp:TextBox ID="txt_min" MaxLength="15" TabIndex="1" CssClass="form-control" runat="server" />
                                </div>         
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:Button ID="Btn_Buscar" Text="Buscar" TabIndex="2" CssClass="btn btn-primary" runat="server" ValidationGroup="buscar" />
                                <asp:Button ID="Btn_Exportar" Text="Exportar" TabIndex="3" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div><br />
                        <div class="Leyendas">
                            <asp:Label ID="Lbl_Cuenta" runat="server"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="DtgGeneral" runat="server" AllowPaging="True" PageSize="40" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />                                
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
