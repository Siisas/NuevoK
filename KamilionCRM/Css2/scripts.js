var $_$ = jQuery.noConflict();
/***************validar raiz**************/
var Raiz = '/';
if (Val_Url(Raiz + window.location.pathname.split('/')[1].split('.')[0] + '/default.aspx')) {
    Raiz = Raiz + window.location.pathname.split('/')[1] + '/'
};
var CCP_Interval;

if ($_$.datepicker) {
    $_$.datepicker.regional['es-CO'] = {
        "Name": "es-CO",
        "closeText": "Cerrar",
        "prevText": "Atras",
        "nextText": "Adelante",
        "currentText": "Hoy",
        "monthNames": ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", ""],
        "monthNamesShort": ["Ene", "Feb", "Mar", "Abr", "May", "Jn", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic", ""],
        "dayNames": ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
        "dayNamesShort": ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"],
        "dayNamesMin": ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sá"],
        "dateFormat": "dd/mm/yy",
        "firstDay": 0,
        "isRTL": false
    };
    $_$.datepicker.setDefaults($_$.datepicker.regional['es-CO']);
};

    function pageLoad(sender, args) {
    	try {
                    /*Sección que gestiona los inputs file*/
            $_$('.input-group .lbl-input-file').val('');
            $_$(document).on('change', ':file', function() {
                var input = $_$(this),
                    numFiles = input.get(0).files ? input.get(0).files.length : 1,
                    label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
                input.trigger('fileselect', [numFiles, label]);
            });
            $_$(':file').on('fileselect', function(event, numFiles, label) {
                var input = $_$(this).parents('.input-group').find(':text'),
                    log = numFiles > 1 ? numFiles + ' files selected' : label;

                if( input.length ) {
                    input.val(log);
                }
            });
            /*****************************************/ 

            
	        if ($_$('.Fecha').length) {
	         	$_$(".Fecha").datepicker({
	                changeMonth: true,
	                changeYear: true,
	                dateFormat: 'dd/mm/yy',
	                showAnim: "show"
	         	}).val();
	      	};
	      	if ($_$('.Hora').length) {
	         	$_$(".Hora").timepicker({
	                timeFormat: 'hh:mm',
	                showAnim: "show"
	         	});
	    	};
	        if ($_$('.HoraFecha').length) {
	            $_$('.HoraFecha').datetimepicker({
	           		changeMonth: true,
	                changeYear: true,
	                dateFormat: 'dd/mm/yy',
	                timeFormat: 'hh:mm',
	                showAnim: "show"
	         	});
	      	};
            if ($_$('.HoraSegundo').length) {
	            $_$('.HoraSegundo').timepicker({
	                timeFormat: 'hh:mm:ss',
	                showAnim: "show",
                    showSecond: true
	            });
	        };

	        //validar desplegables
	        if ($_$('.Desplegable').length) {
	     		Pleg_Esc();
	     		if ($_$('#Desp_Loading')) {
	        		$_$('.Desplegar_Loading').off('click').click(function () {
	           			try{
	              			var ValidationGroup = $_$(this).attr('onclick').split('(')[2].split(',')[3].replace(/"/gi, '').trim()
	                  		if (Page_ClientValidate(ValidationGroup)) {
	                  			Despleg_Loading();
	              			}
	           			}catch (ex) {
	           				if($_$(this).attr('ValidationGroup')){
           						var ValidationGroup = $_$(this).attr('ValidationGroup')
		                  		if (Page_ClientValidate(ValidationGroup)) {
		                  			Despleg_Loading();
		              			}	
           					}else{
           						Despleg_Loading();
           					}
       					}
	            	});
	         	};
	         	if ($_$('#Desp_Calif').length) {
	             	$_$('#Plegar_Form_Calif').off('click').click(function () {
	                 	PlegDes_Dinamico("#Desp_Calif", "slide", '', '', '');
	         		});
	     		};
	        };
	        /*ajustar tamaño de cajas de texto*/
	        for (var i = 0; i < $_$('.input-group > .input-group-addon').length; i++) {
	            if($_$('.input-group:eq('+i+') > .input-group-addon:eq(0)').height() > 20){
	                $_$('.input-group:eq('+i+') > .form-control').height($_$('.input-group:eq('+i+') > .input-group-addon:eq(0)').height());
	            }
	        };
	        if (typeof LocalpageLoad !== 'undefined' && jQuery.isFunction(LocalpageLoad)) {
	            LocalpageLoad(sender, args);
	        };
            try {   
                if (!args._isPartialLoad) {
                    //if (Raiz + 'default.aspx' == window.location.pathname) {
                        $_$('#Pop_Up_Cas_Prog #Btn_Hiden').off('click').click(function () {
                            $_$('#Pop_Up_Cas_Prog').slideUp();
                            $_$('#DBtn_Show_Pop_Up').slideDown();
                        })
                        $_$('#DBtn_Show_Pop_Up').off('click').click(function () {
                            $_$('#Pop_Up_Cas_Prog').slideDown();
                            $_$('#DBtn_Show_Pop_Up').slideUp();
                        })
//                        Cons_Cas_Prog();
//                        CCP_Interval = setInterval(function () { Cons_Cas_Prog(); }, 125000);
                    //};
                };
            } catch (ex) {
                Ex_Pop_Up(ex);
            };
            if ($_$('.material-switch').length) {
                $_$('.material-switch').each(function () {
                    if ($_$(this).find('label.label-success').length && $_$(this).find('input[type="checkbox"]').length) {
                        $_$(this).find('label.label-success').attr('for', $_$(this).find('input[type="checkbox"]').attr('id'))
                    }
                });
            };
        }catch (ex) {
        	$_$('#Pnl_Message').attr('class', 'alert alert-danger');
            $_$('#Lbl_Mensage').html('<span class="glyphicon glyphicon-remove-sign"></span> ' + ex.message);      
        };
    };
/*###############Seccion plegable#################*/
    function PlegDes_Dinamico(Tool, Efect, SubEfect, Duration, Aliv) {
        if (Efect == 'show') {
            if ($_$(Tool).is(':visible')) {
                $_$(Tool).hide(SubEfect, Duration, Aliv);
            } else {
                $_$(Tool).show(SubEfect, Duration, Aliv);
            };
        };
        if (Efect == 'slide') {
            if ($_$(Tool).is(':visible')) {
                $_$(Tool).slideUp(Duration, Aliv);
            } else {
                $_$(Tool).slideDown(Duration, Aliv);
            };
        };
    };
    function Pleg_Esc() {
     	$_$(document).bind('keydown', function (e) {
         	if (e.which == 27) {
            	if ($_$("#Desp_Loading").is(":visible")) {
                   	Pleg_Loading();
            	}else{
                   	if ($_$(".Desplegable").is(":visible")) {
                      	$_$(".Desplegable").hide();
                   	}
            	}
         	}
  		});
    };
    function Pleg_Loading(){
		$_$("#Desp_Loading").hide("puff", 500);
    };
    function Pleg_Loading1() {
        $_$("#Desp_Loading").hide("puff", 500);
    };
	function Despleg_Loading(){
		$_$("#Desp_Loading").show("puff", 500);
	};
/*###########Sección de grid###############*/
/*###########Sección de grid###############*/
    function Data_Grid(Input_Data) {
        try{
            /*download('json consulta.txt', JSON.stringify(Input_Data))*/
            $_$(Input_Data.Grid.Config.Container).show();
            /*rectificado datetie*/
            for (var i = Input_Data.Grid.Data.length - 1; i >= 0; i--) {
                for (var item in Input_Data.Grid.Data[i]) {
                    if (RegExp('^(/Date\(\))').test(Input_Data.Grid.Data[i][item])){
                        //quitar barras y convertir a datetime
                        Input_Data.Grid.Data[i][item] = new Date(Number(Input_Data.Grid.Data[i][item].replace(/\/Date\((-?\d+)\)\//,/$1/).replace(/\//gi,''))).format('dd/MM/yyyy HH:mm:ss');
                    };
                };
            };

            /*renderizado de columnas*/
            for (var i = Input_Data.Grid.Format.Columns.length - 1; i >= 0; i--) {
                if (!Input_Data.Grid.Format.Columns[i].columntype) {
                    Input_Data.Grid.Format.Columns[i].cellsrenderer = function (row, column, value) {return '<span Class="Cell-Grid">' + value + '</span>'};
                };
            };
              /*generar herramientas*/
            function Gerenate_Tool(i, Grid){
                if (Input_Data[Grid].Format.Columns[i].type=='button' ) {
                    var Event = Input_Data[Grid].Format.Columns[i].onclick;
                    var TextTool = Input_Data[Grid].Format.Columns[i].textool;
                    Input_Data[Grid].Format.Columns[i].createwidget =  function (row, column, value, htmlElement) {
                        var Val_Prin = $_$(value).html();
                        if (!Val_Prin) {
                            Val_Prin = value
                        };
                        $_$(htmlElement).addClass('btn btn-primary');
                        $_$(htmlElement).css('font-weight', 'bold');
                        $_$(htmlElement).attr('onclick', Event+"('"+Val_Prin+"')");
                        $_$(htmlElement).html(TextTool);
                    };
                    Input_Data[Grid].Format.Columns[i].initwidget = function (row, column, value, htmlElement) {
                        $_$(htmlElement).attr("onclick", Event+"('"+value+"')");
                    };
                }
            };
            var Width = '100%';
            var Heigth = 61;
            if (Input_Data.Grid.Config.ShowFilter) {
                Heigth = 91;
            };
            if (Input_Data.Grid.Data.length <= 3) {
                Heigth = Heigth + 25
            };
            /*Datos de data grid secundario*/
            var Rowdetails = false;
            if (Input_Data.Sub_Grid) {

                            /*rectificado datetie*/
                for (var i = Input_Data.Sub_Grid.Data.length - 1; i >= 0; i--) {
                    for (var item in Input_Data.Sub_Grid.Data[i]) {
                        if (RegExp('^(/Date\(\))').test(Input_Data.Sub_Grid.Data[i][item])) {
                            //quitar barras y convertir a datetime
                            Input_Data.Sub_Grid.Data[i][item] = new Date(Number(Input_Data.Sub_Grid.Data[i][item].replace(/\/Date\((-?\d+)\)\//, /$1/).replace(/\//gi, ''))).format('dd/MM/yyyy HH:mm:ss');
                        };
                    };
                };

                /*Ajustar altura de tabla principal*/
                Heigth = 271;
                for (var i = 0; i < Input_Data.Grid.Data.length-7; i++) {
                    if (Heigth<Input_Data.Grid.Config.MaxHeigth) {
                        Heigth= Heigth+30;
                    };
                };
                /*###############*/
                Rowdetails = true;
                /*Renderizado de columnas de grid secundario*/
                for (var i = Input_Data.Sub_Grid.Format.Columns.length - 1; i >= 0; i--) {
                    Input_Data.Sub_Grid.Format.Columns[i].cellsrenderer = function (row, column, value) {return '<span Class="Cell-SubGrid">' + value + '</span>'};
                };
                /*herramientas de lelección grid anidado*/
                for (var i = 0; i < Input_Data.Sub_Grid.Format.Columns.length; i++) {
                    if (Input_Data.Sub_Grid.Format.Columns[i].onclick) {
                        Gerenate_Tool(i, 'Sub_Grid')
                    }
                }
            }else{
                for (var i = 0; i < Input_Data.Grid.Data.length -1; i++) {
                    if (Heigth < Input_Data.Grid.Config.MaxHeigth) {
                        Heigth = Heigth+30;
                    }
                };
            };
            /*herramientas de selección grid principal*/
            for (var i = 0; i < Input_Data.Grid.Format.Columns.length; i++) {
                if (Input_Data.Grid.Format.Columns[i].onclick) {
                    Gerenate_Tool(i, 'Grid')
                }
            };
            /*Funcion para crear detalles de grid*/
            var Sub_Grid = function (index, parentElement, gridElement, record) {
                /*###Capturar Grid###*/
                var grid = $_$($_$(parentElement).children()[0]);
                var Sub_Data = [];
                for (var m = 0; m < Input_Data.Sub_Grid.Data.length; m++) {
                    if (record[Input_Data.Grid.Format.Keys.Primary].toString() == Input_Data.Sub_Grid.Data[m][Input_Data.Sub_Grid.Format.Keys.Foreign].toString()){
                        Sub_Data.push(Input_Data.Sub_Grid.Data[m]);
                    }
                };
                /*#######Preparar sub datos##########*/
                if (grid != null) {
                    var SubSource = { 
                        datafields: Input_Data.Sub_Grid.Format.Datafields,
                        id: Input_Data.Sub_Grid.Format.Keys.Primary,
                        localdata: Sub_Data
                    };
                    var SubDataAdapter = new $_$.jqx.dataAdapter(SubSource);
                    grid.jqxGrid({
                        source: SubDataAdapter, 
                        width: '90%', 
                        height: 181,
                        columnsresize: true,
                        filterable: Input_Data.Sub_Grid.Config.Filterable,
                        showfilterrow: Input_Data.Sub_Grid.Config.ShowFilter,
                        selectionmode: 'multiplecellsextended',
                        sortable: true,
                        editable: Input_Data.Sub_Grid.Config.Editable,
                        columns: Input_Data.Sub_Grid.Format.Columns,
                        rowsheight: 30,
                    });
                };
            };
            /*######Generar Datagrid Principal######*/
            var Source = {
                datafields: Input_Data.Grid.Format.Datafields,
                localdata: Input_Data.Grid.Data,
                datatype: "array",
                id: Input_Data.Grid.Format.Keys.Primary,
            };
            var DataAdapter = new $_$.jqx.dataAdapter(Source);
            $_$(Input_Data.Grid.Config.Container).jqxGrid({
                width: '100%',
                height: Heigth,
                columnsresize: true,
                selectionmode: 'multiplecellsextended',
                sortable: true,
                editable: Input_Data.Grid.Config.Editable,
                filterable: Input_Data.Grid.Config.Filterable,
                rowsheight: 30,
                showfilterrow: Input_Data.Grid.Config.ShowFilter,
                source: DataAdapter,
                columns: Input_Data.Grid.Format.Columns,
                rowdetails: Rowdetails,
                initrowdetails: Sub_Grid,
                rowdetailstemplate: {
                    rowdetails: "<div id='grid' style='margin: 0 Auto; border: 2px solid #B3C556;'></div>", 
                    rowdetailsheight: 185, 
                    rowdetailshidden: true 
                },
            });
            //$_$(Input_Data.Grid.Config.Container).jqxWindow();
            
            $_$(Input_Data.Grid.Config.Container).css('z-index', 2);
        }catch (ex){
            throw ex
        };
    };

function download(filename, text) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    element.setAttribute('download', filename);
    element.style.display = 'none';
    document.body.appendChild(element);
    element.click();
    document.body.removeChild(element);
}

/*********GESTIONA LOS PANELES DESPLEGABLES************/
function GridViewSI(ID) {
    $_$(ID).attr("class", "panel_desplegable2");
};
function GridViewNO(ID) {
    $_$(ID).attr("class", "panel_desplegable");
};
function GridViewPOINT(ID) {
    $_$(ID).css("animation", "bounce 2000ms  ease-out");
};
function GridViewNOPOINT(ID) {
    $_$(ID).css("animation", "none");
}
/******************************************************/
/**************Validar URL*************************/
    function Val_Url(url) {
        var http = new XMLHttpRequest();
        http.open('HEAD', url, false);
        http.send();
        return http.status != 404;
    }
/*gestionar objeto devuelto por vb.net*/
    function Val_ObjVb(Obj) {
        try {
            if (typeof (Obj) == 'string') {
                var Exp = /^\/Date\((\d*)\)\/$/.exec(Obj)
                if (Exp) {
                    Obj = new Date(+Exp[1]);
                }
            } else if (typeof (Obj) == 'object') {
                for (var i in Obj) {
                    if (typeof (Obj[i]) == 'string') {
                        var Exp = /^\/Date\((\d*)\)\/$/.exec(Obj[i])
                        if (Exp) {
                            Obj[i] = new Date(+Exp[1]);
                        }
                    } else if (typeof (Obj[i]) == 'object') {
                        Obj[i] = Val_ObjVb(Obj[i])
                    };
                }
            };
            return Obj
        } catch (ex) {
            throw ex
        };
    }
/*********seción pop up********************************/
    function Cons_Cas_Prog() {
        try {
            var Cas_Prog = Cookies_To_Object().Casos_Programados;
            if (typeof Cas_Prog === 'object' && Object.prototype.toString.call(Cas_Prog.Hora) === '[object Date]' && Cas_Prog.Hora >= new Date(new Date().setMinutes(new Date().getMinutes() - 15))) {
                Val_Cas_Prog(Cas_Prog)
            } else {
                document.cookie = "Casos_Programados=;expires=Thu, 01 Jan 1970 00:00:01 GMT;";
                Limpiar_Pop_up()
                $_$.ajax({
                    type: "POST",
                    url: Raiz + "default.aspx/Pop_Up_Cas_Prog",
                    async: true,
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        try {
                            if (typeof (response.d) === 'object') {
                                document.cookie = "Casos_Programados=" + encodeURI(JSON.stringify(Val_ObjVb(response.d), dateTimeDiscourage))
                                var Cas_Prog = Cookies_To_Object().Casos_Programados;
                                if (typeof Cas_Prog === 'object' && Object.prototype.toString.call(Cas_Prog.Hora) === '[object Date]') {
                                    Val_Cas_Prog(Cas_Prog)
                                } else {
                                    throw { message: "La consulta de casos programados no cumple con los parámetros" };
                                };
                            };
                        } catch (ex) {
                            Ex_Pop_Up(ex);
                        }
                    },
                    error: function (result) {
                        Ex_Pop_Up(result);
                    }
                });
            }
        } catch (ex) {
            Ex_Pop_Up(ex);
        };
    };
    function Val_Cas_Prog(Obj) { //valida casos programados
        try {
            var date = new Date()
            var Hora_Min = new Date(date.setMinutes(date.getMinutes() - 10))//el caso debe tener no más de 10 minutos
            date = new Date()
            var Hora_Max = new Date(date.setMinutes(date.getMinutes() + 20))//el caso debe estar entre los proximos 20 minutos
            date = new Date()
            var HUV_Min = new Date(date.setMinutes(date.getMinutes() - 2))//el popup debe tener más de 2 minuto desde la última ves que apareció
            for (var i in Obj.Dtt) {
                if (((Object.prototype.toString.call(Obj.HUV) === '[object Date]' && Obj.HUV < HUV_Min) || Object.prototype.toString.call(Obj.HUV) !== '[object Date]') && (Obj.Dtt[i].Hora_Prog >= Hora_Min && Obj.Dtt[i].Hora_Prog <= Hora_Max) && Obj.Dtt[i].Check == false) {
                    if ($_$('#Pop_Up_Cas_Prog').is(':visible') && $_$('#Pop_Up_Cas_Prog #Txt_Codigo').html() == Obj.Dtt[i].Id_Caso_Prog) {
                        setTimeout(function () {
                            Audio_Alerta('Pollux.ogg');
                            $_$('#Pop_Up_Cas_Prog').css({ 'animation': 'Brum 80ms infinite', 'opacity': '1' });
                            setTimeout(function () {
                                $_$('#Pop_Up_Cas_Prog').css({ 'animation': '', 'opacity': '0.3' });
                            }, 1000);
                        }, 200);
                    } else if (!$_$('#Pop_Up_Cas_Prog').is(':visible') || $_$('#Pop_Up_Cas_Prog #Txt_Codigo').html() != Obj.Dtt[i].Id_Caso_Prog) {
                        Limpiar_Pop_up()
                        $_$('#Pop_Up_Cas_Prog #Txt_Bandeja').html(Obj.Dtt[i].Bandeja_Prog)
                        $_$('#Pop_Up_Cas_Prog #Txt_Codigo').html(Obj.Dtt[i].Id_Caso_Prog)
                        $_$('#Pop_Up_Cas_Prog #Txt_Hora').html(Obj.Dtt[i].Hora_Prog.format('HH:mm:ss'))
                        $_$('#Pop_Up_Cas_Prog').slideDown();
                        setTimeout(function () {
                            Audio_Alerta('Pollux.ogg');
                            $_$('#Pop_Up_Cas_Prog').css({ 'animation': 'Brum 80ms infinite', 'opacity': '1' });
                            setTimeout(function () {
                                $_$('#Pop_Up_Cas_Prog').css({ 'animation': '', 'opacity': '0.3' });
                            }, 1000);
                        }, 200);
                        $_$('#Pop_Up_Cas_Prog #Btn_Ok').off('click').click(function () {
                            try {
                                var Obj2 = Cookies_To_Object().Casos_Programados;
                                if (typeof Obj2 === 'object') {
                                    for (var indx in Obj2.Dtt) {
                                        if (Obj2.Dtt[indx].Id_Caso_Prog === Obj.Dtt[i].Id_Caso_Prog) {
                                            Obj2.Dtt[indx].Check = true
                                            delete Obj2.HUV
                                            document.cookie = "Casos_Programados=" + encodeURI(JSON.stringify((Obj2), dateTimeDiscourage))
                                            Limpiar_Pop_up()
                                            Cons_Cas_Prog()
                                            break
                                        }
                                    }
                                } else {
                                    throw 'no hay cookie para validar'
                                };

                            } catch (ex) {
                                Ex_Pop_Up(ex)
                            };
                            
                        })
                    };
                    Obj["HUV"] = new Date()
                    document.cookie = "Casos_Programados=" + encodeURI(JSON.stringify(Val_ObjVb(Obj), dateTimeDiscourage))
                    break
                };
            };
        } catch (ex) {
            throw ex
        };
    };
    function Ex_Pop_Up(ex) {
        if (typeof (CCP_Interval) != 'undefined') {
            clearInterval(CCP_Interval);
        };
        $_$('#Pop_Up_Cas_Prog .input-group, #Pop_Up_Cas_Prog #Btn_Ok, #Pop_Up_Cas_Prog .Subtitulos').hide();
        $_$('#Pop_Up_Cas_Prog #Ex_Pop_Up').show();
        if (typeof (ex.message) != 'undefined') {
            $_$('#Pop_Up_Cas_Prog #Ex_Pop_Up').html('Internal Client Error! ' + ex.message);
        } else if (typeof ex.responseJSON != 'undefined') {
            $_$('#Pop_Up_Cas_Prog #Ex_Pop_Up').html(ex.statusText + '! ' + ex.responseJSON.Message);
        } else if (typeof ex == 'string') {
            $_$('#Pop_Up_Cas_Prog #Ex_Pop_Up').html('Internal Client Error! ' + ex);
        } else {
            $_$('#Pop_Up_Cas_Prog #Ex_Pop_Up').html('Internal Client Error! no se pudo determinar le objeto de la excepción');
        };
        $_$('#Pop_Up_Cas_Prog').slideDown();
        setTimeout(function () {
            Audio_Alerta('Pollux.ogg');
            $_$('#Pop_Up_Cas_Prog').css({ 'animation': 'Brum 80ms infinite', 'opacity': '1' });
            setTimeout(function () {
                $_$('#Pop_Up_Cas_Prog').css({ 'animation': '', 'opacity': '0.3' });
            }, 1000);
        }, 200);
    };
    function Limpiar_Pop_up() {
        try {
            if ($_$('#Pop_Up_Cas_Prog').is(':visible')) {
                $_$('#Pop_Up_Cas_Prog').slideUp();
            };
            if ($_$('#DBtn_Show_Pop_Up').is(':visible')) {
                $_$('#DBtn_Show_Pop_Up').slideUp();
            };
            $_$('#Pop_Up_Cas_Prog .input-group, #Pop_Up_Cas_Prog #Btn_Ok, #Pop_Up_Cas_Prog .Subtitulos').show();
            $_$('#Pop_Up_Cas_Prog #Ex_Pop_Up').hide();
            $_$('#Pop_Up_Cas_Prog #Ex_Pop_Up').html('');
            $_$('#Pop_Up_Cas_Prog #Txt_Bandeja').html('');
            $_$('#Pop_Up_Cas_Prog #Txt_Codigo').html('');
            $_$('#Pop_Up_Cas_Prog #Txt_Hora').html('');
        } catch (ex) {
            throw ex;
        };
    };
    function Audio_Alerta(Obj) {
        try {
            if (typeof (Obj) != 'undefined') {
                var audioe = document.createElement("audio");
                audioe.src = Raiz + 'Css2/Alertas/' + Obj;
                audioe.onloadeddata = function () {
                    audioe.play();
                }
            };
        } catch (ex) {
            throw ex
        };
    }
    /*devuelve un objeto de las cookie almacenadas*/
    function Cookies_To_Object() {
        try {
            var ArrayCookies = document.cookie.split(';');
            var ObjCookies = new Object();
            for (var i in ArrayCookies) {
                var Cookie = ArrayCookies[i];
                while (Cookie.charAt(0) == ' ') Cookie = Cookie.substring(1, Cookie.length);
                var SplitCookie = Cookie.split('=');
                SplitCookie[0] = decodeURI(SplitCookie[0])
                try {
                    ObjCookies[SplitCookie[0]] = JSON.parse(decodeURI(SplitCookie[1]), dateTimeReviver);
                } catch (ex) {
                    ObjCookies[SplitCookie[0]] = decodeURI(SplitCookie[1])
                }
            }
            return ObjCookies;
        } catch (ex) {
            throw ex
        }
    };
    function dateTimeReviver(key, value) {
        var Exp = /^\/Date\((\d*)\)\/$/.exec(value);;
        if (typeof value === 'string') {
            if (Exp) {
                return new Date(+Exp[1]);
            }
        }
        return value;
    };
    function dateTimeDiscourage(key, Obj) {
        try {
            if (Object.prototype.toString.call(Obj) === '[object Date]') {
                Obj = '/Date(' + Obj.getTime() + ')/';
            } else if (typeof Obj === 'object') {
                for (var i in Obj) {
                    if (Object.prototype.toString.call(Obj[i]) === '[object Date]') {
                        Obj[i] = '/Date(' + Obj[i].getTime() + ')/';
                    }
                }
            }
            return Obj;
        } catch (ex) {
            throw ex
        }
    };

   function PlegDespleg(Tool, Action, Efect, SubEfect, Duration, Aliv) {
            if (Action.toUpperCase() == 'Despleg'.toUpperCase()) {
                if (!$_$(Tool).is(':visible')) {
                    if (Efect.toUpperCase() == 'Show'.toUpperCase()) {
                        $_$(Tool).show(SubEfect, Duration, Aliv);
                    } else if (Efect.toUpperCase() == 'Slide'.toUpperCase()) {
                        $_$(Tool).slideDown(Duration, Aliv);
                    };
                };
            } else if (Action.toUpperCase() == 'pleg'.toUpperCase()) {
                if ($_$(Tool).is(':visible')) {
                    if (Efect.toUpperCase() == 'Show'.toUpperCase()) {
                        $_$(Tool).hide(SubEfect, Duration, Aliv);
                    } else if (Efect.toUpperCase() == 'Slide'.toUpperCase()) {
                        $_$(Tool).slideUp(Duration, Aliv);
                    };
                };
            };
            
        };