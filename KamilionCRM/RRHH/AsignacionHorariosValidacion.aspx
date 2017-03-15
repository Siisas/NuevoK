<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AsignacionHorariosValidacion.aspx.vb" Inherits="digitacion.AsignacionHorariosValidacion" %>


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
                        <div class="text-center Subtitulos">Filtros de Consulta</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Código</div>
                                    <asp:TextBox ID="TxtCod_Agente" TabIndex="1" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="TxtFechaInicio" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="TxtFechaFin" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha fin incorrecta, verifique!!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Final</div>
                                    <asp:TextBox ID="TxtFechaInicio" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    <div class="input-group-addon">-</div>
                                    <asp:TextBox ID="TxtFechaFin" TabIndex="4" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                                <h4></h4>
                                <div class="text-center Sub-Subtitulo">Tipo de Consulta</div>
                                <h4></h4>
                                <asp:RadioButtonList ID="RadBtnTipoConsulta"  TabIndex="5" RepeatDirection="Vertical" runat="server">
                                    <asp:ListItem>Géneral</asp:ListItem>
                                    <asp:ListItem>Descanso</asp:ListItem>
                                    <asp:ListItem>Validación</asp:ListItem>
                                    <asp:ListItem>No Programadas</asp:ListItem>
                                    <asp:ListItem>Inf. Novedad</asp:ListItem>
                                    <asp:ListItem>Ingreso</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Jefe Inmediato</div>
                                    <asp:DropDownList ID="drlPersonalACargo" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <h4></h4>
                        <asp:LinkButton ID="BtnConsultar" TabIndex="6" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-folder-open"></span> Consultar
                        </asp:LinkButton>
                        <asp:LinkButton ID="BtnExporExc" TabIndex="7" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-save"></span> Exportar
                        </asp:LinkButton>

                    </section>
                    <asp:Panel runat="server" ID="Pnl_ConsTk">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="LblCuenta"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="dtgGeneral" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="cod_agente" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="fcingreso" HeaderText="Ingreso Centinela" />
                                    <asp:BoundField DataField="Fc_Ingreso" HeaderText="Ingreso Programado" />
                                    <asp:BoundField DataField="fcsalida" HeaderText="Salida Centinela" />
                                    <asp:BoundField DataField="Fc_Salida" HeaderText="Salida Programada"></asp:BoundField>
                                    <asp:BoundField DataField="jefe_inmediato" HeaderText="Jefe Inmediato" />
                                    <asp:BoundField DataField="Tipo_Horario" HeaderText="Tipo Horario" />
                                    <asp:BoundField DataField="Segmento" HeaderText="Operacion" />
                                    <asp:ButtonField CommandName="Seleccion" HeaderText="Alerta" Text="Selección" AccessibleHeaderText="Seleccione" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--segundo grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtgGeneralExcel" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="cod_agente" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="fcingreso" HeaderText="Ingreso Centinela" />
                                    <asp:BoundField DataField="Fc_Ingreso" HeaderText="Ingreso Programado" />
                                    <asp:BoundField DataField="fcsalida" HeaderText="Salida Centinela" />
                                    <asp:BoundField DataField="Fc_Salida" HeaderText="Salida Programada"></asp:BoundField>
                                    <asp:BoundField DataField="jefe_inmediato" HeaderText="Jefe Inmediato" />
                                    <asp:BoundField DataField="Tipo_Horario" HeaderText="Tipo Horario" />
                                    <asp:BoundField DataField="Segmento" HeaderText="Operacion" />
                                    <asp:ButtonField CommandName="Seleccion" HeaderText="Alerta" Text="Selección" AccessibleHeaderText="Seleccione" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--tercer grid--%>
                        <div class="bordes">
                            <asp:GridView ID="Dtgbusquedaseleccion" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="idreg" HeaderText="ID" />
                                    <asp:BoundField DataField="cod" HeaderText="Código" />
                                    <asp:BoundField DataField="documento" HeaderText="Identificación" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="fcnovedad" HeaderText="Fecha Novedad" />
                                    <asp:BoundField DataField="descripcioninasistencia" HeaderText="Tipo Novedad" />
                                    <asp:BoundField DataField="dias" HeaderText="Dias Nov" />
                                    <asp:BoundField DataField="horas" HeaderText="Horas Nov" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="repone" HeaderText="Repone" />
                                    <asp:BoundField DataField="reportanom" HeaderText="Reporta Nom" />
                                    <asp:BoundField DataField="desctipo" HeaderText="Tipificación" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                                    <asp:BoundField DataField="fcregistro" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="idusuarioreg" HeaderText="Usuario Reg" />
                                    <asp:BoundField DataField="mesreporte" HeaderText="Mes Reporte" />
                                    <asp:BoundField DataField="Aprobacion" HeaderText="Estado Revision" />
                                    <asp:ButtonField CommandName="Aprobado" HeaderText="" Text="Aprobado" AccessibleHeaderText="Aprobado" />
                                    <asp:ButtonField CommandName="Anulado" HeaderText="" Text="Anulado" AccessibleHeaderText="Anulado" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--cuarto grid--%>
                        <div class="bordes">
                            <asp:GridView ID="Dtgbusquedaseleccion1" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="idreg" HeaderText="ID" />
                                    <asp:BoundField DataField="cod" HeaderText="Código" />
                                    <asp:BoundField DataField="documento" HeaderText="Identificación" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="fcnovedad" HeaderText="Fecha Novedad" />
                                    <asp:BoundField DataField="descripcioninasistencia" HeaderText="Tipo Novedad" />
                                    <asp:BoundField DataField="dias" HeaderText="Dias Nov" />
                                    <asp:BoundField DataField="horas" HeaderText="Horas Nov" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="repone" HeaderText="Repone" />
                                    <asp:BoundField DataField="reportanom" HeaderText="Reporta Nom" />
                                    <asp:BoundField DataField="desctipo" HeaderText="Tipificación" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                                    <asp:BoundField DataField="fcregistro" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="idusuarioreg" HeaderText="Usuario Reg" />
                                    <asp:BoundField DataField="mesreporte" HeaderText="Mes Reporte" />
                                    <asp:BoundField DataField="Aprobación" HeaderText="Estado Revision" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--quinto grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtgValidacion" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Cod_Agente" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="Fc_Ingreso" HeaderText="Ingreso Programado" />
                                    <asp:BoundField DataField="Fc_Salida" HeaderText="Salida Programada"></asp:BoundField>
                                    <asp:BoundField DataField="Jefe_Inmediato" HeaderText="Jefe Inmediato" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--sexto grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtgValidacionExcel" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Cod_Agente" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="Fc_Ingreso" HeaderText="Ingreso Programado" />
                                    <asp:BoundField DataField="Fc_Salida" HeaderText="Salida Programada"></asp:BoundField>
                                    <asp:BoundField DataField="Jefe_Inmediato" HeaderText="Jefe Inmediato" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--septimo grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtgnoprogramados" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="codigo" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Jefe" HeaderText="Jefe Inmediato" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--octavo grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtgnoprogramadosExcel" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="codigo" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Jefe" HeaderText="Jefe Inmediato" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--noveno grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtginformacionovedad" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="codigo" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="area" HeaderText="Área" />
                                    <asp:BoundField DataField="jefe_inmediato" HeaderText="Jefe Inmediato" />
                                    <asp:BoundField DataField="Laboro" HeaderText="Laboró" />
                                    <asp:BoundField DataField="descripcioninasistencia" HeaderText="Novedad" />
                                    <asp:BoundField DataField="Fcnovedad" HeaderText="Fecha Novedad" />

                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--decimo grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtginformacionovedadexcel" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="codigo" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="area" HeaderText="Área" />
                                    <asp:BoundField DataField="jefe_inmediato" HeaderText="Jefe Inmediato" />
                                    <asp:BoundField DataField="Laboro" HeaderText="Laboró" />
                                    <asp:BoundField DataField="descripcioninasistencia" HeaderText="Novedad" />
                                    <asp:BoundField DataField="Fcnovedad" HeaderText="Fecha Novedad" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--onceavo grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtgdescanso" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Cod_Agente" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="Fc_Ingreso" HeaderText="Ingreso Programado" />
                                    <asp:BoundField DataField="Fc_Salida" HeaderText="Salida Programada"></asp:BoundField>
                                    <asp:BoundField DataField="jefe_inmediato" HeaderText="Jefe Inmediato" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Descanso" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <%--decimosegundo grid--%>
                        <div class="bordes">
                            <asp:GridView ID="dtgdescansoexcel" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Cod_Agente" HeaderText="Agente" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="Fc_Ingreso" HeaderText="Ingreso Programado" />
                                    <asp:BoundField DataField="Fc_Salida" HeaderText="Salida Programada"></asp:BoundField>
                                    <asp:BoundField DataField="jefe_inmediato" HeaderText="Jefe Inmediato" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Descanso" />
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
                </article>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger  ControlID="BtnExporExc" />
                <asp:PostBackTrigger  ControlID="dtgGeneralExcel" />
                <asp:PostBackTrigger  ControlID="dtgValidacionExcel" />
                <asp:PostBackTrigger  ControlID="dtgnoprogramadosExcel" />
                <asp:PostBackTrigger  ControlID="dtginformacionovedadexcel" />
                 <asp:PostBackTrigger  ControlID="dtgdescansoexcel" />                
            </Triggers>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>

