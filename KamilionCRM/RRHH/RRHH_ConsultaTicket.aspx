
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RRHH_ConsultaTicket.aspx.vb" Inherits="digitacion.ConsultaTicketsRh" %>

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
                        <div class="text-center Subtitulos">Filtros de Consulta</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <%--<asp:RegularExpressionValidator Font-Size="10px" runat="server" ControlToValidate="TxtCodigoFiltro" Display="Dynamic" SetFocusOnError="True" ValidationExpression="((MT)?(MT)?)*([0-9]{4,4})*">Codigo mal escrito, Ejemplo(MT0000)</asp:RegularExpressionValidator>--%>
                                <%--   <asp:RegularExpressionValidator  ControlToValidate="TxtCodigoFiltro"   Style="color: #F45761;font-size:10px"  Display="Dynamic" ValidationExpression="'{1,6}$" runat="server">Código mal escrito. EJEMPLO(MT0000)!</asp:RegularExpressionValidator>--%>
                                <asp:RegularExpressionValidator Font-Size="10px" runat="server" ControlToValidate="TxtCodigoFiltro" Display="Dynamic" SetFocusOnError="True" ValidationExpression="((MT)?(MT)?)*([0-9]{4,4})*">Codigo mal escrito, Ejemplo(MT0000)</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Código</div>
                                    <asp:TextBox ID="TxtCodigoFiltro" TabIndex="1" CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox>
                                </div>
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="TxtFechaInicio" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Inicio</div>
                                    <asp:TextBox ID="TxtFechaInicio" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Nivel de Satisfacción</div>
                                    <asp:DropDownList ID="Drl_Satisfaccion" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Usuario Gestiono</div>
                                    <asp:DropDownList ID="Drl_UsuarioAsignado" TabIndex="7" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:LinkButton ID="Btn_Filtrar" TabIndex="9" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Filtrar
                                </asp:LinkButton>
                                <asp:LinkButton ID="Btn_Exportar" TabIndex="10" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-save"></span> Exportar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Prioridad</div>
                                    <asp:DropDownList ID="Drl_PrioridadGestion" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Cierre</div>
                                    <asp:TextBox ID="TxtFechaFin" TabIndex="4" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Calificación</div>
                                    <asp:DropDownList ID="Drl_Calificaciones" TabIndex="6" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="Drl_Estado" TabIndex="8" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </section>
                    </section>
                              <div class="Leyendas">
                                     <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                              </div>
                     <div class="bordes" style="overflow:auto; min-height:0px;max-height:400px; width:100%;">                             
                        <asp:GridView ID="Gtg_ConsultaTickets" runat="server" AllowPaging="false" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
						 <Columns>
                                <asp:ButtonField   CommandName="Gestionar" ControlStyle-Font-Size="10px" ControlStyle-Width="67px" ControlStyle-CssClass="btn btn-primary glyphicon-barcode" Text="Detalle" ButtonType="Button" />
                            </Columns>
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                    </div>
                    <div class="Leyendas">
                        <asp:Label runat="server" ID="Lbl_MensajeGes"></asp:Label>
                    </div>
            <div class="bordes">
                <asp:GridView ID="Gtg_ConsultaTicketsGestiones" runat="server" AllowPaging="false" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
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
                    <asp:PostBackTrigger runat="server" ControlID="btn_exportar" />
                </Triggers>
                <Triggers>
                    <asp:PostBackTrigger runat="server" ControlID="Gtg_ConsultaTicketsGestiones" />
                </Triggers>
                <Triggers>
                    <asp:PostBackTrigger runat="server" ControlID="Gtg_ConsultaTickets" />
                </Triggers>
            </asp:UpdatePanel>
       
        <footer></footer>
    </form>
</body>
</html>
<%--	© 2016 Ricardo Lara C1842--%>

<%--hasta aqui ok, falta exportar a excel el segundo dato y crear los botones q van a separar en la aspxawawwawaawwa