<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CasosHoraD.aspx.vb" Inherits="digitacion.CasosHoraD" %>
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
                <section>
                        <div class="text-center Subtitulos">Consulta Casos</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                 <%--<asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="Txt_Cons_FcIni" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>                                    --%>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Final</div>
                                        <asp:TextBox ID="TxtFecha_Inicio" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>                                     
                                    </div>
                                    <asp:LinkButton ID="BtnFiltro" TabIndex="6" CssClass="btn btn-primary" Font-Strikeout="false" runat="server">
                                    <span class="glyphicon glyphicon-floppy-disk"></span> Buscar
                                </asp:LinkButton>
                                    <asp:LinkButton ID="BtnDiario" TabIndex="6" CssClass="btn btn-primary" Font-Strikeout="false" runat="server">
                                    <span class="glyphicon glyphicon-check"></span> Diario
                                </asp:LinkButton>
                                <asp:LinkButton ID="BtnExpo" Visible="false" TabIndex="6" CssClass="btn btn-primary" Font-Strikeout="false" runat="server">
                                    <span class="glyphicon glyphicon-floppy-save"></span> Exportar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:Label ID="fc1" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="fc2" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="fc3" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="fc4" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="fc5" runat="server" Visible="False"></asp:Label>
                            </div>
                    </section>

                    <asp:Panel runat="server" ID="Pnl_ConsTk">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="LblCantidad"></asp:Label>
                        </div>
                        <div class="bordes">               
                          <asp:GridView ID="DtgDiario" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="true" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />                               
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
            <Triggers>          
                  <asp:PostBackTrigger  ControlID="BtnExpo" />
            </Triggers>

        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>


