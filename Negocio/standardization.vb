Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports DataLayer
Imports DataLayer.arrendadoraDL

Namespace arrendadora
  Public MustInherit Class standardization

    Private Enum attrName
      Nombre = 1
      Tipo = 2
      Valor = 3
    End Enum

    Protected Class xmlfile
      Public Property name() As String
      Public Property value() As String
    End Class

    Protected Camposxml As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Protected xmllist As List(Of xmlfile)

    Protected Const EXPR_START As String = "¶"
    Protected Const OUT_BEGIN As String = "={$O+}"
    Protected Const OUT_END As String = "{$O-}"

    Protected tiposTexto As List(Of String) = New List(Of String)({"Char", "String"})
    Protected tiposNumero As List(Of String) = New List(Of String)({"Int16", "Int32", "Int64", "UInt16", "UInt32", "UInt64", "Decimal", "Byte", "Single", "SByte", "Double", "Integer", "Long", "Short", "UInteger", "ULong", "UShort"})
    Protected tiposFecha As List(Of String) = New List(Of String)({"Date", "DateTime"})

    Public Sub New()
      Me.loadxmldescriptions()
    End Sub

#Region "NORMALIZACION"
    Protected Sub loadxmldescriptions()
      Me.xmllist = New List(Of xmlfile)
      Me.xmllist.Add(New xmlfile With {.name = "cliente",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<cliente> " & _
                                                " <origen name='Origen' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <cliente_id name='Cliente' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <pfisica name='Pfisica' type='bit' def='true' nullable='false' /> " & _
                                                " <nombre name='Nombre' type='char' def='' nullable='false' /> " & _
                                                " <n name='N' type='text' def='' nullable='false' /> " & _
                                                " <s name='S' type='text' def='' nullable='false' /> " & _
                                                " <p name='P' type='text' def='' nullable='false' /> " & _
                                                " <m name='M' type='text' def='' nullable='false' /> " & _
                                                " <rfc name='Rfc' type='char' def='' nullable='false' /> " & _
                                                " <domicilio name='Domicilio' type='char' def='' nullable='true' /> " & _
                                                " <colonia name='Colonia' type='char' def='' nullable='true' /> " & _
                                                " <cp name='Cp' type='int' def='0' nullable='false' /> " & _
                                                " <municipio name='Municipio' type='char' def='' nullable='false' /> " & _
                                                " <estado name='Estado' type='char' def='' nullable='false' /> " & _
                                                " <telefono name='Telefono' type='char' def='' nullable='false' /> " & _
                                                " <email name='Email' type='char' def='' nullable='false' /> " & _
                                                "	<promotor name='Promotor' type='int' def='0' nullable='false' /> " & _
                                                " <promo_cve name='' type='char' def='' nullable='false' /> " & _
                                                " <fec_alta name='Fec_Alta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_baja name='' type='datetime' def='' nullable='false' /> " & _
                                                " <cltedesde name='ClteDesde' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <contactos name='Contactos' type='text' def='' nullable='false' /> " & _
                                                " <riesgo name='Riesgo' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <actividad name='Actividad' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <notas name='Notas' type='text' def='' nullable='false' /> " & _
                                                " <bnc_dump name='Bnc_dump' type='text' def='' nullable='false' /> " & _
                                                " <aval name='Aval' type='bit' def='false' nullable='false' /> " & _
                                                " <pfempre name='Pfempre' type='bit' def='false' nullable='false' /> " & _
                                                " <banx_activ name='Banx_activ' type='decimal' def='0' nullable='false' /> " & _
                                                " <banx_calif name='Banx_calif' type='char' def='' nullable='false' /> " & _
                                                " <curp name='Curp' type='char' def='' nullable='false' /> " & _
                                                " <pais name='Pais' type='int' def='0' nullable='false' /> " & _
                                                " <extranjero name='Extranjero' type='bit' def='false' nullable='false' /> " & _
                                                " <pexpuesto name='Pexpuesto' type='bit' def='false' nullable='false' /> " & _
                                                " <altoriesgo name='Altoriesgo' type='bit' def='false' nullable='false' /> " & _
                                                " <numemp name='Numemp' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <nip name='' type='int' def='' nullable='false' /> " & _
                                                " <accionista name='Accionista' type='bit' def='false' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <id_unico name='id_unico' type='char' def='' nullable='true' /> " & _
                                                " <sepomex name='sepomex' type='char' def='' nullable='true' /> " & _
                                                " <ingresos name='Ingresos' type='money' def='0.00' nullable='true' /> " & _
                                                " <numext name='numext' type='char' def='' nullable='true' /> " & _
                                                " <numint name='numint' type='char' def='' nullable='true' /> " & _
                                                " <activo name='activo' type='money' def='0.00' nullable='true' /> " & _
                                                " <pasivo name='pasivo' type='money' def='0.00' nullable='true' /> " & _
                                                " <capital name='capital' type='money' def='0.00' nullable='true' /> " & _
                                                " <calle name='calle' type='char' def='' nullable='true' /> " & _
                                                " <edocivil name='edocivil' type='int' def='0' nullable='true' /> " & _
                                                " <identificacion name='identificacion' type='int' def='0' nullable='true' /> " & _
                                                " <tipovivienda name='tipovivienda' type='int' def='0' nullable='true' /> " & _
                                                " <ife name='' type='char' def='' nullable='true' /> " & _
                                                " <TEL name='' type='char' def='' nullable='true' /> " & _
                                                " <login_name name='Login_Name' type='char' def='' nullable='true' /> " & _
                                                " <xfer name='Xfer' type='bit' def='false' nullable='true' /> " & _
                                                " <nbrclientecs name='' type='int' def='' nullable='true' /> " & _
                                                " <tiposociedad name='tiposociedad' type='int' def='0' nullable='true' /> " & _
                                                " <sociedad name='sociedad' type='char' def='' nullable='true' /> " & _
                                                " <subactiv name='subactiv' type='numeric' def='0' nullable='true' /> " & _
                                                " <Riesgopld name='riesgopld' type='int' def='0' nullable='true' /> " & _
                                                " <fecbalance name='fecbalance' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <cveprebc name='' type='char' def='' nullable='true' /> " & _
                                                " <relacion name='relacion' type='bit' def='false' nullable='true' /> " & _
                                                " <sececo name='sececo' type='int' def='1' nullable='true' /> " & _
                                                " <grupo name='' type='int' def='' nullable='true' /> " & _
                                                " <bnc_reporte name='bnc_reporte' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <bnc_folio name='bnc_folio' type='nchar' def='' nullable='true' /> " & _
                                                " <bnc_max_retraso name='bnc_max_retraso' type='int' def='0' nullable='true' /> " & _
                                                " <bnc_max_dias name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <cnbv_loca name='' type='char' def='' nullable='true' /> " & _
                                                " <relacion_tipo name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <relacion_juridico name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <digito_control name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <cve_consolida name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <historia_fecha_max name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <historia_vigente_max name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <historia_vencido_max name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <fec_edores name='fec_edores' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <nbrchequera name='nbrchequera' type='char' def='' nullable='true' /> " & _
                                                " <metpago name='metpago' type='int' def='0' nullable='true' /> " & _
                                                " <patron name='patron' type='char' def='' nullable='true' /> " & _
                                                " <etiquetas name='' type='char' def='' nullable='true' /> " & _
                                                " <desbloqueado name='' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <pagodomici name='pagodomici' type='bit' def='{null}' nullable='true' /> " & _
                                                " <pais_actual name='pais_actual' type='int' def='0' nullable='true' /> " & _
                                                " <ingre_neto name='ingre_neto' type='money' def='0' nullable='true' /> " & _
                                                " <cnbvloca2016 name='' type='char' def='{null}' nullable='true' /> " & _
                                                " <fecha_variables name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <pagos_infonavit name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <numemp_a1 name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <numemp_a1_total name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <numemp_a2 name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <numemp_a2_total name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <numemp_a3 name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <numemp_a3_total name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <mercado_proveedores name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <mercado_clientes name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <edos_finan_auditados name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <no_agencias_calificadoras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <ind_consejo_admon name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <estructura_org name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <comp_accionaria name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <tipoentidad name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <segm_inst_finan name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <diversificacion_negocio_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <diversificacion_finaciamiento_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <top3_acreditados_financieras name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <consejeros_indep_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <consejeros_total_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <comp_accionaria_financieras name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <solvencia_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <liquidez_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <eficiencia_financiera name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <calidad_gobierno_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <experiencia_funcionarios_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <existencia_politicas_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <edo_financieros_audit_financieras name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <metpagocta name='' type='char' def='' nullable='true' /> " & _
                                                " <bloqvarcual name='' type='text' def='' nullable='true' /> " & _
                                                " <patron_pais name='' type='int' def='23' nullable='true' /> " & _
                                                " <fecreportado name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <ccc_previos name='' type='char' def='' nullable='true' /> " & _
                                                " <ocupacion name='' type='text' def='' nullable='true' /> " & _
                                                " <seriefiel name='' type='text' def='' nullable='true' /> " & _
                                                " <tieneproveedor name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <proveedores name='' type='text' def='' nullable='true' /> " & _
                                                " <espropietarioreal name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <propietarios name='' type='text' def='' nullable='true' /> " & _
                                                " <puestopublico name='' type='text' def='' nullable='true' /> " & _
                                                " <trabajo name='' type='text' def='' nullable='true' /> " & _
                                                " <padre name='' type='text' def='' nullable='true' /> " & _
                                                " <madre name='' type='text' def='' nullable='true' /> " & _
                                                " <hijos name='' type='text' def='' nullable='true' /> " & _
                                                " <conyugue name='' type='text' def='' nullable='true' /> " & _
                                                " <hermanos name='' type='text' def='' nullable='true' /> " & _
                                                " <pexpuestoasimilado name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <pepasimilado name='' type='text' def='' nullable='true' /> " & _
                                                " <peprelacion name='' type='text' def='' nullable='true' /> " & _
                                                " <pmfideicomiso name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <enlistas name='' type='char' def='' nullable='true' /> " & _
                                                "</cliente> "
                                      })

      Me.xmllist.Add(New xmlfile With {.name = "contrato",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<contrato> " & _
                                                " <origen name='Origen' type='decimal' def='0' nullable='false' /> " & _
                                                " <oficina name='Oficina' type='decimal' def='0' nullable='false' /> " & _
                                                " <cliente name='' type='int' def='0' nullable='false' /> " & _
                                                " <linea name='Linea' type='int' def='0' nullable='false' /> " & _
                                                " <riesgo name='' type='money' def='0' nullable='false' /> " & _
                                                " <actual name='actual' type='money' def='0' nullable='false' /> " & _
                                                " <caratula name='' type='decimal' def='0' nullable='false' /> " & _
                                                " <modalidad name='Modalidad' type='int' def='0' nullable='false' /> " & _
                                                " <solicitado name='Solicitado' type='money' def='0' nullable='false' /> " & _
                                                " <autorizado name='Autorizado' type='money' def='0' nullable='false' /> " & _
                                                " <ejercido name='Saldotot' type='money' def='0' nullable='false' /> " & _
                                                " <i_libre name='I_libre' type='money' def='0' nullable='false' /> " & _
                                                " <i_gravado name='I_gravado' type='money' def='0' nullable='false' /> " & _
                                                " <depanual name='' type='decimal' def='' nullable='false' /> " & _
                                                " <depmens name='' type='money' def='0' nullable='false' /> " & _
                                                " <rentota name='' type='money' def='0' nullable='false' /> " & _
                                                " <inttota name='' type='money' def='0' nullable='false' /> " & _
                                                " <ivatota name='' type='money' def='0' nullable='false' /> " & _
                                                " <renmens name='Renmens' type='money' def='0' nullable='false' /> " & _
                                                " <ivaanti name='Ivaanti' type='money' def='0' nullable='false' /> " & _
                                                " <ivamens name='Ivamens' type='money' def='0' nullable='false' /> " & _
                                                " <paganti name='Paganti' type='money' def='0' nullable='false' /> " & _
                                                " <ivapaganti name='Ivapaganti' type='money' def='0' nullable='false' /> " & _
                                                " <pagdife name='Pagdife' type='money' def='0' nullable='false' /> " & _
                                                " <ivapagdif name='' type='money' def='' nullable='false' /> " & _
                                                " <seguro name='Seguro' type='money' def='0' nullable='false' /> " & _
                                                " <pzoseguro name='PzoSeguro' type='int' def='0' nullable='false' /> " & _
                                                " <plazo name='Plazo' type='int' def='0' nullable='false' /> " & _
                                                " <ultpag name='' type='int' def='' nullable='false' /> " & _
                                                " <responsabe name='Responsabe' type='int' def='0' nullable='false' /> " & _
                                                " <promotor name='Promotor' type='int' def='0' nullable='false' /> " & _
                                                " <pro_clave name='' type='char' def='' nullable='false' /> " & _
                                                " <pro_comi name='Pro_comi' type='decimal' def='0' nullable='false' /> " & _
                                                " <pcompgda name='' type='bit' def='' nullable='false' /> " & _
                                                " <pcomiape name='Pcomiape' type='decimal' def='0' nullable='false' /> " & _
                                                " <comiape name='Comiape' type='money' def='0' nullable='false' /> " & _
                                                " <ivacomi name='Ivacomi' type='money' def='0' nullable='false' /> " & _
                                                " <raticto name='Raticto' type='money' def='0' nullable='false' /> " & _
                                                " <ratictoiva name='Ratictoiva' type='money' def='0' nullable='true' /> " & _
                                                " <ratimodi name='Ratimodi' type='bit' def='false' nullable='false' /> " & _
                                                " <endoso name='Endoso' type='bit' def='false' nullable='false' /> " & _
                                                " <desc_bien name='Descrip' type='text' def='' nullable='true' /> " & _
                                                " <desc_cara name='Desc_cara' type='text' def='' nullable='false' /> " & _
                                                " <tasa name='Tasa' type='decimal' def='0' nullable='false' /> " & _
                                                " <tasaa name='' type='decimal' def='' nullable='false' /> " & _
                                                " <margen name='Margen' type='decimal' def='0' nullable='false' /> " & _
                                                " <margena name='' type='decimal' def='' nullable='false' /> " & _
                                                " <factor name='Factor' type='decimal' def='0' nullable='false' /> " & _
                                                " <fondeo name='Fondeo' type='decimal' def='0' nullable='false' /> " & _
                                                " <pnafinsa name='Pnafinsa' type='decimal' def='0' nullable='false' /> " & _
                                                " <tasaiva name='Tasaiva' type='decimal' def='0' nullable='false' /> " & _
                                                " <tasamora name='Tasamora' type='decimal' def='0' nullable='false' /> " & _
                                                " <pena name='Pena' type='money' def='0' nullable='false' /> " & _
                                                " <poriva name='Poriva' type='decimal' def='0' nullable='false' /> " & _
                                                " <nrendepo name='Nrendepo' type='decimal' def='0' nullable='true' /> " & _
                                                " <rendepo name='Rendepo' type='money' def='0' nullable='false' /> " & _
                                                " <ivarndpo name='Ivarndpo' type='money' def='0' nullable='false' /> " & _
                                                " <ivarndpcap name='Ivarndpcap' type='money' def='0' nullable='false' /> " & _
                                                " <dia_intp name='Dia_intp' type='decimal' def='0' nullable='false' /> " & _
                                                " <int_prop name='Int_prop' type='money' def='0' nullable='false' /> " & _
                                                " <iva_intp name='Iva_intp' type='money' def='0' nullable='false' /> " & _
                                                " <popccomp name='Popccomp' type='decimal' def='0' nullable='false' /> " & _
                                                " <opccompra name='Opccompra' type='money' def='0' nullable='false' /> " & _
                                                " <ivaopcomp name='Ivaopcomp' type='money' def='0' nullable='false' /> " & _
                                                " <tipoactivo name='Tipoactivo' type='int' def='0' nullable='false' /> " & _
                                                " <notas name='Notas' type='text' def='' nullable='false' /> " & _
                                                " <aval1 name='Aval1' type='char' def='' nullable='false' /> " & _
                                                " <tel_aval1 name='Tel_aval1' type='char' def='' nullable='false' /> " & _
                                                " <dom_aval1 name='Dom_aval1' type='text' def='' nullable='false' /> " & _
                                                " <amoral1 name='Amoral1' type='bit' def='false' nullable='false' /> " & _
                                                " <aval2 name='Aval2' type='char' def='' nullable='false' /> " & _
                                                " <tel_aval2 name='Tel_aval2' type='char' def='' nullable='false' /> " & _
                                                " <dom_aval2 name='Dom_aval2' type='text' def='' nullable='false' /> " & _
                                                " <avales name='Avales' type='text' def='' nullable='false' /> " & _
                                                " <amoral2 name='Amoral2' type='bit' def='false' nullable='false' /> " & _
                                                " <fec_altc name='Fecalta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_inic name='Fecini' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_soli name='Fecsoli' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_canc name='Fecbaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_auto name='Fecauto' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_rech name='Fecrech' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_ejer name='' type='datetime' def='' nullable='false' /> " & _
                                                " <cancelado name='Cancelado' type='decimal' def='0' nullable='false' /> " & _
                                                " <login_name name='Login_name' type='char' def='' nullable='false' /> " & _
                                                " <fec_fond name='Fec_fond' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_cesi name='Fec_cesi' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_cesioc name='Fec_cesioc' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <cliente_oc name='Cliente_oc ' type='decimal' def='0' nullable='false' /> " & _
                                                " <fecxmit name='Fecxmit' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <estado name='' type='int' def='0' nullable='true' /> " & _
                                                " <fec_enot name='' type='datetime' def='' nullable='false' /> " & _
                                                " <fec_rnot name='' type='datetime' def='' nullable='false' /> " & _
                                                " <alta_cont name='' type='bit' def='' nullable='false' /> " & _
                                                " <redoc name='reestruct' type='bit' def='' nullable='false' /> " & _
                                                " <camb_clte name='Camb_Clte' type='bit' def='false' nullable='false' /> " & _
                                                " <cve_aval name='' type='bit' def='' nullable='false' /> " & _
                                                " <flag_cont name='' type='bit' def='' nullable='false' /> " & _
                                                " <flag_paga name='' type='bit' def='' nullable='false' /> " & _
                                                " <flag_fact name='' type='bit' def='' nullable='false' /> " & _
                                                " <flag_segu name='' type='bit' def='' nullable='false' /> " & _
                                                " <flag_recha name='' type='bit' def='' nullable='false' /> " & _
                                                " <flag_escritura name='' type='bit' def='' nullable='false' /> " & _
                                                " <fec_inirev name='' type='datetime' def='' nullable='false' /> " & _
                                                " <fec_finrev name='' type='datetime' def='' nullable='false' /> " & _
                                                " <gtia_hipo name='' type='bit' def='' nullable='false' /> " & _
                                                " <gtia_prend name='' type='bit' def='' nullable='false' /> " & _
                                                " <gtia_memo name='' type='text' def='' nullable='false' /> " & _
                                                " <moneda name='Moneda' type='decimal' def='0' nullable='false' /> " & _
                                                " <folio name='Folio' type='char' def='' nullable='false' /> " & _
                                                " <expand name='' type='datetime' def='' nullable='false' /> " & _
                                                " <historia name='' type='char' def='' nullable='false' /> " & _
                                                " <fec_bnc name='' type='datetime' def='' nullable='false' /> " & _
                                                " <baja_bnc name='' type='datetime' def='' nullable='false' /> " & _
                                                " <name_auto name='Name_auto' type='char' def='' nullable='false' /> " & _
                                                " <q_concepto name='' type='text' def='' nullable='false' /> " & _
                                                " <q_importe name='' type='money' def='0' nullable='false' /> " & _
                                                " <q_anexos name='' type='text' def='' nullable='false' /> " & _
                                                " <q_gestion name='' type='text' def='' nullable='false' /> " & _
                                                " <q_login name='' type='char' def='' nullable='false' /> " & _
                                                " <notaregsol name='' type='text' def='' nullable='false' /> " & _
                                                " <voiid name='' type='bit' def='' nullable='false' /> " & _
                                                " <calcmora name='Calcmora' type='char' def='' nullable='false' /> " & _
                                                " <revperso name='' type='text' def='' nullable='false' /> " & _
                                                " <fec_cesirat name='' type='datetime' def='' nullable='false' /> " & _
                                                " <linea_nafin name='' type='int' def='' nullable='true' /> " & _
                                                " <original name='Original' type='int' def='0' nullable='true' /> " & _
                                                " <rebate name='Rebate' type='money' def='0' nullable='true' /> " & _
                                                " <ctoventa name='ctoventa' type='int' def='0' nullable='true' /> " & _
                                                " <fecventa name='' type='datetime' def='' nullable='true' /> " & _
                                                " <anexo name='anexo' type='int' def='0' nullable='true' /> " & _
                                                " <nbrlineacs name='' type='char' def='' nullable='true' /> " & _
                                                " <credito name='Credito' type='int' def='0' nullable='true' /> " & _
                                                " <creditonum name='' type='char' def='' nullable='true' /> " & _
                                                " <clabe name='' type='char' def='' nullable='true' /> " & _
                                                " <ctabanco name='' type='char' def='' nullable='true' /> " & _
                                                " <ctaroli name='' type='char' def='' nullable='true' /> " & _
                                                " <fecincum name='' type='datetime' def='' nullable='true' /> " & _
                                                " <adelantado name='' type='bit' def='' nullable='true' /> " & _
                                                " <sofi name='' type='bit' def='' nullable='true' /> " & _
                                                " <contranexo name='contranexo' type='char' def='' nullable='true' /> " & _
                                                " <fecautbaja name='Fecautbaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <renta_anti name='renta_anti' type='bit' def='false' nullable='true' /> " & _
                                                " <folio_gtia name='' type='char' def='' nullable='true' /> " & _
                                                " <folio_anti name='Folio_anti' type='char' def='' nullable='true' /> " & _
                                                " <depo_gtia name='' type='money' def='0' nullable='true' /> " & _
                                                " <condi_esp name='condi_esp' type='text' def='' nullable='true' /> " & _
                                                " <cto_texto name='cto_texto' type='text' def='' nullable='true' /> " & _
                                                " <com_prepag name='' type='numeric' def='0' nullable='true' /> " & _
                                                " <pasivo name='' type='int' def='0' nullable='true' /> " & _
                                                " <dias name='' type='int' def='0' nullable='true' /> " & _
                                                " <antiprov name='antiprov' type='bit' def='false' nullable='true' /> " & _
                                                " <sececo name='sececo' type='int' def='0' nullable='true' /> " & _
                                                " <digito_control name='' type='int' def='' nullable='true' /> " & _
                                                " <capsanual name='capsanual' type='int' def='0' nullable='true' /> " & _
                                                " <folio_ci name='folio_ci' type='char' def='' nullable='true' /> " & _
                                                " <fecha_ci name='fecha_ci' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <valor_ci name='valor_ci' type='money' def='0' nullable='true' /> " & _
                                                " <metpago name='metpago' type='int' def='0' nullable='true' /> " & _
                                                " <idcnbv name='' type='char' def='' nullable='true' /> " & _
                                                " <fec_reestructura name='' type='datetime' def='' nullable='true' /> " & _
                                                " <fec_adju name='' type='datetime' def='' nullable='true' /> " & _
                                                " <fec_propio name='' type='datetime' def='' nullable='true' /> " & _
                                                " <Iva_util name='iva_util' type='money' def='0' nullable='true' /> " & _
                                                " <fec_juicio name='' type='datetime' def='' nullable='true' /> " & _
                                                " <pagodomici name='pagodomici' type='bit' def='false' nullable='true' /> " & _
                                                " <metpagocta name='metpagocta' type='char' def='0' nullable='true' /> " & _
                                                " <fec_firma name='' type='datetime' def='' nullable='true' /> " & _
                                                " <fec_pagprom name='' type='datetime' def='' nullable='true' /> " & _
                                                " <depconti name='' type='money' def='0' nullable='true' /> " & _
                                                " <depcontiva name='' type='money' def='0' nullable='true' /> " & _
                                                " <fec_quebrancierre name='' type='datetime' def='' nullable='true' /> " & _
                                                " <fec_entrega name='' type='datetime' def='' nullable='true' /> " & _
                                                " <fondexcep name='' type='text' def='' nullable='true' /> " & _
                                                " <v_gtahipo name='v_gtahipo' type='int' def='0' nullable='true' /> " & _
                                                " <v_gtaprend name='v_gtaprend' type='money' def='0' nullable='true' /> " & _
                                                " <v_gtaliq name='v_gtaliq' type='money' def='0' nullable='true' /> " & _
                                                " <v_gtaotras name='v_gtaotras' type='money' def='0' nullable='true' /> " & _
                                                " <gtaliq name='' type='bit' def='' nullable='true' /> " & _
                                                " <gtaotras name='' type='bit' def='' nullable='true' /> " & _
                                                " <aviso_no name='aviso_no' type='int' def='0' nullable='true' /> " & _
                                                " <flag_custodia name='flag_custodia' type='bit' def='{null}' nullable='true' /> " & _
                                                " <engarantia name='engarantia' type='int' def='{null}' nullable='true' /> " & _
                                                " <fec_aviso name='fec_aviso' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <fec_autprom name='fec_autprom' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <mc_fecrecep name='mc_fecrecep' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <mc_fecrecepreal name='mc_fecrecepreal' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <mc_tr name='mc_tr' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <mc_nr name='mc_nr' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <mc_hi name='mc_hi' type='char' def='' nullable='true' /> " & _
                                                " <mc_hf name='mc_hf' type='char' def='' nullable='true' /> " & _
                                                " <nameautprint name='nameautprint' type='char' def='' nullable='true' /> " & _
                                                " <gtaprend name='gtaprend' type='bit' def='{null}' nullable='true' /> " & _
                                                " <pgastoinspeccion name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <gastoinspeccion name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <ivagastoinspeccion name='' type='money' def='{null}' nullable='true' /> " & _
                                                "</contrato>"})

      Me.xmllist.Add(New xmlfile With {.name = "oficina",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<oficina> " & _
                                                " <clave name='Clave' type='char' def='' nullable='false' /> " & _
                                                " <origen name='Origen' type='decimal' def='0' nullable='false' /> " & _
                                                " <oficina_id name='Oficina' type='decimal' def='0' nullable='false' /> " & _
                                                " <folio name='Folio' type='decimal' def='0' nullable='false' /> " & _
                                                " <nombre name='Nombre' type='char' def='' nullable='false' /> " & _
                                                " <tasaiva name='' type='decimal' def='' nullable='false' /> " & _
                                                " <s_domic name='' type='char' def='' nullable='false' /> " & _
                                                " <s_colonia name='' type='char' def='' nullable='false' /> " & _
                                                " <s_ciudad name='' type='char' def='' nullable='false' /> " & _
                                                " <s_emitido name='' type='char' def='' nullable='false' /> " & _
                                                " <c_domic name='' type='char' def='' nullable='false' /> " & _
                                                " <c_colonia name='' type='char' def='' nullable='false' /> " & _
                                                " <c_ciudad name='' type='char' def='' nullable='false' /> " & _
                                                " <c_municipio name='' type='char' def='' nullable='true' /> " & _
                                                " <c_estado name='' type='char' def='' nullable='true' /> " & _
                                                " <c_cp name='' type='int' def='' nullable='true' /> " & _
                                                " <representante name='' type='char' def='' nullable='false' /> " & _
                                                " <correo_repre name='' type='char' def='' nullable='false' /> " & _
                                                " <c_telefonos name='' type='text' def='' nullable='false' /> " & _
                                                " <print_ofic name='' type='bit' def='' nullable='false' /> " & _
                                                " <path_sucur name='' type='text' def='' nullable='false' /> " & _
                                                " <path_bnc_in name='' type='text' def='' nullable='false' /> " & _
                                                " <path_bnc_loaded name='' type='text' def='' nullable='false' /> " & _
                                                " <path_xch_out name='' type='text' def='' nullable='false' /> " & _
                                                " <path_xch_sent name='' type='text' def='' nullable='false' /> " & _
                                                " <bncgenera name='' type='bit' def='' nullable='false' /> " & _
                                                " <cons_in name='' type='int' def='' nullable='false' /> " & _
                                                " <cons_out name='' type='int' def='' nullable='false' /> " & _
                                                " <fec_cont name='' type='datetime' def='' nullable='false' /> " & _
                                                " <lista_conts name='' type='text' def='' nullable='false' /> " & _
                                                " <fec_tesore name='' type='datetime' def='' nullable='false' /> " & _
                                                " <expediente name='' type='char' def='' nullable='false' /> " & _
                                                " <ratifija name='Ratifija' type='decimal' def='0' nullable='false' /> " & _
                                                " <ratibase name='Ratibase' type='decimal' def='0' nullable='false' /> " & _
                                                " <ratimillar name='Ratimillar' type='decimal' def='0' nullable='false' /> " & _
                                                " <raticalc name='Raticalc' type='bit' def='false' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <u_cliente name='U_cliente' type='decimal' def='0' nullable='true' /> " & _
                                                " <u_refer name='' type='int' def='' nullable='true' /> " & _
                                                " <u_riesgo name='' type='int' def='' nullable='true' /> " & _
                                                " <u_poliza name='' type='int' def='' nullable='true' /> " & _
                                                " <u_demanda name='U_demanda' type='int' def='0' nullable='true' /> " & _
                                                " <u_etapa name='U_etapa' type='int' def='0' nullable='true' /> " & _
                                                " <u_abogado name='' type='int' def='0' nullable='true' /> " & _
                                                " <u_linea name='U_linea' type='int' def='0' nullable='true' /> " & _
                                                " <u_orden name='U_orden' type='int' def='0' nullable='true' /> " & _
                                                " <apoderado name='Apoderado' type='text' def='' nullable='true' /> " & _
                                                " <testigo1 name='Testigo1' type='text' def='' nullable='true' /> " & _
                                                " <testigo2 name='Testigo2' type='text' def='' nullable='true' /> " & _
                                                " <placas name='Placas' type='text' def='' nullable='true' /> " & _
                                                " <salidas name='Salidas' type='text' def='' nullable='true' /> " & _
                                                " <seguro name='Seguro' type='text' def='' nullable='true' /> " & _
                                                " <notarionum name='Notarionum' type='int' def='0' nullable='true' /> " & _
                                                " <notarionom name='Notarionom' type='text' def='' nullable='true' /> " & _
                                                " <notariociu name='Notariociu' type='text' def='' nullable='true' /> " & _
                                                " <jurisdic name='Jurisdic' type='text' def='' nullable='true' /> " & _
                                                " <serie_ini name='Serie_ini' type='char' def='' nullable='true' /> " & _
                                                " <serie_ncc name='Serie_ncc' type='char' def='' nullable='true' /> " & _
                                                " <chd_serie name='Chd_serie' type='char' def='' nullable='true' /> " & _
                                                " <u_notacc name='U_notacc' type='int' def='0' nullable='true' /> " & _
                                                " <u_numchd name='U_numchd' type='decimal' def='0' nullable='true' /> " & _
                                                " <u_folio name='U_folio' type='int' def='0' nullable='true' /> " & _
                                                " <com_prepag name='' type='numeric' def='' nullable='true' /> " & _
                                                " <cierrecont name='' type='bit' def='' nullable='true' /> " & _
                                                " <u_ficha name='' type='int' def='' nullable='true' /> " & _
                                                " <regional name='' type='int' def='' nullable='true' /> " & _
                                                " <correo_operativo name='' type='char' def='' nullable='true' /> " & _
                                                " <u_caratula name='' type='int' def='' nullable='true' /> " & _
                                                " <id_tren name='' type='int' def='' nullable='true' /> " & _
                                                " <corto name='' type='nchar' def='' nullable='true' /> " & _
                                                " <robot_sync name='' type='datetime' def='' nullable='true' /> " & _
                                                " <difhorario name='' type='int' def='' nullable='true' /> " & _
                                                " <id_plaza name='' type='int' def='' nullable='true' /> " & _
                                                " <division name='' type='char' def='' nullable='true' /> " & _
                                                " <cond_mora name='' type='int' def='' nullable='true' /> " & _
                                                " <u_credito name='' type='int' def='' nullable='true' /> " & _
                                                " <u_promotor name='' type='int' def='' nullable='true' /> " & _
                                                " <u_proveedor name='U_provedor' type='int' def='0' nullable='true' /> " & _
                                                " <u_factprov name='U_factura' type='int' def='0' nullable='true' /> " & _
                                                " <u_cfd name='' type='int' def='0' nullable='true' /> " & _
                                                " <fec_contra name='fec_cont' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <u_efactura name='U_efactura' type='int' def='0' nullable='true' /> " & _
                                                " <serie_efac name='Serie_efac' type='char' def='' nullable='true' /> " & _
                                                " <orden_region name='' type='int' def='' nullable='true' /> " & _
                                                " <run_process name='' type='bit' def='' nullable='true' /> " & _
                                                " <firma_cred name='' type='char' def='' nullable='true' /> " & _
                                                " <u_interfas name='' type='int' def='0' nullable='true' /> " & _
                                                " <puesto name='puesto' type='nchar' def='' nullable='true' /> " & _
                                                " <conomina name='conomina' type='nchar' def='' nullable='true' /> " & _
                                                "</oficina> "})

      Me.xmllist.Add(New xmlfile With {.name = "activo",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<activo> " & _
                                                " <activo name='activo' type='decimal' def='0' nullable='false' /> " & _
                                                " <linea name='linea' type='decimal' def='0' nullable='false' /> " & _
                                                " <marca name='marca' type='int' def='0' nullable='false' /> " & _
                                                " <articulo name='articulo' type='int' def='0' nullable='false' /> " & _
                                                " <serie name='serie' type='char' def='' nullable='false' /> " & _
                                                " <motor name='motor' type='char' def='' nullable='false' /> " & _
                                                " <cveveh name='cveveh' type='char' def='' nullable='false' /> " & _
                                                " <placas name='' type='char' def='' nullable='false' /> " & _
                                                " <modelo name='modelo' type='int' def='' nullable='false' /> " & _
                                                " <transp name='transp' type='bit' def='false' nullable='false' /> " & _
                                                " <fecalta name='fecalta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecbaja name='fecbaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <contacto name='contacto' type='text' def='' nullable='false' /> " & _
                                                " <domicilio name='domicilio' type='text' def='' nullable='false' /> " & _
                                                " <telefono name='telefono' type='text' def='' nullable='false' /> " & _
                                                " <notas name='notas' type='text' def='' nullable='false' /> " & _
                                                " <economico name='economico' type='char' def='' nullable='false' /> " & _
                                                " <estado name='estado' type='char' def='' nullable='false' /> " & _
                                                " <municipio name='municipio' type='char' def='' nullable='false' /> " & _
                                                " <login_name name='login_name' type='char' def='' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                "</activo>"})

      Me.xmllist.Add(New xmlfile With {.name = "cfd",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<cfd> " & _
                                                " <oficina name='Oficina' type='int' def='0' nullable='false' /> " & _
                                                " <cfd name='Cfd' type='int' def='0' nullable='false' /> " & _
                                                " <solicitud name='Solicitud' type='int' def='0' nullable='false' /> " & _
                                                " <linea name='Linea' type='int' def='0' nullable='false' /> " & _
                                                " <factura name='Factura' type='int' def='0' nullable='false' /> " & _
                                                " <folio name='Folio' type='char' def='' nullable='false' /> " & _
                                                " <proveedor name='Proveedor' type='int' def='0' nullable='false' /> " & _
                                                " <nombre name='Nombre' type='char' def='' nullable='false' /> " & _
                                                " <concepto name='Concepto' type='text' def='' nullable='false' /> " & _
                                                " <xml name='Xml' type='text' def='' nullable='false' /> " & _
                                                " <certificado name='Certificado' type='text' def='' nullable='false' /> " & _
                                                " <fec_alta name='fec_alta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_baja name='fec_baja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <login_name name='login_name' type='char' def='' nullable='false' /> " & _
                                                " <void name='' type='bit' def='0' nullable='false' /> " & _
                                                " <pdf name='' type='image' def='{null}' nullable='true' /> " & _
                                                " <xml2 name='' type='text' def='{null}' nullable='true' /> " & _
                                                " <xml3 name='' type='text' def='{null}' nullable='true' /> " & _
                                                " <valida1 name='' type='image' def='{null}' nullable='true' /> " & _
                                                " <valida2 name='' type='image' def='{null}' nullable='true' /> " & _
                                                "</cfd>"})

      Me.xmllist.Add(New xmlfile With {.name = "bnccon",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<bnccon> " & _
                                                " <solicitud name='' type='decimal' def='' nullable='false' /> " & _
                                                " <oficina name='' type='decimal' def='' nullable='false' /> " & _
                                                " <cliente name='' type='decimal' def='' nullable='false' /> " & _
                                                " <caratula name='' type='decimal' def='' nullable='false' /> " & _
                                                " <fisicas name='' type='bit' def='' nullable='false' /> " & _
                                                " <morales name='' type='bit' def='' nullable='false' /> " & _
                                                " <bncscore name='' type='bit' def='' nullable='false' /> " & _
                                                " <solicito name='' type='char' def='' nullable='false' /> " & _
                                                " <solicita name='' type='datetime' def='' nullable='false' /> " & _
                                                " <autorizo name='' type='char' def='' nullable='false' /> " & _
                                                " <autoriza name='' type='datetime' def='' nullable='false' /> " & _
                                                " <aborta name='' type='datetime' def='' nullable='false' /> " & _
                                                " <consulta name='' type='datetime' def='' nullable='false' /> " & _
                                                " <reporte name='' type='datetime' def='' nullable='false' /> " & _
                                                " <folio name='' type='char' def='' nullable='false' /> " & _
                                                " <notas name='' type='text' def='' nullable='false' /> " & _
                                                " <archivo name='' type='char' def='' nullable='false' /> " & _
                                                " <archivado name='' type='datetime' def='' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <max_retraso name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <max_dias name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <retraso_otorgante name='' type='char' def='' nullable='true' /> " & _
                                                " <retraso_tipocred name='' type='char' def='' nullable='true' /> " & _
                                                " <historia12 name='' type='char' def='' nullable='true' /> " & _
                                                " <retraso_contrato name='' type='char' def='' nullable='true' /> " & _
                                                " <historia_vigente_max name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <historia_vencida_max name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <historia_fecha_max name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <version name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <claveretorno name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <bk_12_clean name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <bk12_num_cred name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <bk12_num_tc_act name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <nbk12_num_cred name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <bk12_num_exp_paidontime name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <bk12_pct_promt name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <nbk12_pct_promt name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <bk12_pct_sat name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <nbk12_pct_sat name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <bk24_pct_60plus name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <nbk24_pct_60plus name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <nbk12_comm_pct_plus name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <bk12_pct_90plus name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <bk12_dpd_prom name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <bk12_ind_qcra name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <bk12_max_credit_amt name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <months_on_file_banking name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <months_since_last_open_banking name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <bk_ind_pmor name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <bk24_ind_exp name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <_12_inst name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <bk_deuda_tot name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <bk_deuda_cp name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <nbk_deuda_tot name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <nbk_deuda_cp name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <deuda_tot name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <deuda_tot_cp name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <bk12_ind_qcra_valida name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <fd_hit name='' type='bit' def='{null}' nullable='true' /> " & _
                                                " <sdo_vigente name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <sdo_d29 name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <sdo_d59 name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <sdo_d89 name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <sdo_d119 name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <sdo_d179 name='' type='money' def='{null}' nullable='true' /> " & _
                                                " <sdo_d180 name='' type='money' def='{null}' nullable='true' /> " & _
                                                "</bnccon>"})

      Me.xmllist.Add(New xmlfile With {.name = "cobranza",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<cobranza> " & _
                                                " <oficina name='oficina' type='int' def='0' nullable='false' /> " & _
                                                " <tipo name='tipo' type='char' def='' nullable='false' /> " & _
                                                " <folio name='folio' type='char' def='' nullable='false' /> " & _
                                                " <linea name='linea' type='int' def='' nullable='false' /> " & _
                                                " <pago name='pago' type='int' def='0' nullable='false' /> " & _
                                                " <plazo name='plazo' type='int' def='0' nullable='false' /> " & _
                                                " <cliente name='cliente' type='int' def='0' nullable='false' /> " & _
                                                " <nombre name='nombre' type='char' def='' nullable='true' /> " & _
                                                " <promotor name='promotor' type='int' def='0' nullable='false' /> " & _
                                                " <respons name='respons' type='int' def='0' nullable='false' /> " & _
                                                " <lote_no name='lote_no' type='int' def='0' nullable='false' /> " & _
                                                " <imp_orig name='imp_orig' type='money' def='0' nullable='false' /> " & _
                                                " <importe name='importe' type='money' def='0' nullable='false' /> " & _
                                                " <moratorios name='moratorios' type='money' def='0' nullable='false' /> " & _
                                                " <salinsan name='salinsan' type='money' def='0' nullable='false' /> " & _
                                                " <costamor name='costamor' type='money' def='0' nullable='false' /> " & _
                                                " <interes name='interes' type='money' def='0' nullable='false' /> " & _
                                                " <tasaa name='' type='decimal' def='' nullable='false' /> " & _
                                                " <ivacapital name='ivacapital' type='money' def='0' nullable='false' /> " & _
                                                " <iva_aplic name='iva_aplic' type='decimal' def='0' nullable='false' /> " & _
                                                " <fecven name='fecven' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecpago name='fecpago' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecante name='fecante' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecbaja name='fecbaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <concepto name='concepto' type='int' def='0' nullable='false' /> " & _
                                                " <eliminable name='eliminable' type='bit' def='false' nullable='false' /> " & _
                                                " <pagado name='pagado' type='bit' def='false' nullable='false' /> " & _
                                                " <login_name name='login_name' type='char' def='' nullable='false' /> " & _
                                                " <referencia name='referencia' type='char' def='' nullable='false' /> " & _
                                                " <sta_aviso name='sta_aviso' type='int' def='0' nullable='false' /> " & _
                                                " <fec_aviso name='fec_aviso' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <hora_aviso name='hora_aviso' type='char' def='' nullable='false' /> " & _
                                                " <resp_aviso name='resp_aviso' type='char' def='' nullable='false' /> " & _
                                                " <cont_aviso name='cont_aviso' type='char' def='' nullable='false' /> " & _
                                                " <congelado name='congelado' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <recibo name='recibo' type='text' def='' nullable='false' /> " & _
                                                " <desglose name='desglose' type='text' def='' nullable='false' /> " & _
                                                " <reimpreso name='reimpreso' type='int' def='0' nullable='false' /> " & _
                                                " <donde name='donde' type='int' def='0' nullable='false' /> " & _
                                                " <quebranto name='quebranto' type='bit' def='false' nullable='false' /> " & _
                                                " <aplicofact name='aplicofact' type='bit' def='false' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <contranexo name='contranexo' type='char' def='' nullable='true' /> " & _
                                                " <ivarta name='' type='money' def='0' nullable='true' /> " & _
                                                " <ivainsol name='' type='money' def='0' nullable='true' /> " & _
                                                " <rendepo name='' type='money' def='0' nullable='true' /> " & _
                                                " <Ivarndp name='' type='money' def='0' nullable='true' /> " & _
                                                " <Ivarndpcap name='' type='money' def='0' nullable='true' /> " & _
                                                " <ivaseg name='ivaseg' type='money' def='0' nullable='true' /> " & _
                                                " <ivacom_pp name='ivacom_pp' type='numeric' def='0' nullable='true' /> " & _
                                                " <cond_mora name='' type='text' def='' nullable='true' /> " & _
                                                "</cobranza>"})

      Me.xmllist.Add(New xmlfile With {.name = "control",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<control> " & _
                                                " <registro name='' type='int' def='' nullable='false' /> " & _
                                                " <compania name='' type='char' def='' nullable='false' /> " & _
                                                " <razon name='' type='char' def='' nullable='true' /> " & _
                                                " <rfc name='' type='char' def='' nullable='false' /> " & _
                                                " <domicilio name='' type='char' def='' nullable='false' /> " & _
                                                " <colonia name='' type='char' def='' nullable='false' /> " & _
                                                " <municipio name='' type='char' def='' nullable='false' /> " & _
                                                " <estado name='' type='char' def='' nullable='false' /> " & _
                                                " <cp name='' type='int' def='' nullable='false' /> " & _
                                                " <telefono name='' type='char' def='' nullable='false' /> " & _
                                                " <u_cliente name='' type='int' def='' nullable='false' /> " & _
                                                " <tasas name='' type='text' def='' nullable='false' /> " & _
                                                " <u_esquema name='' type='decimal' def='' nullable='false' /> " & _
                                                " <serie_fm name='' type='char' def='' nullable='false' /> " & _
                                                " <folio_fm name='' type='decimal' def='' nullable='false' /> " & _
                                                " <serie_rta name='' type='char' def='' nullable='false' /> " & _
                                                " <folio_rta name='' type='decimal' def='' nullable='false' /> " & _
                                                " <serie_oc name='' type='char' def='' nullable='false' /> " & _
                                                " <folio_oc name='' type='decimal' def='' nullable='false' /> " & _
                                                " <serie_la name='' type='char' def='' nullable='false' /> " & _
                                                " <folio_la name='' type='decimal' def='' nullable='false' /> " & _
                                                " <folio_poli name='' type='decimal' def='' nullable='false' /> " & _
                                                " <parametros name='' type='text' def='' nullable='false' /> " & _
                                                " <filltasas name='' type='text' def='' nullable='false' /> " & _
                                                " <fec_cont name='' type='datetime' def='' nullable='false' /> " & _
                                                " <fec_cobra name='' type='datetime' def='' nullable='false' /> " & _
                                                " <trustees name='' type='text' def='' nullable='false' /> " & _
                                                " <requer name='' type='decimal' def='' nullable='false' /> " & _
                                                " <marca name='' type='int' def='' nullable='false' /> " & _
                                                " <cargo name='' type='decimal' def='' nullable='false' /> " & _
                                                " <solicitud name='' type='decimal' def='' nullable='false' /> " & _
                                                " <abogado name='' type='decimal' def='' nullable='false' /> " & _
                                                " <demanda name='' type='decimal' def='' nullable='false' /> " & _
                                                " <etapa name='' type='decimal' def='' nullable='false' /> " & _
                                                " <stop_robot name='' type='bit' def='' nullable='false' /> " & _
                                                " <expand name='' type='bit' def='' nullable='false' /> " & _
                                                " <u_cuenta name='' type='int' def='' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <u_oficina name='' type='int' def='' nullable='false' /> " & _
                                                " <folio_ls name='' type='decimal' def='' nullable='false' /> " & _
                                                " <serie_ls name='' type='char' def='' nullable='false' /> " & _
                                                " <folio_ap name='' type='decimal' def='' nullable='false' /> " & _
                                                " <serie_ap name='' type='char' def='' nullable='false' /> " & _
                                                " <trusteesfora name='' type='text' def='' nullable='false' /> " & _
                                                " <fec_oper name='' type='datetime' def='' nullable='false' /> " & _
                                                " <cfd_source name='' type='text' def='' nullable='false' /> " & _
                                                " <cfd_certificate name='' type='ntext' def='' nullable='true' /> " & _
                                                " <cfd_privatekey name='' type='ntext' def='' nullable='true' /> " & _
                                                " <cfd_password name='' type='nchar' def='' nullable='true' /> " & _
                                                " <u_layclabe name='' type='int' def='' nullable='true' /> " & _
                                                " <fax name='' type='char' def='' nullable='true' /> " & _
                                                " <homepage name='' type='char' def='' nullable='true' /> " & _
                                                " <dominio name='' type='char' def='' nullable='true' /> " & _
                                                " <mailserver name='' type='text' def='' nullable='true' /> " & _
                                                " <ftpserver name='' type='text' def='' nullable='true' /> " & _
                                                " <dias_cont name='' type='char' def='' nullable='true' /> " & _
                                                " <rangoaviso name='' type='char' def='' nullable='true' /> " & _
                                                " <venceauto name='' type='decimal' def='' nullable='true' /> " & _
                                                " <vencseguro name='' type='decimal' def='' nullable='true' /> " & _
                                                " <pzomaxseg name='' type='decimal' def='' nullable='true' /> " & _
                                                " <mincruzado name='' type='decimal' def='' nullable='true' /> " & _
                                                " <opcongela name='' type='decimal' def='' nullable='true' /> " & _
                                                " <intevfp name='' type='bit' def='' nullable='true' /> " & _
                                                " <interfasnew name='' type='bit' def='' nullable='true' /> " & _
                                                " <exp_pass name='' type='decimal' def='' nullable='true' /> " & _
                                                " <hist_pass name='' type='decimal' def='' nullable='true' /> " & _
                                                " <len_pass name='' type='decimal' def='' nullable='true' /> " & _
                                                " <sens_pass name='' type='bit' def='' nullable='true' /> " & _
                                                " <login_attempts name='' type='decimal' def='' nullable='true' /> " & _
                                                " <op_relevnte name='' type='decimal' def='' nullable='true' /> " & _
                                                " <fira_dias name='' type='decimal' def='' nullable='true' /> " & _
                                                " <dom_border name='' type='text' def='' nullable='true' /> " & _
                                                " <col_border name='' type='text' def='' nullable='true' /> " & _
                                                " <cp_border name='' type='int' def='' nullable='true' /> " & _
                                                " <mpo_border name='' type='text' def='' nullable='true' /> " & _
                                                " <edo_border name='' type='text' def='' nullable='true' /> " & _
                                                " <noaproba name='' type='int' def='' nullable='true' /> " & _
                                                " <anoaproba name='' type='decimal' def='' nullable='true' /> " & _
                                                " <nocertif name='' type='char' def='' nullable='true' /> " & _
                                                " <fec_efactu name='' type='date' def='' nullable='true' /> " & _
                                                " <iva_cambio name='' type='date' def='' nullable='true' /> " & _
                                                " <cpgeneral name='' type='char' def='' nullable='true' /> " & _
                                                " <cpcedula name='' type='char' def='' nullable='true' /> " & _
                                                " <antesquien name='' type='char' def='' nullable='true' /> " & _
                                                " <serie_xm name='' type='char' def='' nullable='true' /> " & _
                                                " <folio_xm name='' type='int' def='' nullable='true' /> " & _
                                                " <cfdi_source name='' type='text' def='' nullable='true' /> " & _
                                                " <aviso_privacidad name='' type='text' def='' nullable='true' /> " & _
                                                " <adlogon name='' type='bit' def='false' nullable='true' /> " & _
                                                "</control>"})

      Me.xmllist.Add(New xmlfile With {.name = "credito",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<credito> " & _
                                                " <oficina name='Oficina' type='int' def='0' nullable='false' /> " & _
                                                " <original name='Original' type='int' def='0' nullable='false' /> " & _
                                                " <credito name='Credito' type='int' def='0' nullable='true' /> " & _
                                                " <cliente name='Cliente' type='int' def='0' nullable='false' /> " & _
                                                " <linea name='linea' type='decimal' def='0' nullable='false' /> " & _
                                                " <riesgo name='Riesgo' type='decimal' def='0' nullable='false' /> " & _
                                                " <actual name='Actual' type='decimal' def='0' nullable='false' /> " & _
                                                " <caratula name='Caratula' type='decimal' def='0' nullable='false' /> " & _
                                                " <modalidad name='Modalidad' type='decimal' def='0' nullable='false' /> " & _
                                                " <rebate name='Rebate' type='money' def='0' nullable='false' /> " & _
                                                " <solicitado name='Solicitado' type='money' def='0' nullable='false' /> " & _
                                                " <autorizado name='Autorizado' type='money' def='0' nullable='false' /> " & _
                                                " <ejercido name='Ejercido' type='money' def='0' nullable='false' /> " & _
                                                " <plazo name='Plazo' type='int' def='0' nullable='false' /> " & _
                                                " <camb_clte name='Camb_Clte' type='bit' def='false' nullable='false' /> " & _
                                                " <gtahipo name='Gtahipo' type='bit' def='false' nullable='false' /> " & _
                                                " <promotor name='Promotor' type='int' def='0' nullable='false' /> " & _
                                                " <pro_comi name='Pro_comi' type='decimal' def='0' nullable='false' /> " & _
                                                " <pcomiape name='Pcomiape' type='decimal' def='0' nullable='false' /> " & _
                                                " <endoso name='Endoso' type='bit' def='false' nullable='false' /> " & _
                                                " <desc_cara name='Desc_cara' type='text' def='' nullable='false' /> " & _
                                                " <tasa name='Tasa' type='decimal' def='0' nullable='false' /> " & _
                                                " <margen name='Margen' type='decimal' def='0' nullable='false' /> " & _
                                                " <factor name='Factor' type='decimal' def='0' nullable='false' /> " & _
                                                " <fondeo name='' type='decimal' def='' nullable='false' /> " & _
                                                " <margfond name='' type='decimal' def='' nullable='false' /> " & _
                                                " <pnafinsa name='' type='decimal' def='' nullable='false' /> " & _
                                                " <tasaiva name='Tasaiva' type='decimal' def='0' nullable='false' /> " & _
                                                " <poriva name='' type='decimal' def='' nullable='false' /> " & _
                                                " <nrendepo name='Nrendepo' type='decimal' def='0' nullable='true' /> " & _
                                                " <popccomp name='Popccomp' type='decimal' def='0' nullable='false' /> " & _
                                                " <tipoactivo name='Tipoactivo' type='decimal' def='0' nullable='false' /> " & _
                                                " <notas name='Notas' type='text' def='' nullable='false' /> " & _
                                                " <avales name='Avales' type='text' def='' nullable='false' /> " & _
                                                " <fecalta name='Fecalta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecini name='Fecini' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecsoli name='Fecsoli' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecbaja name='Fecbaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecauto name='Fecauto' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecrech name='Fecrech' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecxmit name='' type='datetime' def='' nullable='false' /> " & _
                                                " <fec_cesi name='' type='datetime' def='' nullable='false' /> " & _
                                                " <fec_cesioc name='' type='datetime' def='' nullable='false' /> " & _
                                                " <feulpag name='' type='datetime' def='' nullable='false' /> " & _
                                                " <name_auto name='Name_auto' type='char' def='' nullable='false' /> " & _
                                                " <login_name name='Login_name' type='char' def='' nullable='false' /> " & _
                                                " <calcmora name='' type='char' def='' nullable='false' /> " & _
                                                " <main name='Main' type='bit' def='false' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <firmas name='' type='text' def='' nullable='true' /> " & _
                                                " <vigencia name='Vigencia' type='decimal' def='0' nullable='true' /> " & _
                                                " <pagdife name='Pagdife' type='money' def='0' nullable='true' /> " & _
                                                " <cto_cesi name='Cto_cesi' type='int' def='0' nullable='true' /> " & _
                                                " <revperso name='' type='text' def='' nullable='true' /> " & _
                                                " <notaregsol name='' type='text' def='' nullable='true' /> " & _
                                                " <Historia name='' type='text' def='' nullable='true' /> " & _
                                                " <aforo name='Aforo' type='decimal' def='0' nullable='true' /> " & _
                                                " <Fec_residu name='fec_residu' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <v_gtahipo name='V_gtahipo' type='int' def='0' nullable='true' /> " & _
                                                " <renta_anti name='renta_anti' type='bit' def='false' nullable='true' /> " & _
                                                " <depo_gtia name='' type='money' def='0' nullable='true' /> " & _
                                                " <condi_esp name='condi_esp' type='text' def='' nullable='true' /> " & _
                                                " <folio_gtia name='' type='char' def='' nullable='true' /> " & _
                                                " <folio_anti name='' type='char' def='' nullable='true' /> " & _
                                                " <com_prepag name='' type='numeric' def='0' nullable='true' /> " & _
                                                " <antiprov name='antiprov' type='bit' def='false' nullable='true' /> " & _
                                                " <digito_control name='' type='numeric' def='0' nullable='true' /> " & _
                                                " <idcnbv name='' type='char' def='' nullable='true' /> " & _
                                                " <capsanual name='capsanual' type='int' def='0' nullable='true' /> " & _
                                                " <iddos name='' type='char' def='' nullable='true' /> " & _
                                                " <pagodomici name='' type='bit' def='0' nullable='true' /> " & _
                                                " <anexo name='anexo' type='int' def='0' nullable='true' /> " & _
                                                " <fec_sinxml name='fec_sinxml' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <fec_firma name='fec_firma' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <gtaprend name='gtaprend' type='bit' def='false' nullable='true' /> " & _
                                                " <v_gtaprend name='v_gtaprend' type='money' def='0' nullable='true' /> " & _
                                                " <v_gtaliq name='v_gtaliq' type='money' def='0' nullable='true' /> " & _
                                                " <v_gtaotras name='v_gtaotras' type='money' def='0' nullable='true' /> " & _
                                                " <gtaliq name='gtaliq' type='bit' def='false' nullable='true' /> " & _
                                                " <gtaotras name='gtaotras' type='bit' def='false' nullable='true' /> " & _
                                                " <fecautorig name='' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <plazomax name='' type='int' def='0' nullable='true' /> " & _
                                                " <vigen_orig name='' type='int' def='0' nullable='true' /> " & _
                                                " <fecautopac name='' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <num_pac name='' type='char' def='' nullable='true' />" & _
                                                " <prog_10 name='' type='bit' def='{null}' nullable='true' />" & _
                                                " <pgastoinspeccion name='' type='decimal' def='{null}' nullable='true' />" & _
                                                "</credito>"})

      Me.xmllist.Add(New xmlfile With {.name = "efactura",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<efactura> " & _
                                                " <oficina name='oficina' type='decimal' def='0' nullable='false' /> " & _
                                                " <tipo name='tipo' type='char' def='' nullable='false' /> " & _
                                                " <serie name='serie' type='char' def='' nullable='false' /> " & _
                                                " <folio name='folio' type='int' def='0' nullable='false' /> " & _
                                                " <sfolio name='sfolio' type='char' def='' nullable='false' /> " & _
                                                " <linea name='linea' type='int' def='0' nullable='false' /> " & _
                                                " <pago name='pago' type='int' def='0' nullable='false' /> " & _
                                                " <plazo name='plazo' type='int' def='0' nullable='false' /> " & _
                                                " <cliente name='cliente' type='int' def='0' nullable='false' /> " & _
                                                " <nombre name='nombre' type='char' def='0' nullable='false' /> " & _
                                                " <rfc name='rfc' type='char' def='' nullable='false' /> " & _
                                                " <importe name='importe' type='money' def='0' nullable='false' /> " & _
                                                " <iva name='iva' type='money' def='0' nullable='false' /> " & _
                                                " <tasaiva name='tasaiva' type='decimal' def='0' nullable='false' /> " & _
                                                " <fechahora name='fechahora' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fechabaja name='fechabaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <cancelado name='concepto' type='decimal' def='0' nullable='false' /> " & _
                                                " <login_name name='login_name' type='char' def='' nullable='false' /> " & _
                                                " <referencia name='referencia' type='char' def='' nullable='false' /> " & _
                                                " <recibo name='recibo' type='text' def='' nullable='false' /> " & _
                                                " <desglose name='desglose' type='text' def='' nullable='false' /> " & _
                                                " <noaproba name='noaproba' type='int' def='0' nullable='false' /> " & _
                                                " <anoaproba name='anoaproba' type='int' def='0' nullable='false' /> " & _
                                                " <nocertif name='nocertif' type='char' def='0' nullable='false' /> " & _
                                                " <tipocompr name='tipocompr' type='char' def='0' nullable='false' /> " & _
                                                " <cadenaorig name='cadenaorig' type='text' def='' nullable='false' /> " & _
                                                " <sello name='sello' type='text' def='' nullable='false' /> " & _
                                                " <certifica name='certifica' type='text' def='' nullable='false' /> " & _
                                                " <xml name='xml' type='text' def='' nullable='false' /> " & _
                                                " <fecven name='fecven' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <contranexo name='contranexo' type='char' def='' nullable='true' /> " & _
                                                " <enviar name='' type='bit' def='' nullable='true' /> " & _
                                                " <correoe name='' type='text' def='' nullable='true' /> " & _
                                                " <moneda name='' type='decimal' def='0' nullable='true' /> " & _
                                                " <tipocambio name='' type='money' def='0' nullable='true' /> " & _
                                                " <html name='' type='text' def='' nullable='true' /> " & _
                                                " <dispersar name='' type='bit' def='' nullable='true' /> " & _
                                                " <ati name='ati' type='int' def='0' nullable='true' /> " & _
                                                " <pdflocal name='' type='bit' def='' nullable='true' /> " & _
                                                " <concepto name='concepto' type='int' def='0' nullable='true' /> " & _
                                                "</efactura>"})

      Me.xmllist.Add(New xmlfile With {.name = "factprov",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<factprov> " & _
                                                " <oficina name='Oficina' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <factura name='Factura' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <linea name='Linea' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <proveedor name='Proveedor' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <folio name='Folio' type='char' def='' nullable='false' /> " & _
                                                " <subtotal name='Subtotal' type='money' def='0.00' nullable='false' /> " & _
                                                " <subiva name='Subiva' type='money' def='0.00' nullable='false' /> " & _
                                                " <total name='Total' type='money' def='0.00' nullable='false' /> " & _
                                                " <tasaiva name='Tasaiva' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <fecalta name='Fecalta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecasig name='Fecasig' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecxfer name='Fecxfer' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecbaja name='Fecbaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <notas name='Notas' type='text' def='' nullable='false' /> " & _
                                                " <endoso name='Endoso' type='bit' def='false' nullable='false' /> " & _
                                                " <intercont name='' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <login_name name='Login_name' type='char' def='' nullable='false' /> " & _
                                                " <marca name='marca' type='int' def='0' nullable='false' /> " & _
                                                " <articulo name='articulo' type='int' def='0' nullable='false' /> " & _
                                                " <modelo name='modelo' type='int' def='0' nullable='false' /> " & _
                                                " <transp name='transp' type='bit' def='false' nullable='false' /> " & _
                                                " <void name='' type='bit' def='false' nullable='false' /> " & _
                                                " <fec_soli name='fec_soli' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <solicitud name='solicitud' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <pagada name='Pagada' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_fact name='fec_fact' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <solicheq name='solicheq' type='int' def='{null}' nullable='true' /> " & _
                                                " <cliente name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <fec_estatus name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <estatus name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <credito name='' type='int' def='{null}' nullable='true' /> " & _
                                                "</factprov>"})

      Me.xmllist.Add(New xmlfile With {.name = "historia",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<historia> " & _
                                                " <oficina name='oficina' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <tipo name='tipo' type='char' def='' nullable='false' /> " & _
                                                " <folio name='folio' type='char' def='' nullable='false' /> " & _
                                                " <linea name='linea' type='int' def='0' nullable='false' /> " & _
                                                " <pago name='pago' type='int' def='0' nullable='true' /> " & _
                                                " <plazo name='plazo' type='int' def='0' nullable='false' /> " & _
                                                " <cliente name='cliente' type='int' def='0' nullable='false' /> " & _
                                                " <nombre name='nombre' type='char' def='' nullable='true' /> " & _
                                                " <promotor name='promotor' type='int' def='0' nullable='false' /> " & _
                                                " <respons name='respons' type='int' def='0' nullable='false' /> " & _
                                                " <lote_no name='lote_no' type='int' def='0' nullable='false' /> " & _
                                                " <imp_orig name='imp_orig' type='money' def='0' nullable='false' /> " & _
                                                " <importe name='importe' type='money' def='0' nullable='false' /> " & _
                                                " <moratorios name='' type='money' def='0' nullable='false' /> " & _
                                                " <salinsan name='salinsan' type='money' def='0' nullable='false' /> " & _
                                                " <costamor name='costamor' type='money' def='0' nullable='false' /> " & _
                                                " <interes name='interes' type='money' def='0' nullable='false' /> " & _
                                                " <tasaa name='tasaa' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <iva_aplic name='iva_aplic' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <ivacapital name='ivacapital' type='money' def='0.0' nullable='false' /> " & _
                                                " <fecven name='fecven' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecpago name='fecpago' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fechist name='' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fecbaja name='fecbaja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <concepto name='concepto' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <login_name name='login_name' type='char' def='' nullable='false' /> " & _
                                                " <referencia name='referencia' type='char' def='' nullable='false' /> " & _
                                                " <sta_aviso name='sta_aviso' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <fec_aviso name='fec_aviso' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <hora_aviso name='hora_aviso' type='char' def='' nullable='false' /> " & _
                                                " <resp_aviso name='resp_aviso' type='char' def='' nullable='false' /> " & _
                                                " <cont_aviso name='cont_aviso' type='char' def='' nullable='false' /> " & _
                                                " <congelado name='congelado' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <recibo name='recibo' type='text' def='' nullable='false' /> " & _
                                                " <desglose name='desglose' type='text' def='' nullable='false' /> " & _
                                                " <reimpreso name='reimpreso' type='decimal' def='0' nullable='false' /> " & _
                                                " <donde name='donde' type='decimal' def='0' nullable='false' /> " & _
                                                " <aplicofact name='aplicofact' type='bit' def='0' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <fecante name='fecante' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <contranexo name='contranexo' type='char' def='{null}' nullable='true' /> " & _
                                                " <ivarta name='ivarta' type='money' def='{null}' nullable='true' /> " & _
                                                " <ivainsol name='ivainsol' type='money' def='{null}' nullable='true' /> " & _
                                                " <rendepo name='rendepo' type='money' def='{null}' nullable='true' /> " & _
                                                " <Ivarndp name='ivarndp' type='money' def='{null}' nullable='true' /> " & _
                                                " <Ivarndpcap name='ivarndpcap' type='money' def='{null}' nullable='true' /> " & _
                                                " <ivaseg name='ivaseg' type='money' def='{null}' nullable='true' /> " & _
                                                " <ivacom_pp name='ivacom_pp' type='numeric' def='{null}' nullable='true' /> " & _
                                                " <cond_mora name='' type='text' def='{null}' nullable='true' /> " & _
                                                "</historia>"})

      Me.xmllist.Add(New xmlfile With {.name = "perso",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<perso> " & _
                                                  " <cliente name='Cliente' type='int' def='0' nullable='false' /> " & _
                                                  " <socios name='Socios' type='text' def='' nullable='false' /> " & _
                                                  " <dur_socie name='Dur_socie' type='decimal' def='0.0' nullable='false' /> " & _
                                                  " <capital name='Capital' type='decimal' def='0.0' nullable='false' /> " & _
                                                  " <apoderado name='Apoderado' type='text' def='' nullable='false' /> " & _
                                                  " <ap_escrit name='Ap_escrit' type='char' def='' nullable='false' /> " & _
                                                  " <ap_notar name='Ap_notar' type='char' def='' nullable='false' /> " & _
                                                  " <ap_cd name='Ap_cd' type='text' def='' nullable='false' /> " & _
                                                  " <ap_numero name='Ap_numero' type='char' def='' nullable='false' /> " & _
                                                  " <ap_folio name='Ap_folio' type='char' def='' nullable='false' /> " & _
                                                  " <ap_volum name='Ap_volum' type='char' def='' nullable='false' /> " & _
                                                  " <ap_libro name='Ap_libro' type='char' def='' nullable='false' /> " & _
                                                  " <ap_auxil name='Ap_auxil' type='char' def='' nullable='false' /> " & _
                                                  " <ap_fecha name='Ap_fecha' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                  " <ar_escrit name='Ar_escrit' type='char' def='' nullable='false' /> " & _
                                                  " <ar_feccon name='Ar_feccon' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                  " <ar_notar name='Ar_notar' type='char' def='' nullable='false' /> " & _
                                                  " <ar_cd name='Ar_cd' type='text' def='' nullable='false' /> " & _
                                                  " <ar_numero name='Ar_numero' type='char' def='' nullable='false' /> " & _
                                                  " <ar_folio name='Ar_folio' type='char' def='' nullable='false' /> " & _
                                                  " <ar_volum name='Ar_volum' type='char' def='' nullable='false' /> " & _
                                                  " <ar_libro name='Ar_libro' type='char' def='' nullable='false' /> " & _
                                                  " <ar_auxil name='Ar_auxil' type='char' def='' nullable='false' /> " & _
                                                  " <ar_fecha name='Ar_fecha' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                  " <login_name name='Login_Name' type='char' def='' nullable='false' /> " & _
                                                  " <generales name='Generales' type='text' def='' nullable='false' /> " & _
                                                  " <void name='' type='bit' def='' nullable='false' /> " & _
                                                  " <fec_revi name='Fec_revi' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                  " <accionista name='Accionista' type='text' def='' nullable='false' /> " & _
                                                  " <fec_revacc name='Fec_revacc' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                  " <porc_menor name='Porc_menor' type='bit' def='false' nullable='true' /> " & _
                                                  " <sociedad name='' type='char' def='' nullable='true' /> " & _
                                                  " <tiposociedad name='' type='int' def='{null}' nullable='true' /> " & _
                                                  " <ar_ciudad name='' type='char' def='{null}' nullable='true' /> " & _
                                                  " <ap_ciudad name='' type='char' def='{null}' nullable='true' /> " & _
                                                "</perso>"})

      Me.xmllist.Add(New xmlfile With {.name = "promotor",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<promotor> " & _
                                                " <promotor name='Promotor' type='int' def='0' nullable='false' /> " & _
                                                " <codigo name='Codigo' type='char' def='' nullable='false' /> " & _
                                                " <nombre name='Nombre' type='char' def='' nullable='false' /> " & _
                                                " <empresa name='empresa' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <activo name='Activo' type='bit' def='false' nullable='false' /> " & _
                                                " <valor_fin name='Valor_Fin' type='money' def='{null}' nullable='true' /> " & _
                                                " <valor_com name='Valor_Com' type='money' def='{null}' nullable='true' /> " & _
                                                " <telefono name='Telefono' type='char' def='' nullable='false' /> " & _
                                                " <tipo name='Tipo' type='char' def='' nullable='false' /> " & _
                                                " <comision name='Comision' type='money' def='0.00' nullable='true' /> " & _
                                                " <void name='' type='bit' def='{null}' nullable='false' /> " & _
                                                " <enviado name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <rfc name='rfc' type='char' def='' nullable='true' /> " & _
                                                " <domicilio name='domicilio' type='char' def='' nullable='true' /> " & _
                                                " <colonia name='colonia' type='char' def='' nullable='true' /> " & _
                                                " <municipio name='municipio' type='char' def='' nullable='true' /> " & _
                                                " <estado name='estado' type='char' def='' nullable='true' /> " & _
                                                " <cp name='cp' type='int' def='0' nullable='true' /> " & _
                                                " <email name='email' type='char' def='' nullable='true' /> " & _
                                                " <fec_alta name='fec_alta' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <fec_baja name='fec_baja' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <pbase name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                " <curp name='curp' type='char' def='' nullable='true' /> " & _
                                                " <incentivo name='Incentivo' type='money' def='0.00' nullable='true' /> " & _
                                                " <ultrenovac name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                " <renovacion name='' type='varchar' def='{null}' nullable='true' /> " & _
                                                " <cuenta name='' type='char' def='{null}' nullable='true' /> " & _
                                                " <segmento name='segmento' type='int' def='0' nullable='true' /> " & _
                                                " <zona name='zona' type='int' def='0' nullable='true' /> " & _
                                                " <nomina name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <id_regi name='id_regi' type='int' def='0' nullable='true' /> " & _
                                                " <oficina name='oficina' type='int' def='0' nullable='false' /> " & _
                                                " <fordtwoo name='fordtwoo' type='int' def='' nullable='true' />" & _
                                                " <pfisica name='pfisica' type='bit' def='false' nullable='true' />" & _
                                                " <calle name='calle' type='char' def='' nullable='true' />" & _
                                                " <numint name='numint' type='char' def='' nullable='true' />" & _
                                                " <numext name='numext' type='char' def='' nullable='true' />" & _
                                                " <sepomex name='sepomex' type='char' def='' nullable='true' />" & _
                                                " <id_plaza name='id_plaza' type='int' def='1' nullable='true' /> " & _
                                                " <contrato name='contrato' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                " <puesto name='puesto' type='nchar' def='' nullable='true' /> " & _
                                                " <conomina name='conomina' type='nchar' def='' nullable='true' /> " & _
                                                "</promotor>"})

      Me.xmllist.Add(New xmlfile With {.name = "riesgo",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<riesgo> " & _
                                                " <grupo name='Grupo' type='decimal' def='0' nullable='false' /> " & _
                                                " <nombre name='Nombre' type='char' def='' nullable='false' /> " & _
                                                " <domicilio name='Domicilio' type='text' def='' nullable='false' /> " & _
                                                " <colonia name='Colonia' type='text' def='' nullable='false' /> " & _
                                                " <municipio name='Municipio' type='text' def='' nullable='false' /> " & _
                                                " <estado name='Estado' type='text' def='' nullable='false' /> " & _
                                                " <cp name='Cp' type='decimal' def='0' nullable='false' /> " & _
                                                " <tels name='Tels' type='text' def='' nullable='false' /> " & _
                                                " <socios name='Socios' type='text' def='' nullable='false' /> " & _
                                                " <actividad name='Actividad' type='text' def='' nullable='false' /> " & _
                                                " <cltedesde name='Cltedesde' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <void name='' type='bit' def='false' nullable='false' /> " & _
                                                " <oficina name='' type='int' def='{null}' nullable='true' /> " & _
                                                "</riesgo>"})

      Me.xmllist.Add(New xmlfile With {.name = "seguro",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<seguro> " & _
                                                " <oficina name='Oficina' type='decimal' def='0' nullable='false' /> " & _
                                                " <linea name='Linea' type='decimal' def='0' nullable='false' /> " & _
                                                " <cliente name='Cliente' type='decimal' def='0' nullable='false' /> " & _
                                                " <referencia name='Referencia' type='char' def='' nullable='false' /> " & _
                                                " <promotor name='Promotor' type='int' def='0' nullable='false' /> " & _
                                                " <folio name='Folio' type='int' def='-1' nullable='false' /> " & _
                                                " <poliza name='Poliza' type='char' def='' nullable='false' /> " & _
                                                " <marca name='Marca' type='char' def='' nullable='false' /> " & _
                                                " <modelo name='Modelo' type='decimal' def='0' nullable='false' /> " & _
                                                " <motor name='Motor' type='char' def='' nullable='false' /> " & _
                                                " <serie name='Serie' type='char' def='' nullable='false' /> " & _
                                                " <rfv name='RFV' type='char' def='' nullable='false' /> " & _
                                                " <cveveh name='cveveh' type='char' def='' nullable='false' /> " & _
                                                " <primas name='Primas' type='decimal' def='0' nullable='false' /> " & _
                                                " <placas name='Placas' type='char' def='' nullable='false' /> " & _
                                                " <fec_ini name='Fec_Ini' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_fin name='Fec_Fin' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_ven name='Fec_Ven' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <fec_baja name='Fec_Baja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <endoso name='Endoso' type='bit' def='false' nullable='false' /> " & _
                                                " <cancelado name='Cancelado' type='bit' def='false' nullable='false' /> " & _
                                                " <garantia name='Garantia' type='bit' def='false' nullable='false' /> " & _
                                                " <encasa name='Encasa' type='bit' def='false' nullable='false' /> " & _
                                                " <ciaseguros name='Ciaseguros' type='char' def='' nullable='false' /> " & _
                                                " <login_name name='Login_name' type='char' def='' nullable='false' /> " & _
                                                " <agente name='Agente' type='char' def='' nullable='false' /> " & _
                                                " <observac name='Observac' type='text' def='' nullable='false' /> " & _
                                                " <xfer name='xfer' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <void name='' type='bit' def='' nullable='false' /> " & _
                                                " <revisado name='' type='char' def='' nullable='true' /> " & _
                                                " <pago name='pago' type='int' def='{null}' nullable='true' /> " & _
                                                " <plazo name='plazo' type='int' def='{null}' nullable='true' /> " & _
                                                " <documento name='' type='nchar' def='{null}' nullable='true' /> " & _
                                                " <porcliente name='' type='datetime' def='{null}' nullable='true' /> " & _
                                                "</seguro>"})

      Me.xmllist.Add(New xmlfile With {.name = "usuario",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<usuario> " & _
                                                " <folio name='folio' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <userid name='userid' type='char' def='' nullable='false' /> " & _
                                                " <nombre name='nombre' type='char' def='' nullable='false' /> " & _
                                                " <password name='password' type='int' def='0' nullable='false' /> " & _
                                                " <activo name='activo' type='bit' def='false' nullable='false' /> " & _
                                                " <supervisor name='supervisor' type='bit' def='false' nullable='false' /> " & _
                                                " <trustees name='trustees' type='text' def='' nullable='false' /> " & _
                                                " <email name='email' type='text' def='' nullable='false' /> " & _
                                                " <lista_pass name='lista_pass' type='text' def='' nullable='false' /> " & _
                                                " <fec_pass name='fec_pass' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <jefe name='jefe' type='char' def='' nullable='false' /> " & _
                                                " <user_job name='user_job' type='char' def='' nullable='false' /> " & _
                                                " <acepta name='acepta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                " <historia name='historia' type='text' def='' nullable='false' /> " & _
                                                " <void name='' type='bit' def='false' nullable='false' /> " & _
                                                " <oficina name='' type='decimal' def='0.0' nullable='false' /> " & _
                                                " <perfil name='perfil' type='text' def='' nullable='false' /> " & _
                                                " <sign name='' type='text' def='{null}' nullable='true' /> " & _
                                                " <promotor name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <fecbaja name='' type='datetime' def='' nullable='true' /> " & _
                                                " <regional name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <id_regi name='' type='nchar' def='{null}' nullable='true' /> " & _
                                                " <ubicacion name='' type='int' def='{null}' nullable='true' /> " & _
                                                " <oficinas name='' type='nvarchar' def='{null}' nullable='true' /> " & _
                                                " <session name='' type='text' def='{null}' nullable='true' /> " & _
                                                " <firma name='' type='image' def='{null}' nullable='true' /> " & _
                                                " <token name='' type='text' def='{null}' nullable='true' /> " & _
                                                " <last_login name='' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                "</usuario>"})

      Me.xmllist.Add(New xmlfile With {.name = "ficha",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<ficha> " & _
                                                "  <oficina name='oficina' type='decimal' def='0' nullable='false' /> " & _
                                                "  <foliocta name='Foliocta' type='decimal' def='0' nullable='false' /> " & _
                                                "  <cuenta name='Cuenta' type='char' def='' nullable='false' /> " & _
                                                "  <ficha name='Ficha' type='decimal' def='0' nullable='false' /> " & _
                                                "  <documento name='Documento' type='decimal' def='0' nullable='false' /> " & _
                                                "  <fecha name='Fecha' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <tipo name='Tipo' type='char' def='' nullable='false' /> " & _
                                                "  <numdoc name='numdoc' type='decimal' def='0' nullable='false' /> " & _
                                                "  <banco name='Banco' type='char' def='' nullable='false' /> " & _
                                                "  <concepto name='Concepto' type='char' def='' nullable='false' /> " & _
                                                "  <importe name='Importe' type='money' def='0' nullable='true' /> " & _
                                                "  <gencont name='Gencont' type='bit' def='0' nullable='false' /> " & _
                                                "  <aplicado name='Aplicado' type='bit' def='0' nullable='false' /> " & _
                                                "  <cancelado name='Cancelado' type='bit' def='0' nullable='false' /> " & _
                                                "  <uniqueid name='Uniqueid' type='int' def='0' nullable='false' /> " & _
                                                "  <void name='' type='bit' def='' nullable='false' /> " & _
                                                "  <cliente name='' type='int' def='' nullable='true' /> " & _
                                                "</ficha>"})

      Me.xmllist.Add(New xmlfile With {.name = "movsct",
                                       .value = "<movsct> " & _
                                                "  <oficina name='oficina' type='decimal' def='0' nullable='false' /> " & _
                                                "  <foliocta name='foliocta' type='decimal' def='0' nullable='false' /> " & _
                                                "  <auxiliar name='auxiliar' type='char' def='' nullable='false' /> " & _
                                                "  <tipo name='tipo' type='char' def='' nullable='false' /> " & _
                                                "  <concepto name='concepto' type='decimal' def='0' nullable='false' /> " & _
                                                "  <ficha name='ficha' type='decimal' def='0' nullable='false' /> " & _
                                                "  <documento name='documento' type='decimal' def='0' nullable='false' /> " & _
                                                "  <fecha name='fecha' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <linea name='linea' type='decimal' def='0' nullable='false' /> " & _
                                                "  <cliente name='cliente' type='decimal' def='0' nullable='false' /> " & _
                                                "  <nombre name='nombre' type='char' def='' nullable='false' /> " & _
                                                "  <pago name='pago' type='int' def='0' nullable='false' /> " & _
                                                "  <plazo name='plazo' type='int' def='0' nullable='false' /> " & _
                                                "  <vence name='vence' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <aplicado name='aplicado' type='bit' def='false' nullable='false' /> " & _
                                                "  <fich_dep name='fich_dep' type='bit' def='false' nullable='false' /> " & _
                                                "  <fol_deven name='fol_deven' type='char' def='' nullable='false' /> " & _
                                                "  <importe name='importe' type='money' def='0' nullable='false' /> " & _
                                                "  <ivarta name='ivarta' type='money' def='0' nullable='false' /> " & _
                                                "  <ivacapital name='ivacapital' type='money' def='0' nullable='false' /> " & _
                                                "  <ivainsol name='ivainsol' type='money' def='0' nullable='false' /> " & _
                                                "  <rendepo name='rendepo' type='money' def='0' nullable='false' /> " & _
                                                "  <ivarndp name='ivarndp' type='money' def='0' nullable='false' /> " & _
                                                "  <ivarndpcap name='ivarndpcap' type='money' def='0' nullable='false' /> " & _
                                                "  <bonifica name='bonifica' type='money' def='0' nullable='false' /> " & _
                                                "  <moratorio name='moratorio' type='decimal' def='0' nullable='false' /> " & _
                                                "  <iva_pago name='iva_pago' type='money' def='0' nullable='false' /> " & _
                                                "  <iva_aplic name='iva_aplic' type='decimal' def='0' nullable='false' /> " & _
                                                "  <diferencia name='diferencia' type='money' def='0' nullable='false' /> " & _
                                                "  <congelado name='congelado' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <reactivado name='reactivado' type='bit' def='false' nullable='false' /> " & _
                                                "  <desglose name='desglose' type='text' def='' nullable='false' /> " & _
                                                "  <fec_baja name='fec_baja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <pagado name='pagado' type='bit' def='false' nullable='false' /> " & _
                                                "  <void name='' type='bit' def='' nullable='false' /> " & _
                                                "  <ivaseg name='ivaseg' type='money' def='0' nullable='true' /> " & _
                                                "  <ivacom_pp name='ivacom_pp' type='numeric' def='0' nullable='true' /> " & _
                                                "</movsct>"})

      Me.xmllist.Add(New xmlfile With {.name = "movto",
                                       .value = "<movto> " & _
                                                "  <oficina name='Oficina' type='decimal' def='0' nullable='false' /> " & _
                                                "  <foliocta name='Foliocta' type='decimal' def='0' nullable='false' /> " & _
                                                "  <cuenta name='Cuenta' type='char' def='' nullable='false' /> " & _
                                                "  <tipo name='Tipo' type='char' def='0' nullable='false' /> " & _
                                                "  <solicheq name='Solicheq' type='decimal' def='0' nullable='false' /> " & _
                                                "  <folio name='Folio' type='decimal' def='0' nullable='false' /> " & _
                                                "  <fec_alta name='Fec_alta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fec_sist name='Fec_sist' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fecrech name='Fecrech' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fec_auto name='Fec_auto' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fec_print name='Fec_print' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fec_liber name='Fec_liber' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fec_entrega name='Fec_entrega' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fec_conci name='Fec_conci' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <cancelado name='Cancelado' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <benefic name='Benefic' type='char' def='' nullable='false' /> " & _
                                                "  <concepto name='concepto' type='char' def='' nullable='false' /> " & _
                                                "  <cruzado name='Cruzado' type='bit' def='true' nullable='false' /> " & _
                                                "  <impreso name='Impreso' type='decimal' def='0' nullable='false' /> " & _
                                                "  <entro name='Entro' type='money' def='0' nullable='true' /> " & _
                                                "  <salio name='Salio' type='money' def='0' nullable='true' /> " & _
                                                "  <saldo name='Saldo' type='money' def='0' nullable='false' /> " & _
                                                "  <status name='Status' type='char' def='' nullable='false' /> " & _
                                                "  <name_auto name='Name_auto' type='text' def='' nullable='false' /> " & _
                                                "  <firma name='Firma' type='text' def='' nullable='false' /> " & _
                                                "  <firmapend name='Firmapend' type='bit' def='' nullable='false' /> " & _
                                                "  <login_name name='Login_name' type='char' def='' nullable='false' /> " & _
                                                "  <contrato name='Contrato' type='decimal' def='0' nullable='false' /> " & _
                                                "  <factura name='Factura' type='decimal' def='0' nullable='false' /> " & _
                                                "  <void name='' type='bit' def='' nullable='false' /> " & _
                                                "  <benex name='Benex' type='bit' def='false' nullable='true' /> " & _
                                                "  <sin_xml name='Sin_xml' type='bit' def='false' nullable='true' /> " & _
                                                "  <proveedor name='Proveedor' type='int' def='0' nullable='true' /> " & _
                                                "  <fec_sinxml name='Fec_sinxml' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                "  <folctadest name='folctadest' type='decimal' def='0' nullable='true'/> " & _
                                                "  <ctadestino name='ctadestino' type='char' def='' nullable='true'/>	" & _
                                                "</movto>"})

      Me.xmllist.Add(New xmlfile With {.name = "operelev",
                                       .value = "<operelev> " & _
                                                "  <oficina name='oficina' type='decimal' def='0' nullable='false' /> " & _
                                                "  <folio name='folio' type='decimal' def='0' nullable='false' /> " & _
                                                "  <foliocta name='foliocta' type='decimal' def='0' nullable='false' /> " & _
                                                "  <ficha name='ficha' type='decimal' def='0' nullable='false' /> " & _
                                                "  <documento name='documento' type='decimal' def='0' nullable='false' /> " & _
                                                "  <uniqueid name='uniqueid' type='int' def='0' nullable='false' /> " & _
                                                "  <cliente name='cliente' type='int' def='0' nullable='false' /> " & _
                                                "  <nombre name='nombre' type='char' def='' nullable='false' /> " & _
                                                "  <importe name='importe' type='money' def='0' nullable='false' /> " & _
                                                "  <tipo name='tipo' type='char' def='' nullable='false' /> " & _
                                                "  <numdoc name='numdoc' type='decimal' def='' nullable='false' /> " & _
                                                "  <banco name='banco' type='char' def='' nullable='false' /> " & _
                                                "  <relevan name='relevan' type='bit' def='false' nullable='false' /> " & _
                                                "  <inusual name='inusual' type='bit' def='false' nullable='false' /> " & _
                                                "  <preocup name='preocup' type='bit' def='false' nullable='false' /> " & _
                                                "  <facturas name='facturas' type='text' def='' nullable='false' /> " & _
                                                "  <fec_alta name='fec_alta' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <fec_baja name='fec_baja' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <notas name='notas' type='text' def='' nullable='false' /> " & _
                                                "  <void name='' type='bit' def='' nullable='false' /> " & _
                                                "  <linea name='linea' type='int' def='0' nullable='true' /> " & _
                                                "</operelev>"})

      Me.xmllist.Add(New xmlfile With {.name = "calen",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<calen> " & _
                                                "  <fecha name='fecha' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <habil name='habil' type='bit' def='false' nullable='false' /> " & _
                                                "  <comentario name='comentario' type='char' def='' nullable='false' /> " & _
                                                "  <void name='void' type='bit' def='false' nullable='false' /> " & _
                                                "</calen>"})

      Me.xmllist.Add(New xmlfile With {.name = "saldo",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<saldo> " & _
                                                "  <oficina name='' type='decimal' def='0' nullable='false' /> " & _
                                                "  <foliocta name='Foliocta' type='decimal' def='0' nullable='false' /> " & _
                                                "  <cuenta name='Cuenta' type='char' def='' nullable='false' /> " & _
                                                "  <fecha name='Fecha' type='datetime' def='1900-01-01 00:00:00.000' nullable='false' /> " & _
                                                "  <banco name='Banco' type='char' def='' nullable='false' /> " & _
                                                "  <sucursal name='sucursal' type='char' def='' nullable='false' /> " & _
                                                "  <fol_cheq name='Fol_Cheq' type='decimal' def='0' nullable='false' /> " & _
                                                "  <fol_depo name='Fol_Depo' type='decimal' def='0' nullable='false' /> " & _
                                                "  <fol_canc name='Fol_Canc' type='decimal' def='0' nullable='false' /> " & _
                                                "  <entradas name='Entradas' type='money' def='0' nullable='false' /> " & _
                                                "  <salidas name='Salidas' type='money' def='0' nullable='false' /> " & _
                                                "  <saldo name='Saldo' type='money' def='0' nullable='false' /> " & _
                                                "</saldo>"})

      Me.xmllist.Add(New xmlfile With {.name = "carteram",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<carteram> " & _
                                                "  <periodo name='' type='int' def='' nullable='false' /> " & _
                                                "  <oficina name='' type='int' def='' nullable='false' /> " & _
                                                "  <tipo name='' type='char' def='' nullable='false' /> " & _
                                                "  <folio name='' type='char' def='' nullable='false' /> " & _
                                                "  <linea name='' type='int' def='' nullable='false' /> " & _
                                                "  <pago name='' type='int' def='' nullable='false' /> " & _
                                                "  <plazo name='' type='int' def='' nullable='false' /> " & _
                                                "  <cliente name='' type='int' def='' nullable='false' /> " & _
                                                "  <nombre name='' type='char' def='' nullable='true' /> " & _
                                                "  <promotor name='' type='int' def='' nullable='false' /> " & _
                                                "  <respons name='' type='int' def='' nullable='false' /> " & _
                                                "  <lote_no name='' type='int' def='' nullable='false' /> " & _
                                                "  <imp_orig name='' type='money' def='' nullable='false' /> " & _
                                                "  <importe name='' type='money' def='' nullable='false' /> " & _
                                                "  <moratorios name='' type='money' def='' nullable='false' /> " & _
                                                "  <salinsan name='' type='money' def='' nullable='false' /> " & _
                                                "  <costamor name='' type='money' def='' nullable='false' /> " & _
                                                "  <interes name='' type='money' def='' nullable='false' /> " & _
                                                "  <tasaa name='' type='decimal' def='' nullable='false' /> " & _
                                                "  <ivacapital name='' type='money' def='' nullable='false' /> " & _
                                                "  <iva_aplic name='' type='decimal' def='' nullable='false' /> " & _
                                                "  <fecven name='' type='datetime' def='' nullable='false' /> " & _
                                                "  <fecpago name='' type='datetime' def='' nullable='false' /> " & _
                                                "  <fecante name='' type='datetime' def='' nullable='false' /> " & _
                                                "  <fecbaja name='' type='datetime' def='' nullable='false' /> " & _
                                                "  <concepto name='' type='int' def='' nullable='false' /> " & _
                                                "  <eliminable name='' type='bit' def='' nullable='false' /> " & _
                                                "  <pagado name='' type='bit' def='' nullable='false' /> " & _
                                                "  <login_name name='' type='char' def='' nullable='false' /> " & _
                                                "  <referencia name='' type='char' def='' nullable='false' /> " & _
                                                "  <sta_aviso name='' type='int' def='' nullable='false' /> " & _
                                                "  <fec_aviso name='' type='datetime' def='' nullable='false' /> " & _
                                                "  <hora_aviso name='' type='char' def='' nullable='false' /> " & _
                                                "  <resp_aviso name='' type='char' def='' nullable='false' /> " & _
                                                "  <cont_aviso name='' type='char' def='' nullable='false' /> " & _
                                                "  <congelado name='' type='datetime' def='' nullable='false' /> " & _
                                                "  <recibo name='' type='text' def='' nullable='false' /> " & _
                                                "  <desglose name='' type='text' def='' nullable='false' /> " & _
                                                "  <reimpreso name='' type='int' def='' nullable='false' /> " & _
                                                "  <donde name='' type='int' def='' nullable='false' /> " & _
                                                "  <quebranto name='' type='bit' def='' nullable='false' /> " & _
                                                "  <aplicofact name='' type='bit' def='' nullable='false' /> " & _
                                                "  <void name='' type='bit' def='' nullable='false' /> " & _
                                                "  <contranexo name='' type='char' def='' nullable='true' /> " & _
                                                "  <ivarta name='' type='money' def='' nullable='true' /> " & _
                                                "  <ivainsol name='' type='money' def='' nullable='true' /> " & _
                                                "  <rendepo name='' type='money' def='' nullable='true' /> " & _
                                                "  <Ivarndp name='' type='money' def='' nullable='true' /> " & _
                                                "  <Ivarndpcap name='' type='money' def='' nullable='true' /> " & _
                                                "  <ivaseg name='' type='money' def='' nullable='true' /> " & _
                                                "  <ivacom_pp name='' type='decimal' def='' nullable='true' /> " & _
                                                "</carteram>"})

      Me.xmllist.Add(New xmlfile With {.name = "plaza",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<plaza> " & _
                                                "  <id_plaza name='id_plaza' type='int' def='0' nullable='true' /> " & _
                                                "  <nombre name='nombre' type='char' def='' nullable='true' /> " & _
                                                "</plaza>"})

      Me.xmllist.Add(New xmlfile With {.name = "esquema",
                                       .value = "<?xml version='1.0' encoding='utf-8' ?> " & _
                                                "<esquema> " & _
                                                "  <nombre name='Nombre' type='char' def='' nullable='false' /> " & _
                                                "  <english name='' type='char' def='' nullable='false' /> " & _
                                                "  <modalidad name='Modalidad' type='decimal' def='0' nullable='false' /> " & _
                                                "  <active name='Active' type='bit' def='false' nullable='false' /> " & _
                                                "  <tasafija name='Tasafija' type='bit' def='false' nullable='false' /> " & _
                                                "  <tasa name='Tasa' type='char' def='0' nullable='false' /> " & _
                                                "  <margen name='Margen' type='decimal' def='0' nullable='false' /> " & _
                                                "  <factor name='Factor' type='decimal' def='0' nullable='false' /> " & _
                                                "  <fondeo name='Fondeo' type='decimal' def='0' nullable='false' /> " & _
                                                "  <pnafinsa name='Pnafinsa' type='decimal' def='0' nullable='false' /> " & _
                                                "  <nafinsa name='Nafinsa' type='bit' def='false' nullable='false' /> " & _
                                                "  <inmobil name='Inmovil' type='bit' def='false' nullable='false' /> " & _
                                                "  <nrendepo name='Nrendepo' type='decimal' def='0' nullable='true' /> " & _
                                                "  <tipoactivo name='Tipoactivo' type='char' def='' nullable='false' /> " & _
                                                "  <c_defns name='C_defns' type='bit' def='false' nullable='false' /> " & _
                                                "  <defnsforma name='' type='char' def='' nullable='false' /> " & _
                                                "  <defnstexto name='Defnstexto' type='char' def='' nullable='true' /> " & _
                                                "  <c_perge name='C_perge' type='bit' def='false' nullable='false' /> " & _
                                                "  <pergeforma name='Pergeforma' type='char' def='' nullable='false' /> " & _
                                                "  <c_descr name='C_descr' type='bit' def='false' nullable='false' /> " & _
                                                "  <c_amort name='C_amort' type='bit' def='false' nullable='false' /> " & _
                                                "  <c_pagar name='C_pagar' type='bit' def='false' nullable='false' /> " & _
                                                "  <c_factu name='C_factu' type='bit' def='false' nullable='false' /> " & _
                                                "  <c_talon name='C_talon' type='bit' def='false' nullable='false' /> " & _
                                                "  <taxmensual name='Taxmensual' type='bit' def='false' nullable='false' /> " & _
                                                "  <extendido name='Extendido' type='char' def='' nullable='false' /> " & _
                                                "  <adjfactor name='Adjfactor' type='bit' def='false' nullable='false' /> " & _
                                                "  <pagofijo name='Pagofijo' type='bit' def='false' nullable='false' /> " & _
                                                "  <clausula name='Clausula' type='char' def='' nullable='false' /> " & _
                                                "  <afactor name='' type='bit' def='false' nullable='false' /> " & _
                                                "  <letra name='' type='char' def='' nullable='false' /> " & _
                                                "  <moneda name='moneda' type='decimal' def='0' nullable='false' /> " & _
                                                "  <iva_financ name='Iva_financ' type='bit' def='false' nullable='false' /> " & _
                                                "  <puro name='Puro' type='bit' def='false' nullable='false' /> " & _
                                                "  <depanual name='' type='decimal' def='0' nullable='false' /> " & _
                                                "  <abono_cap name='Abono_cap' type='bit' def='false' nullable='false' /> " & _
                                                "  <fira name='Fira' type='bit' def='false' nullable='false' /> " & _
                                                "  <void name='' type='bit' def='false' nullable='false' /> " & _
                                                "  <tasamora name='Tasamora' type='decimal' def='0' nullable='false' /> " & _
                                                "  <calcmora name='' type='char' def='' nullable='false' /> " & _
                                                "  <opcion name='Opcion' type='numeric' def='0' nullable='true' /> " & _
                                                "  <apertura name='' type='numeric' def='{null}' nullable='true' /> " & _
                                                "  <internet name='' type='bit' def='{null}' nullable='true' /> " & _
                                                "  <cesion name='Cesion' type='bit' def='false' nullable='true' /> " & _
                                                "  <fec_reca name='Fec_reca' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                "  <fec_cesion name='Fec_cesion' type='datetime' def='1900-01-01 00:00:00.000' nullable='true' /> " & _
                                                "  <mesesfijos name='' type='bit' def='{null}' nullable='true' /> " & _
                                                "  <segurosininteres name='seg_sinint' type='bit' def='false' nullable='true' /> " & _
                                                "  <ces_contcap name='ces_contcap' type='int' def='0' nullable='true' /> " & _
                                                "  <ces_contint name='ces_contint' type='int' def='0' nullable='true' /> " & _
                                                "  <renta_anti name='renta_anti' type='bit' def='false' nullable='true' /> " & _
                                                "  <devengue name='' type='bit' def='{null}' nullable='true' /> " & _
                                                "  <pagoanti name='' type='bit' def='{null}' nullable='true' /> " & _
                                                "  <colaboradores name='' type='bit' def='{null}' nullable='true' /> " & _
                                                "  <pagodomici name='pagodomici' type='bit' def='false' nullable='true' /> " & _
                                                "  <Anexo name='anexos' type='bit' def='false' nullable='true' /> " & _
                                                "  <text_anexo name='text_anexo' type='char' def='' nullable='true' /> " & _
                                                "  <condi_esp name='condi_esp' type='text' def='' nullable='true' /> " & _
                                                "  <tasacredito name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                "  <endosofira name='' type='bit' def='{null}' nullable='true' /> " & _
                                                "  <pgastoinspeccion name='' type='decimal' def='{null}' nullable='true' /> " & _
                                                "  <gastoinspeccion name='' type='bit' def='{null}' nullable='true' /> " & _
                                                "</esquema> "})
    End Sub

    Public Function Normaliza(ByRef origen As Object) As Object
      Dim oInterfaces = origen.GetType().GetInterfaces()
      Dim oTipos As List(Of String) = New List(Of String)({"IEnumerable", "IList", "ICollection"})
      Dim oInterface = oInterfaces.Where(Function(s) oTipos.Contains(s.Name))
      Dim oProps As IEnumerable(Of Reflection.PropertyInfo)
      If oInterface.Count > 0 Then
        If origen.Count > 0 Then
          Dim clasename = origen(0).GetType().Name
          CargaXML(clasename)
          If xmllist.Where(Function(w) w.name = clasename).Count > 0 Then
            oProps = origen(0).GetType().GetProperties().ToList
            For Each oOri In origen
              For Each oProp As System.Reflection.PropertyInfo In oProps
                DefaultValues(oOri, oProp)
              Next
            Next
          Else
            oProps = origen(0).GetType().GetProperties().ToList
            For Each oOri In origen
              For Each oProp As System.Reflection.PropertyInfo In oProps
                DefaultValues(oOri, oProp)
              Next
            Next
          End If
        End If
      Else
        Dim clasename = origen.GetType().Name
        If xmllist.Where(Function(w) w.name = clasename).Count > 0 Then
          CargaXML(clasename)
          oProps = origen.GetType().GetProperties().ToList
          For Each oProp As System.Reflection.PropertyInfo In oProps
            DefaultValues(origen, oProp)
          Next
        Else
          oProps = origen.GetType().GetProperties().ToList
          For Each oProp As System.Reflection.PropertyInfo In oProps
            DefaultValues(origen, oProp)
          Next
        End If
      End If
      LiberaXML()
      Return origen
    End Function

    Private Sub DefaultValues(ByRef clase As Object, ByRef prop As System.Reflection.PropertyInfo)
      If prop.PropertyType.Name.Contains("Nullable") Then
        SetDefaults(clase, prop)
      Else
        If prop.PropertyType.FullName = "System.Byte[]" Then
          If prop.GetValue(clase) Is Nothing Then
            prop.SetValue(clase, Nothing)
          End If
          Exit Sub
        End If
        For Each tipo In tiposNumero
          If prop.PropertyType.FullName.Contains(tipo) Then
            If prop.GetValue(clase) Is Nothing Then
              Dim nulltype = Nullable.GetUnderlyingType(prop.PropertyType)
              Dim value = Convert.ChangeType(-1, nulltype)
              prop.SetValue(clase, value, Nothing)
            End If
            Exit Sub
          End If
        Next
        For Each tipo In tiposTexto
          If prop.PropertyType.FullName.Contains(tipo) Then
            If prop.GetValue(clase) Is Nothing Then
              If prop.PropertyType.Name.ToLower = "char" Then
                prop.SetValue(clase, " "c, Nothing)
              Else
                prop.SetValue(clase, "", Nothing)
              End If
            End If
            Exit Sub
          End If
        Next
        For Each tipo In tiposFecha
          If prop.PropertyType.FullName.Contains(tipo) Then
            If prop.GetValue(clase) Is Nothing Then
              prop.SetValue(clase, New DateTime(1900, 1, 1, 0, 0, 0))
            Else
              If prop.GetValue(clase) < New DateTime(1753, 1, 1, 0, 0, 0, 0) Then
                prop.SetValue(clase, New DateTime(1900, 1, 1, 0, 0, 0))
              End If
              If prop.GetValue(clase) > New DateTime(9999, 12, 31, 23, 59, 59, 997) Then
                prop.SetValue(clase, New DateTime(1900, 1, 1, 0, 0, 0))
              End If
            End If
            Exit Sub
          End If
        Next
        If prop.PropertyType.FullName.Contains("Boolean") Then
          If prop.GetValue(clase) Is Nothing Then
            prop.SetValue(clase, False)
          End If
          Exit Sub
        End If
      End If
    End Sub

    Private Sub SetDefaults(ByRef clase As Object, ByRef prop As System.Reflection.PropertyInfo)
      Dim sName = prop.Name
      If Camposxml Is Nothing Then
        Defaultval(clase, prop)
      Else
        If prop.GetValue(clase) Is Nothing Then
          Dim field = Camposxml.Where(Function(w) w.Name = sName)
          If field.Count() > 0 Then
            Dim value = ValorAtributosXML(field.Single(), attrName.Valor, prop)
            If (prop.PropertyType.Name.ToLower = "char") Then
              If (value.ToString().Length = 0) Then
                prop.SetValue(clase, " "c)
              Else
                prop.SetValue(clase, Convert.ToChar(value))
              End If
            Else
              prop.SetValue(clase, value)
            End If
            value = Nothing
            field = Nothing
          Else
            Defaultval(clase, prop)
          End If
        Else
          Defaultval(clase, prop)
        End If
      End If
    End Sub

    Private Sub Defaultval(ByRef clase As Object, ByRef prop As System.Reflection.PropertyInfo)
      If prop.GetValue(clase) Is Nothing Then
        If prop.PropertyType.Name.Contains("Nullable") Then
          If tiposNumero.Contains(Nullable.GetUnderlyingType(prop.PropertyType).Name) Then
            Dim nulltype = Nullable.GetUnderlyingType(prop.PropertyType)
            Dim value = Convert.ChangeType(-1, nulltype)
            prop.SetValue(clase, value)
            Exit Sub
          End If
          If tiposFecha.Contains(Nullable.GetUnderlyingType(prop.PropertyType).Name) Then
            Dim nulltype = Nullable.GetUnderlyingType(prop.PropertyType)
            Dim value = Convert.ChangeType(New Date(1900, 1, 1), nulltype)
            prop.SetValue(clase, value)
            Exit Sub
          End If
          If Nullable.GetUnderlyingType(prop.PropertyType).Name = "Boolean" Then
            Dim nulltype = Nullable.GetUnderlyingType(prop.PropertyType)
            Dim value = Convert.ChangeType(False, nulltype)
            prop.SetValue(clase, value)
            Exit Sub
          End If
        Else
          If prop.PropertyType.Name = "Byte[]" Then
            prop.SetValue(clase, New Byte())
            Exit Sub
          End If
          If tiposNumero.Contains(prop.PropertyType.Name) Then
            prop.SetValue(clase, -1)
            Exit Sub
          End If
          If tiposTexto.Contains(prop.PropertyType.Name) Then
            If prop.PropertyType.Name = "Char" Then
              prop.SetValue(clase, " "c)
            Else
              prop.SetValue(clase, "")
            End If
            Exit Sub
          End If
          If tiposFecha.Contains(prop.PropertyType.Name) Then
            prop.SetValue(clase, New Date(1900, 1, 1))
            Exit Sub
          End If
          If prop.PropertyType.Name = "Boolean" Then
            prop.SetValue(clase, False)
            Exit Sub
          End If
        End If
      Else
        If tiposFecha.Contains(prop.PropertyType.FullName.ToLower) Then
          If prop.GetValue(clase) < New DateTime(1753, 1, 1, 0, 0, 0, 0) Then
            prop.SetValue(clase, New DateTime(1900, 1, 1, 0, 0, 0))
          End If
          If prop.GetValue(clase) > New DateTime(9999, 12, 31, 23, 59, 59, 997) Then
            prop.SetValue(clase, New DateTime(1900, 1, 1, 0, 0, 0))
          End If
          Exit Sub
        End If
      End If
    End Sub

    Private Function ValorAtributosXML(ByRef element As System.Xml.XmlElement, ByVal attrName As attrName, ByRef prop As System.Reflection.PropertyInfo) As Object
      Dim xmlval As Object = Nothing
      Try
        Dim attrlst = From attr As System.Xml.XmlAttribute In element.Attributes Select attr
        If attrName = standardization.attrName.Nombre Then
          xmlval = attrlst.Where(Function(w) w.Name = "name").Single().Value.Trim
        ElseIf attrName = standardization.attrName.Tipo Then
          xmlval = attrlst.Where(Function(w) w.Name = "type").Single().Value.Trim
        ElseIf attrName = standardization.attrName.Valor Then
          xmlval = GetValueXML(element, prop)
        End If
        attrlst = Nothing
      Catch ex As Exception
        Throw ex
      End Try
      Return xmlval
    End Function

    Private Function GetValueXML(ByRef element As System.Xml.XmlElement, ByRef prop As System.Reflection.PropertyInfo) As Object
      Dim xmlval As Object = Nothing
      Try
        Dim attrlst = From attr As System.Xml.XmlAttribute In element.Attributes Select attr
        Dim sValue = attrlst.Where(Function(w) w.Name = "def").Single().Value.Trim
        Dim bnullable = If(attrlst.Where(Function(w) w.Name = "nullable").Single().Value.Trim = "true", True, False)
        xmlval = setval(sValue, bnullable, prop)
        attrlst = Nothing
      Catch ex As Exception
        Throw ex
      End Try
      Return xmlval
    End Function

    Private Function setval(ByVal svalue As String, ByVal bnullable As Boolean, ByRef prop As System.Reflection.PropertyInfo) As Object
      Dim val As Object = Nothing
      Try
        If bnullable And svalue = "{null}" Then
          If tiposNumero.Contains(Nullable.GetUnderlyingType(prop.PropertyType).Name) Then
            val = Nothing
          ElseIf tiposFecha.Contains(Nullable.GetUnderlyingType(prop.PropertyType).Name) Then
            val = Nothing
          ElseIf Nullable.GetUnderlyingType(prop.PropertyType).Name = "Boolean" Then
            val = Nothing
          Else
            If Nullable.GetUnderlyingType(prop.PropertyType).Name = "Char" Then
              val = " "c
            Else
              val = ""
            End If
          End If
        Else
          If prop.PropertyType.Name.Contains("Nullable") Then
            If tiposNumero.Contains(Nullable.GetUnderlyingType(prop.PropertyType).Name) Then
              Dim nulltype = Nullable.GetUnderlyingType(prop.PropertyType)
              val = Convert.ChangeType(CDbl(If(svalue.Trim.Length = 0, "-1", svalue)), nulltype)
            ElseIf tiposFecha.Contains(Nullable.GetUnderlyingType(prop.PropertyType).Name) Then
              Dim nulltype = Nullable.GetUnderlyingType(prop.PropertyType)
              val = Convert.ChangeType(CDate(If(svalue.Trim.Length = 0, "1900-01-01", svalue)), nulltype)
            ElseIf Nullable.GetUnderlyingType(prop.PropertyType).Name = "Boolean" Then
              Dim nulltype = Nullable.GetUnderlyingType(prop.PropertyType)
              val = Convert.ChangeType(If(svalue.Trim.Length = 0, False, If(svalue.ToLower.Trim = "false", False, True)), nulltype)
            End If
          Else
            If tiposNumero.Contains(prop.PropertyType.Name) Then
              val = -1
            ElseIf tiposFecha.Contains(prop.PropertyType.Name) Then
              val = New Date(1900, 1, 1)
            ElseIf prop.PropertyType.Name = "Boolean" Then
              val = False
            Else
              If prop.PropertyType.Name = "Char" Then
                val = " "c
              Else
                val = ""
              End If
            End If
          End If
        End If
      Catch ex As Exception
        Throw ex
      End Try
      Return val
    End Function
#End Region

#Region "OUTBOX"
    Public Function ChangesOutbox(ByRef objOriginal As Object, ByRef objModificado As Object, ByRef Llaves As List(Of String)) As String
      Dim props = objOriginal.GetType().GetProperties
      Dim c As String = ""
      For Each prop As System.Reflection.PropertyInfo In props
        If Llaves.Select(Function(s) s.ToLower).ToList.Contains(prop.Name.ToLower) Then
          c &= Me.GenerarOutbox(prop, objModificado)
        Else
          If SiNuloDefaul(prop.GetValue(objOriginal)) <> SiNuloDefaul(prop.GetValue(objModificado)) Then
            c &= Me.GenerarOutbox(prop, objModificado)
          End If
        End If
      Next
      Return c
    End Function

    Public Function GenerarOutbox(ByRef prop As System.Reflection.PropertyInfo, ByRef clase As Object) As String
      Dim s As String
      Dim campo As String = ""
      Dim sName = prop.Name
      Dim sDataTypeName As String = ""

      If Not Me.Camposxml Is Nothing Then
        Dim field = Me.Camposxml.Where(Function(w) w.Name = sName)
        If field.Count > 0 Then
          campo = Me.NombreCampoOubux(field.Single, prop)
        Else
          campo = prop.Name
        End If
        field = Nothing
      Else
        campo = prop.Name
      End If

      If InStr(prop.PropertyType.Name, "Nullable") > 0 Then
        sDataTypeName = Nullable.GetUnderlyingType(prop.PropertyType).Name
      Else
        sDataTypeName = prop.PropertyType.Name
      End If

      Dim valor As String = Me.SiNuloDefaul(prop.GetValue(clase), sDataTypeName)

      If tiposFecha.Contains(sDataTypeName) Then
        If CDate(valor) <= CDate("#1/1/1900 00:00:00#") Then
          valor = "{}"
        Else
          Dim d As Date = CDate(valor)
          valor = Format(d, "{dd/MM/yyyy HH:mm:ss}")
        End If
      ElseIf Me.tiposNumero.Contains(sDataTypeName) Then
      Else
        If valor = "True" Then
          valor = "T"
        ElseIf valor = "False" Then
          valor = "F"
        End If
        valor = valor.Trim
      End If

      s = standardization.EXPR_START & campo.ToUpper & standardization.OUT_BEGIN & valor & standardization.OUT_END & vbCrLf
      Return s
    End Function

    Protected Function SiNuloDefaul(ByRef param As Object, Optional ByVal datatypename As String = "") As Object
      If param IsNot Nothing Then
        Return param.ToString.Trim
      ElseIf Me.tiposFecha.Contains(datatypename) Then
        Return "#1/1/1900 00:00:00#"
      Else
        Return String.Empty
      End If
    End Function

    Protected Function NombreCampoOubux(ByRef nodexml As System.Xml.XmlNode, ByVal prop As System.Reflection.PropertyInfo) As String
      Dim sName As String = ""
      Dim oName = nodexml.Attributes.GetNamedItem("name")
      If oName.Value.Trim.Length > 0 Then
        sName = oName.Value
      Else
        sName = prop.Name
      End If
      Return sName
    End Function
#End Region

    Public Sub CargaXML(ByVal clase As String)
      Dim Xml As Xml.XmlDocument = Nothing
      Me.LiberaXML()

      If xmllist.Where(Function(w) w.name = clase).Count > 0 Then
        Xml = New Xml.XmlDocument()
        Xml.LoadXml(xmllist.Where(Function(w) w.name = clase).SingleOrDefault.value)
      End If

      If Xml IsNot Nothing Then
        Dim nodos = From n As System.Xml.XmlNode In Xml.ChildNodes
                    Select n

        Me.Camposxml = From n As System.Xml.XmlNode In nodos.Where(Function(w) w.Name = clase.Trim).Single().ChildNodes()
                 Select n

        If Me.Camposxml Is Nothing Then Throw New Exception(String.Format("Error: {0} debe de tener un XML y no fue encontrado", clase.Trim))
        If Me.Camposxml.Count <= 0 Then Throw New Exception(String.Format("Error: el XML de {0} no tiene campos", clase.Trim))
      End If

    End Sub

    Public Sub LiberaXML()
      If Not Me.Camposxml Is Nothing Then Me.Camposxml = Nothing
    End Sub

    Protected Sub Release()
      If Me.Camposxml IsNot Nothing Then Me.Camposxml = Nothing
      If Me.xmllist IsNot Nothing Then Me.xmllist.Clear()
      If Me.xmllist IsNot Nothing Then Me.xmllist = Nothing
      If Me.tiposTexto IsNot Nothing Then Me.tiposTexto.Clear()
      If Me.tiposTexto IsNot Nothing Then Me.tiposTexto = Nothing
      If Me.tiposFecha IsNot Nothing Then Me.tiposFecha.Clear()
      If Me.tiposFecha IsNot Nothing Then Me.tiposFecha = Nothing
      If Me.tiposNumero IsNot Nothing Then Me.tiposNumero.Clear()
      If Me.tiposNumero IsNot Nothing Then Me.tiposNumero = Nothing
    End Sub

  End Class
End Namespace