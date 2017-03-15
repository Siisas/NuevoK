<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Cambio_Horarios_Aprobacion.aspx.vb" Inherits="digitacion.Cambio_Horarios_Aprobacion" %>
<%@ Register src="~/Controles/Header.ascx" tagname="Header" tagprefix="Control" %>

<!DOCTYPE html>
<%--	© 2016 Crisitan Duarte C1477	--%>
<html>
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Aprobación | Kamilion ERP</title>
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
                    <asp:Panel ID="Pnl_Registro" Visible="False" runat="server">
                        <section>
                        <div class="text-center Subtitulos">Aprobación de Cambios de Horario</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Codigo Ingeniero</div>
                                    <asp:Label ID="Lbl_Codigo_Ingeniero" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Codigo Horario</div>
                                    <asp:Label ID="Lbl_Codigo_Horario" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="text-center Subtitulos">Antiguo</div>                                
                                <div class="input-group">
                                    <div class="input-group-addon">Tipo de Horario</div>
                                    <asp:Label ID="Lbl_Tipo_Horario_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <asp:Label ID="Lbl_Cod_Tipo_Horario_Ant" Visible="false" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Segmento</div>
                                    <asp:Label ID="Lbl_Segmento_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Jefe Inmediato</div>
                                    <asp:Label ID="Lbl_Jefe_Inmediato_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Almuerzo</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_A_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_A_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Break 1</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_B1_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_B1_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Break 2</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_B2_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_B2_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Capacitacion</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_C_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_C_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Pre-Turno</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_P_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_P_Ant" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <br />
                                <asp:Button ID="Btn_Aprobar" Text="Aprobar" CssClass="btn btn-primary" runat="server" />
                                <asp:Button ID="Btn_Rechazar" Text="Rechazar" CssClass="btn btn-primary" runat="server" />
                                <asp:Button ID="Btn_Cancelar" Text="Cancelar" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Turno</div>
                                    <asp:Label ID="Lbl_Fecha_Turno" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Codigo Solicitud</div>
                                    <asp:Label ID="Lbl_Codigo_Solicitud" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="text-center Subtitulos">Nuevo</div>
                                <div class="input-group">
                                    <div class="input-group-addon">Tipo de Horario</div>
                                    <asp:Label ID="Lbl_Tipo_Horario_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <asp:Label ID="Lbl_Cod_Tipo_Horario_New" Visible="false" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Segmento</div>
                                    <asp:Label ID="Lbl_Segmento_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Jefe Inmediato</div>
                                    <asp:Label ID="Lbl_Jefe_Inmediato_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Almuerzo</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_A_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_A_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Break 1</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_B1_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_B1_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Break 2</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_B2_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_B2_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Capacitacion</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_C_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_C_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Pre-Turno</div>
                                <h4></h4>
                                <div class="input-group">
                                    <div class="input-group-addon">Hora Ingreso</div>
                                    <asp:Label ID="Lbl_Hora_Ingreso_P_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                    <div class="input-group-addon">Hora Salida</div>
                                    <asp:Label ID="Lbl_Hora_Salida_P_New" CssClass="form-control" Style="background-color: inherit; overflow: auto; height: auto; min-height: 35px; max-height: 100px" runat="server" />
                                </div>
                            </div>
                        </div>
                    </section>
                    </asp:Panel><br />
                        <asp:Panel ID="Pnl_Dtg_Solicitudes" runat="server">
                        <div class="Leyendas ">
                            <asp:Label ID="LblCuenta" runat="server"></asp:Label>
                        </div>
                        <div class="bordes" style="overflow: auto; min-height:0px; max-height:700px; width:100%;">
                            <asp:GridView ID="Dtg_Solicitudes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True" PageSize="20">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Codigo Solicitud" HeaderText="Codigo Solicitud" />
                                    <asp:BoundField DataField="Codigo Horario" HeaderText="Codigo Horario" />
                                    <asp:BoundField DataField="Codigo Agente" HeaderText="Codigo Agente" />
                                    <asp:BoundField DataField="Fecha Registro" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="Usuario Registra" HeaderText="Usuario Registra" />
                                    <asp:BoundField DataField="Fecha Ingreso" HeaderText="Fecha Ingreso" />
                                    <asp:BoundField DataField="Fecha Salida" HeaderText="Fecha Salida" />
                                    <asp:BoundField DataField="Segmento" HeaderText="Segmento" />
                                    <asp:BoundField DataField="Jefe Inmediato" HeaderText="Jefe Inmediato" />
                                    <asp:BoundField DataField="Tipo Horario" HeaderText="Tipo Horario" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-primary  glyphicon glyphicon-eye-open" ControlStyle-Height="25px" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" ControlStyle-Font-Strikeout="false" ControlStyle-ForeColor="White" CommandName="Seleccione" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </article>
            <footer></footer>
        </form>
    </body>
</html>
<%--	© 2016 Crisitan Duarte C1477	--%>