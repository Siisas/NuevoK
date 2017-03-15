<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Control_PQR.aspx.vb" Inherits="digitacion.Control_PQR" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>

<!DOCTYPE html>
<%--	© 2016 Crisitan Duarte C1477	--%>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Kamilion ERP</title>
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
    <script>
        /********************************/
        /*Esto gestiona los desplegables*/
        /********************************/
        function Chang_Panel1() {
            if ($_$(".Pnl_Asignacion").is(":visible")) {
            } else {
                PlegDes_Dinamico(".Pnl_Asignacion", "slide", '', '', '');
                if ($_$("#Pnl_Cargue_PQR").is(":visible")) {
                    PlegDes_Dinamico("#Pnl_Cargue_PQR", "slide", '', '', '');
                }
                if ($_$("#Pnl_Cas_Sin_PQR").is(":visible")) {
                    PlegDes_Dinamico("#Pnl_Cas_Sin_PQR", "slide", '', '', '');
                }
            }
        };
        function Chang_Panel2() {
            if ($_$("#Pnl_Cargue_PQR").is(":visible")) {
            } else {
                PlegDes_Dinamico("#Pnl_Cargue_PQR", "slide", '', '', '');
                if ($_$(".Pnl_Asignacion").is(":visible")) {
                    PlegDes_Dinamico(".Pnl_Asignacion", "slide", '', '', '');
                }
                if ($_$("#Pnl_Cas_Sin_PQR").is(":visible")) {
                    PlegDes_Dinamico("#Pnl_Cas_Sin_PQR", "slide", '', '', '');
                }
            }
        };
        function Chang_Panel3() {
            if ($_$("#Pnl_Cas_Sin_PQR").is(":visible")) {
            } else {
                PlegDes_Dinamico("#Pnl_Cas_Sin_PQR", "slide", '', '', '');
                if ($_$(".Pnl_Asignacion").is(":visible")) {
                    PlegDes_Dinamico(".Pnl_Asignacion", "slide", '', '', '');
                }
                if ($_$("#Pnl_Cargue_PQR").is(":visible")) {
                    PlegDes_Dinamico("#Pnl_Cargue_PQR", "slide", '', '', '');
                }
            }
        };
        /********************************/
        /********************************/
    </script>
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
        <asp:Panel ID="Pnl_General" runat="server">
        <article>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <br />
                    <section>
                        <div class="btn-group btn-group-justified">
                            <div class="btn-group">
                                <asp:Button ID="Btn_Asignacion" OnClientClick="Chang_Panel1()"  Text="Asignacion" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="btn-group">
                                <asp:Button ID="Btn_Cargue_PQR" OnClientClick="Chang_Panel2()" Text="Cargue de Base PQR" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="btn-group">
                                <asp:Button ID="Btn_Cas_Sin_PQR" OnClientClick="Chang_Panel3()" Text="Casos sin PQR" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Panel ID="Pnl_Asignacion" CssClass="Pnl_Asignacion" runat="server">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <section>
                            <div class="text-center Subtitulos">Seleccionar Agente/Ingeniero</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Agente</div>
                                        <asp:DropDownList ID="Drl_Agente" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="btn-group btn-group-justified">
                                        <div class="btn-group">
                                            <asp:Button ID="Btn_Liberar" Text="Liberar Agente" CssClass="btn btn-primary" runat="server" />
                                        </div>
                                        <div class="btn-group">
                                            <asp:Button ID="Btn_Lib_Mas" Text="Liberar Todo" CssClass="btn btn-primary" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <section>
                            <div class="text-center Subtitulos">Filtros de Consulta</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Casos Sin Asignar</div>
                                        <b><em><asp:Label ID="Lbl_Casos" Enabled="false" Font-Size="17px" ForeColor="#8F9E45" CssClass="form-control" runat="server"></asp:Label></em></b>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Escalamiento</div>
                                        <asp:DropDownList ID="Drl_Escalamiento" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0" Text="SD & CPD" />
                                            <asp:ListItem Text="CPD" />
                                            <asp:ListItem Text="SD" />
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="Txt_Cantidad" ValidationGroup="Buscar" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9]{0,100}$">El campo Cantidad de Casos es de tipo numerico!</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cantidad de Casos</div>
                                        <asp:TextBox ID="Txt_Cantidad" MaxLength="7" runat="server" CssClass="form-control" />
                                    </div>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="Txt_Caso" ValidationGroup="Buscar" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9]{0,100}$">El campo Caso Individual es de tipo numerico!</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Caso Individual</div>
                                        <asp:TextBox ID="Txt_Caso" MaxLength="15" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Bandeja</div>
                                        <asp:DropDownList ID="Drl_Bandeja" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Estado</div>
                                        <asp:DropDownList ID="Drl_Estado" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_Fc_Ini" ValidationGroup="Buscar" SetFocusOnError="True" Type="Date" MaximumValue="01/01/3000" MinimumValue="01/01/1900">Verifique las fechas, ya que el rango o el formato no es el correcto!</asp:RangeValidator>
                                    <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="Txt_Fc_Fin" ValidationGroup="Buscar" SetFocusOnError="True" Type="Date" MaximumValue="01/01/3000" MinimumValue="01/01/1900">Verifique las fechas, ya que el rango o el formato no es el correcto!</asp:RangeValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fechas</div>
                                        <asp:TextBox ID="Txt_Fc_Ini" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                        <div class="input-group-addon">-</div>
                                        <asp:TextBox ID="Txt_Fc_Fin" runat="server" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" />
                                    </div>
                                    <br />
                                    <asp:Button ID="Btn_Buscar" ValidationGroup="Buscar" Text="Buscar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                    <asp:Button ID="Btn_Asignar" Text="Asignar" CssClass="btn btn-primary" runat="server" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="bordes">
                                        <asp:GridView ID="Dtg_Estad" runat="server" AllowPaging="True" PageSize="12" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                            <RowStyle BackColor="#F7F6F3" Font-Bold="true" ForeColor="#333333" />
                                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>            
            <asp:Panel ID="Pnl_Cargue_PQR" Style="display: none;" runat="server">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <section>
                            <div class="text-center Subtitulos">Cargue Masivo Base de PQR</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Registro Masivo</div>
                                        <input type="text" class="form-control lbl-input-file" disabled="disabled">
                                        <label class="input-group-btn">
                                            <span class="btn btn-primary">
                                                <span class="glyphicon glyphicon-open"> </span>
                                                Explorar 
                                                <asp:FileUpload ID="File_Carga_Masiva" CssClass="file" runat="server" style="display: none;"/>
                                            </span>
                                        </label>
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <asp:Button ID="Btn_Carga_Masiva" Text="Guardar" CssClass="btn btn-primary" runat="server" />
                                </div>
                            </div>
                        </section>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Btn_Carga_Masiva" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="Pnl_Cas_Sin_PQR" Style="display: none;" runat="server">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <section>
                            <div class="text-center Subtitulos">Seleccion de Ingeniero</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Ingeniero</div>
                                        <asp:DropDownList ID="Drl_Ingeniero_SP" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form"></div>
                            </div>
                            <div class="text-center Subtitulos">Consulta de Casos</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="Txt_Cantidad_SP" SetFocusOnError="True" ValidationExpression="^[0-9]{0,5}$">El campo [Cantidad de Casos] debe ser de tipo numerico!</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cantidad de Casos</div>
                                        <asp:TextBox ID="Txt_Cantidad_SP" MaxLength="4" CssClass="form-control" runat="server"/>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Estado</div>
                                        <asp:DropDownList ID="Drl_Estado_SP" CssClass="form-control" runat="server">
                                            <asp:ListItem Text="- Seleccione -"/>
                                            <asp:ListItem Text="Gestionado"/>
                                            <asp:ListItem Text="Seguimiento"/>
                                            <asp:ListItem Text="Programado"/>
                                            <asp:ListItem Text="Solicitud Escalar SD"/>
                                            <asp:ListItem Text="Solicitud Escalar CPD"/>
                                        </asp:DropDownList>
                                    </div><h3></h3>
                                    <asp:Button ID="Btn_Consultar_SP" Text="Consultar" CssClass="btn btn-primary" runat="server" />
                                    <asp:Button ID="Btn_Asignar_SP" Text="Asignar" CssClass="btn btn-primary" runat="server" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
				   <div class="bordes" style="overflow:auto;width:100%;min-height:0; max-height:150px;">
                                        <asp:GridView ID="Dtg_Estad_SP" runat="server" AllowPaging="false" PageSize="100" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div><br />
                            <div class="Leyendas">
                                <asp:Label ID="Lbl_Cuenta3" runat="server"></asp:Label>
                            </div>
                            <div class="bordes">
                                <asp:GridView ID="Dtg_Casos_SP" runat="server" AllowPaging="false" PageSize="100" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="Id_caso" HeaderText="Id_caso" />
                                        <asp:BoundField DataField="Fecha_registro" HeaderText="Fecha_registro" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:BoundField DataField="Nombre_cliente" HeaderText="Nombre_cliente" />
                                        <asp:BoundField DataField="Min" HeaderText="Min" />
                                        <asp:BoundField DataField="Fec_prog" HeaderText="Fec_prog" />
                                    </Columns>
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                        </section>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
            <asp:Panel ID="Pnl_Dtg_General" CssClass="Pnl_Asignacion" runat="server">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <section>
                    <div class="Leyendas">
                        <asp:Label ID="Lbl_Cuenta" runat="server"></asp:Label>
                    </div>
                    <div class="bordes">
                        <asp:GridView ID="Dtg_General" runat="server" AllowPaging="True" PageSize="100" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                            <RowStyle BackColor="#F7F6F3" Font-Bold="true" ForeColor="#333333" />
                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
            </asp:Panel>            
        </article>
        </asp:Panel>
        <asp:Panel ID="Pnl_Ingenieros" runat="server">
        <article>
            <section>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                                <div class="Leyendas">
                                    <asp:Label ID="Lbl_Cuenta2" runat="server"></asp:Label>
                                </div>
                                <div class="bordes">
                                    <asp:GridView ID="Dtg_Mis_Asignados" runat="server" AllowPaging="True" PageSize="100" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                        <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                        <Columns>
                                            <asp:ButtonField HeaderText="CERRAR" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Strikeout="false" ItemStyle-Width="6%" ButtonType="Link" ControlStyle-CssClass="btn btn-primary glyphicon glyphicon-ok"  ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Cerrar" />
                                            <asp:BoundField DataField="CASO" HeaderText="CASO" />
                                            <asp:BoundField DataField="PQR" HeaderText="PQR" />
                                            <asp:BoundField DataField="FECHA_INGRESO" HeaderText="FECHA INGRESO" />
                                            <asp:BoundField DataField="FECHA_SAP" HeaderText="FECHA SAP" />
                                            <asp:BoundField DataField="TITULAR" HeaderText="TITULAR" />
                                            <asp:BoundField DataField="MIN" HeaderText="MIN" />
                                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                            <asp:BoundField DataField="BANDEJA" HeaderText="BANDEJA" />
                                            <asp:ButtonField HeaderText="LIBERAR" ItemStyle-HorizontalAlign="Center" ControlStyle-Font-Strikeout="false" ItemStyle-Width="6%" ButtonType="Link" ControlStyle-CssClass="btn btn-danger glyphicon glyphicon-remove"  ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Liberar" />
                                        </Columns>
                                        <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                    </asp:GridView>
                                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </article>
        </asp:Panel>
        <footer></footer>
    </form>
</body>
</html>
<%--	© 2016 Crisitan Duarte C1477	--%>