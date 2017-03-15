<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="escalamiento.aspx.vb" Inherits="digitacion.escalamiento" %>
<%@ Register src="~/Controles/Header.ascx" tagname="Header" tagprefix="Control" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Kamilion ERP</title>
        <link rel="icon" href="~/favicon.ico" type="image/x-icon"/>              
        <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>     
        <%--Jquery--%>
        <script type="text/javascript" src="../Css2/jquery.min.js"></script>
        <script type="text/javascript" src="../Css2/jquery-ui.min.js"></script>
        <script type="text/javascript" src="../Css2/jquery-ui-timepiker.js"></script>
        <%--Scripts--%>    
        <script type="text/javascript" src="../Css2/scripts.js"></script>
        <!--#########Estilos############-->
        <link type="text/css" rel="Stylesheet" href="~/Css2/Boot/css/bootstrap.min.css"/>   
        <link type="text/css" rel="Stylesheet" href="~/Css2/jquery-ui.css"/>   
        <link type="text/css" rel="Stylesheet" href="~/Css2/Kamilion.css"/>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <Control:Header ID="Header" runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Panel id="Pnl_Message" runat="server">
                        <asp:Label ID="Lbl_Mensage" runat="server"></asp:Label>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <article>
                <section>
                    <button id="Btn_Change_Form" type="button" onclick="PlegDes_Dinamico('#Pnl_Asig_Cas', 'slide', '', '', ''); PlegDes_Dinamico('#Pnl_Asig_Cas_Dev', 'slide', '', '', '');" class="btn btn-primary" style="padding-bottom:20px; padding-top:0px; font-weight:bold; height:20px; border-radius:20px; border-bottom-left-radius: 0px; border-bottom-right-radius: 0px; margin-bottom:-20px;">Cambiar Formulario</button>
                </section>
            </article>
            <article id="Pnl_Asig_Cas" >
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <section>
                            <div class="text-center Subtitulos">Asignación de Casos Técnica</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Agente Asignado
                                            <asp:RequiredFieldValidator  runat="server" ID="RFV_Drl_Agent" ControlToValidate="Drl_Agent" InitialValue="" Display="Dynamic" ValidationGroup="VG_Asig_cas">*</asp:RequiredFieldValidator>
                                        </div>
                                        <asp:DropDownList ID="Drl_Agent" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="10"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Total casos pendientes por Asignar
                                        </div>
                                        <asp:Label ID="lblcantidadtot" CssClass="form-control"   runat="server"></asp:Label>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Campaña</div>
                                        <asp:DropDownList ID="Drl_Camp" runat="server" CssClass="form-control" TabIndex="12"></asp:DropDownList>
                                    </div>
                                    <asp:Button ID="Btn_Cons_Cas" Text="Consultar" CssClass="btn btn-primary Desplegar_Loading" runat="server" ValidationGroup="VG_Cons_cas" TabIndex="16"/>
                                    <asp:Button ID="Btn_Limpiar" Text="Limpiar" CssClass="btn btn-primary" runat="server" ValidationGroup="VG_Cons_cas" TabIndex="16"/>
                                    <asp:Button ID="Btn_Asig_Cas" Text="Asignar" CssClass="btn btn-primary Desplegar_Loading" runat="server" ValidationGroup="VG_Asig_cas" TabIndex="17"/>
                                    <asp:Button ID="Btn_Export_Cas" Text="Exportar" CssClass="btn btn-primary" runat="server" TabIndex="18"/>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Asignar Caso
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtcaso" ErrorMessage="La información no es válida" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                        </div>
                                        <asp:TextBox ID="txtcaso" CssClass="form-control" runat="server"  MaxLength="11" TabIndex="11"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Casos a Asignar
                                            <asp:CompareValidator ID="CV_Txb_Num_Cas" runat="server" ControlToValidate="Txb_Num_Cas" Operator="DataTypeCheck" Type="Integer" Display="Dynamic"  ValidationGroup="VG_Asig_cas">*</asp:CompareValidator>
                                        </div>
                                        <asp:TextBox ID="Txb_Num_Cas" CssClass="form-control"  runat="server"  MaxLength ="6" TabIndex="13"/>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Rango de fechas
                                            <asp:CompareValidator ID="CV_Txb_Fech_Ini" runat="server" ControlToValidate="Txb_Fech_Ini" Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="VG_Cons_cas">*</asp:CompareValidator>
                                        </div>
                                        <asp:TextBox ID="Txb_Fech_Ini" runat="server" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" TabIndex="14"/>
                                        <div class="input-group-addon">-
                                            <asp:CompareValidator ID="CV_Txb_Fech_Fin" runat="server" ControlToValidate="Txb_Fech_Fin" Operator="DataTypeCheck" Type="Date" Display="Dynamic" ValidationGroup="VG_Cons_cas">*</asp:CompareValidator>
                                        </div>
                                        <asp:TextBox ID="Txb_Fech_Fin" runat="server" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" TabIndex="15"/>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="bordes">
                                <asp:GridView ID="Dtg_ConsAgentAsig" runat="server" AllowPaging="True"
                                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" PageSize="10" Width="100%" Style="font-size: x-small"
                                    EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="idusuriocpd" HeaderText="Agente" />
                                        <asp:BoundField DataField="casos" HeaderText="Casos" />
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
                        <asp:Panel runat="server" ID="Pnl_Grid_Cas" Visible="false" >
                            <div class="Leyendas">
                                Casos encontrados: <asp:Label ID="lblcantidad" runat="server">0</asp:Label>
                            </div>
                            <div class="bordes">
                                <asp:GridView ID="Dtg_ConsCas" runat="server" AllowPaging="True"
                                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" PageSize="100" Width="100%" Style="font-size: x-small"
                                    EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="idreg" HeaderText="ID" />
                                        <asp:BoundField DataField="idcaso" HeaderText="Caso" />
                                        <asp:BoundField DataField="fc_ingreso" HeaderText="Fecha Ingreso" />
                                        <asp:BoundField DataField="fcregistro" HeaderText="Fecha Reporte" />
                                        <asp:BoundField DataField="idusuario" HeaderText="Agente Reporta" />
                                        <asp:BoundField DataField="Campaña" HeaderText="Campaña" />
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
                    <Triggers >
                        <asp:PostBackTrigger ControlID ="Btn_Export_Cas" />
                    </Triggers>
                </asp:UpdatePanel>
            </article>
            <article id="Pnl_Asig_Cas_Dev" style="display:none;" >
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <section>
                            <div class="text-center Subtitulos">Asignación de Casos Técnica Devueltos</div>
                            <div class="Leyendas">
                                Número de Casos Devueltos por Asignar: <asp:Label ID="Lbl_Cas_Dev" runat="server"></asp:Label>
                            </div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon" >
                                            Agente Asignado
                                            <asp:RequiredFieldValidator runat="server" Id="RFV_Drl_Agent_Dev" ControlToValidate="Drl_Agent_Dev" ValidationGroup="VG_Asig_Cas_Dev" Display="Dynamic" InitialValue="">*</asp:RequiredFieldValidator>
                                        </div>
                                        <asp:DropDownList ID="Drl_Agent_Dev" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="20"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Campaña
                                        </div>
                                        <asp:DropDownList ID="Drl_Camp_Dev" runat="server" CssClass="form-control" TabIndex="22"></asp:DropDownList>
                                    </div>
                                    <asp:Button ID="Btn_Consultar_Casos_Devueltos" Text="Consultar" CssClass="btn btn-primary Desplegar_Loading" runat="server"/>
                                    <asp:button ID="Btn_Asignar_Casos_Devueltos" cssclass="btn btn-primary Desplegar_Loading" ValidationGroup="VG_Asig_Cas_Dev" Text="Asignar" runat="server"/>
                                    <asp:Button ID="Btn_Limpiar_Filtro_Develtos" Text="Limpiar" CssClass="btn btn-primary" runat="server"/>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Cod Caso</div>
                                        <asp:TextBox ID="Txb_Cod_Cas_Dev" CssClass="form-control" runat="server" MaxLength="11" TabIndex="21"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Número de casos
                                            <asp:CompareValidator ID="CV_Txb_Num_Cas_Dev" runat="server" ControlToValidate="Txb_Num_Cas_Dev" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ValidationGroup="VG_Cons_Cas_Dev">*</asp:CompareValidator>
                                        </div>
                                        <asp:TextBox ID="Txb_Num_Cas_Dev" CssClass="form-control"  runat="server"  MaxLength ="6" TabIndex="23"/>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Rango de fechas
                                            <asp:CompareValidator ID="CV_Txb_Fech_Ini_Dev" runat="server" ControlToValidate="Txb_Fech_Ini_Dev" Display="Dynamic" Operator="DataTypeCheck" Type="Date" ValidationGroup="VG_Cons_Cas_Dev">*</asp:CompareValidator>
                                        </div>
                                        <asp:TextBox ID="Txb_Fech_Ini_Dev" runat="server" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" TabIndex="24"/>
                                        <div class="input-group-addon">-
                                            <asp:CompareValidator ID="CV_Txb_Fech_Fin_Dev" runat="server" ControlToValidate="Txb_Fech_Fin_Dev" Display="Dynamic" Operator="DataTypeCheck" Type="Date" ValidationGroup="VG_Cons_Cas_Dev">*</asp:CompareValidator>
                                        </div>
                                        <asp:TextBox ID="Txb_Fech_Fin_Dev" runat="server" CssClass="form-control Fecha" MaxLength="10" placeholder="DD/MM/YYYY" TabIndex="25"/>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <asp:Panel runat="server"  ID="Pnl_ConsCasDev">
                            <div class="Leyendas">
                                Número de Casos Devueltos: <asp:Label runat="server" ID="Lbl_CountConsCasDev">0</asp:Label>
                                <br />
                                Todo
                                <div class="material-switch checkbox-inline">
                                    <asp:CheckBox ID="Check_All" runat="server" AutoPostBack="true" />
                                    <label class="label-success"></label>
                                </div>
                            </div>
                            <div class="bordes">
                                <asp:GridView ID="Dtg_ConsCasDev" runat="server" AllowPaging="True"
                                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" PageSize="10" Width="100%" Style="font-size: x-small"
                                    EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                    <Columns>
                                         <asp:TemplateField HeaderText="Check">
                                            <ItemTemplate>
                                                <div class="material-switch pull-left">
                                                    <asp:CheckBox ID="Check" runat="server" AutoPostBack="true" />
                                                    <label class="label-success" ></label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IdCaso" HeaderText="Id Caso" />
                                        <asp:BoundField DataField="FRegBandeja" HeaderText="Fecha Registro Bandeja" />
                                        <asp:BoundField DataField="FRegCPD" HeaderText="Fecha Registro CPD" />
                                        <asp:BoundField DataField="FAsignado" HeaderText="Fecha Asignación" />
                                        <asp:BoundField DataField="FProcDev" HeaderText="Fecha Devolución" />
                                        <asp:BoundField DataField="UsuDev" HeaderText="Usuaio Devuelve" />
                                        <asp:BoundField DataField="Campaña" HeaderText="Campaña" />
                                        <asp:ButtonField ItemStyle-Width="6%" HeaderText="Ver Gestiones" ButtonType="Link" ControlStyle-CssClass="btn btn-primary glyphicon glyphicon-eye-open Desplegar_Loading" ControlStyle-Font-Strikeout="false" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Ver_Gestiones" />
                                    </Columns>
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                            <asp:Panel runat="server" id="Pnl_ConsGestDev">
                                <div class="Leyendas">
                                    Id Caso <asp:Label runat ="server" id="Lbl_ConsGestDevId">0</asp:Label>
                                    <br />
                                    Nímero de Gestiones: <asp:Label runat="server" ID="Lbl_CountConsGestDev">0</asp:Label>
                                </div>
                                <div class="bordes">
                                    <asp:GridView ID="Dtg_ConsGestDev" runat="server" AllowPaging="True"
                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                        GridLines="None" PageSize="100" Width="100%" Style="font-size: x-small"
                                        EnableModelValidation="True">
                                        <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField DataField="Id_Crm" HeaderText="Id" />
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha Registro" />
                                            <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario" />
                                            <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                                            <asp:BoundField DataField="Tipificacion" HeaderText="Tipificación" />
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
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </article>
            <footer></footer>
        </form>
    </body>
</html>
<%--	© 2016 Crisitan Duarte C1477	--%>
<%--	© 2016-06-02 (Ac) Gerson Sánchez C1555	--%>