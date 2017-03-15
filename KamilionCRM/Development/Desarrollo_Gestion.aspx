<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Desarrollo_Gestion.aspx.vb" Inherits="digitacion.Desarrollo_Gestion" %>

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
                    <asp:Panel ID="Pnl_Filtros" Visible="true" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Filtros de Consulta</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <asp:RegularExpressionValidator Font-Size="10px" runat="server" ControlToValidate="Txt_Cons_Cod" Display="Dynamic" SetFocusOnError="True" ValidationExpression="((DES)?(DES)?)*([0-9]{4,4})*">Codigo mal escrito, Ejemplo(DES0000)</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Código</div>
                                        <asp:TextBox ID="Txt_Cons_Cod" TabIndex="1" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="Txt_Cons_FcIni" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                    <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="Txt_Cons_FcFin" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha fin incorrecta, verifique!!</asp:RangeValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Final</div>
                                        <asp:TextBox ID="Txt_Cons_FcIni" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                        <div class="input-group-addon">-</div>
                                        <asp:TextBox ID="Txt_Cons_FcFin" TabIndex="4" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:LinkButton ID="Btn_Filtrar" TabIndex="6" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Filtrar
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Prioridad</div>
                                        <asp:DropDownList ID="Drl_Cons_Pri" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Estado</div>
                                        <asp:DropDownList ID="Drl_Cons_Est" TabIndex="5" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <%-- Seccion de registro --%>
                    <asp:Panel ID="Pnl_Gestion" Visible="false" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Registro de Gestión del Desarrollo</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Código</div>
                                        <asp:TextBox ID="Txt_Codigo" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Persona Solicita</div>
                                        <asp:TextBox ID="Txt_Solicitante" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Registro</div>
                                        <asp:TextBox ID="Txt_Fc_Reg" ReadOnly="true"  CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Requerimientos</div>
                                        <asp:TextBox ID="Txt_Requerimientos" ReadOnly="true"  TextMode="MultiLine" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Prioridad</div>
                                        <asp:TextBox ID="Txt_Prioridad" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Area</div>
                                        <asp:TextBox ID="Txt_Area" ReadOnly="true" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Tema</div>
                                        <asp:TextBox ID="Txt_Tema" ReadOnly="true"  CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <section>
                            <div class="text-center Subtitulos"></div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Complejidad</div>
                                        <asp:DropDownList ID="Drl_Complejidad" TabIndex="11" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Observación</div>
                                        <asp:TextBox ID="Txt_Observacion" TabIndex="13" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <asp:Panel ID="Pnl_Usu_Esc" Visible="false" runat="server">
                                        <div class="input-group">
                                            <div class="input-group-addon">Desarrollador</div>
                                            <asp:DropDownList ID="Drl_Usu_Asig" TabIndex="15" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </asp:Panel>
                          <asp:LinkButton ID="Btn_Guardar" TabIndex="16" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-save"></span> Guardar
                                    </asp:LinkButton>
               <asp:LinkButton ID="Btn_Volver" TabIndex="17" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-arrow-left"></span> Volver
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Operatividad</div>
                                        <asp:DropDownList ID="Drl_Operatividad" TabIndex="12" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Estado</div>
                                        <asp:DropDownList ID="Drl_Estado" AutoPostBack="true" TabIndex="14" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Dtg_Desarrollos" Visible="True" runat="server">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="Dtg_Desarrollos" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Reg_Cod" HeaderText="Codigo" />
                                    <asp:BoundField DataField="Reg_Fch" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="Reg_Usu_Reg" HeaderText="Usuario Registra" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Reg_Tem" HeaderText="Tema" />
                                    <asp:BoundField DataField="Reg_Pri" HeaderText="Prioridad" />
                                    <asp:BoundField DataField="Area" HeaderText="Area" />
                                    <asp:BoundField DataField="Reg_Usu_Sol" HeaderText="Usuario Solicita" />
                                    <asp:BoundField DataField="Reg_Req" HeaderText="Requerimientos" />
                                    <asp:BoundField DataField="Reg_Usu_Asi" HeaderText="Usuario Asigna" />
                                    <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-primary  glyphicon glyphicon-eye-open" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Seleccionar" />
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
                    <asp:Panel runat="server" ID="Pnl_Dtg_Gestiones">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="Lbl_Cantidad2"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="Dtg_Gestiones" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Codigo" HeaderText="Desarrollo" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="Usuario_Reg" HeaderText="Usuario Registra" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Observ" HeaderText="Observacion" />
                                    <asp:BoundField DataField="Compl" HeaderText="Complejidad" />
                                    <asp:BoundField DataField="Opera" HeaderText="Operatividad" />
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



