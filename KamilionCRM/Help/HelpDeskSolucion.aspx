<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HelpDeskSolucion.aspx.vb"
    Inherits="digitacion.HelpDeskSolucion" %>

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
                                    <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Consulta" ControlToValidate="TxtCod_Help_Desk" Display="Dynamic" SetFocusOnError="True" ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$">Solo números</asp:RegularExpressionValidator>
                                    <div class="input-group-addon">
                                        Código Ticket   
                                    </div>
                                    <asp:TextBox ID="TxtCod_Help_Desk" TabIndex="1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="drlEstadoConsulta" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
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
                                <asp:LinkButton ID="btnConsultaCod_HelpDesk" TabIndex="7" ValidationGroup="Consulta" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-search"></span> Buscar 
                                </asp:LinkButton>
                                <asp:LinkButton ID="BtnTodos" TabIndex="8" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-refresh"></span> Ver Todos
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
                        <div class="text-center Subtitulos">Registro de seguimiento del Help Desk</div>
                        <div class="Form">

                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Código HelpDesk</div>
                                    <asp:Label ID="LblCod_HeplDeks" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Usuario Asigna</div>
                                    <asp:Label ID="LblUsuarioAsigan" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Comentario</div>
                                    <asp:Label ID="LblComentario" ReadOnly="true" CssClass="form-control" runat="server" />
                                    <asp:TextBox ID="LblComentario1" runat="server" TextMode="MultiLine" CssClass="form-control"
                                        Enabled="False" Visible="False"></asp:TextBox>
                                </div>

                                  <div class="input-group">
                                    <div class="input-group-addon">Tema</div>
                                    <asp:Label ID="LblTema" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                    <asp:TextBox ID="LblTema1" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" Visible="False"></asp:TextBox>
                                </div>
                              
                                <div class="input-group">
                                    <div class="input-group-addon">Persona Reporta Falla</div>
                                    <asp:Label ID="LblPersona_Reporta_Falla" ReadOnly="true" CssClass="form-control" runat="server" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:Label ID="LblEstado" ReadOnly="true" CssClass="form-control" runat="server" />
                                </div>
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
                                    <div class="input-group-addon">Fecha Asignado</div>
                                    <asp:Label ID="LblFecha_Asigan" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Prioridad</div>
                                    <asp:Label ID="LblPrioridad" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Observación</div>
                                    <asp:Label ID="LblObservacion" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" runat="server"></asp:Label>
                                    <asp:TextBox ID="LblObservacion1" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false" Visible="False"></asp:TextBox>
                                </div>                               
                              
                                   <div class="input-group">
                                    <div class="input-group-addon">Modulo</div>
                                    <asp:Label ID="LblModulo" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                                   <div class="input-group">
                                    <div class="input-group-addon">Área</div>
                                    <asp:Label ID="LblArea" CssClass="form-control" ReadOnly="true" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section>
                        <div class="text-center Subtitulos"></div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Observación</div>
                                    <asp:TextBox ID="txtObservacion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Complejidad</div>
                                    <asp:DropDownList ID="drlcomplejidad" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">                                   
                                    <div class="input-group-addon">Reiteración</div>
                                    <asp:TextBox ID="txtreiteracion" TabIndex="3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <asp:CheckBox ID="CheckBoxTipificacion" AutoPostBack="true" TabIndex="34" runat="server" CssClass="input-group-addon" />
                                    <div class="input-group-addon">Cambio Tipificación Categoría</div>
                                    <asp:DropDownList ID="drlCategoria" AutoPostBack="true" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                  <div class="input-group">
                                    <asp:CheckBox ID="CheckBoxArea" TabIndex="34" runat="server" CssClass="input-group-addon" />
                                    <div class="input-group-addon">Área</div>
                                    <asp:DropDownList ID="drlAreaUpdate" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                      <asp:LinkButton ID="BtnGuardar" Visible="False" TabIndex="7" ValidationGroup="Consulta" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-save"></span> Guardar 
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="drlEstado" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">- Seleccione -</asp:ListItem>
                                        <asp:ListItem>Gestionado</asp:ListItem>
                                        <asp:ListItem>Escalado</asp:ListItem>
                                        <asp:ListItem>Solucionado</asp:ListItem>
                                        <asp:ListItem>Rechazado</asp:ListItem>
                                        <asp:ListItem>Escalado Claro</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Operatividad</div>
                                    <asp:DropDownList ID="drloperatividad" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                               <div class="input-group">
                                    <div class="input-group-addon">Asignar a: </div>
                                    <asp:DropDownList ID="drlTecnico" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                     <div class="input-group">
                                    <div class="input-group-addon">Tipo</div>
                                    <asp:DropDownList ID="drlTipo" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
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
                          <asp:LinkButton ID="Btnxls" Visible="False" TabIndex="7" ValidationGroup="Consulta" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-save"></span> Guardar 
                                </asp:LinkButton>
                          <div class="input-group">
                                    <div class="input-group-addon">Timer</div>
                                    <asp:TextBox ID="TxtContar"  CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                        <div class="bordes">
                            <asp:GridView ID="dtggeneralHelpDesk" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                              <Columns>
                            <asp:BoundField DataField="Cod_HelpDesk_Registro" HeaderText="Codigo" />
                            <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" />
                            <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
                            <asp:BoundField DataField="Tema" HeaderText="Tema" />
                            <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="Canal" HeaderText="Canal" />
                            <asp:BoundField DataField="Persona_Reporta" HeaderText="Reporta" />
                            <asp:BoundField DataField="Modulo" HeaderText="Modulo" />
                            <asp:BoundField DataField="codnom" HeaderText="Cod" />
                            <asp:BoundField DataField="Area" HeaderText="Area" />
                            <asp:BoundField DataField="Asigna" HeaderText="Asigna" />
                            <asp:BoundField DataField="Fecha_Asigna" HeaderText="Fecha Asigna" />
                            <asp:BoundField DataField="ObservacionAsigna" HeaderText="Observacion Asigna" />
                            <asp:ButtonField CommandName="Seleccion" HeaderText="Seleccion un Caso" Text="Seleccion" />
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
                    <h4></h4>
                    <h4></h4>
                        <asp:Panel runat="server" ID="Panel1">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="lblcuentaSoluciones"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="dtggeneralHelpDeskSolucion" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                          <Columns>
                            <asp:BoundField DataField="Cod_HelpDesk_Solucion" HeaderText="Codigo" />
                            <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" />
                            <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="Complejidad" HeaderText="Complejidad" />
                            <asp:BoundField DataField="Operatividad" HeaderText="Operatividad" />
                            <asp:BoundField DataField="Reiteracion" HeaderText="Reiteracion" />
                            <asp:BoundField DataField="Fk_Cod_HelpDesk_Registro" HeaderText="Help Desk Registro" />
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
