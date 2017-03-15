<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RRHHlinq.aspx.vb" Inherits="digitacion.RRHHlinq" %>

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
                        </div>    
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <article>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    
                                        <asp:Panel ID="Pnl_Filtros1" Visible="true" runat="server">
                    <asp:Panel ID="Pnl_Filtros" Visible="true" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Filtros de Consulta</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <asp:RegularExpressionValidator Font-Size="10px" runat="server" ControlToValidate="TxtCodigoFiltro" Display="Dynamic" SetFocusOnError="True" ValidationExpression="((MT)?(MT)?)*([0-9]{4,4})*">Codigo mal escrito, Ejemplo(MT0000)</asp:RegularExpressionValidator> 
                                     <%--   <asp:RegularExpressionValidator  ControlToValidate="TxtCodigoFiltro"   Style="color: #F45761;font-size:10px"  Display="Dynamic" ValidationExpression="'{1,6}$" runat="server">Código mal escrito. EJEMPLO(MT0000)!</asp:RegularExpressionValidator>--%>
                                    <div class="input-group">
                                        <div class="input-group-addon">Código</div>
                                        <asp:TextBox ID="TxtCodigoFiltro" TabIndex="1" CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox>
                                    </div>
                                    <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="TxtFechaInicio" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                    <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="TxtFechaFiltroFinal" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha fin incorrecta, verifique!!</asp:RangeValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Registro</div>
                                        <asp:TextBox ID="TxtFechaInicio" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                        <div class="input-group-addon">-</div>
                                        <asp:TextBox ID="TxtFechaFiltroFinal" TabIndex="4" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    </div>

                                    <asp:LinkButton ID="Btn_Filtrar" TabIndex="5" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Filtrar
                                        </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Prioridad</div>
                                        <asp:DropDownList ID="Drl_PrioridadGestion" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>                                 
                                </div>
                            </div>                                                                         
                                              <div class="Leyendas">
                                <asp:Label ID="Lbl_Cantidad" Font-Bold="false" ForeColor="#8F9E45" runat="server" />
                            </div>                         
                            </div>  
                               <div class="bordes">
                                <asp:GridView ID="Gtg_ConsultaTickets" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                     <Columns>                                    
                                    <asp:ButtonField CommandName="Gestionar"   ControlStyle-Font-Size= 10px ControlStyle-Width=67px  ControlStyle-CssClass="btn btn-primary glyphicon-barcode" Text="Gestionar" ButtonType="Button" />                             
                                </Columns>   
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                                        </asp:Panel>                 
                                               </asp:Panel>                                    
                    <%--Segunda Parte Gestionar Ticket --%>                    
                    <asp:Panel ID="Pnl_Gestion" Visible="false" runat="server">                       
                        </div>    
                          <section>
                            <div class="text-center Subtitulos">Gestionar Tickets</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Código</div>
                                        <asp:TextBox ID="TxtCodigoGestion" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Usuario Solícita</div>
                                        <asp:TextBox ID="TxtPersonaSolicita" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                     <div class="input-group">
                                        <div class="input-group-addon">Tema</div>
                                        <asp:TextBox ID="TxtTemaG" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                      
                                    <div class="input-group">
                                        <div class="input-group-addon">Área</div>
                                        <asp:TextBox ID="TxtArea" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Requerimientos</div>
                                        <asp:TextBox ID="Txt_Requerimientos" ReadOnly="true" CssClass="form-control" TextMode="MultiLine" runat="server" />
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Prioridad</div>
                                        <asp:TextBox ID="TxtPrioridad" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Localización</div>
                                        <asp:TextBox ID="TxtAreaLocalizacion" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Elemento</div>
                                        <asp:TextBox ID="TxtElementoG" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                 <div class="input-group">
                                        <div class="input-group-addon">Fecha Registro</div>
                                        <asp:TextBox ID="TxtFechaTktGestion" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                 
                                       <div class="input-group">
                                    <div class="input-group-addon">Usuario Asignado</div>
                                    <asp:TextBox ID="TxtUsuarioAsignado" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                           </div>
                                           <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:TextBox ID="TxtEstado" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                           </div>
                                </div>
                            </div>
                            <div class="text-center Subtitulos">
                            </div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Estado</div>
                                        <asp:DropDownList ID="Drl_Estado" TabIndex="10" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                  <div  class="input-group" >
                                        <div  class="input-group-addon">
                                            Asignar Usuario</div>
                                        <asp:DropDownList ID="Drl_Usuarios" TabIndex="12" runat="server" CssClass="form-control">
                                      
                                              </asp:DropDownList>
                                    </div>                  
                                </div>
                               <div class="Space-Form">
                                </div>
                                <div class="Cell-Form">     
                                      <asp:RegularExpressionValidator Font-Size="10px" ValidationGroup="Observacion" runat="server" ControlToValidate="TxtObservacion" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[\s\S]{0,250}$">Maximo 250 caracteres</asp:RegularExpressionValidator>                     
                                   <div class="input-group">
                                        <div class="input-group-addon">
                                            Observación</div>

                                        <asp:TextBox ID="TxtObservacion" TabIndex="11" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="250" />
                                        
                                    </div>
                                     <div class="input-group">
                                  
                                        <asp:TextBox ID="TxtIdTicket" visible="false" runat="server" CssClass="form-control"  />
                                    </div>
                                     
                                </div>
                            </div>
                            <asp:LinkButton ID="Btn_GuardarGestion" TabIndex="13" ValidationGroup="Observacion" runat="server" CssClass="btn btn-primary" Font-Strikeout="false">
                                            <span class="glyphicon glyphicon-floppy-disk"></span> Guardar
                                        </asp:LinkButton>
                                       &nbsp;&nbsp;&nbsp;         
                              <asp:LinkButton ID="Btn_CerrarTicket" Visible ="false" TabIndex="14" runat="server" CssClass="btn btn-primary" Font-Strikeout="false">
                                            <span class="glyphicon glyphicon-flag"></span> Cerrar Ticket
                                        </asp:LinkButton>
                                       &nbsp;&nbsp;&nbsp;         
                            <asp:LinkButton ID="Btn_VolverGestion"  TabIndex="15" PostBack="true" runat="server" CssClass="btn btn-primary" Font-Strikeout="false">
                                            <span class="glyphicon glyphicon-arrow-left"></span> Volver
                                        </asp:LinkButton>                                             
                               
                        </section>                 

                        <div class="Leyendas">
                                <asp:Label ID="Lbl_CatidadGestiones" Font-Bold="false" ForeColor="#8F9E45" runat="server" />
                            </div>
                            <div class="bordes">
                                <asp:GridView ID="Gtg_ConsultaGestiones" runat="server" AllowPaging="false" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />

                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                            </div>

                    </asp:Panel>                 

                 <%-- Tercera parte en la que llamo el Panel para cerra la gestion--%>
        <div id="Desp_General" class="Desplegable">
            <div class="Dialog-Confirm">
                <div class="text-center Subtitulos">
                    <strong>ADVERTENCIA</strong>
                </div>
                   <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Label ForeColor="White" ID="Lbl_Msgdesp" runat="server" />
                        <div>
                            <asp:Button runat="server" ID="Btn_Si" Text="SI" CssClass=" btn btn-primary" />
                            <input type="button" id="Btn_No" value="NO" onclick="PlegDes_Dinamico('#Desp_General', 'slide', '', '', '');" class="btn btn-primary" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
                       <asp:Panel  ID="Pnl_CerrarGestion" Visible="false" runat ="server">
                        
                        </div>  
                              <section>
                        <div class="text-center Subtitulos">Cierre del Ticket</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Código</div>
                                    <asp:TextBox ID="TxtCodigoaa" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Usuario Solicita</div>
                                    <asp:TextBox ID="TxtPersona" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                        <div class="input-group">
                                        <div class="input-group-addon">Tema</div>
                                        <asp:TextBox ID="TxtTemaCierre" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Área</div>
                                    <asp:TextBox ID="TxtAreaCierre" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                
                                <div class="input-group">
                                    <div class="input-group-addon">Requerimientos</div>
                                    <asp:TextBox ID="TxtRequerimientosCierre" ReadOnly="true" CssClass="form-control" TextMode="MultiLine" runat="server" />
                                </div>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                             
                                   <div class="input-group">
                                    <div class="input-group-addon">Prioridad</div>
                                    <asp:TextBox ID="TxtPrioridadCierre" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Localización</div>
                                    <asp:TextBox ID="TxtLocalizacionCierre" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Elemento</div>
                                    <asp:TextBox ID="TxtElementoCierre" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                               <div class="input-group">
                                    <div class="input-group-addon">Usuario Gestiona</div>
                                    <asp:TextBox ID="TxtUsuarioGestionaCierre" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                   <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:TextBox ID="TxtEstadoCierre" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                            
                        <div class="text-center Subtitulos"></div>
                        <div class="Form">
                            <div class="Cell-Form">
                               <%--  <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="Drl_EstadoCierre" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Calificación Servicio</div>
                                    <asp:DropDownList ID="Drl_Calificacion" TabIndex="20" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                  <asp:RegularExpressionValidator Font-Size="10px" ValidationGroup="ObservacionCierre" runat="server" ControlToValidate="TxtObservacionCierre" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[\s\S]{0,250}$">Maximo 250 caracteres</asp:RegularExpressionValidator>                     
                                <div class="input-group">
                                    <div class="input-group-addon">Observación</div>
                                    <asp:TextBox ID="TxtObservacionCierre" TabIndex="22" CssClass="form-control" TextMode="MultiLine" runat="server" MaxLength="250" />
                                </div>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Nivel Satisfacción Trabajo realizado </div>
                                        <asp:DropDownList ID="Drl_NivelS" ToolTip="Realice la calificación del nivel de satisfaccion en el trabajo realizado" TabIndex ="21" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>         
                                 
                            </div>                              
                        </div>
                        <asp:LinkButton ID="Btn_GuardarCalificacion" TabIndex="22" ValidationGroup="ObservacionCierre"  Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-floppy-disk"></span> Guardar
                                        </asp:LinkButton>     
                          <asp:LinkButton ID="Btn_VolverCierreCalificacion" TabIndex="23" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-arrow-left"></span> Volver
                                        </asp:LinkButton>                   
                        </section>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </article>
        <footer></footer>
    </form>
</body>
</html>
<%--	© 2016 Ricardo Lara C1842--%>

