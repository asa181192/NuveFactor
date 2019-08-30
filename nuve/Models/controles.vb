﻿Imports FactorEntidades

Public Class controles
    Inherits Controller

    Public Function CargaLiquidaCuenta(identidad As Integer, id As Integer, moneda As Integer) As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.CobranzaBAL()
        Dim sucursales = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaCuentaLiquidaAforoBAL(identidad, id, moneda, lista)

        If resultado.Ok And resultado IsNot Nothing Then
            sucursales = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.claveStr + " " + s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return sucursales

    End Function


    Function CargaAnexo(contrato As Integer) As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim anexo = New List(Of SelectListItem)
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaAnexoCtoBAL(contrato, lista)

        If resultado.Ok And resultado IsNot Nothing Then
            anexo = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.claveStr + " " + s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return anexo
    End Function


	Public Function CargaProveedores(listaDeudor As List(Of Integer)) As List(Of SelectListItem)
		Dim resultado
		Dim consulta = New FactorBAL.CobranzaBAL()
		Dim sucursales = New List(Of SelectListItem)()
		Dim lista = New List(Of DropDownEntidad)

		resultado = consulta.CargaProveedoresBAL(lista, listaDeudor)

		If resultado.Ok And resultado IsNot Nothing Then
			sucursales = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

		Else
			resultado.Mensaje = "Ocurrio un error al consultar la informacion"
		End If

		Return sucursales

	End Function
    Public Function CargaSucursales() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim sucursales = New List(Of SelectListItem)()
        Dim lista = New List(Of SucursalEntidad)

        resultado = consulta.ConsultaSucursalBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
			sucursales = lista.Select(Function(s) New SelectListItem With {.Value = s.sucursal1, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return sucursales

    End Function
    Public Function CargaRegimen() As List(Of SelectListItem)

        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 0,
                                              .Text = "Exento"
                                            },
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Tasa de IVA al 0%"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Tasa de IVA al 11%"
                                              },
                            New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "Tasa de IVA al 16%"
                                              }
                                           }).ToList()
    End Function
    Public Function CargaCodigoGarantia() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim sucursales = New List(Of SelectListItem)()
        Dim lista = New List(Of CodigoGarantiaEntidad)

        resultado = consulta.ConsultaCodigoGarantiaBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
            sucursales = lista.Select(Function(s) New SelectListItem With {.Value = s.codigoid, .Text = s.nombre}).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return sucursales

    End Function
    Public Function CargaTipoGarantia() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim garantia = New List(Of SelectListItem)()
        Dim lista = New List(Of TipoGarantiaEntidad)

        resultado = consulta.ConsultaTipoGarantiaBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
            garantia = lista.Select(Function(s) New SelectListItem With {.Value = s.tipoid, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return garantia

    End Function
    Public Function CargaPromotores(promprod As Boolean) As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim promotor = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaPromotorBAL(promprod, lista)

        If resultado.Ok And resultado IsNot Nothing Then
            promotor = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return promotor

    End Function
    Public Function CargaGrupos() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim grupos = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaGrupoEmpresarialBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
            grupos = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return grupos

    End Function
    Public Function CargaCiudades() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim ciudades = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaCiudadesBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
            ciudades = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return ciudades

    End Function
    Public Function CargaEstados() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim estados = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaEstadosBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
            estados = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return estados

    End Function
    Public Function CargaPerfiles() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim perfiles = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaPerfilBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
			perfiles = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()
			perfiles.Where(Function(x) x.Value = "6").SingleOrDefault().Selected = True
        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return perfiles

    End Function
    Public Function CargaSectorFinanciero() As List(Of SelectListItem)

        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 11,
                                              .Text = "GOBIERNO FEDERAL"
                                              },
                            New SelectListItem() With {
                                              .Value = 12,
                                              .Text = "DEPARTAMENTO DEL D.F."
                                              },
                            New SelectListItem() With {
                                              .Value = 13,
                                              .Text = "GOBIERNOS ESTATALES Y MUNICIPALES"
                                              },
                            New SelectListItem() With {
                                              .Value = 14,
                                              .Text = "ORG. DESCENTRALIZADOS Y EMP. DE PARTICIPACION ESTATAL"
                                            },
                            New SelectListItem() With {
                                              .Value = 21,
                                              .Text = "BANCO DE MEXICO"
                                            },
                            New SelectListItem() With {
                                              .Value = 22,
                                              .Text = "BANCO DE DESARROLLO"
                                            },
                            New SelectListItem() With {
                                              .Value = 23,
                                              .Text = "BANCA MULTIPLE"
                                            },
                            New SelectListItem() With {
                                              .Value = 25,
                                              .Text = "OTRAS ENTIDADES FINANCIERAS DEL SECTOR PUBLICO"
                                            },
                            New SelectListItem() With {
                                              .Value = 26,
                                              .Text = "OTRAS ENTIDADES FINANCIERAS DEL SECTOR PRIVADO"
                                            },
                            New SelectListItem() With {
                                              .Value = 31,
                                              .Text = "EMPRESAS"
                                            },
                            New SelectListItem() With {
                                              .Value = 32,
                                              .Text = "PARTICULARES"
                                            },
                            New SelectListItem() With {
                                              .Value = 41,
                                              .Text = "INSTITUCIONES FINANCIERAS DEL EXTRANJERO"
                                            },
                            New SelectListItem() With {
                                              .Value = 42,
                                              .Text = "EMPRESAS NO FINANCIERAS Y PARTICULARES DEL EXTRANJERO"
                                            }
                                           }).ToList()
    End Function
    Public Function CargaSectorEconomico() As List(Of SelectListItem)

        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "INDUSTRIA"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "COMERCIO"
                                              },
                            New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "SERVICIO"
                                              },
                            New SelectListItem() With {
                                              .Value = 4,
                                              .Text = "OTROS"
                                            }
                                           }).ToList()
    End Function
    Public Function CargaGiro() As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.Manager()
        Dim giros = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.ConsultaGirosBAL(lista)

        If resultado.Ok And resultado IsNot Nothing Then
            giros = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()

        Else
            resultado.Mensaje = "Ocurrio un error al consultar la informacion"
        End If

        Return giros

    End Function
    Public Function CargaCalCliente() As List(Of SelectListItem)

        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "A-1"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "A-2"
                                              },
                            New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "B-1"
                                              },
                            New SelectListItem() With {
                                              .Value = 4,
                                              .Text = "B-2"
                                            },
                            New SelectListItem() With {
                                              .Value = 5,
                                              .Text = "B-3"
                                            },
                            New SelectListItem() With {
                                              .Value = 6,
                                              .Text = "C-1"
                                            },
                            New SelectListItem() With {
                                              .Value = 7,
                                              .Text = "C-2"
                                            },
                            New SelectListItem() With {
                                              .Value = 8,
                                              .Text = "D"
                                            },
                            New SelectListItem() With {
                                              .Value = 9,
                                              .Text = "E"
                                            }
                                           }).ToList()
    End Function
    Public Function CargaRelacion() As List(Of SelectListItem)

        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 0,
                                              .Text = "No Relacionada"
                                              },
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Personas físicas y morales que tengan mas del 1% del capital de la institución o de la sociedad controladora del grupo financiero al que pertenezca la institución"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Miembros del consejo de administración (propietarios y suplentes) de la institución o de la sociedad controladora del grupo financiero al que pertenece la institución"
                                              },
                            New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "Cónyuges y personas que tengan parentesco por consanguinidad o afinidad civil hasta el segundo grado con las personas separadas en las claves 1 y 2."
                                            },
                            New SelectListItem() With {
                                              .Value = 4,
                                              .Text = "Personas distintas a los funcionarios o empleados que con su firma puedan obligar a la institución."
                                            },
                            New SelectListItem() With {
                                              .Value = 5,
                                              .Text = "Personas morales, así como consejeros y funcionarios de éstas, en las que la institución detente directa o indirectamente el control de 10% o más de los títulos representativos del capital."
                                            },
                            New SelectListItem() With {
                                              .Value = 6,
                                              .Text = "Personas Morales en las que cualesquiera de las personas separadas en las fracciones anteriores así como la fracc. VI art. 106 en que la institución detecte directa o indirectamente el control del 10% o mas de los títulos representativos del capital."
                                            }
                                           }).ToList()
    End Function
    Public Function CargaRelevante() As List(Of SelectListItem)

        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 0,
                                              .Text = "No"
                                              },
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Si"
                                              }
                                           }).ToList()
    End Function
    Public Function CargaClasifica() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 0,
                                              .Text = "Bajo Riesgo"
                                              },
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Alto Riesgo"
                                              }
                                           }).ToList()
    End Function
    Public Function CargaFelectronica() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Correo Electrónico"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Copia Impresa"
                                              },
                            New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "Consulta por internet"
                                              }
                                           }).ToList()
    End Function
    Public Function CargaDias() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Domingo"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Lunes"
                                              },
                            New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "Martes"
                                              },
                            New SelectListItem() With {
                                              .Value = 4,
                                              .Text = "Miercoles"
                                              },
                            New SelectListItem() With {
                                              .Value = 5,
                                              .Text = "Jueves"
                                              },
                            New SelectListItem() With {
                                              .Value = 6,
                                              .Text = "Viernes"
                                              },
                            New SelectListItem() With {
                                              .Value = 7,
                                              .Text = "Sabado"
                                              }
                                           }).ToList()
    End Function
    Public Function CargaDivisa() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "MXN"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "DLLS"
                                              }
                                           }).ToList()
    End Function
    Public Function Cargatipointeres() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Anticipado"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Mensual Vencido"
                                              },
                             New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "Al Vencimiento"
                                              }
                                           }).ToList()
    End Function

    Public Function cargaBancos() As List(Of SelectListItem)

        Dim resultado
        Dim consulta = New FactorBAL.DropDownBAL()
        Dim bancos = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.obtenerBancosBAL(lista)

        If resultado.ok And resultado IsNot Nothing Then

            bancos = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).OrderBy(Function(s) s.Text).ToList()


        Else
            resultado.mensaje = "Ocurrio un error al consultar la información"

        End If

        Return bancos

    End Function
    Public Function cargaWebBancos() As List(Of SelectListItem)

        Dim resultado
        Dim consulta = New FactorBAL.DropDownBAL()
        Dim bancos = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.obtenerWebBancosBAL(lista)

        If resultado.ok And resultado IsNot Nothing Then

            bancos = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).ToList()


        Else
            resultado.mensaje = "Ocurrio un error al consultar la información"

        End If

        Return bancos

    End Function
    Public Function CargaCuentas() As List(Of SelectListItem)

        Dim resultado
        Dim consulta = New FactorBAL.DropDownBAL()
        Dim cuentas = New List(Of SelectListItem)()
        Dim lista = New List(Of DropDownEntidad)

        resultado = consulta.obtenerCuentasBAL(lista)

        If resultado.ok And resultado IsNot Nothing Then
            cuentas = lista.Select(Function(s) New SelectListItem With {.Value = s.clave, .Text = s.nombre}).ToList()

            If cuentas.Count > 0 Then
                cuentas(0).Selected = True

            End If

        Else
            resultado.mensaje = "Ocurrio un error la consultar la información"

        End If

        Return cuentas

    End Function
    Public Function CargaIndicadores() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Cetes 28"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Cetes 91"
                                              },
                            New SelectListItem() With {
                                              .Value = 3,
                                              .Text = "CPP"
                                              },
                            New SelectListItem() With {
                                              .Value = 4,
                                              .Text = "TIPP"
                                              },
                            New SelectListItem() With {
                                              .Value = 5,
                                              .Text = "TIIE"
                                              },
                            New SelectListItem() With {
                                              .Value = 6,
                                              .Text = "TIIE 91"
                                              },
                            New SelectListItem() With {
                                              .Value = 7,
                                              .Text = "FONDEO"
                                              },
                            New SelectListItem() With {
                                              .Value = 7,
                                              .Text = "LIBOR"
                                              },
                            New SelectListItem() With {
                                              .Value = 7,
                                              .Text = "LIBOR 3M"
                                              },
                            New SelectListItem() With {
                                              .Value = 7,
                                              .Text = "FONDEO USD"
                                              }
                                           }).ToList()
    End Function
    Public Function CargaTipoEsq() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Tradicional"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Descuentos / Mermas"
                                              }
                                           }).ToList()
    End Function
    Public Function CargaGarantias() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
                            New SelectListItem() With {
                                              .Value = 1,
                                              .Text = "Obligado solidario"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Prendaria"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Hipotecaria"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Fianzas de crédito"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Otro tipo de garantía"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Sin garantía"
                                              },
                            New SelectListItem() With {
                                              .Value = 2,
                                              .Text = "Seguro de crédito"
                                              }
                                           }).ToList()
    End Function

    Function CargaConceptos(tipo As String) As List(Of SelectListItem)
        Dim resultado
        Dim consulta = New FactorBAL.FacturacionBAL()
        Dim conceptos = New List(Of SelectListItem)()
        Dim lista = New List(Of cfiscales)

        resultado = consulta.CargaConceptosBAL(lista, tipo)

        If resultado.ok And resultado IsNot Nothing Then
            conceptos = lista.Select(Function(x) New SelectListItem With {.Value = x.tipo, .Text = x.descrip}).ToList()

            If conceptos.Count > 0 Then
                conceptos(0).Selected = True
            End If
        Else
            resultado.mensaje = "Ocurrio un error la consultar la información"
        End If

        Return conceptos
    End Function

    Function CargaSeries() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
            New SelectListItem() With {.Value = "A", .Text = "A"}}).ToList()
    End Function

    Function CargaIdentidad() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
            New SelectListItem() With {.Value = 1, .Text = "Cliente"},
            New SelectListItem() With {.Value = 2, .Text = "Proveedor"},
            New SelectListItem() With {.Value = 3, .Text = "Comprador"}
                                           }).ToList()
    End Function

	Function CargaDocumentos() As List(Of SelectListItem)
		Return New List(Of SelectListItem)({
			New SelectListItem() With {.Value = "A", .Text = "A - Facturas"},
			New SelectListItem() With {.Value = "B", .Text = "B - Notas de Crédito"},
			New SelectListItem() With {.Value = "C", .Text = "C - Notas de Cargo"},
			New SelectListItem() With {.Value = "D", .Text = "D - Remisiones"}
										   }).ToList()
	End Function

    Function CargaVigencias() As List(Of SelectListItem)

        Dim vigencias = New List(Of SelectListItem)

        For value As Integer = 0 To 120

            Dim x = New SelectListItem

            If value > 120 Then
                Exit For
            Else
                x.Value = value

                If value = 1 Then
                    x.Text = value & " Mes"
                Else
                    x.Text = value & " Meses"
                End If

                vigencias.Add(x)
            End If
        Next

        Return vigencias

    End Function

    Function CargaPeriodos() As List(Of SelectListItem)
        Return New List(Of SelectListItem)({
            New SelectListItem() With {.Value = 1, .Text = "Mensual"},
            New SelectListItem() With {.Value = 2, .Text = "Bimestral"},
            New SelectListItem() With {.Value = 3, .Text = "Trimestral"},
            New SelectListItem() With {.Value = 4, .Text = "Cuatrimestral"},
            New SelectListItem() With {.Value = 6, .Text = "Semestral"},
            New SelectListItem() With {.Value = 12, .Text = "Anual"}
                                           })
    End Function

    Function CargaAseguradoras() As List(Of SelectListItem)
        Dim consulta = New FactorBAL.AseguradorasBAL()
        Dim aseguradoras = New List(Of SelectListItem)
        Dim lista = New List(Of aseguradora)

        consulta.ConsultaAseguradorasBAL(lista)

        aseguradoras = lista.Select(Function(x) New SelectListItem With {.Value = x.idaseguradora, .Text = x.nombre}).ToList()

        If aseguradoras.Count > 0 Then
            aseguradoras(0).Selected = True
        End If

        Return aseguradoras
    End Function




   



End Class
