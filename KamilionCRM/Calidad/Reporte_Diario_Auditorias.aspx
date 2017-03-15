<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporte_Diario_Auditorias.aspx.vb" Inherits="digitacion.Reporte_Diario_Auditorias" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>

<!DOCTYPE html>
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
        <div id="Solicitudes" class="Desplegable">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <section>
                        <div class="Form-Mini-Desp" style="width: 70%">
                            <div class="text-center Subtitulos">SOLICITAR SEGUNDO CONCEPTO</div>
                            <asp:Panel runat="server" ID="Pnl_mensaje" Width="100%">
                                <asp:Label runat="server" ID="lbl_mensaje"></asp:Label>
                            </asp:Panel>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <%--ID Auditoria--%>
                                    <div class="input-group">
                                        <div class="input-group-addon">Id Auditoria</div>
                                        <asp:Label runat="server" ID="lbl_id_auditoria" CssClass="form-control" Style="background-color: rgba(238, 238, 238, 10); overflow: auto; height: auto; min-height: 35px; max-height: 100px"></asp:Label>
                                    </div>
                                    <%--Razon--%>
                                    <div class="input-group">
                                        <div class="input-group-addon">Razon</div>
                                        <asp:DropDownList ID="drl_razon" runat="server" AutoPostBack="True" CssClass="form-control">
                                            <asp:ListItem>- Seleccione -</asp:ListItem>
                                            <asp:ListItem>No corresponde afectacion de acuerdo a la descripcion de la variable.</asp:ListItem>
                                            <asp:ListItem>No aplica afectacion conforme a procedimientos establecidos.</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <%--ID Auditoria--%>
                                    <div class="input-group">
                                        <div class="input-group-addon">Proceso</div>
                                        <asp:Label runat="server" ID="lbl_proceso" CssClass="form-control" Style="background-color: rgba(238, 238, 238, 10); overflow: auto; height: auto; min-height: 35px; max-height: 100px"></asp:Label>
                                    </div>
                                    <%--Lider asistio--%>
                                    <div class="input-group">
                                        <div class="input-group-addon">Líder asistió a la retroalimentación</div>
                                        <asp:DropDownList ID="drl_asistio" runat="server" AutoPostBack="True" CssClass="form-control">
                                            <asp:ListItem>- Seleccione -</asp:ListItem>
                                            <asp:ListItem>SI</asp:ListItem>
                                            <asp:ListItem>NO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                            <div class="Form">
                                <%--Observacion--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Observacion</div>
                                    <asp:TextBox runat="server" ID="txt_obs" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Button ID="btn_solicitar" runat="server" Text="Solicitar" CssClass=" btn btn-primary" />
                            <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass=" btn btn-primary" />
                        </div>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <Control:Header ID="Header" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="Pnl_Message" runat="server">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <article>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <section>
                        <div class="text-center Subtitulos">CONSULTA AUDITORIA</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <%--Id auditoria--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Id Auditoria</div>
                                    <asp:TextBox ID="txt_auditoria" runat="server" MaxLength="6" CssClass="form-control" />
                                </div>
                                <%--SUpervisor--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Supervisor</div>
                                    <asp:DropDownList ID="Drl_Supervisor" runat="server" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                                </div>  
                                <%--Campaña--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Proceso</div>
                                    <asp:DropDownList ID="drl_campaña" runat="server" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                                </div>                      
                                <asp:Button ID="btn_buscar" runat="server" Text="Buscar" CssClass=" btn btn-primary" />
                                <asp:Button ID="btn_segundo_concepto" runat="server" Text="Mis segundos conceptos" CssClass=" btn btn-primary" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <%--COdigo agente--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Codigo Agente</div>
                                    <asp:TextBox ID="txt_cod_agente" runat="server" MaxLength="5" CssClass="form-control" />
                                </div>                        
                                <%--Fechas--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Fechas</div>
                                    <asp:TextBox ID="Txt_Fc_Ini" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                    <div class="input-group-addon">-</div>
                                    <asp:TextBox ID="Txt_Fc_Fin" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                </div>
                            </div>
                        </div>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
            <section class="DataGrids">
            </section>
            
            <br />
        </article>
        <article style="width:90% !important">
            <asp:Panel ID="PanelGestiones" runat="server">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <h4 style="color: #8F9E45;"><em>
                            <asp:Label ID="Lbl_seguimiento" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:Button ID="btn_exportar" runat="server" Text="Exportar" CssClass=" btn btn-primary" Visible="false" />
                        </em></h4>
                        <div class="bordes">
                            <asp:GridView ID="dtggeneral" runat="server" AllowPaging="True"
                                CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="100" Width="100%"
                                Style="font-size: x-small" EnableModelValidation="True">
                                <Columns>
                                    <asp:ButtonField ItemStyle-Width="6%" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Solicitar" HeaderText="Segundo Concepto" Text="Solicitar" />
                                </Columns>
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="dtgconceptos" runat="server" AllowPaging="True"
                                CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="100" Width="100%"
                                Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btn_exportar" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
        </article>
        <footer></footer>
    </form>
</body>
</html>

