<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HelpDeskAsignacion.aspx.vb" Inherits="digitacion.HelpDeskAsignacion" %>

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
                        <div class="text-center Subtitulos">Consulta Casos</div>
                        <div class="Form">
                            <div class="Cell-Form">

                                <div class="input-group">
                                       <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Consulta" ControlToValidate="TxtCod_Ticket_Consulta" Display="Dynamic" SetFocusOnError="True" ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$">Solo números</asp:RegularExpressionValidator>
                                    <div class="input-group-addon">
                                        Código Ticket   
                                    </div>
                                    <asp:TextBox ID="TxtCod_Ticket_Consulta" TabIndex="1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="drlEstados" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="TxtFecha_Inicio" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="TxtFecha_Fin" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha fin incorrecta, verifique!!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Rango de Fecha </div>
                                    <asp:TextBox ID="TxtFecha_Inicio" TabIndex="5" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    <div class="input-group-addon">-</div>
                                    <asp:TextBox ID="TxtFecha_Fin" TabIndex="6" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                                <h4></h4>
                                <h4></h4>
                                <h4></h4>
                                <asp:LinkButton ID="BtnConsulta" TabIndex="7" ValidationGroup="Consulta" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-search"></span> Consulta
                                </asp:LinkButton>
                                <asp:LinkButton ID="BtnActualizar" TabIndex="8" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-refresh"></span> Actualizar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Código Usuario
                                    </div>
                                    <asp:TextBox ID="txt_cod_usu" TabIndex="2" CssClass="form-control" runat="server" MaxLength="5"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Prioridad</div>
                                    <asp:DropDownList ID="drlPrioridad" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">- Seleccione -</asp:ListItem>
                                        <asp:ListItem>Bajo</asp:ListItem>
                                        <asp:ListItem>Medio</asp:ListItem>
                                        <asp:ListItem>Alto</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section>
                        <div class="text-center Subtitulos">Asignación Casos</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Asignar a: </div>
                                    <asp:DropDownList ID="drlTecnico" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <h4></h4>
                                <h4></h4>
                                <div class="input-group">
                                    <asp:CheckBox ID="CheckBoxTipificacion" TabIndex="34" runat="server" CssClass="input-group-addon" />
                                    <div class="input-group-addon">Cambio Tipificación Categoría</div>
                                    <asp:DropDownList ID="drlCategoria" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <h4></h4>
                                <h4></h4>
                                <div class="input-group">
                                    <asp:CheckBox ID="CheckBoxPrioridad" TabIndex="34" runat="server" CssClass="input-group-addon" />
                                    <div class="input-group-addon">Cambia Prioridad</div>
                                    <asp:DropDownList ID="drlPrioridadUpdate" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">- Seleccione -</asp:ListItem>
                                        <asp:ListItem>Bajo</asp:ListItem>
                                        <asp:ListItem>Medio</asp:ListItem>
                                        <asp:ListItem>Alto</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <h4></h4>
                                <h4></h4>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Comentario</div>
                                    <asp:TextBox ID="TxtObservacionAsigna" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Tipo</div>
                                    <asp:DropDownList ID="drlTipo" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <asp:CheckBox ID="CheckBoxArea" TabIndex="34" runat="server" CssClass="input-group-addon" />
                                    <div class="input-group-addon">Área</div>
                                    <asp:DropDownList ID="drlAreaUpdate" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section>
                        <div class="text-center Subtitulos"></div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Código HelpDesk</div>
                                    <asp:Label ID="LblCod_HeplDeks" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Usuario Reporta</div>
                                    <asp:Label ID="LblUsuarioReporta" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Tema</div>
                                    <asp:Label ID="LblTema" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                    <asp:TextBox ID="LblTema1" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" Visible="False"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Realiza Registro</div>
                                    <asp:Label ID="LblUsuarioReg" ReadOnly="true" CssClass="form-control" runat="server" />
                                </div>
                                <h4></h4>
                                <h4></h4>

                                <asp:LinkButton ID="BtnAsignarCaso" Visible="false" TabIndex="8" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-random"></span> Asignar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Registro</div>
                                    <asp:Label ID="LblFecha_Registro" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>

                                <div class="input-group">
                                    <div class="input-group-addon">Prioridad</div>
                                    <asp:Label ID="LblPrioridad" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Observación</div>
                                    <asp:TextBox ID="LblObservacion" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="LblObservacion1" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false" Visible="False"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:Label ID="LblEstado" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <h4></h4>
                        <h4></h4>
                    </section>
                    <h4></h4>
                    <h4></h4>

                    <asp:Panel runat="server" ID="Pnl_ConsTk">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="lblcuentaHelpDesk"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="dtggeneralHelpDesk" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Cod_HelpDesk_Registro" HeaderText="Codigo" />
                                    <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="codnom" HeaderText="Cod" />
                                    <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                                    <asp:BoundField DataField="Tema" HeaderText="Tema" />
                                    <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Canal" HeaderText="Canal" />
                                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Persona_Reporta" HeaderText="Reporta" />
                                    <asp:BoundField DataField="Modulo" HeaderText="Modulo" />
                                    <asp:BoundField DataField="Area" HeaderText="Area" />
                                    <asp:BoundField DataField="Asignado" HeaderText="Asignado" />
                                    <asp:BoundField DataField="Asigna" HeaderText="Asigna" />
                                    <asp:BoundField DataField="Fecha_Asigna" HeaderText="Fecha Asigna" />
                                    <asp:ButtonField CommandName="Seleccion" HeaderText="Seleccion un Caso"
                                        Text="Seleccion" />
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
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>




