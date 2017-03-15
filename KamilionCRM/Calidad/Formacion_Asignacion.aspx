<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Formacion_Asignacion.aspx.vb" Inherits="digitacion.Formacion_Asignacion" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>
<!DOCTYPE html>
<%--	Ricar	--%>
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
                        <div class="text-center Subtitulos">Filtros de Consulta</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="txtcaso" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">Solo Numeros</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Número Solicitud
                                    </div>
                                    <asp:TextBox ID="txtcaso" TabIndex="1" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                </div>
                                <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_fc_inicio" SetFocusOnError="True" Type="Date" MaximumValue="01/01/2020" MinimumValue="01/01/2000">Por favor verifique el rango de fechas!</asp:RangeValidator>
                                <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_fc_fin" SetFocusOnError="True" Type="Date" MaximumValue="01/01/2020" MinimumValue="01/01/2000">Por favor verifique el rango de fechas!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Registro</div>
                                    <asp:TextBox ID="Txt_fc_inicio" TabIndex="6" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" runat="server" />
                                    <div class="input-group-addon">-</div>
                                    <asp:TextBox ID="Txt_fc_fin" TabIndex="7" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Mis Casos
                                    </div>
                                    <asp:CheckBox ID="CheckBox_casos" CssClass="form-control" runat="server" />
                                </div>
                                <div class="Cell-Form">
                                    <asp:LinkButton ID="Btn_Buscar" TabIndex="2" ValidationGroup="Requerimientos1" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-search"></span> Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="Btn_buscar_todos" TabIndex="2" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-search"></span> Buscar Todos
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Prioridad</div>
                                    <asp:DropDownList ID="Drl_Prioridad" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="Drl_Estado" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                    </section>
                    <section>
                        <div class="text-center Subtitulos">Asignar Formación</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="txtcaso" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">Solo Numeros</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Número Solicitud
                                    </div>
                                    <asp:TextBox ID="Txt_id_cargue" ReadOnly="true" TabIndex="1" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                </div>
                                <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_fc_inicio" SetFocusOnError="True" Type="Date" MaximumValue="01/01/2020" MinimumValue="01/01/2000">Por favor verifique el rango de fechas!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Para Ejecución</div>
                                    <asp:TextBox ID="txtfcingn3" TabIndex="6" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY HH:mm" runat="server" />
                                </div>

                                <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="Txt_npersonas" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">Solo Numeros</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        N Personas a Capacitar
                                    </div>
                                    <asp:TextBox ID="Txt_npersonas" TabIndex="1" CssClass="form-control" runat="server" MaxLength="3"></asp:TextBox>
                                </div>
                                <div class="Cell-Form">
                                    <asp:LinkButton ID="Btn_guardar_N_Personas" Visible="false" TabIndex="2" ValidationGroup="Requerimientos1" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-sort"></span> Cambiar
                                    </asp:LinkButton>
                                </div>


                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Estado
                                    </div>
                                    <asp:TextBox ID="Txt_estado" ReadOnly="true" TabIndex="1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="input-group">
                                    <div class="input-group-addon">Lugar</div>
                                    <asp:DropDownList ID="Drl_Lugar" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Observación
                                    </div>
                                    <asp:TextBox ID="Txt_Observacion" TextMode="MultiLine" TabIndex="1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                    </section>
                    <section>
                        <div class="text-center Subtitulos"></div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="txtcaso" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">Solo Numeros</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Grupo
                                    </div>
                                    <asp:TextBox ID="txt_grupo" TabIndex="1" CssClass="form-control" runat="server" MaxLength="3"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        N Personas
                                    </div>
                                    <asp:TextBox ID="Txt_Personas_asignar" TabIndex="1" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:Label runat="server" ID="Lbl_N_Personas" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Formador</div>
                                    <asp:DropDownList ID="Drl_Auditor_Asignar" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="Cell-Form">
                                    <asp:LinkButton ID="Btn_Agregar" TabIndex="2" Visible="false" ValidationGroup="Requerimientos1" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-plus-sign"></span> Agregar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btn_crear" TabIndex="2" ValidationGroup="Requerimientos1" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-ok-circle"></span> Asignar
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Grupo
                                        </div>
                                        <asp:TextBox ID="txt_modulo" TabIndex="1" CssClass="form-control" runat="server" MaxLength="3"></asp:TextBox>
                                    </div>
                                    <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_fc_inicio" SetFocusOnError="True" Type="Date" MaximumValue="01/01/2020" MinimumValue="01/01/2000">Por favor verifique el rango de fechas!</asp:RangeValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Modulo</div>
                                        <asp:TextBox ID="Txt_Fecha_modulo" TabIndex="6" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY HH:mm" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="Pnl_ConsTk">
                                <div class="Leyendas">
                                    <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                                </div>
                                <div class="bordes">
                                    <asp:GridView ID="Dtg_Asignar" PageSize="20" runat="server" AllowPaging="false" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                        <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                        <Columns>
                                            <asp:BoundField DataField="ID_Formacion" HeaderText="ID Formacion" />
                                            <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                                            <asp:BoundField DataField="Modulo" HeaderText="Modulo" />
                                            <asp:BoundField DataField="N_Personas" HeaderText="N Personas" />
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha Capacitacion" />
                                            <asp:BoundField DataField="Formador" HeaderText="Formador" />
                                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" ControlStyle-Height="25px" ControlStyle-Font-Size="10px" CommandName="Delete" Text="Quitar" />
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
                    </section>

                    <div class="Leyendas">
                        <asp:Label runat="server" ID="lblcuenta1"></asp:Label>
                        <div class="bordes" style="overflow: auto; min-height: 0px; width: 100%;">
                            <asp:GridView ID="dtggeneral" runat="server" AllowPaging="false" PageSize="80" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="150%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Id_Solicitud_Formacion" HeaderText="ID" />
                                    <asp:BoundField DataField="Fc_Reg" HeaderText="Fecha Registro Caso" />
                                    <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="Tipo_Formacion" HeaderText="Tipo Formacion" />
                                    <asp:BoundField DataField="Fc_Ejecucion" HeaderText="Fecha Ejecucion" />
                                    <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                                    <asp:BoundField DataField="Tema" HeaderText="Tema" />
                                    <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                    <asp:BoundField DataField="Area_Solicita" HeaderText="Area Solicitante" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
                                    <asp:BoundField DataField="Numero_Personas" HeaderText="N Personas" />
                                   <asp:ButtonField CommandName="Seleccion" HeaderText="Seleccionar" ShowHeader="True" Text="Seleccionar" />
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
                            <asp:Label runat="server" ID="lblcuenta"></asp:Label>
                            <div class="bordes" style="overflow: auto; min-height: 0px; width: 100%;">
                                <asp:GridView ID="dtg_seguim" runat="server" AllowPaging="false" PageSize="80" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="150%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                    <Columns>
                                        <asp:BoundField DataField="id_Asignacion_Formacion" HeaderText="ID" />
                                        <asp:BoundField DataField="Id_Solicitud_Formacion" HeaderText="Caso" />
                                        <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario" />
                                        <asp:BoundField DataField="Fc_Reg" HeaderText="Fecha Registro" />
                                        <asp:BoundField DataField="Formador_Asignado" HeaderText="Formador Asignado" />
                                        <asp:BoundField DataField="Fecha_Ejecucion" HeaderText="Fecha Ejecucion" />
                                        <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
                                        <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                    </Columns>
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                </article>
                <section>
                   <div class="Form">
                      <div class="Cell-Form">
                        <div class="input-group">
                            <div class="input-group-addon">Seleccionar Formador</div>
                            <asp:DropDownList ID="Drl_Formador_Consulta" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="Space-Form"></div>
                    <div class="Cell-Form">
                        <asp:LinkButton ID="Btn_Buscar_Formador" TabIndex="2" ValidationGroup="Requerimientos1" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-sort"></span> Buscar Formador
                        </asp:LinkButton>
                    </div>
                       </div>
                </section>
                <div class="Leyendas">
                    <asp:Label runat="server" ID="lblcuenta3"></asp:Label>
                    <div class="bordes" style="overflow: auto; min-height: 0px; width: 100%;">
                        <asp:GridView ID="Dtg_Formador" runat="server" AllowPaging="false" PageSize="80" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="150%" Style="font-size: x-small" EnableModelValidation="True">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="id_Formaciones" HeaderText="ID" />
                                <asp:BoundField DataField="Id_Formacion" HeaderText="Id_Formacion" />
                                <asp:BoundField DataField="Formador" HeaderText="Formador" />
                                <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                                <asp:BoundField DataField="Modulo" HeaderText="Modulo" />
                                <asp:BoundField DataField="N_Personas" HeaderText="N_Personas" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Tipo_Formacion" HeaderText="Tipo_Formacion" />
                                <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                                <asp:BoundField DataField="Tema" HeaderText="Tema" />
                                <asp:BoundField DataField="Area_Solicita" HeaderText="Area_Solicita" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                </Columns>
                                <footerstyle backcolor="#B3C556" font-bold="True" forecolor="White" />
                                <pagerstyle backcolor="#B3C556" forecolor="White" horizontalalign="Center" />
                                <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                                <headerstyle backcolor="#B3C556" font-bold="False" forecolor="White" font-size="Small" />
                                <editrowstyle backcolor="#999999" />
                                <alternatingrowstyle backcolor="White" forecolor="#333333" />
                        </asp:GridView>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
