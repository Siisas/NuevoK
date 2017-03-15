<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Activo_Inventario.aspx.vb" Inherits="digitacion.cambiestilo" %>


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
                    <%-- Seccion de Registro --%>
                    <%-------------------------%>
                    <%--.   ss  dds--%><%--cdcd--%>
                    <section>
                        <div class="text-center Subtitulos">Registro Activos</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Clasificación</div>
                                    <asp:DropDownList ID="drlclasificacion" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Serial
                                    </div>
                                    <asp:TextBox ID="TxtSerialActivo" runat="server" TabIndex="1" placeholder="152405XX0001" CssClass="form-control" MaxLength="12"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Zona
                                    </div>
                                    <asp:DropDownList ID="drlZonaActivo" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Referencia
                                    </div>
                                    <asp:TextBox ID="TxtReferenciaActivo" TabIndex="1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Responsable</div>
                                    <asp:DropDownList ID="drlresponsable" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="drlEstadoActivo" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:Panel ID="Panel3" runat="server">                                
                                 <div class="input-group">
                                    <div class="input-group-addon">
                                        N° Acta
                                    </div>
                                    <asp:TextBox ID="TxtN_Acta" TabIndex="1" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                </div>
                                      </asp:Panel>
                                <%--Ojo el id del boton es btnRegistrarActivo--%>
                                <asp:LinkButton ID="btnRegistrarActivo" TabIndex="6" CssClass="btn btn-primary" Font-Strikeout="false" runat="server">
                                    <span class="glyphicon glyphicon-floppy-disk"></span> Registrar
                                </asp:LinkButton>

                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Activo</div>
                                    <asp:DropDownList ID="drlNombreActivo" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Sede</div>
                                    <asp:DropDownList ID="drlSedeActivo" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Marca</div>
                                    <asp:DropDownList ID="drlMarcaActivo" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Descripción
                                    </div>
                                    <asp:TextBox ID="TxtDescripcionActivo" TabIndex="1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Usuario</div>
                                    <asp:DropDownList ID="drlsubResponsable" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </section>

                    <%--- Carga Masiva Activos---%>

                    <section>
                        <div class="text-center Subtitulos">Carga Masiva Activos</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Imagen</div>
                                    <input type="text" class="form-control lbl-input-file" disabled="disabled">
                                    <label class="input-group-btn">
                                        <span class="btn btn-crm">
                                            <span class="glyphicon glyphicon-open"></span>
                                            Examinar 
                                                <ajaxToolkit:AsyncFileUpload ID="AsF_Archivo" CssClass="file" runat="server" Style="display: none;" />
                                        </span>
                                    </label>
                                </div>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:LinkButton ID="btnRegistrarActivo0" TabIndex="6" CssClass="btn btn-primary" Font-Strikeout="false" runat="server">
                                    <span class="glyphicon glyphicon-floppy-disk"></span> Registrar
                                </asp:LinkButton>
                            </div>
                    </section>
                    <%--- Nuevos Registros---%>

                    <section>
                        <div class="text-center Subtitulos">Nuevos Registros</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Nombre
                                    </div>
                                    <asp:TextBox ID="TxtNombre" TabIndex="1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                <asp:Panel ID="Panel1" runat="server" Style="width: 100%" Visible="False">
                                    <div class="input-group">
                                        <div class="input-group-addon">Clasificación</div>
                                        <asp:DropDownList ID="drlclasificacion0" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </asp:Panel>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Pertenece</div>
                                    <asp:DropDownList ID="drlPertenece" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:LinkButton ID="btnRegistrarNuevo" TabIndex="6" CssClass="btn btn-primary" Font-Strikeout="false" runat="server">
                                    <span class="glyphicon glyphicon-floppy-disk"></span> Registrar
                                </asp:LinkButton>
                            </div>
                    </section>

                    <%--- Seccion de Consulta ---%>
                    <section>
                        <div class="text-center Subtitulos">Consultas</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="RdbSeriall" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Serial</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:TextBox ID="TxtSerialConsulta" runat="server" placeholder="152405XX0001" CssClass="form-control" MaxLength="12"></asp:TextBox>
                                </div>

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="Rdbresponsable" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Responsable</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:DropDownList ID="drlresponsable0" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="RdbClasificacion" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Clasificación</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:DropDownList ID="drlclasificacionconsulta" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="Rdbmarca" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Marca</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:DropDownList ID="drlMarca" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="Rdbsub_responsable" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Usuario</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:DropDownList ID="drlsub_responsable" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:LinkButton ID="btnConsultarActivo" TabIndex="11" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Buscar
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnExportarActivo" Visible="False" TabIndex="11" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-save"></span> Exportar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="RdbZona" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Zona</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:DropDownList ID="drlZona" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="Rdbcodres" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Cod Responsable</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:DropDownList ID="drlcodresponsable" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="RdbActivo" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>Activo</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:DropDownList ID="drlNombreActivo0" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <div class="input-group-addon">
                                            Referencia
                                        </div>
                                    </div>
                                    <asp:DropDownList ID="drlReferencia" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:RadioButtonList ID="RdbN_ActaC" TabIndex="5" RepeatDirection="Vertical" runat="server">
                                            <asp:ListItem>N° Acta</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:TextBox ID="TxtN_ActaC" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>


                            </div>
                        </div>
                    </section>
                    <asp:Panel runat="server" ID="Pnl_ConsTk">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="LblCantidad"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="dtgInvt" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                 <Columns>
                                            <asp:BoundField DataField="cod_inventario_activos" HeaderText="Codigo inventario" />
                                            <asp:BoundField DataField="Nombre_activo" HeaderText="Activo" />
                                            <asp:BoundField DataField="serial" HeaderText="Serial" />
                                            <asp:BoundField DataField="sigla" HeaderText="Sigla" />
                                            <asp:BoundField DataField="marca" HeaderText="Marca" />
                                            <asp:BoundField DataField="referencia" HeaderText="Referencia" />
                                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                            <asp:BoundField DataField="estado" HeaderText="Estado" />
                                            <asp:BoundField DataField="sede" HeaderText="Sede" />
                                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                                            <asp:BoundField DataField="Sub_responsable" HeaderText="Usuario" />
                                            <asp:BoundField DataField="usu_registra" HeaderText="Usu Registra" />
                                            <asp:BoundField DataField="fc_reg" HeaderText="Fecha Registro" />
                                            <asp:BoundField DataField="No_Acta_baja" HeaderText="N° Acta"></asp:BoundField>
                                        </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>

                                  <div class="bordes">
                            <asp:GridView ID="dtgxls" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                 <Columns>
                                <asp:BoundField DataField="cod_inventario_activos" HeaderText="Codigo inventario" />
                                <asp:BoundField DataField="Nombre_activo" HeaderText="Activo" />
                                <asp:BoundField DataField="serial" HeaderText="Serial" />
                                <asp:BoundField DataField="sigla" HeaderText="Sigla" />
                                <asp:BoundField DataField="referencia" HeaderText="Referencia" />
                                <asp:BoundField DataField="descripción" HeaderText="Descripcion" />
                                <asp:BoundField DataField="sede" HeaderText="Sede" />
                                <asp:BoundField DataField="estado" HeaderText="Estado" />
                                <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                                <asp:BoundField DataField="usu_registra" HeaderText="Usu Registra" />
                                <asp:BoundField DataField="fc_reg" HeaderText="Fecha Registro" />
                                <asp:BoundField DataField="marca" HeaderText="Marca" />
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




















