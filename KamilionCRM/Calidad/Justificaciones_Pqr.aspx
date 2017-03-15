<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Justificaciones_Pqr.aspx.vb" Inherits="digitacion.Prueba001" %>

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
                        <div class="text-center Subtitulos">Crear Nuevo Caso</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="txtfcingn3" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Ingreso Caso</div>
                                    <asp:TextBox ID="txtfcingn3" TabIndex="1" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Ingeniero Claro Solicita</div>
                                    <asp:DropDownList ID="drlingclaro" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <h4></h4>
                                <asp:LinkButton ID="btn_crear" TabIndex="5" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-floppy-disk"></span> Guardar
                                </asp:LinkButton>
                                <h4></h4>
                                <h4></h4>
                                <h4></h4>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Tipo De Solicitud</div>
                                    <asp:DropDownList ID="Drl_Tipo_Solicitud" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                  
                                    <div class="input-group-addon">Observación</div>
                                    <asp:TextBox ID="Txt_Observacion" TabIndex="4" TextMode="MultiLine" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                      <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="GrupoNuevoIngeniero" ControlToValidate="txt_nuevo_ing" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[\s\S]{0,50}$">Máximo 50 caracteres</asp:RegularExpressionValidator>
                                    <div class="input-group-addon">Nuevo Ingeniero</div>
                                    <asp:TextBox ID="txt_nuevo_ing" TabIndex="6" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:LinkButton ID="btn_nuevo_ing" ValidationGroup="GrupoNuevoIngeniero"  TabIndex="7" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-floppy-disk"></span> Guardar Ing
                                </asp:LinkButton>
                            </div>
                        </div>
                    </section>
                    <%-- Seccion de registro --%>
                    <section>
                        <div class="text-center Subtitulos">Registro de Seguimiento</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Registro Caso</div>
                                    <asp:TextBox ID="Lbl_fc_ingreso" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Ingeniero Claro Solicita</div>
                                    <asp:TextBox ID="lbl_ing_r" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado Caso</div>
                                    <asp:DropDownList ID="Drl_estado_reg" AutoPostBack="True" TabIndex="21" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="GrupoRegistro" ControlToValidate="txt_Numero_Solic" Display="Dynamic" SetFocusOnError="True" ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$">Solo números</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    
                                    <div class="input-group-addon">Número De Solicitudes </div>
                                    <asp:TextBox ID="txt_Numero_Solic" Enabled="false" TabIndex="23" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Resultado</div>
                                    <asp:DropDownList ID="Drl_Respuesta" AutoPostBack="True" TabIndex="25" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:LinkButton ID="Btn_Guardar" TabIndex="28" ValidationGroup="GrupoRegistro" Visible ="False" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-floppy-save"></span> Guardar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:TextBox ID="lbl_estado" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Caso</div>
                                    <asp:TextBox ID="Lbl_Caso" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Observación</div>
                                    <asp:TextBox ID="Txt_obs_reg" TabIndex="22" TextMode="MultiLine" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                 <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="GrupoRegistro" ControlToValidate="txt_Numero_grabaciones" Display="Dynamic" SetFocusOnError="True" ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$">Solo números</asp:RegularExpressionValidator>
                                <div class="input-group">
                                   
                                    <div class="input-group-addon">Número De Grabaciones</div>
                                    <asp:TextBox ID="txt_Numero_grabaciones" Enabled="false" TabIndex="24" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </section>
                    <%--filtros de consulta--%>
                    <section>
                        <div class="text-center Subtitulos">Filtros de Consulta</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                  <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="GrupoRegistro" ControlToValidate="txtcaso" Display="Dynamic" SetFocusOnError="True" ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$">Solo números</asp:RegularExpressionValidator>
                                <div class="input-group">                                  
                                    <div class="input-group-addon">Caso</div>
                                    <asp:TextBox ID="txtcaso" TabIndex="31" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                </div>
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="Txt_fc_inicio" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="Txt_fc_fin" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha fin incorrecta, verifique!!</asp:RangeValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Fecha Final</div>
                                    <asp:TextBox ID="Txt_fc_inicio" TabIndex="33" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    <div class="input-group-addon">-</div>
                                    <asp:TextBox ID="Txt_fc_fin" TabIndex="34" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado Caso</div>
                                    <asp:DropDownList ID="Drl_Estado_Busca" TabIndex="36" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <h4></h4>
                                <h4></h4>
                                <h4></h4>
                                <h4></h4>
                                <asp:LinkButton ID="Btn_Buscar" TabIndex="36" ValidationGroup="GrupoRegistro" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Buscar
                                </asp:LinkButton>
                                <asp:LinkButton ID="Btn_buscar_todos" ValidationGroup="GrupoRegistro" TabIndex="37" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Buscar Todos 
                                </asp:LinkButton>
                                <asp:LinkButton ID="btn_Exportar" TabIndex="38" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-save"></span> Exportar
                                </asp:LinkButton>
                                <asp:Label ID="Lbl_Exportar" runat="server" Visible="False"></asp:Label>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Ingeniero Claro Solicita</div>
                                    <asp:DropDownList ID="Drl_ing_busca" TabIndex="32" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Mis Casos</div>
                                    <asp:CheckBox ID="CheckBox_casos" TabIndex="34" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </section>
                    <div class="Leyendas">
                        <asp:Label runat="server" ID="lblcuenta2"></asp:Label>
                    </div>
                    <div class="bordes">
                        <asp:GridView ID="dtg_seguim" runat="server" AllowPaging="false" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="false">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="Id_Historial_Justificacion" HeaderText="Id" />
                                <asp:BoundField DataField="Id_Caso" HeaderText="Caso" />
                                <asp:BoundField DataField="Fc_Reg" HeaderText="Fecha Registro" />
                                <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                            </Columns>
                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                    <h4></h4>
                    <h4></h4>
                    <h4></h4>
                    <h4></h4>
                    <%--/********************DATAGRID GESTIONES************************/--%>
                    <div class="Leyendas">
                        <asp:Label runat="server" ID="lblcuenta"></asp:Label>
                    </div>
                    <div class="bordes">
                        <asp:GridView ID="dtggeneral" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="true">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="Id_Caso" HeaderText="Caso" />
                                <asp:BoundField DataField="Fc_Ingreso_Caso" HeaderText="Fecha Ingreso Caso" />
                                <asp:BoundField DataField="Fc_Reg" HeaderText="Fecha Registro Caso" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="Ing_Claro" HeaderText="Ingeniero Claro" />
                                <asp:BoundField DataField="Tipo_Solicitud" HeaderText="Tipo Solicitud" />
                                <asp:BoundField DataField="Numero_Solicitudes" HeaderText="N. Solicitudes" />
                                <asp:BoundField DataField="N_Grabaciones" HeaderText="N. Grabaciones" />
                                <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                                <asp:BoundField DataField="Fc_Entrega" HeaderText="Fecha Entrega" />
                                <asp:BoundField DataField="Fc_Envio" HeaderText="Fecha Envio" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
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
                    <%--grilla de exportar--%>
                    <div class="bordes">
                        <asp:GridView ID="dtg_exportar" Visible="false" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="true">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="Id_Caso" HeaderText="Caso" />
                                <asp:BoundField DataField="Fc_Ingreso_Caso" HeaderText="Fecha Ingreso Caso" />
                                <asp:BoundField DataField="Fc_Reg" HeaderText="Fecha Registro Caso" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="Ing_Claro" HeaderText="Ingeniero Claro" />
                                <asp:BoundField DataField="Tipo_Solicitud" HeaderText="Tipo Solicitud" />
                                <asp:BoundField DataField="Numero_Solicitudes" HeaderText="N. Solicitudes" />
                                <asp:BoundField DataField="N_Grabaciones" HeaderText="N. Grabaciones" />
                                <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                                <asp:BoundField DataField="Fc_Entrega" HeaderText="Fecha Entrega" />
                                <asp:BoundField DataField="Fc_Envio" HeaderText="Fecha Envio" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
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
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_Exportar" />                      
            </Triggers>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>
