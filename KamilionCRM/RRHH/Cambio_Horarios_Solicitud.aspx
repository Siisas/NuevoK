<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Cambio_Horarios_Solicitud.aspx.vb" Inherits="digitacion.Cambio_Horarios_Solicitud" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Solicitud | Kamilion ERP</title>
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
                    <asp:Panel ID="Pnl_Consulta" runat="server">
                        <section>
                            <div class="text-center Subtitulos">
                                Consulta de Horario Agentes
                            </div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Codigo</div>
                                        <asp:TextBox ID="TxtCod_Agente" runat="server" CssClass="form-control" MaxLength="5" TabIndex="1"></asp:TextBox>
                                    </div><h4></h4>
                                    <asp:Button ID="Btn_Buscar" Text="Buscar" CssClass="btn btn-primary" runat="server" />
                                    <br />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Registro<asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="TxtFecha_Turno" ErrorMessage="Revise hora" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator></div>
                                        <asp:TextBox ID="TxtFecha_Turno" runat="server" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" TabIndex="2"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <section>
                        <asp:Panel ID="Pnl_Registro" Visible="false" runat="server">
                            <%--*** TURNO ***--%>
                            <asp:Panel ID="Pnl_Turno" runat="server">
                                <div class="text-center Subtitulos">Cambios de Horario</div>
                                <div class="Form">
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Codigo Ingeniero</div>
                                            <asp:Label ID="LblCod_Agente" Style="background-color: inherit" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Fecha Turno</div>
                                            <asp:Label ID="LblFec_Turno" Style="background-color: inherit" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Ingreso</div>
                                            <asp:DropDownList ID="DrlHora_Ingreso" CssClass="form-control" TabIndex="10" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Segmento</div>
                                               <asp:DropDownList ID="DrlSegmento" CssClass="form-control" TabIndex="10" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="Space-Form"></div>
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Codigo Horario</div>
                                            <asp:Label ID="LblCod_Horario" Style="background-color: inherit" CssClass="form-control" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Tipo de Horario</div>
                                            <asp:DropDownList ID="drlTipoHorario" CssClass="form-control"  runat="server" AutoPostBack="True" TabIndex="5"/>
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Salida</div>
                                            <asp:DropDownList ID="DrlHora_Salida" CssClass="form-control" TabIndex="10" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Jefe Inmediato</div>
                                            <asp:DropDownList ID="DrlJefeInmediato" CssClass="form-control" TabIndex="10" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </asp:Panel>
                            <%--*** ALMUERZO ***--%>
                            <asp:Panel ID="PnlAlmuerzo" Enabled="false"  runat="server">
                                <div class="text-center Sub-Subtitulo">Almuerzo</div><h4></h4>
                                <div class="Form">
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Ingreso</div>
                                            <asp:DropDownList ID="DrlHora_Almuerzo_1" CssClass="form-control" TabIndex="10" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="Space-Form"></div>
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Salida</div>
                                            <asp:DropDownList ID="DrlHora_Almuerzo_2" CssClass="form-control" Enabled="false" TabIndex="10" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </asp:Panel>
                            <%--*** BREAKS ***--%>
                            <asp:Panel ID="PnlBreaks"  runat="server">
                                <div class="text-center Sub-Subtitulo">Break</div><h4></h4>
                                <div class="Form">
                                    <div class="Cell-Form">
                                        <div class="text-center Sub-Subtitulo">Break 1</div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Ingreso</div>
                                            <asp:DropDownList ID="Drl_Hora_Break1_1" CssClass="form-control" TabIndex="10" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            <div class="input-group-addon">Hora Salida</div>
                                            <asp:DropDownList ID="Drl_Hora_Break1_2" CssClass="form-control" Enabled="false" TabIndex="11" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="Space-Form"></div>
                                    <div class="Cell-Form">
                                        <div class="text-center Sub-Subtitulo">Break 2</div>
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Ingreso</div>
                                            <asp:DropDownList ID="Drl_Hora_Break2_1" CssClass="form-control" TabIndex="12" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            <div class="input-group-addon">Hora Salida</div>
                                            <asp:DropDownList ID="Drl_Hora_Break2_2" CssClass="form-control" Enabled="false" TabIndex="13" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </asp:Panel>
                            <%--*** CAPACITACION ***--%>
                            <asp:Panel ID="PnlCapacitacion"  runat="server">
                                <div class="text-center Sub-Subtitulo">Capacitacion</div><h4></h4>
                                <div class="Form">
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Ingreso</div>
                                            <asp:TextBox ID="Txt_Hora_Capacitacion_1" runat="server" TabIndex="14" CssClass="form-control Hora" MaxLength="5" placeholder="HH:mm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="Space-Form"></div>
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Salida</div>
                                            <asp:TextBox ID="Txt_Hora_Capacitacion_2" runat="server" CssClass="form-control Hora"  TabIndex="15" MaxLength="5" placeholder="HH:mm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </asp:Panel>
                            <%--*** PRE-TURNO ***--%>
                            <asp:Panel ID="PnlPreTurno"  runat="server"><div class="text-center Sub-Subtitulo">Pre - Turno</div><h4></h4>
                                <div class="Form">
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Ingreso</div>
                                            <asp:TextBox ID="Txt_Pre_Turno_1" runat="server" Enabled="false" TabIndex="16" CssClass="form-control Hora" MaxLength="5" placeholder="HH:mm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="Space-Form"></div>
                                    <div class="Cell-Form">
                                        <div class="input-group">
                                            <div class="input-group-addon">Hora Salida</div>
                                            <asp:TextBox ID="Txt_Pre_Turno_2" runat="server" Enabled="false" TabIndex="17" CssClass="form-control Hora" MaxLength="5" placeholder="HH:mm"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </asp:Panel>
                            <div class="Form">
                                <asp:Button ID="Btn_Solicitar" Text="Solicitar" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </asp:Panel>
                    </section><br />
                    <asp:Panel ID="Pnl_Dtg_Solicitudes" runat="server">
                        <div class="Leyendas ">
                            <asp:Label ID="LblCuenta" runat="server"></asp:Label>
                        </div>
                        <div class="bordes" style="overflow: auto; min-height:0px; max-height:700px; width:100%;">
                            <asp:GridView ID="Dtg_Solicitudes" runat="server" AllowPaging="True" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333"
                                GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True" PageSize="20">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
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
                <footer></footer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
