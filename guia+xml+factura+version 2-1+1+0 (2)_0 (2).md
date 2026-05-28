![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.001.png)

**Guía de Elaboración de Documentos XML       Factura Electrónica UBL 2.1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.002.png)**

**PROYECTO DE COMPROBANTES DE PAGO** 

**ELECTRONICOS**  

**Versión 1.0** 

**Mayo 2017** 

Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

***INDICE*** 

1  INTRODUCCION............................................................................................................ 3 2  FACTURA ELECTRONICA ............................................................................................ 4 

1. Contenido de la factura electrónica ..................................................................................... 4 
1. Estructura de Factura electrónica vs Formato XML .......................................................... 19 
1. Normas de Uso del Formato de la Factura Electrónica ..................................................... 24 A  Normas de Uso .................................................................................................................. 24 A.1 Elementos de la Factura electrónica .................................................................................. 25 
1. Firma Digital. ......................................................................................................................... 25 
1. Versión del UBL. ................................................................................................................... 27 
1. Versión de la estructura del documento. .............................................................................. 27 
1. Tipo de Operación. ............................................................................................................... 28 
1. Numeración, conformada por serie y número correlativo. .................................................... 29 
1. Fecha de emisión. ................................................................................................................. 30 
1. Hora de emisión. ................................................................................................................... 31 8 Fecha de Vencimiento. .......................................................................................................... 31 9 Código de Tipo de documento. .............................................................................................. 32 

   10\. Leyendas............................................................................................................................. 32 11 Tipo de moneda. .................................................................................................................. 34 12 Tipo y número de la guía de remisión relacionada con la operación que se factura. ......... 36 

   13 Tipo y número de otro documento y/ código documento relacionado con la operación que 

se factura. ..................................................................................................................... 37 

14 Nombre Comercial. .............................................................................................................. 38 15 Apellidos y nombres o denominación o razón social del emisor. ........................................ 38 16 Tipo y Número de RUC del Emisor. .................................................................................... 39 17 Código del domicilio fiscal o de local anexo del emisor. ..................................................... 40 18 Tipo y número de documento de identidad del adquirente o usuario.................................. 40 19 Apellidos y nombres o denominación o razón social del adquirente o usuario. .................. 41 20 Dirección del lugar en el que se entrega el bien.................................................................. 42 21 Descuentos Globales ........................................................................................................... 43 22 Monto Total de Impuestos. .................................................................................................. 44 

23 Total valor de venta - operaciones gravadas....................................................................... 44 24 Total valor de venta - operaciones exoneradas................................................................... 45 25 Total valor de venta - operaciones inafectas. ...................................................................... 47 26 Total Valor de Venta de Operaciones gratuitas. .................................................................. 48 27 Sumatoria IGV. .................................................................................................................... 50 28 Sumatoria ISC. ..................................................................................................................... 51 29 Sumatoria otros tributos. ...................................................................................................... 52 30 Total Valor de Venta. ........................................................................................................... 54 31 Total Precio de Venta. ......................................................................................................... 54 32 Total de Descuentos. ........................................................................................................... 55 33 Sumatoria otros Cargos. ...................................................................................................... 55 34 Importe total de la venta, de la cesión en uso o del servicio prestado. ............................... 56 35 Número de orden del Ítem. .................................................................................................. 56 36 Cantidad y Unidad de Medida por ítem. .............................................................................. 56 37 Valor de venta por ítem........................................................................................................ 58 38 Precio de venta unitario por ítem y código. ......................................................................... 58 

39 Valor referencial unitario por ítem en operaciones no onerosas ......................................... 59 40 Descuentos por ítem ............................................................................................................ 60 41 Cargos por ítem ................................................................................................................... 61 42 Afectación al IGV por ítem. .................................................................................................. 62 43 Sistema de ISC por ítem ...................................................................................................... 64 44  Descripción detallada. ....................................................................................................... 65 45 Código de producto del Ítem. ............................................................................................... 66 46 Código de producto SUNAT. ............................................................................................... 67 47 Propiedades Adicionales del Ítem ....................................................................................... 68 48 Valor unitario por ítem.......................................................................................................... 71 B.2  Detalle de elementos complejos ........................................................................................... 72 B.2.1 Tag UBLExtension ........................................................................................................... 72 2.5  Ejemplos de casos identificados ........................................................................................ 76 

1. Factura con 4 ítems y una bonificación ............................................................................. 76 
1. Factura con 2 ítems e ISC ................................................................................................. 87 
1. Factura de Transferencia Gratuita ..................................................................................... 97 

**1 INTRODUCCION** 

Continuando con el objetivo de promover la emisión electrónica de los comprobantes de pago, documentos relacionados a estos y otros documentos de carácter tributario, se ha considerado conveniente incorporar en el Sistema de Emisión Electrónica (SEE) un nuevo sistema que permita la emisión electrónica denominado: SEE- Operador de Servicios Electrónicos (SEE- OSE), el cual tiene como principal función comprobar informáticamente el cumplimiento de los aspectos esenciales de lo emitido en el referido sistema. 

Por otro lado, al ser este un nuevo sistema se hace necesario realizar la presente guía de elaboración de documentos electrónicos XML (Lenguaje Extensible de Marcado) , que permita presentar el análisis e identificación de los campos tributarios requeridos para la emisión de los comprobantes  de  pago  y  demás  documentos  electrónicos  regulados  por  la  Resolución  de Superintendencia 117-2017/SUNAT y modificatorias. Ahora bien, la presente guía no limita el uso de campos adicionales “no tributarios”, en cuyo caso, se deberá identificar en el referido estándar el campo (Tag) correspondiente para cada dato no tributario. 

Por  su  parte,  el  estándar  UBL  es  extenso  ya  que  permite  especificar  gran  cantidad  de información  relacionada  con  los  procesos  comerciales,  siendo  que  las  referidas  *guías  de elaboración* solo abarcan la información tributaria. Se recomienda revisar también la propia definición  del  estándar  Universal  Business  Language  (UBL)  y  contar  a  su  vez  con  una aplicación que permita validar y editar archivos de tipo XML. 

Es preciso señalar que el UBL es una librería estándar de documentos XML, diseñados para representar documentos comerciales tales como órdenes de compra,  facturas, etc. Ha sido desarrollado por un comité técnico de la organización OASIS  (www.oasis-open.org), con la participación de varias organizaciones relacionadas con los estándares de datos en la industria. UBL está pensado para integrarse directamente en los procesos de intercambio electrónico de datos entre empresas e instituciones, así como en internet 

Ahora bien, considerando que se ha actualizado la versión UBL 2.1 se hace necesario redefinir las  estructuras  a  fin  de  dejar  de  utilizar  extensiones  o  elementos  propios,  para  utilizar  de manera completa el estándar internacional. Además de lo indicado en la presente versión se hace uso de atributos para identificar de manera adecuada la información que se está enviando y facilitar así el interoperabilidad de las transacciones entre los contribuyentes y usuarios del comercio exterior.   

Las  guías  de  elaboración  de  documentos  electrónicos  XML  se  han  definido  para  los documentos que se indican a continuación y sólo representan herramientas técnicas de ayuda. No constituyen documentos de interpretación tributaria: 

1. Factura Electrónica 
1. Boleta de Venta Electrónica 
1. Nota de Crédito Electrónica 
1. Nota de Débito electrónica 
1. Resumen Diario de Boletas de Venta y notas de crédito y debito relacionadas 
1. Comunicación de Baja 

**2 FACTURA ELECTRONICA** 

La factura electrónica es la factura regulada por el Reglamento de Comprobantes de pago (RS 007-99/SUNAT) soportada en un formato digital que cumple con las especificaciones reguladas  en  la  R.S.097-2012/SUNAT,  R.S.177-2017/SUNAT  y  modificatorias,  que  se encuentra firmada digitalmente. 

1. **Contenido de la factura electrónica** 

En el cuadro siguiente, se describe el contenido (campos) de la Factura electrónica. Para tal efecto, es necesario establecer previamente, la  nomenclatura de representación  del valor de los datos, para una comprensión correcta del referido cuadro: 

a  carácter alfabético ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.004.png)

n  carácter numérico ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.005.png)

an  carácter alfanumérico 

a3  3 caracteres alfabéticos de longitud fija ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.006.png)

n3  3 caracteres numéricos de longitud fija an3  3 caracteres alfa-numéricos de longitud fija ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.007.png)a...3  hasta 3 caracteres alfabéticos 

n…3  hasta 3 caracteres numéricos ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.008.png)

an...3  hasta 3 caracteres alfa-numéricos 

Asimismo, la obligatoriedad o no de un determinado elemento se identifica por la siguiente nomenclatura: 

**M**: Mandatorio u obligatorio 

**C**: Condicional u opcional 

En  relación  a  la  identificación  del  formato  de  los  elementos  de  datos  se  especifica  lo siguiente: 

n(12,2)  elemento numérico hasta12 enteros + punto decimal + hasta ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.009.png)

dos decimales 

n(2,2)  elemento numérico hasta 2 enteros + 

punto decimal + hasta dos decimales 

|F##### ||elemento inicia con la letra F seguida de cinco dígitos |
| - | :- | - |
|YYYY-MM-DD ||formato fecha yyyy=año, mm=mes, dd=día |

En el siguiente cuadro se muestran las características de los requisitos solicitados por SUNAT para la Factura electrónica: 

Factura Electrónica  ~ 4 ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

**CONTENIDO DE LA FACTURA ELECTRONICA** 



|Raíz |Nodo |Atributo |DATO |Cardinalidad UBL |Valor/ Formato |Observ. |Factura |RRSSPP |||
| - | - | - | - | :-: | :- | - | - | - | :- | :- |
|` `**/Invoice** |- ||||||||||
|**/Invoice/ext:UBLExtensions** |0\..1 ||||||||||
|**/Invoice/ext:UBLExtensions/ext:UBLExtension** |1\..n ||||||||||
|**/Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent** |1 ||||||||||
||ds:Signature ||Firma Digital |0\..1 |"2.1" ||x |x |||
||cbc:UBLVersionID ||Versión del UBL ||||x |x |||
||cbc:CustomizationID ||Versión de la estructura del documento |0\..1 |"2.0" |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.011.png)</p><p>[Catálogo 51](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo17)</p>|x |x |||
||cbc:ProfileID ||Código de tipo de operación |0\..1 |<p>an2 </p><p>"SUNAT:Identificador de Tipo de Operación" </p>||||||
|||@schemeName |- |0\..1 |||||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||||
|||@schemeURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo17" ||||||
||cbc:ID ||Serie y número del comprobante |1 |F###-NNNNNNNN |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.012.png)|x |x |||
||cbc:IssueDate ||Fecha de emisión |1 |yyyy-mm-dd |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.013.png)|x |x |||
||cbc:IssueTime ||Hora de emisión |0\..1 |hh-mm-ss.0z ||x |x |||
||cbc:DueDate ||Fecha de vencimiento |0\..1 |yyyy-mm-dd |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.014.png)</p><p>[Catálogo 01](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!%23¡REF!)</p>|x |x |||
||cbc:InvoiceTypeCode ||Código de tipo de documento |0\..1 |an2 ||x ||||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||||
|||@listName |- |0\..1 |"SUNAT:Identificador de Tipo de Documento" ||||||
|||@listURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo01" ||||||
||cbc:Note ||Leyenda |0\..n |an..100 ||x |x |||
|||@languageLocaleID |Código de leyenda |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo52" |[Catálogo 52](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo52)|x |x |||
||||||||||||
||cbc:DocumentCurrencyCode ||Código de tipo de moneda en la cual se emite la factura electrónica |0\..1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x |x |||
|||@listID |- |0\..1 |"ISO 4217 Alpha" ||||||
|||@listName |- |0\..1 |Currency ||||||
|||@listAgencyName |- |0\..1 |United Nations Economic Commission for Europe ||||||
||cbc:LineCountNumeric ||Cantidad de ítems de la factura |0\..1 |n3 ||x ||||
||||||||||||
||||||||||||
||||||||||||
|**/Invoice/cac:InvoicePeriod** |0\..n |yyyy-mm-dd |||x ||||||
||cbc:StartDate ||Fecha de inicio de ciclo de facturación |0\..1 |||||||
||cbc:EndDate ||Fecha de fin de ciclo de facturación |0\..1 |yyyy-mm-dd |||x |||
|**/Invoice/cac:OrderReference** |0\..1 ||||||||||
||cbc:ID ||Número de la orden de compra |1 |an..20 |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.015.png)</p><p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.016.png)</p>|x |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.017.png)</p><p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.018.png)</p>|||
|<p>**/Invoice/cac:DespatchDocumentReference** <br>cbc:ID  ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.019.png)![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.020.png)![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.021.png)![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.022.png)</p><p>Número de guía de remisión relacionada con la operación que se factura </p>|0\..n 1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.023.png)|NNNN-NNNNNNNN/ R###-NNNNNNNN ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.024.png)||x ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.025.png)|||||||
||cbc:DocumentTypeCode ||Código de tipo de guía de remisión relacionada con la operación que se factura |0\..1 |an2 |[Catálogo 01](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!%23¡REF!)|x ||||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||||
|||@listName |- |0\..1 |"SUNAT:Identificador de guía relacionada" ||||||
|||@listURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo12" ||||||
|**/Invoice/cac:ContractDocumentReference** |||||||||||
||cbc:ID ||Número de suministro/Número de teléfono |1 |an..9 |[Catálogo 56](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo56)|![ref3]|x |||
||cbc:DocumentTypeCode ||Tipo de Servicio Público |0\..1 |n1 |||x |||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||||
|||@listName |- |0\..1 |"SUNAT:Identificador de Tipo de Servicio" ||||||
|||@listURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo56" ||||||
||cbc:LocaleCode ||Código de Servicios de Telecomunicaciones (De corresponder) |0\..1 |n1 |[Catálogo 57](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catálogo57)||x |||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||||
|||@listName |- |0\..1 |"SUNAT:Identificador de Servicio de Telecomunicación" ||||||
|![ref4]||@listURI ![ref5]|- |0\..1 ![ref6]|"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo57" ||||||
||cbc:DocumentStatusCode ||Código de Tipo de Tarifa contratada |0\..1 |an..4 |Catálogo 24 |![ref3]|x |||
|||@listAgencyName |- |0\..1 |PE:SUNAT ||||||
|||@listName |- |0\..1 |SUNAT:Identificador de Tipo de Tarifa ||||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.030.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.031.png)|@listURI ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.032.png)|- ![ref7]|0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.034.png)|urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo24 ||||||


|**/Invoice/cac:AdditionalDocumentReference** |0\..n ||||||||
| - | - | :- | :- | :- | :- | :- | :- | :- |
||cbc:ID ||Número de documento relacionado con la operación que se factura |1 |an..30 ||x ||
||cbc:DocumentTypeCode ||Código de tipo de documento relacionado con la operación que se factura |0\..1 |an2 |[Catálogo 12](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo12)|x ||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@listName |- |0\..1 |"SUNAT:Identificador de documento relacionado" ||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.035.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.036.png)|@listURI ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.037.png)|- ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.038.png)|0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.039.png)|"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo12" ||||
|**/Invoice/cac:Signature**  |Información adicional de la firma |0\..n |an..100 ||x |x |||
|**/Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyName** |0\..n |||x |x ||||
||cbc:Name ||Nombre Comercial del emisor |1\..1 |||||
|**/Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyTaxScheme** |0\..n |an..100 |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.040.png)|x |x ||||
||cbc:RegistrationName ||Nombre o razón social del emisor |0\..1 |||||
||cbc:CompanyID ||Número de RUC del emisor |0\..1 |n11 |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.041.png)</p><p>[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)</p>|x |x |
|||@schemeID |Tipo de Documento de Identidad del Emisor |0\..1 |an1 ||x |x |
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.042.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.043.png)|@schemeName ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.044.png)|- |0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.045.png)|"SUNAT:Identificador de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.046.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.047.png)|@schemeURI ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.048.png)|- |0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.049.png)|"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo06" ||||
|**/Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyTaxScheme/cac:RegistrationAddress** |0\..1 ||||||||
||cbc:AddressTypeCode ||Código del domicilio fiscal o de local anexo del emisor |0\..1 |n4 ||x |x |
|**/Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme** |0\..n ||||||||
||cbc:RegistrationName ||Nombre o razón social del adquirente o usuario  |0\..1 |an..100 |<p>![ref8]</p><p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.051.png)</p>|x |x |
||cbc:CompanyID ||Número de RUC del adquirente o usuario  |0\..1 |n11 ||x |x |
|||@schemeID |Tipo de Documento de Identidad del Emisor |0\..1 |an1 |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x |x |
|||@schemeName |- |0\..1 |"SUNAT:Identificador de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@schemeURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo06" ||||


|**/Invoice/cac:Delivery** |0\..n ||||x ||||
| - | - | :- | :- | :- | - | :- | :- | :- |
||cbc:ID ||Número de medidor (Servicios públicos) |0\..1 |||||
|||@schemeID |Código del tipo de medidor (Servicio de luz) |0\..1 |n1 |[Catálogo 58](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catálogo57)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.052.png)|x |
|||@schemeName |- |0\..1 |"SUNAT:Identificador de Tipo de Medidor" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@schemeURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo58" ||||
||cbc:Quantity ||Consumo del periodo (Servicios públicos) |0\..1 |n10 |[Catálogo 03](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo03)||x |
|||@unitCode |Código de unidad de medida del consumo del periodo |0\..1 |an3 |||x |
|||@unitCodeListID |- |0\..1 |UN/ECE rec 20 ||||
|||@unitCodeListAgencyN ame |- |0\..1 |United Nations Economic Commission for Europe ||||
||cbc:MaximumQuantity ||Potencia contratada (Servicios públicos) |0\..1 |n..5 |[Catálogo 03](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo03)||x |
|||@unitCode |Código de unidad de medida de la potencia contratada |0\..1 |an3 |||x |
|||@unitCodeListID |- |0\..1 |UN/ECE rec 20 ||||
|||@unitCodeListAgencyN ame |- |0\..1 |United Nations Economic Commission for Europe ||||
|**/Invoice/cac:Delivery/cac:DeliveryLocation/cac:LocationCoordinate** |0\..n ||||x ||||
||cbc:LatitudeDirectionCode ||Ubicación geográfica del medidor |0\..1 |||||
||cbc:LongitudeDirectionCode ||Ubicación geográfica del medidor |0\..1 ||||x |
|**/Invoice/cac:Delivery/cac:DeliveryParty/cac:PartyLegalEntity** |0\..n ||||||||
||cbc:CompanyID ||Número de documento de identidad del destinatario |1 |n11 ||x ||
|||@schemeID |Código de tipo  de documento de identidad del destinatario |0\..1 |an1 |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x ||
|![ref9]||@schemeName |- |0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.054.png)|"SUNAT:Identificador de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|![ref10]|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.056.png)|@schemeURI ![ref11]|- ![ref12]|0\..1 ![ref13]|"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo06" ||||
|<p>**/Invoice/cac:Delivery/cac:DeliveryParty/cac:PartyLegalEntity** </p><p>Apellidos y nombres, denominacion o razon ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.060.png)</p><p>cbc:RegistrationName </p><p>social del destinatario </p>|0\..n 1 |an..100 ||x |||||


|**/Invoice/cac:Delivery/cac:Shipment** |0\..1 ||||||||
| - | - | :- | :- | :- | :- | :- | :- | :- |
||cbc:HandlingCode ||Código de motivo del traslado |0\..1 |an2 |[Catálogo 20](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo20)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.061.png)|
|||@listName |- |0\..1 |"SUNAT:Indicador de Motivo de Traslado" ||||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@listURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo20" ||||
||cbc:GrossWeightMeasure ||Peso bruto total |0\..1 |n(12,3) |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.062.png)</p><p>[Catálogo 03](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo03)</p>|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.063.png)|
|||@unitCode |Código de unidad de medida |1 |an3 ||x ||
|||@unitCodeListVersionID |- ||UN/ECE rec 20 Revision 4 ||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:ShipmentStage** |0\..n ||||||||
||cbc:TransportModeCode ||Modalidad de Transporte |0\..1 |an2 |[Catálogo 18](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo18)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.064.png)|
|||@listName |- |0\..1 |"SUNAT:indicador de Modalidad de Transporte" ||||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@listURI |- |0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo18" ||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:TransitPeriod**  |0\..1 |yyyy-mm-dd ||x |||||
||cbc:StartDate ||Fecha de inicio del traslado o fecha de entrega de bienes al transportista |0\..1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:CarrierParty/cac:PartyLegalEntity** |0\..n |n11 "6" |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.065.png)||||
|![ref9]|<p>cbc:CompanyID </p><p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.066.png)</p>|@schemeID ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.067.png)|Numero de RUC del transportista |1 0..1 |||||
||||Código de tipo de documento de identidad del transportista ||||||
||||||||||
|||@schemeName |- |0\..1 |"SUNAT:Indicador de Tipo de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@schemeURI |- ||"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo06" ||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:CarrierParty/cacPartyLegalEntity** |0\..n |an..100 ||x |||||
||cbc:RegistrationName ||Apellidos y Nombres o denominacion o razon social del transportista |1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:TransportMeans** |0\..1 |an..40 ||x |||||
||cbc:RegistrationNationalityID ||Número de constancia de inscripcion del vehiculo o certificado de habilitación vehicular |0\..1 |||||


|**/Invoice/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:TransportMeans/cac:RoadTransport** |0\..1 |an..8 ||x |||||
| - | - | - | :- | - | :- | :- | :- | :- |
||cbc:LicensePlateID ||Numero de placa del vehiculo del vehiculo que realiza el traslado |1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:DriverPerson**  |0\..n |n11 ||x |||||
||cbc:ID ||Número de Documento de los conductores |1 |||||
|||@schemeID |Tipo de Documento de los conductores |0\..1 |an1 |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.068.png)|
|||@schemeName |- |0\..1 |"SUNAT:Indicador de Tipo de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@schemeURI |- ||"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo06" ||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:Delivery/cac:DeliveryAddress** |0\..1 |n6 |[Catálogo 13](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo13)|x |||||
||cbc:CountrySubentityCode ||Direccion del punto de llegada (Código de ubigeo) |0\..1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:Delivery/cac:DeliveryAddress/cac:AddressLine** |0\..n |an..100 ||x |||||
||cbc:Line ||Direccion del punto de llegada (Dirección completa y detallada) |1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:Delivery/cac:DeliveryParty** |0\..1 |true/"false" ||x |||||
||cbc:MarkAttentionIndicator ||Indicador de subcontratación (en caso de Factura Guia Transportista) |0\..1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:TransportEquipment** |0\..1 |an..8 ||x |||||
||cbc:ID ||Numero de placa del vehiculo del vehiculo que realiza el traslado |1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:OriginAddress** |0\..1 |n6 |[Catálogo 13](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo13)|x |||||
||cbc:CountrySubentityCode ||Direccion del punto de partida (Código de ubigeo) |0\..1 |||||
|**/Invoice/cac:Delivery/cac:Shipment/cac:OriginAddress/cac:AddressLine** |0\..n |an..100 ||x |||||
||cbc:Line ||Direccion del punto de partida (Dirección completa y detallada) |1 |||||
|**/Invoice/cac:DeliveryTerms** |0\..n ||||||||
||cbc:ID ||Numero de registro MTC ||||x ||
||cbc:Amount ||Monto Referencial |0\..1 |PEN ||x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.069.png)|
|||@currencyID |Moneda del valor referencial |0\..1 |||x ||


|**/Invoice/cac:DeliveryTerms/cac:DeliveryLocation/cac:Address/** |0\..1 ||||||||
| - | - | :- | :- | :- | :- | :- | :- | :- |
||cbc:StreetName ||Dirección del lugar en el que se entrega el bien (Dirección completa y detallada) |0\..1 |||x ||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.070.png)|cbc:CitySubdivisionName |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.071.png)|Dirección del lugar en el que se entrega el bien (Urbanización) |0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.072.png)|||x ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.073.png)||
||cbc:CityName ||Dirección del lugar en el que se entrega el bien (Provincia) |0\..1 |||x ||
|![ref14]|cbc:CountrySubentity  ||Dirección del lugar en el que se entrega el bien (Departamento) |0\..1 |||x ![ref15]||
||cbc:CountrySubentityCode ||Dirección del lugar en el que se entrega el bien  (Código de ubigeo) |0\..1 |n6 |[Catálogo 13](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo13)|x ||
|![ref14]|cbc:District  ![ref16]|![ref17]|Dirección del lugar en el que se entrega el bien (Distrito) ![ref18]|0\..1 ![ref19]|||x ![ref15]||
|**/Invoice/cac:DeliveryTerms/cac:DeliveryLocation/cac:Address/cac:Country** |0\..1 ||||||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.080.png)|cbc:IdentificationCode ||Dirección del lugar en el que se entrega el bien (Código de país) |0\..1 ||[Catálogo 04](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo04)|x ||
||||||||||
|||@listID |- |0\..1 |"ISO 3166-1" ||||
|![ref20]||@listAgencyName |- |0\..1 ![ref21]|United Nations Economic Commission for Europe ||||
|||@listName |- |0\..1 |Country ||||
|**/Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount** |0\..n ||||||||
||cbc:ID ||Cuenta del banco de la nacion (detraccion) |0\..1 |||x ||
|**/Invoice/cac:PaymentTerms** |0\..n ||||||||
||cbc:ID  ||Codigo del bien o producto sujeto a detracción  |0\..1 |n2 |[Catalogo 54](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo54)|x ||
|![ref14]|![ref16]|@schemeName ![ref17]||0\..1 ![ref19]|"SUNAT:Codigo de detraccion" ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.083.png)||||
|||@schemeAgencyName ||0\..1 |"PE:SUNAT" ||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.084.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.085.png)|@chemeURI ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.086.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.087.png)|0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.088.png)|"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo54" ||||
||cbc:PaymentPercent ||Porcentaje de la detracción |0\..1 |n(3,2) ||x ||
||cbc:Amount ||Monto de la detracción |0\..1 |n(12,2) ||x ||


|**/Invoice/cac:PrepaidPayment** |0\..n ||||||||
| - | - | :- | :- | :- | :- | :- | :- | :- |
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.089.png)|cbc:ID ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.090.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.091.png)|Serie y número de comprobante del anticipo (para el caso de reorganización de empresas, incluye el RUC) ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.092.png)|0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.093.png)|<p>NNNN-NNNNNNNN/ F###-NNNNNNNN/ NNNNNNNNNNN-NNNN- NNNNNNNN/NNNNNNNN![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.094.png)</p><p>NNN-F###-NNNNNNNN </p>||x ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.095.png)||
|||@schemeID |Código de tipo de documento |0\..1 |n2 |[Catálogo 12](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo12)|x ||
|||@schemeName |- |0\..1 |"SUNAT:Identificador de Documentos Relacionados" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
||cbc:PaidAmount ||Monto prepagado o anticipado |0\..1 |n(15,2) |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.096.png)</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.097.png)|
|||@currencyID |<p>Código de tipo de moneda del monto prepagado </p><p>o anticipado </p>|1 |an3 ||x ||
||cbc:InstructionID ||Número de RUC del emisor del comprobante de anticipo |0\..1 |n11 ||x ||
|||@schemeID |Código de tipo de documento del comprobante de anticipo |0\..1 |"6" |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x ||
|**/Invoice/cac:AllowanceCharge** |0\..n |"true"/"false" |[Catálogo 53](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo53)|x |x ||||
||cbc:ChargeIndicator ||Indicador del cargo/descuento global |1 |||||
||cbc:AllowanceChargeReason Code ||Código del motivo del cargo/descuento global |0\..1 |an..2 |[Catálogo 53](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo53)|x |x |
||cbc:MultiplierFactorNumeric ||Factor del cargo/descuento del ítem |0\..1 |n(3,5) |[Catálogo 53](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo53)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.098.png)|
||cbc:Amount ||Monto del cargo/descuento global |1 |n(12,2) |<p>![ref8]</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |x |
|||@currencyID |Código de tipo de moneda del monto del cargo/descuento global |1 |an3 ||x |x |
||cbc:BaseAmount ||Monto de base de cargo/descuento global |1 |n(12,2) |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.099.png)</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.100.png)|
|||@currencyID |Código de tipo de moneda del monto de base del cargo/descuento global |1 |an3 ||x ||
|**/Invoice/cac:TaxTotal** |0\..n |n(12,2) |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.101.png)|x |x ||||
||cbc:TaxAmount ||Monto total del impuestos |1 |||||
|||@currencyID |Código de tipo de moneda del monto total del tributo |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x |x |
|<p>**/Invoice/cac:TaxTotal/cac:TaxSubtotal** </p><p>Monto las operaciones gravadas/exoneradas/inafectas del impuesto ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.102.png)</p><p>cbc:TaxableAmount </p>|0\..n ||||||||
||0\..1 |||x |||||
|||@currencyID |Código de tipo de moneda del monto de las operaciones gravadas/exoneradas/inafectas del impuesto |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x ||
||cbc:TaxAmount ||Monto total del impuesto |1 |n(12,2) |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.103.png)</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.104.png)|
|||@currencyID |Código de tipo de moneda del monto total del impuesto |1 |an3 ||x ||


|**/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory** |1 ||[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |||||
| - | - | :- | - | - | :- | :- | :- | :- |
||cbc:ID ||Categoría de impuestos |0\..1 |||||
|||@schemeID |- |0\..1 |"UN/ECE 5305" |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.105.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.106.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.107.png)|
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.108.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.109.png)|@schemeName @schemeAgencyName |- - ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.110.png)|0\..1 0..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.111.png)|Tax Category Identifier ||||
||||||"United Nations Economic Commission for Europe" ||||
|**/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.112.png)**|1 ||||||||
||cbc:ID ||Código de tributo |0\..1 |an..3 |[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |x |
||||||||||
|||@schemeID |- |0\..1 |"UN/ECE 5153" ||||
|||@schemeAgencyID |- |0\..1 |"6" |[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |x |
||cbc:Name ||Nombre de tributo |0\..1 |an..6 ||||
||cbc:TaxTypeCode ||Código internacional tributo |0\..1 |an4 |[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |x |
|**/Invoice/cac:LegalMonetaryTotal** |1 ||||||||
||cbc:LineExtensionAmount ||Total valor de venta |0\..1 |n(12,2) |<p>![ref22]</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |x |
|||@currencyID |Código de tipo de moneda del total valor de venta |1 |an3 ||x |x |
||cbc:TaxInclusiveAmount ||Total precio de venta (incluye impuestos) |0\..1 |n(12,2) ||x |x |
|||@currencyID |Código de tipo de moneda del total precio de venta (incluye impuestos) |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x |x |
|![ref10]|cbc:AllowanceTotalAmount ||Monto total de descuentos del comprobante |0\..1 |n(12,2) ||x ![ref23]|x |
|||@currencyID |Código de tipo de moneda del monto total de descuentos globales del comprobante |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x |x |
||cbc:ChargeTotalAmount ||Monto total de otros cargos del comprobante |0\..1 |n(12,2) ||x |x |
|||@currencyID |Código de tipo de moneda del monto total de otros cargos del comprobante |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x |x |
||cbc:PrepaidAmount ||Monto total de anticipos del comprobante |0\..1 |n(15,2) ||x ||
|||@currencyID |Código de tipo de moneda del monto total de anticipos del comprobante |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x ||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.115.png)|cbc:PayableAmount ||Importe total de la venta, cesión en uso o del servicio prestado |1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.116.png)|n(12,2) ||x ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.117.png)|x ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.118.png)|
|||@currencyID |Código tipo de moneda del importe total de la venta, cesión en uso o del servicio prestado |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x |x |



|**/Invoice/cac:InvoiceLine** |1\..n |n..3 ||x |||||
| - | - | - | :- | - | :- | :- | :- | :- |
||cbc:ID ||Número de orden del Ítem |1 |||||
||cbc:InvoicedQuantity ||Cantidad de unidades del ítem |0\..1 |n(12,10) |<p>![ref24]</p><p>[Catálogo 03](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo03)</p>|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.120.png)|
|||@unitCode |Código de unidad de medida del ítem |0\..1 |an..3 ||x ||
|||@unitCodeListID |- |0\..1 |UN/ECE rec 20 ||||
|||@unitCodeListAgencyN ame |- |0\..1 |United Nations Economic Commission for Europe ||||
||cbc:LineExtensionAmount ||Valor de venta del ítem |1 |n(12,2) |<p>![ref22]</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |x |
|||@currencyID |Código de tipo de moneda del valor de venta del ítem |1 |an3 ||x ||
||cbc:TaxPointDate |||0\..1 |||||
|**/Invoice/cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice** |0\..n ||||||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.121.png)|cbc:PriceAmount ||Precio de venta unitario/ Valor referencial unitario en operaciones no onerosas |1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.122.png)|n(12,10) ||x ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.123.png)|x ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.124.png)|
|||@currencyID |Código de tipo de moneda del precio de venta unitario o valor referencial unitario |1 |an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x |x |
||cbc:PriceTypeCode ||Código de tipo de precio |0\..1 |an2 |[Catálogo 16](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo16)|x ||
|||@listName |- |0\..1 |"SUNAT:Indicador de Tipo de Precio" ||||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@listURI ||0\..1 |"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo16" ||||
|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryParty/cac:PartyIdentification** |0\..1 ||||||||
||cbc:ID ||Numero de documento del huesped ||||x ||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.125.png)||@schemeID ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.126.png)|Código de tipo de documento de identidad del huesped |0\..1 |an1 |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x ||
||||||||||
|||@schemeName |- |0\..1 |"SUNAT:Identificador de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|||@schemeAgencyID |Código del país de emisión del pasaporte |0\..1 |an2 |[Catálogo 04](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo04)|x ||


|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryParty/cac:PartyName** |||||||||
| - | :- | :- | :- | :- | :- | :- | :- | :- |
||cbc:Name ||Apellidos y Nombres o denominacion o razon social del huesped |1 |an..100 ||x ||
|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryParty/cac:PostalAddress/cac:Country** |||||||||
||cbc:IdentificationCode ||Código del país de residencia del huesped |0\..1 |an2 ||x ||
|||@listID |- |0\..1 |ISO 3166-1 ||||
|||@listAgencyName |- |0\..1 |United Nations Economic Commission for Europe ||||
|||@listName |- |0\..1 |Country ||||
|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryParty/cac:Person** |0\..1 ||||||||
||cbc:ID ||Paquete turístico – Documento identidad del huésped ||||x ||
|||@schemeID |Paquete turístico – Código de tipo de Documento identidad del huésped |0\..1 |an1 |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x ||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.127.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.128.png)|@schemeName ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.129.png)|- ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.130.png)|0\..1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.131.png)|"SUNAT:Identificador de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.132.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.133.png)|@schemeURI ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.134.png)|- ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.135.png)||"urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo06" ||||
||cbc:FirstName  ||Paquete turístico – Número de documento identidad de huésped |1 |an..100 ||x ||
|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cac:ShipmentStage** |0\..n ||||||||
||cbc:ID ||Número de Asiento (Transporte de Pasajeros) |0\..1 |an..100 ||x ||
|||@schemeID |` `Información de Manifiesto de pasajero |0\..1 |an..100 |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.136.png)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.137.png)|
|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:PlannedDepartureTransportEvent** |0\..1 ||||||||
||cbc:OccurrenceDate ||Fecha de inicio programado |0\..1 |yyyy-mm-dd ||x ||
||cbc:OccurrenceTime ||Hora de inicio programado |0\..1 |hh:mm:ss.0z ||x ||


|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cac:ShipmentStage/cac:PassengerPerson** |0\..n ||||||||
| - | - | :- | :- | :- | :- | :- | :- | :- |
||cbc:ID ||Numero de documento de identidad del pasajero ||||x ||
|||@schemeID |Código de tipo de documento del pasajero |0\..1 |an1 |[Catálogo 06](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo06)|x ||
|||@schemeName |- |0\..1 |"SUNAT:Identificador de Documento de Identidad" ||||
|||@schemeAgencyName |- |0\..1 |"PE:SUNAT" ||||
||cbc:FirstName ||Nombres y apellidos del pasajero |0\..1 |an..100 ||x ||
|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cac:Delivery/cac:DeliveryAddress** |0\..1 |n6 |[Catálogo 13](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo13)|x |||||
||cbc:CountrySubentityCode ||Ciudad o lugar de destino (Código de Ubigeo) |0\..1 |||||
|**/Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cac:OriginAddress/**  |0\..1 |n6 |[Catálogo 13](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo13)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.138.png)||||
||cbc:CountrySubentityCode ||Ciudad o lugar de origen(Código de Ubigeo) ||||||
|**/Invoice/cac:InvoiceLine/cac:AllowanceCharge** |0\..n |"true"/"false" an2 |[Catálogo 53 Catálogo 53](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo53)|x x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.139.png)||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.140.png)|cbc:ChargeIndicator ||Indicador del cargo/descuento del ítem Código del cargo/descuento del ítem |1 0..1 |||||
||cbc:AllowanceChargeReason Code ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.141.png)||||||||
||||||||||
||cbc:MultiplierFactorNumeric ||Factor del cargo/descuento del ítem |0\..1 |n(3,5) |[Catálogo 53](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo53)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.142.png)|
||cbc:Amount ||Monto del cargo/descuento del ítem |1 |n(12,2) |<p>![ref25]</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |![ref26]|
|||@currencyID |Código de tipo de moneda del monto de cargo/descuento del ítem |1 |an3 ||x ||
||cbc:BaseAmount ||Monto de base del cargo/descuento del ítem |1 |n(12,2) |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.145.png)</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.146.png)|
|||@currencyID |Código de tipo de moneda del monto de base del cargo/descuento del ítem |1 |an3 ||x ||
|**/Invoice/cac:InvoiceLine/cac:TaxTotal** |0\..n |n(12,2) an3 |[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)|x x |x x ||||
|![ref14]|<p>cbc:TaxAmount </p><p>![ref16]</p>|@currencyID ![ref17]|Monto de tributo del ítem |1 1 |||||
||||Código de tipo de moneda del monto de tributo del ítem ![ref18]||||||
||||||||||
|**/Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal** |0\..n ||||||||
||cbc:TaxableAmount ||Monto de la operación |0\..1 |n(12,2) |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.147.png)</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |x |
|||@currencyID |Código de tipo de moneda del monto de la operación |1 |an3 ||x |x |
||cbc:TaxAmount ||Monto de tributo del ítem |1 |n(12,2) |<p>![ref24]</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |x |
|||@currencyID |Código de tipo de moneda del monto de tributo del ítem |1 |an3 ||x |x |



|**/Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory** |1 |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.148.png)|[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |x ||||
| - | - | - | - | - | - | :- | :- | :- |
||cbc:ID ||Categoría de impuestos |0\..1 |||||
|||@schemeID |- |0\..1 |"UN/ECE 5305" ||||
|||@schemeAgencyID |- |0\..1 |"6" ||||
||cbc:Percent ||Porcentaje del impuesto |0\..1 |n(3,5) ||x |x |
||cbc:TaxExemptionReasonCod e ||Código de tipo de afectación del IGV |0\..1 |an2 |[Catálogo 07](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo07)|x |x |
|![ref4]|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.149.png)|@listName ![ref5]|- ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.150.png)|0\..1 ![ref6]|"SUNAT:Codigo de Tipo de Afectación del IGV" ||||
|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.151.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.152.png)|@listAgencyName @listURI ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.153.png)|- - ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.154.png)|<p>0\..1 </p><p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.155.png)</p>|<p>"PE:SUNAT" </p><p>urn:pe:gob:sunat:cpe:see:g em:catalogos:catalogo07 </p>|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.156.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.157.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.158.png)|
||cbc:TierRange ||Código de tipo de sistema de ISC |0\..1 |an2 |[Catálogo 08](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo08)|x ||
|**/Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme** |1 |an..3 |[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |x ||||
||cbc:ID ||Código internacional tributo |0\..1 |||||
|||@schemeID |- |0\..1 |"UN/ECE 5153" |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.159.png)|![ref15]|![ref27]|
|![ref20]|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.161.png)|@schemeName @schemeAgencyName |- - ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.162.png)|0\..1 ![ref21]|<p>Tax Scheme Identifier </p><p>"United Nations Economic Commission for Europe" </p>||||
||cbc:Name ||Nombre de tributo |0\..1 |an..6 |[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |x |
||cbc:TaxTypeCode ||Código del tributo |0\..1 |an4 |[Catálogo 05](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo05)|x |x |
|<p>**/Invoice/cac:InvoiceLine/cac:Item** </p><p>Descripción detallada del servicio prestado, bien vendido o cedido en uso, indicando las características. ![ref7]</p><p>cbc:Description </p>|<p>1 </p><p>0\..n ![ref19]</p>|an..250 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.163.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.164.png)|x ![ref15]|x ![ref27]||||
|**/Invoice/cac:InvoiceLine/cac:Item/cac:SellersItemIdentification** |0\..1 ||||||||
||cbc:ID ||Código de producto del ítem |1 |an..30 ||x ||
|<p>**/Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification** cbc:ItemClassificationCode   ![ref10]![ref11]![ref12]</p><p>Código de producto (SUNAT) </p>|0\..1 1 ![ref13]|n8 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.165.png)|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.166.png)|x ![ref23]|![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.167.png)||||
|||@listID ||0\..1 |UNSPSC ||||
|||@listAgencyName ||0\..1 |GS1 US ||||
|||@listName ||0\..1 |Item Classification ||||
||||||||||
||||||||||
||||||||||
|**/Invoice/cac:InvoiceLine/cac:Item/cac:AdditionalItemProperty** |0\..n |an..100 ||x |||||
||cbc:Name ||Nombre del concepto tributario |1 |||||
||cbc:NameCode ||Código del concepto tributario (del ítem) |0\..1 |n4 |[Catálogo 55](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo55)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.168.png)|
|||@listName |- |0\..1 |"SUNAT:Identificador de la propiedad del ítem" ||||
|||@listAgencyName |- |0\..1 |"PE:SUNAT" |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.169.png)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.170.png)|
||cbc:Value ||Valor de la propiedad del ítem |0\..1 |an..100 ||||
||cbc:ValueQualifier ||Código del concepto del ítem |0\..n |an..4 |[Catálogo 54](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo54)|x |![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.171.png)|
|**/Invoice/cac:InvoiceLine/cac:Item/cac:AdditionalItemProperty/cac:UsabilityPeriod** |0\..1 ||||||||
||cbc:StartDate ||Fecha de inicio de la propiedad del ítem |0\..1 |yyyy-mm-dd |<p>![ref22]</p><p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.172.png)</p>|x |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.173.png)</p><p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.174.png)</p>|
||cbc:EndDate ||Fecha de fin de la propiedad del ítem |0\..1 |yyyy-mm-dd ||x ||
||cbc:DurationMeasure ||Duración (días) de la propiedad del ítem |0\..1 |n..4 |![ref25]|x |![ref26]|
|**/Invoice/cac:InvoiceLine/cac:Price** |0\..1 ||||||||
||cbc:PriceAmount ||Valor unitario del ítem |1 |n(12,10) |<p>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.175.png)</p><p>[Catálogo 02](file:///d:\Users\addpc\Desktop\llevar2\Guías\Proyecto\Anexos\2.1%20Final\Impresos%20Peruano\anexo%209-A%20y%20UBL%20guía.xlsx%23RANGE!Catalogo02)</p>|x |x |
|||@currencyID |Código de tipo de moneda del valor unitario del ítem |1 |an3 ||x |x |

Factura Electrónica   ~ 18 ~ ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.176.png)
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

2. **Estructura de Factura electrónica vs Formato XML** 



|**N°** |**REQUISITO** |
| - | - |
|1 |<p>Firma Digital <br><ext:UBLExtensions> </p><p><ext:UBLExtension> <br><ext:ExtensionContent> </p><p><ds:Signature Id="signatureKG"> </p><p><ds:SignedInfo> </p><p><ds:CanonicalizationMethod Algorithm=["http://www.w3.org/TR/2001/REC-xml-c14n- ](http://www.w3.org/TR/2001/REC-xml-c14n-)</p><p>20010315#WithComments"/> </p><p><ds:SignatureMethod Algorithm=["http://www.w3.org/2000/09/xmldsig#dsa-sha1"](http://www.w3.org/2000/09/xmldsig#dsa-sha1)/> <ds:Reference URI=""> </p><p><ds:Transforms> </p><p><ds:Transform Algorithm=["http://www.w3.org/2000/09/xmldsig#enveloped- ](http://www.w3.org/2000/09/xmldsig#enveloped-)</p><p>signature"/> </p><p></ds:Transforms> </p><p><ds:DigestMethod Algorithm=["http://www.w3.org/2000/09/xmldsig#sha1"](http://www.w3.org/2000/09/xmldsig#sha1)/> <ds:DigestValue>+pruib33lOapq6GSw58GgQLR8VGIGqANloj4EqB1cb4=</ds:DigestValue> </p><p></ds:Reference> </p><p></ds:SignedInfo> <ds:SignatureValue>Oatv5xMfFInuGqiX9SoLDTy2yuLf0tTlMFkWtkdw1z/Ss6kiDz+vIgZhgKfIaxp+JbVy57 </p><p>GT52f1 </p><p>0VLMLatdwPVRbrWmz1/NIy5CWp1xWMaM6fC/9SXV0O1Lqopk0UeX2I2yuf05QhmVfjgUu6GnS3m6 o6zM9J36iDvMVZyj7vbJTwI8SfWjTSNqxXlqPQ==</ds:SignatureValue> </p><p><ds:KeyInfo> </p><p><ds:X509Data> <ds:X509Certificate>MIIF9TCCBN2gAwIBAgIGAK0oRTg/MA0GCSqGSIb3DQEBCwUAMFkxCzAJBgNVB AYTAlRSMUowSAYD </p><p>VQQDDEFNYWxpIE3DvGjDvHIgRWxla3Ryb25payBTZXJ0aWZpa2EgSGl6bWV0IFNhxJ9sYXnEsWPE  sXPEsSAtIFRlc3QgMTAeFw0wOTEwMjAxMTM3MTJaFw0xNDEwMTkxMTM3MTJaMIGgMRowGAYDVQQL  DBFHZW5lbCBNw7xkw7xybMO8azEUMBIGA1UEBRMLMTAwMDAwMDAwMDIxbDBqBgNVBAMMY0F5ZMSx  biBHcm91cCAtIFR1cml6bSDEsHRoYWxhdCDEsGhyYWNhdCBUZWtzdGlsIMSwbsWfYWF0IFBhemFy  iMwtPnC2DRjdsyGv3bxwRZr9wXMRrMNwRjyFe9JPA7bSscEgaXwzDUG5FCvfS/PNT+XCce+VECAx  6Q3R1ZRSA49fYz6tDB4Ia5HVBXZODmrCs26XisHF6kuS5N/yGg8E7VC1BRr/SmxXeLTdjQYAfo7l  xCz4dT6wP5TOiBvF+lyWW1bi9nbliXyb/e5HjCp4k/ra9LTskjbY/Ukl5O8G9JEAViZkjvxDX7T0yVRHgMGiioIKVMw U6Lrtln607BNurLwED0OeoZ4wBgkBiB5vXofreXrfN2pHZ2=  </p><p></ds:X509Certificate> </p><p></ds:X509Data> </p><p></ds:KeyInfo> </p><p></ds:Signature> </p><p></ext:ExtensionContent> </p><p></ext:UBLExtension> </p><p></ext:UBLExtensions> </p>|
|2 |<p>Versión del UBL <cbc:UBLVersionID>2.1</cbc:UBLVersionID> </p><p>Versión de la estructura del documento ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.177.png)<cbc:CustomizationID>2.0</cbc:CustomizationID> </p>|
|3 ||
|4 |<p>Código de tipo de operación </p><p><cbc:ProfileID  </p><p>schemeName=" SUNAT:Identificador de Tipo de Operación"    schemeAgencyName="PE:SUNAT"  </p><p>schemeURI=" urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17" >0101</cbc:ProfileID> </p>|
|5 |Numeración, conformada por serie y número correlativo <cbc:ID>F002-10</cbc:ID> |
|6 |Fecha de emisión <cbc:IssueDate>2017-04-28</cbc:IssueDate> |
|7 |Hora de emisión <cbc:IssueTime>11:40:21</cbc:IssueTime>|
|8 |Fecha de Vencimiento <cbc:DueDate>2017-05-28</cbc:DueDate>|
|9 |<p>Tipo de documento (Factura) </p><p><cbc:InvoiceTypeCode  </p><p>listAgencyName="PE:SUNAT" </p><p>listName="SUNAT:Identificador de Tipo de Documento" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">01</cbc:InvoiceTypeCode></p>|
|10 |<p>Leyendas </p><p>Ejemplo:  </p><p>Importes Totales y Código interno generado por el software de facturación </p><p><cbc:Note  </p><p>languageLocaleID="1000">MIL OCHOCIENTOS CINCUENTA Y OCHO CON 59/100 Soles</cbc:Note> <cbc:Note  </p><p>languageLocaleID="3000">05010020170428000005</cbc:Note></p>|
|11 |<p>Tipo de moneda en la cual se emite la factura electrónica </p><p><cbc:DocumentCurrencyCode  </p><p>listID="ISO 4217 Alpha"  </p><p>listName="Currency"  </p><p>listAgencyName="United Nations Economic Commission for Europe">PEN</cbc:DocumentCurrencyCode> </p>|
|12 |<p>Tipo y número de la guía de remisión relacionada con la operación que se factura <cac:DespatchDocumentReference> </p><p><cbc:ID>031-002020</cbc:ID> </p><p><cbc:DocumentTypeCode  </p><p>listAgencyName="PE:SUNAT"  </p><p>listName="SUNAT:Identificador de guía relacionada" </p><p>listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">09</cbc:DocumentTypeCode> </cac:DespatchDocumentReference></p>|
|13 |<p>Tipo y número de otro documento y código relacionado con la operación que se factura <cac:AdditionalDocumentReference> </p><p><cbc:ID>024099</cbc:ID> </p><p><cbc:DocumentTypeCode  </p><p>listAgencyName="PE:SUNAT"  </p><p>listName="SUNAT: Identificador de documento relacionado" </p><p>listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo12">99</cbc:DocumentTypeCode> </cac:AdditionalDocumentReference></p>|
|14 15 16 17 |<p>Nombre Comercial del emisor </p><p>Apellidos y nombres, denominación o razón social del emisor </p><p>Tipo y Número de RUC del emisor </p><p>Código del domicilio fiscal o de local anexo del emisor </p><p><cac:AccountingSupplierParty> </p><p><cac:Party> </p><p><cac:PartyName> </p><p><cbc:Name><![CDATA[K&G Laboratorios]]></cbc:Name> </p><p></cac:PartyName> </p><p><cac:PartyTaxScheme> </p><p><cbc:RegistrationName><![CDATA[K&G Asociados S. A.]]></cbc:RegistrationName> <CompanyID  </p><p>schemeID="6"   </p><p>schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT"  schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20100113612</Compan yID> </p><p><cac:TaxScheme> </p><p>`   `<cbc:ID>-</cbc:ID> </p><p></cac:TaxScheme> </p><p><cac:RegistrationAddress> </p><p><cbc:AddressTypeCode>0001</cbc:AddressTypeCode> </p><p></cac:RegistrationAddress> </p><p></cac:PartyTaxScheme> </p><p></cac:Party> </p><p></cac:AccountingSupplierParty> </p>|
|18 19 |<p>Tipo y número de documento de identidad del adquirente o usuario  </p><p>Apellidos y nombres, denominación o razón social del adquirente o usuario </p><p><cac:AccountingCustomerParty> </p><p><cac:Party> </p><p><cac:PartyTaxScheme> </p><p><cbc:RegistrationName><![CDATA[CECI FARMA IMPORT S.R.L.]]></cbc:RegistrationName> <cbc:CompanyID  </p><p>schemeID="6"   </p><p>schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT"  schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20102420706</cbc:Compa nyID> </p><p><cac:TaxScheme> </p><p>`   `<cbc:ID>-</cbc:ID> </p><p></cac:TaxScheme> </p><p></cac:PartyTaxScheme> </p><p></cac:Party> </p><p></cac:AccountingCustomerParty></p>|



|20 |<p>Dirección del lugar en el que se entrega el bien </p><p><cac:DeliveryTerms> </p><p><cac:DeliveryLocation > </p><p><cac:Address> </p><p><cbc:StreetName>CALLE NEGOCIOS # 420</cbc:StreetName> <cbc:CitySubdivisionName/> </p><p><cbc:CityName>LIMA</cbc:CityName> <cbc:CountrySubentity>LIMA</cbc:CountrySubentity> <cbc:CountrySubentityCode>150141</cbc:CountrySubentityCode> <cbc:District>SURQUILLO</cbc:District> </p><p><cac:Country> </p><p>`   `<cbc:IdentificationCode  </p><p>`   `listID="ISO 3166-1"  </p><p>listAgencyName="United Nations Economic Commission for Europe"               listName="Country">PE</cbc:IdentificationCode> </p><p></cac:Country> </p><p></cac:Address> </p><p></cac:DeliveryLocation > </p><p>` `</cac:DeliveryTerms></p><p>Información de descuentos Globales ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.178.png)</p><p><cac:AllowanceCharge> </p><p><cbc:ChargeIndicator>False</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:Amount currencyID="PEN">60.00</cbc:Amount> </p><p><cbc:BaseAmount currencyID="PEN">1439.48</cbc:BaseAmount> </p><p></cac:AllowanceCharge></p>|
| - | - |
|21 ||
|22 23 24 25 26 27 28 29 |<p>**Monto total de impuestos** </p><p>**Monto las operaciones gravadas** </p><p>**Monto las operaciones Exoneradas** </p><p>Monto las operaciones inafectas del impuesto (Ver Ejemplo en la página 47) Monto las operaciones gratuitas (Ver Ejemplo en la página 48) </p><p>**Sumatoria de IGV** </p><p>Sumatoria de ISC (Ver Ejemplo en la página 51) </p><p>Sumatoria de Otros Tributos (Ver Ejemplo en la página 52) </p><p><cac:TaxTotal> </p><p><cbc:TaxAmount currencyID="PEN">259.11</cbc:TaxAmount> </p><p><cac:TaxSubtotal> </p><p><cbc:TaxableAmount currencyID="PEN">1439.48</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">259.11</cbc:TaxAmount> </p><p><cac:TaxCategory> </p><p><cbc:ID </p><p>schemeID="UN/ECE 5305"   </p><p>schemeName="Tax Category Identifier" </p><p>schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> </p><p><cbc:ID schemeID="UN/ECE 5305" schemeAgencyID="6">1000</cbc:ID> <cbc:Name>IGV</cbc:Name> </p><p><cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> </p><p></cac:TaxScheme> </p><p></cac:TaxCategory> </p><p></cac:TaxSubtotal> </p><p><cac:TaxSubtotal> </p><p><cbc:TaxableAmount currencyID="PEN">320.00</cbc:TaxableAmount> </p><p><cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> </p><p><cac:TaxCategory> </p><p><cbc:ID  </p><p>schemeID="UN/ECE 5305"   </p><p>schemeName="Tax Category Identifier" </p><p>schemeAgencyName="United Nations Economic Commission for Europe">E</cbc:ID> <cac:TaxScheme> </p><p><cbc:ID schemeID="UN/ECE 5305" schemeAgencyID="6">9997</cbc:ID> <cbc:Name>EXONERADO</cbc:Name> <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> </p><p></cac:TaxScheme> </p><p></cac:TaxCategory> </p><p></cac:TaxSubtotal> </p><p></cac:TaxTotal> </p>|
|30 31 32 33 34 |<p>Total valor de venta </p><p>Total precio de venta (incluye impuestos) </p><p>Monto total de descuentos del comprobante </p><p>Monto total de otros cargos del comprobante </p><p>Importe total de la venta, cesión en uso o del servicio prestado </p><p><cac:LegalMonetaryTotal> </p><p><cbc:LineExtensionAmount currencyID="PEN">1439.48</cbc:LineExtensionAmount> <cbc:TaxInclusiveAmount currencyID="PEN">1698.59</cbc:TaxInclusiveAmount> <cbc:AllowanceTotalAmount currencyID="PEN">60.00</cbc:AllowanceTotalAmount> <cbc:ChargeTotalAmount currencyID="PEN">320.00</cbc:ChargeTotalAmount> <cbc:PrepaidAmount currencyID="PEN">100.00</cbc:PrepaidAmount> <cbc:PayableAmount currencyID="PEN">1858.59</cbc:PayableAmount> </p><p></cac:LegalMonetaryTotal></p>|
|35 36 37 |<p>Número de orden del Ítem </p><p>Cantidad y Unidad de medida por ítem </p><p>Valor de venta del ítem </p><p><cac:InvoiceLine> </p><p><cbc:ID>1</cbc:ID> </p><p><cbc:InvoicedQuantity  </p><p>unitCode="CS"  </p><p>unitCodeListID="UN/ECE rec 20"  </p><p>unitCodeListAgencyName="United Nations Economic Commission for Europe">50</cbc:InvoicedQuantity> </p><p><cbc:LineExtensionAmount currencyID="PEN">1439.48</cbc:LineExtensionAmount> …. </p><p></cac:InvoiceLine></p>|
|38 |<p>Precio de venta unitario por item y código </p><p><cac:InvoiceLine> </p><p>… </p><p><cac:PricingReference> </p><p><cac:AlternativeConditionPrice> </p><p><cbc:PriceAmount currencyID="PEN">34.99</cbc:PriceAmount> </p><p><cbc:PriceTypeCode   </p><p>listName="SUNAT:Indicador de Tipo de Precio"  </p><p>listAgencyName="PE:SUNAT"  </p><p>listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> </p><p></cac:PricingReference> </p><p>… </p><p></cac:InvoiceLine> </p>|
|39 |<p>Valor referencial unitario por ítem en operaciones no onerosas </p><p><cac:InvoiceLine> </p><p>… </p><p><cac:PricingReference> </p><p><cac:AlternativeConditionPrice> </p><p><cbc:PriceAmount currencyID="PEN">250.00</cbc:PriceAmount> </p><p><cbc:PriceTypeCode </p><p>listName="SUNAT:Indicador de Tipo de Precio"  </p><p>listAgencyName="PE:SUNAT" </p><p>listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">02</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> </p><p></cac:PricingReference> </p><p>… </p><p></cac:InvoiceLine> </p>|
|40 |<p>Descuentos por Ítem </p><p><cac:InvoiceLine> </p><p><cac:AllowanceCharge> </p><p><cbc:ChargeIndicator>false</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:Amount currencyID="PEN">143.95</cbc:Amount> </p><p><cbc:BaseAmount currencyID="PEN">1439.48</cbc:BaseAmount> </cac:AllowanceCharge> </p><p></cac:InvoiceLine> </p>|
|41 |<p>Cargos por Ítem </p><p><cac:InvoiceLine> </p><p><cac:AllowanceCharge> </p><p><cbc:ChargeIndicator>true</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>50</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.10</cbc:MultiplierFactorNumeric> <cbc:Amount currencyID="PEN">44.82</cbc:Amount> </p><p><cbc:BaseAmount currencyID="PEN">448.20</cbc:BaseAmount> </cac:AllowanceCharge> </p><p></cac:InvoiceLine> </p>|



|42 |<p>Afectación al IGV por ítem </p><p><cac:InvoiceLine> </p><p>… </p><p><cac:TaxTotal> </p><p><cbc:TaxAmount currencyID="PEN">259.11</cbc:TaxAmount> </p><p><cac:TaxSubtotal> </p><p><cbc:TaxableAmount currencyID="PEN">1439.48</cbc:TaxableAmount> </p><p><cbc:TaxAmount currencyID="PEN">259.11</cbc:TaxAmount> </p><p><cac:TaxCategory> </p><p><cbc:ID </p><p>schemeID="UN/ECE 5305"   </p><p>schemeName="Tax Category Identifier" </p><p>schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> </p><p><cbc:Percent>18.00</cbc:Percent> </p><p><cbc:TaxExemptionReasonCode  </p><p>listAgencyName="PE:SUNAT"  </p><p>listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionReasonC ode> </p><p><cac:TaxScheme> </p><p><cbc:ID schemeID="UN/ECE 5153"  schemeName="Tax Scheme Identifier" </p><p>schemeAgencyName="United Nations Economic Commission for Europe">1000</cbc:ID> </p><p><cbc:Name>IGV</cbc:Name> </p><p><cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> </p><p></cac:TaxScheme> </p><p></cac:TaxCategory> </p><p></cac:TaxSubtotal> </p><p></cac:TaxTotal> </p><p>… </p><p></cac:InvoiceLine> <br>Afectación al ISC por ítem </p><p><cac:InvoiceLine> </p><p>… </p><p><cac:TaxTotal> </p><p><cbc:TaxAmount currencyID="PEN">1750.52</cbc:TaxAmount> </p><p><cac:TaxSubtotal> </p><p><cbc:TaxableAmount currencyID="PEN">8752.60</cbc:TaxableAmount> </p><p><cbc:TaxAmount currencyID="PEN">1750.52</cbc:TaxAmount> </p><p><cac:TaxCategory> </p><p><cbc:ID </p><p>schemeID="UN/ECE 5305"   </p><p>schemeName="Tax Category Identifier" </p><p>schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> </p><p><cbc:Percent>20.00</cbc:Percent> </p><p><cbc:TaxExemptionReasonCode  </p><p>listAgencyName="PE:SUNAT"  </p><p>listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionReasonC ode> </p><p><cac:TierRange>01</cac:TierRange> </p><p><cac:TaxScheme> </p><p><cbc:ID schemeID="UN/ECE 5153"  schemeName="Tax Scheme Identifier" </p><p>schemeAgencyName="United Nations Economic Commission for Europe">2000</cbc:ID> </p><p><cbc:Name>ISC</cbc:Name> </p><p><cbc:TaxTypeCode>EXC</cbc:TaxTypeCode> </p><p></cac:TaxScheme> </p><p></cac:TaxCategory> </p><p></cac:TaxSubtotal> </p><p></cac:TaxTotal> </p><p>… </p><p></cac:InvoiceLine></p>|
| - | - |
|43 ||
|44 |<p>Descripción detallada del servicio prestado, bien vendido o cedido en uso, indicando las características <cac:InvoiceLine> </p><p><cac:Item> </p><p><cbc:Description><![CDATA[CAPTOPRIL 1000mg X 30]]></cbc:Description> </p><p>… </p><p></cac:Item> </p><p></cac:InvoiceLine></p>|

45  Código de producto ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.179.png)

46  Código de producto SUNAT 

<cac:InvoiceLine> 

<cac:Item> 

… 

<cbc:SellersItemIdentification> 

<ID>Cap-258963</ID> 

</cbc:SellersItemIdentification> 

<cac:CommodityClassification> 

<ItemClassificationCode  

listID="UNSPSC"  

listAgencyName="GS1 US" 

listName="Item Classification">51121703</ItemClassificationCode> </cac:CommodityClassification> 

… 

</cac:Item> 

</cac:InvoiceLine>![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.180.png)

47  Propiedades Adicionales del Ítem (Ver más ejemplos en la página 68) 

Información Adicional - Gastos art.37° Renta 

Número de placa del vehículo  

<cac:InvoiceLine> 

<cac:Item> 

… 

<cac:AdditionalItemProperty > 

<Name>Gastos Art. 37 Renta: Número de Placa</ Name> 

<NameCode 

listName="SUNAT :Identificador de la propiedad del ítem"  

listAgencyName="PE:SUNAT">7000</NameCode> 

<Value>B6F-045</Value> 

</cac:AdditionalItemProperty> 

… 

</cac:Item> 

</cac:InvoiceLine> 

48  Valor unitario del ítem 

<cac:InvoiceLine> 

… 

<cac:Price> 

… 

<cbc:PriceAmount CurrencyID="PEN" >785.20</cbc:PriceAmount> 

… 

</cac:Price> 

… 

</cac:InvoiceLine>

3. **Normas de Uso del Formato de la Factura Electrónica A  Normas de Uso** 

   Como se ha indicado, el formato UBL está basado en el uso de un documento XML para presentar todos los datos de forma jerárquica. El formato especifica que para un archivo se especifique toda la información de una y solo una factura. Como dicha representación se basa en XML debe existir un único tag que engloba a todos los demás, dicha etiqueta es **Invoice**. 

   <Invoice> 

   ...... 

   </Invoice> 

   Para un mejor entendimiento de la estructura del archivo XML, se describe a continuación los elementos que conforman la factura electrónica, así como también los elementos complejos más importantes. 

**A.1 Elementos de la Factura electrónica**  

A continuación se detallan los elementos que forman parte del documento Factura. 

En cada uno de ellos se muestra una explicación  de la información que almacena, si es obligatorio o no para obtener un documento correcto, su ubicación dentro del documento, un ejemplo así como una breve explicación de acuerdo al estándar UBL (Descripción UBL). Cabe señalar, que se describen solo aquellos tags que son necesarios para el uso tributario y que son requeridos por la SUNAT. 

1. **Firma Digital.**  

**Obligatorio.** Es el conjunto de datos asociados al documento electrónico que se firma y permite la identificación del signatario (emisor de la factura electrónica) y ha sido creada por medios que éste mantiene bajo su control, de manera que está vinculada únicamente al signatario y a los datos a los que refiere. La firma deberá realizarse con el certificado digital que el emisor de la factura comunicó previamente a SUNAT.  

**Ubicación** 

*//Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature //Invoice/cac:Signature* 

**Ejemplo** 

Un ejemplo de declaración de firma electrónica en el contenedor UBLExtensions sería: 

<ext:UBLExtensions> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.181.png)

<ext:UBLExtension> 

<ext:ExtensionContent> 

<ds:Signature Id="signatureKG"> 

<ds:SignedInfo> 

<ds:CanonicalizationMethod Algorithm=["http://www.w3.org/TR/2001/REC-xml-c14n- ](http://www.w3.org/TR/2001/REC-xml-c14n-)20010315#WithComments"/> 

<ds:SignatureMethod Algorithm=["http://www.w3.org/2000/09/xmldsig#dsa-sha1"](http://www.w3.org/2000/09/xmldsig#dsa-sha1)/> <ds:Reference URI=""> 

<ds:Transforms> 

<ds:Transform Algorithm=["http://www.w3.org/2000/09/xmldsig#enveloped- ](http://www.w3.org/2000/09/xmldsig#enveloped-)

signature"/> 

</ds:Transforms> 

<ds:DigestMethod Algorithm=["http://www.w3.org/2000/09/xmldsig#sha1"](http://www.w3.org/2000/09/xmldsig#sha1)/> <ds:DigestValue>+pruib33lOapq6GSw58GgQLR8VGIGqANloj4EqB1cb4=</ds:DigestValue> 

</ds:Reference> 

</ds:SignedInfo> <ds:SignatureValue>Oatv5xMfFInuGqiX9SoLDTy2yuLf0tTlMFkWtkdw1z/Ss6kiDz+vIgZhgKfIaxp+JbVy57GT5 

0VLMLatdwPVRbrWmz1/NIy5CWp1xWMaM6fC/9SXV0O1Lqopk0UeX2I2yuf05QhmVfjgUu6GnS3m6 o6zM9J36iDvMVZyj7vbJTwI8SfWjTSNqxXlqPQ==</ds:SignatureValue> 

<ds:KeyInfo> 

<ds:X509Data> 

<ds:X509Certificate>MIIESTCCAzGgAwIBAgIKWOC RzgAAAAAAIjANBgkqhkiG9w0BAQUFADAnMRUwEwYKCZImiZPyLGQB GRYFU1VOQVQxDjAMBgNVBAMTBVNVTkFUMB4XDTEwMTIyODE5NTExMFoXDT ExMTIyODIwMDExMFow gZUxCzAJBgNVBAYTAlBFMQ0wCwYDVQQIEwRMSU1BMQ0wCwYDVQQHEwRMS U1BMREwDwYDVQQKEwhT T1VUSEVSTjEUMBIGA1UECxMLMjAxMDAxNDc1MTQxFDASBgNVBAMTC0JvcmlzI FN1bGNhMSkwJwYJ 

</ds:X509Certificate> 

</ds:X509Data> 

</ds:KeyInfo> 

</ds:Signature> 

</ext:ExtensionContent> 

</ext:UBLExtension> 

</ext:UBLExtensions> 

Un ejemplo de declaración de firma electrónica en el contenedor cac:Signature sería: 

<cac:Signature> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.182.png)

<cbc:ID>IDSignKG</cbc:ID> 

<cac:SignatoryParty> 

<cac:PartyIdentification> 

<cbc:ID>20100113612</cbc:ID> 

</cac:PartyIdentification> 

<cac:PartyName> 

<cbc:Name><![CDATA[K&G Laboratorios]]></cbc:Name> 

</cac:PartyName> 

</cac:SignatoryParty> 

<cac:DigitalSignatureAttachment> 

<cac:ExternalReference> 

<cbc:URI>#signatureKG</cbc:URI> 

</cac:ExternalReference> 

</cac:DigitalSignatureAttachment> 

</cac:Signature> 

**Descripción UBL** 

**UBLExtensions.** Contenedor de Componentes de extensión. Se incorporan definiciones estructuradas cuando sean de interés para emisores y receptores, y siempre que no estén definidas en el esquema de la factura. Se detalla más adelante (punto B.2.1). 

Se utilizará  el componente Extensions de UBL 2.1 para  incorporar la firma electrónica XMLDSIG1. 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.183.png)

**cac:Signature.** Utilizado para identificar al firmante y otro tipo de información relacionada con  el  mismo.  Su  uso  se  da  principalmente  para  especificar  la  ubicación  de  la  firma electrónica ya sea que este embebida (dentro del mensaje) o desacoplada. 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.184.png)



- **cbc:ID*.*** Obligatorio. Identificador de la firma 



- **cac:SignatoryParty.** Obligatorio. Asociación con la parte firmante, la cual para nuestro caso deberá estar relacionado con el emisor de la factura. 

 

- **PartyIdentification.** Obligatorio. A través del elemento ID, se consigna el RUC de la parte firmante. ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.185.png)

1 Es un estándar creado por la W3C que recoge las reglas básicas de creación y procesamiento de firmas de electrónicas documentos, principalmente en XML. Las firmas [XMLDSig] son firmas digitales creadas y pensadas para transacciones XML. Dentro de la firma electrónica en  formato XML, existen diferentes “subtipos de formatos”, dentro  de los cuales destacan por encima de todos el XML Dsig y la variante de este, el XML Advanced Electronic Signatures (XAdES). 

- **PartyName.**  Obligatorio.  A  través  del  elemento  Name,  se  consigna  el nombre o razón social de la parte firmante. 
- **cac:DigitalSignatureAttachment.** Obligatorio**.** En este componente se puede referenciar la firma del documento como una ExternalReference a una URI local o remota. 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.186.png)

- **ExternalReference.**  Obligatorio.  Información  acerca  de  un  documento vinculado. Los  vínculos pueden ser  externos (referenciados mediante  un elemento  ***URI***),   internos  (accesibles  mediante  un  elemento  MIME)   o pueden estar contenidos dentro del mismo documento en el que se alude a ellos (mediante elementos Documento Incrustado). Este último será el caso a  utilizar,  es  decir  una  referencia  dentro  del  mismo  documento  ***invoice,*** específicamente en el componente ***UBLExtensions.*** 
2. **Versión del UBL.**  

**Obligatorio.** Versión del esquema UBL que define todos los elementos que se podrían encontrar en este documento. Para la presente guía se ha utilizado la versión “2.1”. 

**Ubicación** 

*//Invoice/cbc:UBLVersionID* 

**Ejemplo** 

<cbc:UBLVersionID>2.1</cbc:UBLVersionID> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.187.png)

**Descripción UBL** 

**cbc:UBLVersionID** 

Versión UBL usada para esquematizar y definir los elementos contenidos en el documento. 

3. **Versión de la estructura del documento.**

**Obligatorio.** Identifica una personalización de UBL definida para un uso específico. Para nuestro caso corresponderá a la versión 2.0 de la factura electrónica. Por cada variación o adecuación del esquema se deberá de aumentar la versión, la cual contemplará las nuevas validaciones para los elementos de datos establecidos. 

**Ubicación** 

*//Invoice/cbc:CustomizationID* 

**Ejemplo** 

<cbc:CustomizationID>2.0</cbc:CustomizationID> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.188.png)**Descripción UBL** 

**cbc:CustomizationID** 

Elemento usado para identificar la personalización, definida por el usuario de UBL, sobre los documentos asociados. 

4. **Tipo de Operación.** 

Para efectos de identificar la transacción se deberá indicar el código de operación que corresponda de acuerdo al catálogo N° 51 del Anexo 8 aprobado por la Resolución de Superintendencia N° 097-2012/SUNAT y modificatorias. 

**Ubicación** 

*//invoice/cbc:ProfileID @schemeName @schemeAgencyName @schemeURI* **Ejemplo** 

<cbc:ProfileID schemeName=" SUNAT:Identificador de Tipo de Operación" ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.189.png)schemeAgencyName="PE:SUNAT" schemeURI=" urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17" >0102</cbc:ProfileID> 

**Descripción UBL**  

**ProfileID:** Señala el tipo de operación que se está llevando a cabo. **Atributos** 



|schemeName |SUNAT:Identificador de Tipo de Operación |
| - | - |
|schemeAgencyName |PE:SUNAT |
|schemeURI |urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17 |

**Valor de Códigos Catálogo N°51** 

**cbc: ProfileID** 



|**Código** |**Concepto** |**Descripción** |
| - | - | - |
|0101 |Venta lnterna |Para  la  venta  en  el  país  de  bienes  muebles ubicados en el territorio nacional, que se realice en  cualquiera  de  las  etapas  del  ciclo  de producción y distribución, sean éstos nuevos o usados, independientemente del lugar en que se celebre el contrato, o del lugar en que se realice el  pago.  Así  mismo,  se  consideran  dentro  de este  código  a  la  prestación  de  servicios  en territorio nacional. |
|0102 |Exportación |Cuando la venta de bienes muebles lo realiza un sujeto domiciliado en el país a favor de un sujeto no  domiciliado,  independientemente  de  que  la transferencia de propiedad ocurra en el país o en el exterior, siempre que dichos bienes sean objeto  del  trámite  aduanero  de  exportación definitiva. |



|0103 |No Domiciliados |Tratándose  de  ventas   y/o  prestación  de servicios que son llevadas a cabo en territorio nacional  pero  el  cliente  es  un  no  domiciliado. Este  código  no  se  debe  utilizar  para exportaciones. |
| - | - | - |
|0104 |Venta Interna – Anticipos |Tratandose de anticipos (Pagos realizados antes de la entrega de los bienes y/o prestación del servicio) |
|0105 |Venta Itinerante |Cuando las operaciones de venta de los bienes trasladados  se  concretan  durante  el  recorrido que  efectúa  el  emisor  itinerante  y  no  en  una oportunidad previa. |
|0106 |Factura Guía |Cuando se realiza el traslado de los bienes con la  factura  en  vez  de  la  guía  de  remisión remitente ó transportista. |
|0107 |Venta Arroz Pilado |Se utilizará para indicar que la operación que se está  informando  está  sujeta  al  Impuesto  a  la Venta del Arroz Pilado (IVAP) aprobado por Ley 28211 y modificatorias. |
|0108 |Factura Comprobante de Percepción |Cuando la cancelación del íntegro del precio de venta y del monto de la percepción respectiva se efectúe  hasta  la  oportunidad  de  la  factura electrónica correspondiente. |
|0110 |Factura - Guía remitente |Cuando se realiza el traslado de los bienes con la factura en vez de la guía de remisión remitente. |

5. **Numeración, conformada por serie y número correlativo.**  

**Obligatorio.** Identificador de factura, este elemento contendrá la serie de la factura más el número correlativo del mismo. La serie debe ser alfanumérica de cuatro (4) caracteres, siendo el primer caracter de la izquierda la letra F (Ejemplo: F001). El número correlativo podrá tener hasta ocho (8) caracteres y se iniciará en 1. Dicho número será independiente del número correlativo de la factura emitida en formato impreso y/o importado por imprenta autorizada. 

El número de serie en la factura electrónica, no necesariamente debe estar asociado a un establecimiento o debe declararse su ALTA ante SUNAT. El emisor es libre de decidir la cantidad de series a utilizar y la forma de asignar éstas a sus operaciones, debiendo en todo caso mantener la correlatividad de la numeración en la emisión. 

**Ubicación** 

*//Invoice/cbc:ID* 

**Ejemplo** 

<cbc:ID>FA01-10</cbc:ID> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.190.png)

**Descripción UBL**  

**cbc:ID** Identificador único de la factura asignada por el emisor.

6. **Fecha de emisión.**  

**Obligatorio.** Corresponde a: 

- En el caso de bienes, fecha en que se produce la transferencia, el momento en que se entregue o en el momento en que se efectúe el pago; lo que ocurra primero. 
- En el caso que la transferencia sea concertada por Internet, teléfono, telefax u otros medios similares, en los que el pago se efectúe mediante tarjeta de crédito o de débito y/o abono en cuenta con anterioridad a la entrega del bien, la fecha de emisión será aquella en que se reciba la conformidad de la operación por parte del administrador del medio de pago o se perciba el ingreso, según sea el caso. 
- En el caso de retiro de bienes, la fecha de retiro. 
- En la transferencia de bienes inmuebles, fecha en que se perciba el ingreso o fecha que se celebra el contrato, lo que ocurra primero. 
- En la primera venta de bienes inmuebles que realice el constructor, fecha en que se perciba el ingreso, por el monto que se perciba, sea total o parcial. 
- En el caso de naves y aeronaves, fecha en que se suscribe el respectivo contrato. 
- Por  los  pagos  parciales  recibidos  anticipadamente  a  la  entrega  del  bien  o  puesta  a disposición del mismo, en la fecha en que se perciba el pago.
- En la prestación de servicios, incluyendo el arrendamiento y arrendamiento financiero, cuando alguno de los siguientes supuestos ocurra primero: 
- La culminación del servicio. 
- La percepción de la retribución, parcial o total. 
- El vencimiento del plazo o de cada uno de los plazos fijados o convenidos para el pago del servicio. 

Sin  embargo,  la  fecha  de  emisión  de  la  factura  podrá  ser  anterior  a  las  fechas  antes señaladas. 

**Ubicación** 

*//Invoice/cbc:IssueDate* 

**Ejemplo** 

<cbc:IssueDate>2017-04-28</cbc:IssueDate> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.191.png)

Factura Electrónica  ~ 32 ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

**Descripción UBL** 

**cbc:IssueDate.** Fecha de emisión del documento. El tipo DateType se corresponde con el tipo Date de XML por lo que el formato deberá ser yyyy-mm-dd. 

7. **Hora de emisión.**  

**Obligatorio.** Es la hora que corresponde a la emisión del comprobante de pago. Esta asociada a la fecha de emisión del comprobante de pago, indicado en el numeral anterior.

**Ubicación** 

*//Invoice/cbc:IssueTime* 

**Ejemplo** 

<cbc:IssueTime>15:20:30</cbc:IssueTime> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.192.png)

**Descripción UBL** 

**cbc:IssueTime.** Representa la hora de emisión del día de emisión de la factura en el formato hh:mm:ss.sss. Donde hh representa la hora, mm los minutos, ss.sss los segundos. La hora esta basada en el período de 24 horas, de modo que la hora se debe representar de 00 a 24. 



|**Valores Válidos** |**Comentario** |
| - | - |
|13:20:00 |13:20 |
|13:20:30.5555 |13:20 y 30.5555 segundos |
|00:00:00 |Medianoche |
|24:00:00 |Medianoche |



|**Valores No Válidos** |**Comentario** |
| - | - |
|5:20:00 |Horas, minutos y segundos deben ser de dos dígitos cada uno |
|13:20 |Segundos se deben especificar, incluso si es 00 |
|13:20.5:00 |Los valores de horas y minutos deben ser enteros |
|13:65:00 |El valor debe ser una hora válida |

**8 Fecha de Vencimiento.**  

**Opcional.** En el supuesto que desee utilizar para indicar la fecha máxima de pago de la factura. Se puede utilizar para efectos de la factura negociable o con fines estrictamente financieros. 

**Ubicación** 

*//invoice/cbc:DueDate* 

**Ejemplo** 

<cbc:DueDate>2017-07-31</cbc:DueDate> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.193.png)**Descripción UBL** 

**cbc:DueDate.** Representa la del vencimiento de la factura. Se utiliza el formato YYYY-MM- DD.  

Donde: YYYY representa al año, MM el mes y DD el día. 

**9 Código de Tipo de documento.  Obligatorio.** Tipo de comprobante de pago. 

**Ubicación** 

*//Invoice/cbc:InvoiceTypeCode@listAgencyName @listName @listURI* 

**Ejemplo** 

<cbc:InvoiceTypeCode listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de Tipo de Documento![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.194.png)" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">01</cbc:InvoiceTypeCode> 

**Descripción UBL**  

**cbc:InvoiceTypeCode** Código que especifica el tipo de documento. 

**Atributos** 



|listAgencyName |PE:SUNAT |
| - | - |
|listName |SUNAT:Identifi cador de Tipo de Documento |
|listURI |urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01 |

**Valor de Código**  



|**Código** |**Descripción** |
| - | - |
|01 |FACTURA |

**10. Leyendas.** 

Elemento utilizado para consignar mensajes que deben formar parte del comprobante de pago,  acorde  con  lo  regulado  por  el  Reglamento  de  Comprobantes  de  Pago,  u  otras  disposiciones,  que  buscan  entre  otros,  diferenciar  operaciones  y/o  agregar información complementaria al documento. 

Las leyendas que se encuentra definidas son las siguientes: 

- **Monto expresado en letras. Opcional**

Elemento utilizado para consignar en el documento el monto expresado en letras. 

En el atributo @languageLocaleID se debe consignar el código “1000” (según Catálogo No. 52). 

- **“Transferencia gratuita” o “Servicio prestado Gratuitamente”** 

Aplicable solo en el caso que todas las operaciones (líneas o ítems) comprendidas en la factura electrónica sean gratuitas. 

En el atributo @languageLocaleID se debe consignar el código “1002” (según Catálogo No. 52). 

- **"Comprobante De Percepcion”.**  

Elemento utilizado en operaciones de venta sujetas al Régimen de Percepción del IGV, en aquellos casos en que la normativa permite que el mismo comprobante de pago acredite la Percepción. 

En el atributo @languageLocaleID se debe consignar el código “2000” (según Catálogo No. 52). 

- **“Bienes transferidos en la Amazonía".** 

Dicha  leyenda  se  consignará  en  aquellas  operaciones  exoneradas  del  Impuesto General a las Ventas de acuerdo a lo señalado en el art. 10° del Decreto Supremo N° 103-99-EF,  Reglamento  de  las  Disposiciones  Tributarias  contenidas  en  la  Ley  de Promoción de la inversión en la Amazonía. 

En el atributo @languageLocaleID se debe consignar el código “2001” (según Catálogo No. 52). 

- **“Servicios prestados en la Amazonía".**  

Dicha  leyenda  se  consignará  en  aquellas  operaciones  exoneradas  del  Impuesto General a las Ventas de acuerdo a lo señalado en el art. 10° del Decreto Supremo N° 103-99-EF,  Reglamento  de  las  Disposiciones  Tributarias  contenidas  en  la  Ley  de Promoción de la inversión en la Amazonía. 

En el atributo @languageLocaleID se debe consignar el código “2002” (según Catálogo No. 52). 

- **“Contratos de construcción ejecutados en la Amazonía”.**  

Dicha  leyenda  se  consignará  en  aquellas  operaciones  exoneradas  del  Impuesto General a las Ventas de acuerdo a lo señalado en el art. 10° del Decreto Supremo N° 103-99-EF,  Reglamento  de  las  Disposiciones  Tributarias  contenidas  en  la  Ley  de Promoción de la inversión en la Amazonía. 

En el atributo @languageLocaleID se debe consignar el código “2003” (según Catálogo No. 52). 

- **“Agencia de Viaje - Paquete turístico”.**  

Dicha leyenda se consignará cuando se trate de agencias de viajes y turismo incluidas como tal en el Directorio Nacional de Prestadores de Servicios Turísticos Calificados, publicado por el Ministerio de Comercio Exterior y Turismo. 

En el atributo @languageLocaleID se debe consignar el código “2004” (según Catálogo No. 52). 

- **“Venta realizada por emisor itinerante”.** 

Dicha leyenda se consignará cuando el otorgamiento del comprobantes de pago supone el  desplazamiento  de  bienes  destinados  a  la  venta,  operación  esta  que  recién  se concreta durante el recorrido del emisor y no antes del inicio del traslado de los bienes.. 

En el atributo @languageLocaleID se debe consignar el código “2005” (según Catálogo No. 52). 

- **“Operación sujeta a detracción”.** 

Dicha leyenda se consignará cuando la operación este sujeta al Sistema de Pago de Obligaciones Tributarias con el Gobierno Central a que se refiere el decreto legislativo N° 940 y sus normas modificatorias y complementarias. 

En el atributo @languageLocaleID se debe consignar el código “2006” (según Catálogo No. 52). 

- **Código interno generado por el software de Facturación.** 

Se consignará la llave única o clave única o clave primaria del software donde se generó el ingreso de información para la generación del comprobante de pago electrónico.  

Tratándode  de  software  contables  intregados  (ERP)  se  podrá  consignar  el  código contable del asiento del libro diario que generó la transacción. 

En el atributo @languageLocaleID se debe consignar el código “3000” (según Catálogo No. 52). 

**Ubicación** 

*//Invoice/cbc:Note@languageLocaleID*  

**Ejemplo** 

<Invoice> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.195.png)

… 

<cbc:Note  

languageLocaleID="1000">MIL OCHOCIENTOS CINCUENTA Y OCHO CON 59/100 Soles</cbc:Note> <cbc:Note  

languageLocaleID="3000">05010020170428000005</cbc:Note> 

… 

</Invoice> 

**Descripción UBL** 

**cbc:Note** 

Para hacer uso de este elemento, es necesario consignar el atributo que identifique la leyenda que se está utilizando (languageLocaleID) y el texto de la leyenda o valor según fuera el caso (cbc:Note).  

**11 Tipo de moneda.**

**Obligatorio.** Código de moneda empleada genéricamente en la factura. Los códigos se especifican  en  un  archivo  de  tipo  CodeList  incluido  en  los  esquemas  UBL  y  que corresponde a la norma  ISO 4217 – Currency. 

**Ubicación** 

*//Invoice/cbc:DocumentCurrencyCode@listID @listName @listAgencyName* 

**Ejemplo** 

<cbc:DocumentCurrencyCode listID="ISO 4217 Alpha" listName="Currency" listAgencyName="United ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.196.png)Nations Economic Commission for Europe">PEN</cbc:DocumentCurrencyCode> 

**Descripción UBL** 

**cbc:DocumentCurrencyCode** 

Moneda en la que el documento se presenta. Tener en cuenta que el código de moneda también debe colocarse como atributo en todos aquellos campos que almacenan un monto de tipo monetario. 

**Atributos** 



|listID |"ISO 4217 Alpha" |
| - | - |
|listName |Currency |
|listAgencyName |United Nations Economic Commission for Europe |

**Valor de Código Catálogo N° 2** 

**cbc: DocumentCurrencyCode** 



|**Código** |**Descripción** |
| - | - |
|PEN |Sol |
|CNY |Yuan Renminbi |
|JPY |Yen |
|KRW |Won Surcoreano |
|INR |Rupia India |
|USD |Dólar Estadounidense |
|CAD |Dólar Canadiense |
|MXN |Peso Mexicano |
|CHF |Franco Suizo |
|EUR |Euro |
|BRL |Real Brasileño |
|CLP |Peso Chileno |
|COP |Peso Colombiano |
|BOB |Boliviano |
|PYG |Guaraní |
|UYU |Peso Uruguayo |
|ZAR |Rand |
|XAF |Franco CFA de África Central |
|AUD |Dólar Australiano |
|PAB |Balboa |
|AED |Emiratos Árabes Unidos |
|PHP |Peso Filipino |
|TWD |Nuevo dólar taiwanés |
|VND |Dong vietnamita |
|HKD |Dólar de Hong Kong |
|THB |Baht |
|RUB |Rublo Ruso |
|DOP |Peso Dominicano |
|GTQ |Quetzal |
|MYR |Ringgit |
|CRC |Colón |
|HTG |Gourde |
|VEF |Bolívar |

El resto de códigos se puede descargar desde el siguiente link[: Clic Aquí.](https://www.currency-iso.org/dam/downloads/lists/list_one.xls) 

**12 Tipo y número de la guía de remisión relacionada con la operación que se factura.**  

Referencia  a  las  guías  de  remisión  remitente  o  transportista,  según  corresponda, autorizadas por la SUNAT para sustentar el traslado de los bienes. Pueden existir múltiples guías de remisión, por lo que el número de elementos de este tipo es ilimitado. Se utilizará  el Catálogo N° 01: “Código de Tipo de Documento”. 

**Ubicación** 

*//Invoice/cac:DespatchDocumentReference/cbc:ID* 

*//Invoice/cac:DespatchDocumentReference/cbc:DocumentTypeCode@listAgencyName @listName @listURI* 

**Ejemplo** 

<cac:DespatchDocumentReference> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.197.png)

<cbc:ID>0001-002020</cbc:ID> 

<cbc:DocumentTypeCode listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de guía relacionada" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">09</cbc:DocumentTypeCode> </cac:DespatchDocumentReference> 

**Descripción UBL** 

**cac:DespatchDocumentReference** 

Tag que hace referencia a documentos de transporte asociados a la factura. 

De los elementos que componen este tipo complejo y que serán utilizados en el documento de tipo factura tenemos: 

**cbc:ID**: **Obligatorio**. Identificación del número de guía autorizado por SUNAT. Estará conformado por la serie y el número de documento, separado por un guión. 

**cbc**:**DocumentTypeCode: Obligatorio**. Corresponde al código del tipo de documento al que se hace referencia. Se utilizará de acuerdo al catálogo de códigos establecidos para documentos (Catálogo No. 01). 

**Atributos** 



|listAgencyName |“PE:SUNAT” |
| - | - |
|listName |"SUNAT:Identificador de guía relacionada" |
|listURI |"urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01" |

**Valor de Código  (Catálogo N°1)** 

**Cbc:DocumentTypeCode** 



|**Código** |**Descripción** |
| - | - |
|09 |GUIA DE REMISIÓN REMITENTE |

**13 Tipo y número de otro documento y/ código documento relacionado con la operación que se factura.** 

Repetible. Referencia a cualquier otro documento, distintos a los señalados en el numeral anterior, asociado a la factura. Podrán especificarse documentos como comprobantes de retención,  percepción, código  SCOP, etc. Pueden  existir documentos de distintos tipos asociados  a  una  misma  factura,  por  lo  que  el  número  de  elementos  de  este  tipo  es ilimitado.  Se  utilizará  el  Catálogo  No.  12:  “Códigos  -  Documentos  Relacionados Tributarios”. 

**Ubicación** 

*//Invoice/cac:AdditionalDocumentReference/cbc:ID* 

*//Invoice/cac:AdditionalDocumentReference/cbc:DocumentTypeCode @listAgencyName @listName @listURI* 

**Ejemplo** 

<cac:AdditionalDocumentReference> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.198.png)

<cbc:ID>024099</cbc:ID> 

<cbc:DocumentTypeCode listAgencyName="PE:SUNAT" listName="SUNAT: Identificador de documento 

relacionado" 

listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo12">99</cbc:DocumentTypeCode> </cac:AdditionalDocumentReference>

**Descripción UBL**  

**cac:AdditionalDocumentReference** 

Tag que hace referencia a documentos asociados a la factura. 

De los elementos que componen este tipo complejo y que serán utilizados en el documento de tipo factura tenemos: 

**cbc:ID**: Obligatorio. Identificación del número de  documento asociado a la factura. 

**cbc**:**DocumentTypeCode:** Obligatorio. Corresponde al código del tipo de documento al que se hace referencia. Se utilizarán los códigos definidos en el Catálogo No. 12 

**Atributos** 



|listAgencyName |“PE:SUNAT” |
| - | - |
|listName |"SUNAT:Identifi cador de documento relacionado" |
|listURI |"urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo12" |

**Valor de Código  (Catálogo N°12)** 



|**Código** |**Descripción** |
| - | - |
|01 |Factura – emitida para corregir error en el RUC |
|02 |Factura – emitida por anticipos |
|03 |Boleta de Venta – emitida por anticipos |
|04 |Ticket de Salida – ENAPU |
|05 |Código SCOP |
|99 |Otros |

**14 Nombre Comercial.**  

Corresponde al Nombre Comercial del emisor de la factura, obligatorio sólo en el caso de haber sido declarado en  el RUC. En este caso debe ser conforme al registrado en el Registro Único de Contribuyentes – RUC. 

Este requisito se encuentra contenido en el elemento complejo cac:Party ubicado en el componente cac:AccountingSupplierParty. 

**Ubicación** 

*//Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyName/cbc:Name* 

**Ejemplo** 

<cac:AccountingSupplierParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.199.png)

<cac:Party> 

… 

<cac:PartyName> 

<cbc:Name><![CDATA[K&G Laboratorios]]></cbc:Name> </cac:PartyName> 

… 

</cac:Party> 

</cac:AccountingSupplierParty> 

**Descripción UBL** 

**cac:PartyName** 

Se usará para alojar el elemento Name, donde se indica el nombre comercial. 

**15 Apellidos y nombres o denominación o razón social del emisor.**  

**Obligatorio.** Corresponde a los apellidos y nombres o denominación o razón social del emisor de la factura electrónica. Este debe ser acorde a lo registrado en el Registro Único de Contribuyentes - RUC. Este requisito se encuentra contenido en el elemento complejo cac:Party ubicado en el componente cac:AccountingSupplierParty.  

**Ubicación** *//Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyTaxScheme/cbc:RegistrationName* **Ejemplo** 

<cac:AccountingSupplierParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.200.png)

<cac:Party> 

<cac:PartyTaxScheme> 

… 

<cbc:RegistrationName><![CDATA[K&G Asociados S. A.]]></cbc:RegistrationName> … 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingSupplierParty> 

**Descripción UBL** 

**cbc:RegistrationName** 

Se usa para indicar el nombre o razón social del contribuyente de acuerdo a la información proporcianada al momento de su inscripción o modificación hacia la SUNAT. 

**16 Tipo y Número de RUC del Emisor.**  

**Obligatorio.** El tipo de documento del emisor siempre es 6, que corresponde al RUC. Además  de  esto  se  debe  consignar  el  número  de  RUC  del  emisor  de  la  factura electrónicael cual  debe ser válido. 

**Ubicación** 

*//Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyTaxScheme/cbc:CompanyID  @schemeID @schemeName @schemeAgencyName @schemeURI* 

**Ejemplo** 

<cac:AccountingSupplierParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.201.png)

<cac:Party> 

<cac:PartyTaxScheme> 

… 

<cbc:CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20100113612</cbc:CompanyID> <cac:TaxScheme> 

`   `<cbc:ID>-</cbc:ID> 

</cac:TaxScheme> 

… 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingSupplierParty> 

**Descripción UBL** 

**cac:AccountingSupplierParty** 

Estructura de datos del emisor. Tipo complejo que a su vez contiene un elemento Party que se especificará más adelante. 

- **cbc:RegistrationName*.***  Obligatorio.  Nombre  o  denominación  o  razón  social  del emisor del comprobante electrónico. 
- **cbc:CompanyID*.***  Obligatorio.  Identificación  del  emisor  de  la  factura,  deberá  de indicarse el Número de RUC del Emisor. 

**Atributos** 



|schemeName |"SUNAT:Identificador de Documento de Identidad" |
| - | - |
|schemeAgencyName |"PE:SUNAT" |
|schemeURI |"urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06" |

**Valor de Códigos Catálogo N° 06** 

**cbc: CompanyID** 



|**Código** |**Concepto** |
| - | - |
|6 |REG. UNICO DE CONTRIBUYENTES |

- **cac:Party**. Tener en cuenta el punto anterior. 

Factura Electrónica  ~ 43 ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

**17 Código del domicilio fiscal o de local anexo del emisor.**  

Corresponde informar el código del establecimiento donde se esta realizando la venta de los bienes.  

**Ubicación** 

*//Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyTaxScheme/cac:RegistrationAddress/ cbc:AddressTypeCode*

**Ejemplo** 

<cac:AccountingSupplierParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.202.png)

`              `… 

<cac:PartyTaxScheme> 

… 

`  `<cac:RegistrationAddress> 

<cbc:AddressTypeCode>0011</cbc:AddressTypeCode>   </cac:RegistrationAddress> 

… 

</cac:PartyTaxScheme> 

</cac:AccountingSupplierParty>

**Descripción UBL**  

**cac:AddressTypeCode.**  Código  de  cuatro  dígitos  asignado  por  SUNAT,  que  identifica  al establecimiento anexo. Dicho código se genera  al momento la respectiva comunicación del establecimiento. Tratándose del domicilio fiscal y en el caso de no poder determinar el lugar de la venta, informar “0000”. 

**18 Tipo y número de documento de identidad del adquirente o usuario.**  

**Obligatorio.** El tipo de documento será RUC, salvo en operaciones de exportación en cuyo caso la factura es emitida a un sujeto no domiciliado y únicamente deberá consignarse el(los) nombre(s) y apellido(s), denominación o razón social del adquirente o usuario. 

Para definir el tipo de documento de identidad, se tomará en consideración el Catálogo N° 06  del  anexo  N°  8:  “Códigos  de  Tipos  de  Documentos  de  Identidad”.  Tratándose  de operaciones de exportación el código a utilizar será “-”. 

**Ubicación** 

*/Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme/cbc:CompanyID @schemeID @schemeName @schemeAgencyName @schemeURI* 

**Ejemplo** 

<cac:AccountingCustomerParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.203.png)

<cac:Party> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName><![CDATA[CECI FARMA IMPORT S.R.L.]]></cbc:RegistrationName> <cbc:CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI=" urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20100113612</cbc:CompanyID> <cac:TaxScheme> 

`   `<cbc:ID>-</cbc:ID> 

</cac:TaxScheme> 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingCustomerParty>

**Descripción UBL** 

**cac: AccountingCustomerParty**  

Estructura de datos del clienter. Tipo complejo que a su vez contiene un elemento Party que se especificará más adelante. 

- **cbc:RegistrationName*.***  Obligatorio.  Nombre  o  denominación  o  razón  social  del cliente. 
- **cbc:CompanyID*.***  Obligatorio.  Identificación  del  cliente,  deberá  de  indicarse  el documento de identidad. 

**Atributos** 



|schemeName |"SUNAT:Identificador de Documento de Identidad" |
| - | - |
|schemeAgencyName |"PE:SUNAT" |
|schemeURI |"urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06" |

**Valor de Códigos Catálogo N° 06** 

**cbc: CompanyID** 



|**Código** |**Concepto** |
| - | - |
|0 |DOC.TRIB.NO.DOM.SIN.RUC |
|1 |DOC. NACIONAL DE IDENTIDAD |
|4 |CARNET DE EXTRANJERIA |
|6 |REG. UNICO DE CONTRIBUYENTES |
|7 |PASAPORTE |
|A |CED. DIPLOMATICA DE IDENTIDAD |
|B |DOC.IDENT.PAIS.RESIDENCIA-NO.D |
|C |Tax Identification Number - TIN – Doc Trib PP.NN |
|D |Identification Number - IN – Doc Trib PP. JJ |

- **cac:Party**. Tener en cuenta el punto anterior en relación a este elemento. 

**19  Apellidos  y  nombres  o  denominación  o  razón  social  del  adquirente  o usuario.**  

**Obligatorio.** Corresponde a los apellidos y nombres o denominación o razón social del 

adquirente o usuario.

**Ubicación** */Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme/cbc:RegistrationName* 

**Ejemplo** 

<cac:AccountingCustomerParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.204.png)

… 

<cac:Party> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName><![CDATA[CECI FARMA IMPORT S.R.L.]]></cbc:RegistrationName> </cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingCustomerParty> 

**Descripción UBL** 

**cbc:RegistrationName** 

Se usará para indicar el nombre o razón social, según fuera el caso del cliente. 

**20 Dirección del lugar en el que se entrega el bien.**  

En el caso de venta de bienes, se deberá indicar la dirección de la entrega de dichos bienes siempre que: Se trate de **ventas itinerantes** y no figure el punto de llegada en la guía de remisión – remitente que realice el traslado de los bienes. 

**Ubicación** 

*//Invoice/cac:DeliveryTerms/cac:DeliveryLocation/cac:Address*

**Ejemplo** 

<cac:DeliveryTerms> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.205.png)

<cac:DeliveryLocation > 

<cac:Address> 

<cbc:StreetName>CALLE NEGOCIOS # 420</cbc:StreetName> <cbc:CitySubdivisionName/> 

<cbc:CityName>LIMA</cbc:CityName> <cbc:CountrySubentity>LIMA</cbc:CountrySubentity> <cbc:CountrySubentityCode>150141</cbc:CountrySubentityCode> <cbc:District>SURQUILLO</cbc:District> 

<cac:Country> 

<cbc:IdentificationCode listID="ISO 3166-1" listAgencyName="United Nations Economic Commission for Europe" listName="Country">PE</cbc:IdentificationCode> </cac:Country> 

</cac:Address> 

</cac:DeliveryLocation > 

` `</cac:DeliveryTerms>

**Descripción UBL**  

**cac:Address.** Se usa para especificar el lugar de entrega del contribuyente. Donde: 



|**Elemento** |**Descripción** |
| - | - |
|Cbc:StreetName |Dirección completa y detallada |
|cbc:CitySubdivisionName |Urbanización |
|cbc:CityName |Provincia |
|cbc:CountrySubentity |Departamento |
|cbc:CountrySubentityCode |Código de ubigeo |
|cbc:District |Distrito |
|cbc:Country |País |
|cbc:IdentificationCode |Código de País |

**Atributos** 



|listID |"ISO 3166-1" |
| - | - |
|listAgencyName |"United Nations Economic Commission for Europe" |
|listName |"Country" |

**Valor de Códigos Catálogo N° 04** 

**cbc:IdentificationCode** 



|**Código** |**País** |
| - | - |
|PE |Perú |

La lista completa se puede descargar en el siguiente link[: Clic Aquí.](https://www.iso.org/obp/ui/#search/code/)** 

**21 Descuentos Globales** 

Este elemento es distinto al elemento Total Descuentos definido en el punto 43. 

Su propósito es permitir consignar en el comprobante de pago, un descuento a nivel global  o total. Este campo no debe ser usado para contener la suma de los descuentos de línea o ítem. 

**Ubicación** 

*//Invoice/cac:AllowanceCharge* 

**Ejemplo** 

<cac:AllowanceCharge> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.206.png)

<cbc:ChargeIndicator>False</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.10</cbc:MultiplierFactorNumeric> <cbc:Amount currencyID="PEN">143.95</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">1439.48</cbc:BaseAmount> </cac:AllowanceCharge>

**Descripción UBL** 

**cbc:ChargeIndicator** 

Dado que no es un cargo, se debe asignar indicador “false”. 

**cbc:AllowanceChargeReasonCode** 

Se debe considerar el código 00 de acuerdo al catálogo N° 53. 



|**No.** |53 ||
| - | - | :- |
|**Catálogo** |Códigos de cargos o descuentos ||
|**Código** |**Descripción** |**Charge Indicator** |
|00 |OTROS DESCUENTOS |"false" |

**cbc:MultiplierFactorNumeric** 

En  este  elemento  se  especifica  el  porcentaje  que  corresponde  del  descuento  global aplicado. Se expresa en números decimales por ejemplo 5% será 0.05. 

**cbc:Amount** 

Este campo representa el importe del descuento global 

**cbc:BaseAmount** 

A través de este campo se debe indicar el importe sobre el cual se está aplicando  el descuento global. 

**22 Monto Total de Impuestos.** 

Corresponde al importe total de impuestos ISC, IGV e IVAP de Corresponder. 

**Ubicación** 

*//Invoice/cac:TaxTotal/cbc:TaxAmount* 

**Ejemplo** 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.207.png)

<cbc:TaxAmount currencyID="PEN">59210.65</cbc:TaxAmount> … 

</cac:TaxTotal> 

**Descripción UBL** 

**cbc:TaxAmount** 

Este campo se consigna dentro de un elemento complejo cac:TaxTotal. Se deberá colocar la sumatoria total de los impuestos.  

**23 Total valor de venta - operaciones gravadas.** 

Este elemento es usado solo si al menos una línea de ítem está gravada con el IGV. Contiene a la sumatoria de los valores de venta gravados por ítem ***(ver definición de valor de venta en punto 37)*** y la deducción de descuentos globales si lo hubiere. El total valor de venta **no** incluye IGV, ISC, cargos y otros Tributos si los hubiera. 

La sumatoria **tampoco debe contener** el valor de venta de las transferencias de bienes o servicios prestados a título gratuito comprendidos en la factura y que estuviesen gravados con el IGV. 

**Ubicación** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount @currencyID /Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount @currencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID @schemeID @schemeAgencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:Name* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode* **Ejemplo** 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.208.png)

… 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">8560.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">1540.80</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305"  schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153"  schemeAgencyID="6">1000</cbc:ID> <cbc:Name> IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

… 

</cac:TaxTotal> 

**Descripción UBL**  

**cac:TaxSubTotal** 

Para hacer uso de este elemento, es necesario consignar el monto base sobre el cual se está aplicando el impuesto informado, esto se consigna en el elemento cbc:TaxableAmount. Así mismo, el importe del IGV se coloca en el elemento cbc:TaxAmount.  

**cac:TaxCategory** 

Así mismo, se hace necesario especificar la categoría del impuesto por  el cual se está reportando esto se realiza con el elemento cbc:ID y los  atributos: 

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeName |Tax Category Identifier |
|schemeAgencyName |"United Nations Economic Commission for Europe" |

**Valor de Códigos cbc:ID Catálogo N° 05** 

|**Código** |**Descripción** |
| - | - |
|S |IGV |

**cac:TaxScheme** 

Por otro lado, es importante indicar la clase de impuesto que se está informando para ello con el elemento cbc:ID reportaremos de acuerdo a la información del Catálogo N° 5, que para el caso de ISC es el código 1000 y a los siguientes atributos: 

**Atributos** 

|schemeID |"UN/ECE 5305" |
| - | - |
|schemeAgencyID |"6" |

**cbc:Name** 

Este elemento se utiliza para expresar en letras que la información que se está reportando se encuentra: IGV (Se sigue el formato del Catálogo N° 5). 

**cbc:TaxTypeCode** 

Este elemento se utiliza para expresar a través de un código que la información que se está reportando se encuentra gravada, el valor de acuerdo Catálogo N° 5 es: VAT. 

**24 Total valor de venta - operaciones exoneradas.**

Este elemento es usado solo si al menos una línea de ítem se encuentra exonerada al IGV. Contiene a la sumatoria de valor de venta por ítem exonerados por item ***(ver definición de valor de venta x ítem en punto 37)*** y la deducción de descuentos globales si lo hubiere. El valor de venta **no** incluye ISC, cargos u otros Tributos si los hubiera. La sumatoria **tampoco debe contener** el valor de venta de las transferencias de bienes o servicios prestados a título gratuito comprendidos en la factura y que estuviesen exonerados del IGV. 

**Ubicación** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount @currencyID /Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount @currencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID @schemeID @schemeAgencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:Name* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode* **Ejemplo** 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.209.png)

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">8560.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305"  schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">E</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153"  schemeAgencyID="6">9997</cbc:ID> <cbc:Name> EXONERADO</cbc:Name> <cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

**Descripción UBL**  

**cac:TaxSubTotal** 

Para hacer uso de este elemento, es necesario consignar el monto que se está informando (cbc:TaxableAmount) con  su respectivo atributo de  tipo de moneda  que le corresponda (@currencyID). Ahora bien, dado que estamos ante operaciones exoneradas del impuesto general a las ventas el elemento cbc:TaxAmount irá con 0.00 y el atributo @currencyID con el valor “PEN”. 

**cac:TaxCategory** 

Así mismo, se hace necesario especificar la categoría del impuesto por  el cual se está reportando esto se realiza con el elemento cbc:ID y los  atributos: 

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeName |Tax Category Identifier |
|schemeAgencyName |"United Nations Economic Commission for Europe" |

**Valor de Códigos cbc:ID Catálogo N° 05** 



|**Código** |**Descripción** |
| - | - |
|E |Exonerado |

**cac:TaxScheme** 

Por otro lado, es importante indicar la clase de impuesto que se está informando para ello con el elemento cbc:ID reportaremos de acuerdo a la información del Catálogo N° 5, que para el caso de operaciones exoneradas es el código 9997 y a los siguientes atributos:  

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeAgencyID |"6" |

**cbc:Name** 

Este elemento se utiliza para expresar en letras que la información que se está reportando se encuentra: EXONERADO (Se sigue el formato del Catálogo N° 5). 

**cbc:TaxTypeCode** 

Este elemento se utiliza para expresar a través de un código que la información que se está reportando se encuentra exonerada, el valor de acuerdo Catálogo N° 5 es: VAT. 

**25 Total valor de venta - operaciones inafectas.**  

Este elemento es usado solo si al menos una línea de ítem se encuentra inafecta al IGV. Contiene a la sumatoria de valor de venta por item inafectos, y la deducción de descuentos globales si los hubiere ***(ver definición de valor de venta x ítem en punto 37)***. El valor de venta **no** incluye ISC, cargos u otros tributos si los hubiera. La sumatoria **tampoco debe contener** el valor de venta de las transferencias de bienes o servicios prestados a título gratuito comprendidos en la factura y que estuviesen inafectos al IGV. 

**Ubicación** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount @currencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount @currencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID @schemeID @schemeAgencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:Name* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode* **Ejemplo** 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.210.png)

… 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">320.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305"  schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">O</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153"  schemeAgencyID="6">9998</cbc:ID> <cbc:Name> INAFECTO</cbc:Name> <cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

… 

</cac:TaxTotal> 

**Descripción UBL**  

**cac:TaxSubTotal** 

Para hacer uso de este elemento, es necesario consignar el monto que se está informando (cbc:TaxableAmount) con  su respectivo atributo de  tipo de moneda  que le corresponda (@currencyID).  Ahora bien, dado que estamos ante operaciones inafectas del impuesto general a las ventas el elemento cbc:TaxAmount irá con 0.00 y el atributo @currencyID con el valor “PEN”. 

**cac:TaxCategory** 

Así mismo, se hace necesario especificar la categoría del impuesto por  el cual se está reportando esto se realiza con el elemento cbc:ID y los  atributos: 

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeName |Tax Category Identifier |
|schemeAgencyName |"United Nations Economic Commission for Europe" |

**Valor de Códigos cbc:ID Catálogo N° 05** 

|**Código** |**Descripción** |
| - | - |
|O |Inafecto |

**cac:TaxScheme** 

Por otro lado, es importante indicar la clase de impuesto que se está informando para ello con el elemento cbc:ID reportaremos de acuerdo a la información del Catálogo N° 5, que para el caso de operaciones inafectas es el código 9998 y a los siguientes atributos:  **Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeAgencyID |"6" |

**cbc:Name** 

Este elemento se utiliza para expresar en letras que la información que se está reportando se encuentra: INAFECTO (Se sigue el formato del Catálogo N° 5). 

**cbc:TaxTypeCode** 

Este elemento se utiliza para expresar a través de un código que la información que se está reportando se encuentra inafecta, el valor de acuerdo Catálogo N° 5 es: FRE. 

**26 Total Valor de Venta de Operaciones gratuitas.** 

Este elemento, se utilizará cuando exista transferencia de bienes o de servicios que se realice  gratuitamente.  Representa  la  sumatoria  de  los  ítems,  que  correspondan  a operaciones gratuitas, identificados con el elemento o tag descrito en el **punto 39.**  

Es decir, además del tag o campo indicado en el punto 39, se deberá consignar el Total Valor de venta de las operaciones gratuitas.** 

**Ubicación** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc: TaxableAmount @currencyID /Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount @currencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID @schemeID @schemeAgencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:Name /Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode* 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.211.png)

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">5620.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">1011.60</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305"  schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">Z</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153"  schemeAgencyID="6">9996</cbc:ID> <cbc:Name>GRATUITO</cbc:Name> <cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

**Ejemplo** 

**Descripción UBL**  

**Cac:TaxSubTotal** 

Para hacer uso de este elemento, es necesario consignar el monto que se está informando (cbc:TaxableAmount) con  su respectivo atributo de  tipo de moneda  que le  corresponda (@currencyID).   Ahora  bien,  si  la  operación  está  sujeta  al  IGV  **se  deberá  colocar  el importe  en  el  elemento  cbc:TaxAmount**,  en  caso  contrario  irá  con  0.00  y  el  atributo @currencyID con el valor “PEN”. 

**Cac:TaxCategory** 

Así mismo, se hace necesario especificar la categoría del impuesto por  el cual se está reportando esto se realiza con el elemento cbc:ID y los  atributos: 

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeName |Tax Category Identifier |
|schemeAgencyName |"United Nations Economic Commission for Europe" |

**Valor de Códigos cbc:ID Catálogo N° 05** 



|**Código** |**Descripción** |
| - | - |
|Z |Gratuito |

**cac:TaxScheme** 

Por otro lado, es importante indicar la clase de impuesto que se está informando para ello con el elemento cbc:ID reportaremos de acuerdo a la información del Catálogo N° 5, que para el caso de operaciones gratuitas es el código 9996 y a los siguientes atributos:  

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeAgencyID |"6" |

**cbc:Name** 

Este elemento se utiliza para expresar en letras que la información que se está reportando se encuentra: GRATUITO (Se sigue el formato del Catálogo N° 5). 

**cbc:TaxTypeCode** 

Este elemento se utiliza para expresar a través de un código que la información que se está reportando se encuentra inafecta, el valor de acuerdo Catálogo N° 5 es: FRE.

**27 Sumatoria IGV.** 

Corresponde  al  IGV  Total  de  la  factura.  Esta  asociada  estrechamente  con  el  siguiente numeral. La sumatoria no debe contener el IGV que corresponde a  las transferencias de bienes o servicios prestados a título gratuito comprendidos en la factura y que estuviesen gravados con el IGV. 

El IGV = 18% de la suma: [**Total valor de venta  operaciones gravadas]** + [**Sumatoria ISC]. Ubicación** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount@currencyID **/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount @currencyID*** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID @schemeID @schemeAgencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:Name* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode* **Ejemplo** 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.212.png)

… 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">1500.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">270.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305"  schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153"  schemeAgencyID="6">1000</cbc:ID> <cbc:Name> IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

… 

</cac:TaxTotal> 

**Descripción UBL** 

**cbc:TaxAmount** 

Este campo se consigna dentro de un elemento complejo cac:TaxSubTotal. Se deberá colocar la sumatoria total del IGV en el elemento cbc:TaxAmount con su respectivo atributo (@currencyID) de indicador de moneda. La identificación del Impuesto se realiza con las especificaciones del siguiente numeral. 

**28 Sumatoria ISC.**

Corresponde  al  ISC  Total  de  la  factura.  La  sumatoria  no  debe  contener  el  ISC  que corresponde  a  las  transferencias  de  bienes  o  servicios  prestados  a  título  gratuito comprendidos en la factura y que estuviesen gravados con el ISC. 

**Ubicación** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount @currencyID **/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount @currencyID*** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID @schemeID @schemeAgencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:Name* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode* **Ejemplo** 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.213.png)

… 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">6450.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">1096.50</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305"  schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153"  schemeAgencyID="6">2000</cbc:ID> <cbc:Name> ISC</cbc:Name> 

<cbc:TaxTypeCode>EXC</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

… 

</cac:TaxTotal> 

**Descripción UBL**  

**cac:TaxSubTotal** 

Para hacer uso de este elemento, es necesario consignar el monto base sobre el cual se está aplicando el impuesto informado, esto se consigna en el elemento cbc:TaxableAmount. Así mismo, el importe del ISC se coloca en el elemento cbc:TaxAmount.  

**cac:TaxCategory** 

Así mismo, se hace necesario especificar la categoría del impuesto por  el cual se está reportando esto se realiza con el elemento cbc:ID y los  atributos: 

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeName |Tax Category Identifier |
|schemeAgencyName |"United Nations Economic Commission for Europe" |

**Valor de Códigos cbc:ID Catálogo N° 05** 



|**Código** |**Descripción** |
| - | - |
|S |ISC |

**cac:TaxScheme** 

Por otro lado, es importante indicar la clase de impuesto que se está informando para ello con el elemento cbc:ID y como valor el código reportaremos de acuerdo a la información del Catálogo N° 5, que para el caso de ISC es el código 2000 y a los siguientes atributos:  

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeAgencyID |"6" |

**cbc:Name** 

Este elemento se utiliza para expresar en letras que la información que se está reportando se encuentra: ISC (Se sigue el formato del Catálogo N° 5). 

**cbc:TaxTypeCode** 

Este elemento se utiliza para expresar a través de un código que la información que se está reportando se encuentra gravada con ISC, el valor de acuerdo Catálogo N° 5 es: EXC. 

**29 Sumatoria otros tributos.**  

Corresponde al total de los otros tributos, distintos al IGV o ISC. 

Dichos  importes  formarán  parte  de  este  elemento  cuando  conforme  a  la  regulación pertinente correspondan consignarse en el comprobante de pago. No forman parte del(os) valor(es) de venta señalados anterioremente. 

**Ubicación** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount @currencyID **/Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount @currencyID*** 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID @schemeID @schemeAgencyID* 

*/Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:Name /Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode* 

**Ejemplo** 

<cac:TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.214.png)

… 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">5890.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">445.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305"  schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153"  schemeAgencyID="6">9999</cbc:ID> <cbc:Name>OTROS CONCEPTOS DE PAGO</cbc:Name> <cbc:TaxTypeCode>OTH</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

… 

</cac:TaxTotal> 

**Descripción UBL**  

**cbc:TaxSubTotal** 

Para hacer uso de este elemento, es necesario consignar el monto base sobre el cual se está aplicando los impuestos que se están informando, esto se consigna en el elemento cbc:TaxableAmount.  Así  mismo,  el  importe  de  los  referidos  tributos  se  colocan  en  el elemento cbc:TaxAmount. 

**Cac:TaxCategory** 

Así mismo, se hace necesario especificar la categoría del impuesto por  el cual se está reportando esto se realiza con el elemento cbc:ID y los  atributos: 

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeName |Tax Category Identifier |
|schemeAgencyName |"United Nations Economic Commission for Europe" |

**Valor de Códigos cbc:ID Catálogo N° 05** 



|**Código** |**Descripción** |
| - | - |
|S |Otros conceptos de pago |

**cac:TaxScheme** 

Por otro lado, es importante indicar la clase de impuesto que se está informando para ello con el elemento cbc:ID reportaremos de acuerdo a la información del Catálogo N° 5, que para el caso de otros tributos es el código 9999 y a los siguientes atributos: 

**Atributos** 



|schemeID |"UN/ECE 5305" |
| - | - |
|schemeAgencyID |"6" |

**cbc:Name** 

Este elemento se utiliza para expresar en letras que la información que se está reportando se encuentra: OTROS CONCEPTOS DE PAGO (Se sigue el formato del Catálogo N° 5). 

**cbc:TaxTypeCode** 

Este elemento se utiliza para expresar a través de un código que la información que se está reportando corresponde a otros tributos, el valor de acuerdo Catálogo N° 5 es: OTH. 

**30 Total Valor de Venta.** 

A través de este elemento se debe indicar el valor de venta total de la operación. Es decir el importe total de la venta sin considerar los descuentos, impuestos u otros tributos a que se refiere el numeral anterior, pero que incluye cualquier monto de redondeo aplicable. 

**Ubicación** 

*//Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount* 

**Ejemplo** 

<cac:LegalMonetaryTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.215.png)

… 

<cbc:LineExtensionAmount currencyID="PEN">1439.48</cbc:LineExtensionAmount> … 

</cac:LegalMonetaryTotal>

**Descripción UBL** 

**cbc:LineExtensionAmount** 

Se informa el valor de la venta total con su respectivo atributo de tipo de moneda que le corresponda (@currencyID). Este elemento se descibe en el numeral 11. 

**31 Total Precio de Venta.** 

A través de este elemento se debe indicar el valor de venta total de la operación incluido los impuestos.  

**Ubicación** 

*//Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount* 

**Ejemplo** 

<cac:LegalMonetaryTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.216.png)

… 

<cbc:TaxInclusiveAmount currencyID="PEN">9420.50</cbc:TaxInclusiveAmount> … 

</cac:LegalMonetaryTotal>

**Descripción UBL** 

**cbc:TaxInclusiveAmount** 

Se informa el valor de la venta total incluido impuestos con su respectivo atributo de tipo de moneda que le corresponda (@currencyID). Este elemento se descibe en el numeral 11. 

**32 Total de Descuentos.** 

A  través  de  este  elemento  se  debe  indicar  el  valor  total  de  los  descuentos  globales realizados de ser el caso.  

Este  elemento  es  distinto  al  elemento  Descuentos  Globales  definido  en  el  punto  35.  Su propósito es permitir consignar en el comprobante de pago: 

- la sumatoria de los descuentos de cada línea (descuentos por ítem), o 
- la sumatoria de los descuentos de línea (ítem) + descuentos globales 

**Ubicación** 

*//Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount* 

**Ejemplo** 

<cac:LegalMonetaryTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.217.png)

… 

<cbc:AllowanceTotalAmount currencyID="PEN">9420.50</cbc:AllowanceTotalAmount> … 

</cac:LegalMonetaryTotal>

**Descripción UBL**  

**cbc:AllowanceTotalAmount** 

Para  hacer  uso  de  este  elemento,  es  necesario  consignar  el  valor  del  monto  con  su respectivo atributo de tipo de moneda (@ currencyID). Revisar punto 11. 

**33 Sumatoria otros Cargos.** 

Corresponde al total de otros cargos cobrados al adquirente o usuario y que no forman parte de la operación que se factura, es decir no forman parte del(os) valor(es) de ventas señaladas  anteriormente,  pero  sí  forman  parte  del  importe  total  de  la  Venta  (Ejemplo: propinas, garantías para devolución de envases, etc.) 

**Ubicación** 

*//Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount* 

**Ejemplo** 

<cac:LegalMonetaryTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.218.png)

… 

<cbc:ChargeTotalAmount currencyID="PEN">9420.50</cbc:ChargeTotalAmount> … 

</cac:LegalMonetaryTotal>

**Descripción UBL** 

**cbc:ChargeTotal Amount** 

Este campo se consigna el importe total de otros cargos. 

**34 Importe total de la venta, de la cesión en uso o del servicio prestado.**  

Corresponde al importe total de la venta, de la cesión en uso o del servicio prestado. Es el resultado de la suma y/o resta (Según corresponda) de los siguientes puntos: 31-32+33 menos los anticipos que hubieran sido recibidos. 

**Ubicación** 

*//Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount* 

**Ejemplo** 

<cac:LegalMonetaryTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.219.png)

… 

<cbc:PayableAmount currencyID="PEN">45.34</cbc:PayableAmount> </cac:LegalMonetaryTotal> 

**Descripción UBL** 

**cbc:PayableAmount** 

El  campo  cbc:PayableAmount  se  consigna  dentro  del  elemento  complejo cac:LegalMonetaryTotal, cuyo detalle se describe en el numeral 37. 

**35 Número de orden del Ítem.**

**Obligatorio.**  Número de la línea que es secuencial  y se encuentra en cada  línea que contiene la factura. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cbc:ID* 

**Ejemplo** 

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.220.png)

<cbc:ID>1</cbc:ID> 

…. 

</cac:InvoiceLine> 

**Descripción UBL** 

**cac:InvoiceLine** 

Este elemento se encuentra ubicado en el elemento complejo cac:InvoiceLine, se detalle en forma numérica en el orden que corresponde al ítem a informar. 

**36 Cantidad y Unidad de Medida por ítem.** 

**Obligatorio** Se consignará la cantidad de productos vendidos o servicios prestados en la operación. En el caso de retiro de bienes, se consignará la cantidad de bienes transferidos a titulo gratuito. Cuando se trate de servicios o cualquier otra operación no cuantificable se deberá consignar el valor uno (1). 

**Ubicación** 

*/Invoice/cac:InvoiceLine/cbc:InvoicedQuantity @unitCode @unitCodeListID @unitCodeListAgencyName* 

**Ejemplo** 

<cbc:InvoicedQuantity unitCode="CS" unitCodeListID="UN/ECE rec 20" ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.221.png)unitCodeListAgencyName="United Nations Economic Commission for Europe">50</cbc:InvoicedQuantity> 

**Descripción UBL** 

**cbc:InvoicedQuantity** 

Este  campo  se  encuentra  ubicado  en  el  elemento  complejo  cac:InvoiceLine,  aquí  se detalla la cantidad de unidades de acuerdo a la unidad de medida que se esté informando.  

**Atributos** 



|unitCode |Catálogo N° 3 |
| - | - |
|unitCodeListID |"UN/ECE rec 20" |
|unitCodeListAgencyName |"United Nations Economic Commission for Europe" |

**Valor de Códigos cbc:ID Catálogo N° 03\*** 



|**Código** |**Descripción** |
| - | - |
|BJ |BALDE |
|BG |BOLSA |
|BO |BOTELLAS |
|BX |CAJA |
|CT |CARTONES |
|CY |CILINDRO |
|CJ |CONOS |
|GRM |GRAMO |
|SET |JUEGO |
|KGM |KILOGRAMO |
|KTM |KILOMETRO |
|KT |KIT |
|CA |LATAS |
|LBR |LIBRAS |
|LTR |LITRO |
|MTR |METRO |
|MLL |MILLARES |
|UM |MILLON DE UNIDADES |
|NIU |UNIDAD (BIENES) |
|ZZ |UNIDAD (SERVICIOS) |

\*El resto de códigos se pueden verificar en el anexo II del siguiente link:[ Clic Aquí.](https://www.unece.org/fileadmin/DAM/cefact/recommendations/rec20/rec20_rev4E_2006.xls)  

**37 Valor de venta por ítem** 

**Obligatorio.** Este elemento es el producto de la cantidad por el **valor unitario (Q x Valor Unitario)** y la deducción de los descuentos aplicados a dicho ítem (de existir).  

Este importe no incluye los tributos (IGV, ISC  y otros Tributos), los descuentos globales o cargos. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cbc:LineExtensionAmount @currencyID* 

**Ejemplo** 

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.222.png)

… 

<cbc:LineExtensionAmount  currencyID="PEN">172890.0</cbc:LineExtensionAmount> … 

</cac:InvoiceLine> 

**Descripción UBL**  

**cbc:LineExtensionAmount** 

Este elemento se encuentra ubicado en el elemento complejo cac:InvoiceLine. Su atributo @currencyID se encuentra especificado en el punto 11. 

**38 Precio de venta unitario por ítem y código.**  

**Obligatorio.**Dentro del ámbito tributario, es el monto correspondiente al precio unitario facturado del bien vendido o servicio vendido. Este monto es la suma total que queda 

obligado a pagar el adquirente o usuario por cada bien o servicio. Esto incluye los tributos (IGV, ISC y otros Tributos) y la deducción de descuentos por ítem. Para identificar este monto se debe consignar el código “01” (Catálogo No. 16). 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice @currencyID* 

**Ejemplo** 

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.223.png)

… 

<cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">18.75</cbc:PriceAmount> 

<cbc:PriceTypeCode 

listName="SUNAT:Indicador de Tipo de Precio"  

listAgencyName="PE:SUNAT" 

listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> 

</cac:PricingReference> 

… 

</cac:InvoiceLine> 

**Descripción UBL** 

` `**cac:PricingReference**  

Este elemento se encuentra ubicado en el elemento complejo cac:InvoiceLine. Su atributo @currencyID se encuentra especificado en el punto 11. 

**cac:PriceTypeCode**  

Este elemento se encuentra ubicado en el elemento complejo cac:AlternativeConditionPrice y 

indica si estamos ante una operación onerosa o no. 

**Atributos** 



|listName |"SUNAT:Indicador de Tipo de Precio" |
| - | - |
|listAgencyName |"PE:SUNAT" |
|listURI |"urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16" |

**Valor de Códigos cbc:ID Catálogo N° 16** 



|**Código** |**Descripción** |
| - | - |
|01 |Precio unitario (incluye el IGV) |
|02 |Valor referencial unitario en operaciones no onerosas |

**39 Valor referencial unitario por ítem en operaciones no onerosas**  

` `Cuando la transferencia de bienes o de servicios se efectúe gratuitamente, se consignará el importe del valor de venta unitario que hubiera correspondido a dicho bien o servicio, en operaciones onerosas con terceros. En su defecto se aplicará el valor de mercado. 

Para identificar este valor, se debe de consignar el código “02” (incluido en el Catálogo No. 16). 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:PricingReference/cac:AlternativeConditionPrice* 

**Ejemplo** 

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.224.png)

… 

<cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">18.75</cbc:PriceAmount> 

<cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio"  

listAgencyName="PE:SUNAT"  

listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">02</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> 

</cac:PricingReference> 

… 

`  `<cac:InvoiceLine> 

**Descripción UBL** 

**cac:PricingReference** 

Este elemento se encuentra ubicado en el elemento complejo cac:InvoiceLine. Su atributo 

@currencyID se encuentra especificado en el punto 11. 

El elemento cbc: PriceTypeCode se detalla en el numeral anterior. 

**40 Descuentos por ítem** 

Su propósito es permitir consignar en el comprobante de pago, un descuento a nivel de  línea o ítem. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:Allowancecharge* 

**Descripción UBL** 

- **AllowanceCharge**: Opcional. Descuentos aplicados a los ítems facturados en la línea. 
- **ChargeIndicator**: Obligatorio. Si es descuento (False). 
- **AllowanceChargeReasonCode**: Obligatorio.  Puede tomar cualquiera  de  los  siguientes valores descritos en el catálogo N° 53. 
- **MultiplierFactorNumeric**: Es el porcentaje que le corresponde por el descuento aplicado. Para el caso de retención por ejemplo es 0.03. 
- **Amount**: Monto del descuento del ítem .Se debe especificar la moneda en la que se emite el descuento, para ello se utiliza el atributo ***currencyID*.** 
- **BaseAmount**: Monto sobre el cual se le debe aplicar el descuento del ítem .Se debe especificar la moneda en la que se emite. 

**Valor de Códigos Catálogo N° 53** 



|**Código** |**Descripción** |**Charge Indicator** |**Multiplier FactorNumeric** |
| - | - | :- | :- |
|00 |OTROS DESCUENTOS |false |Variable |
|01 |DETRACCIÓN |false |Variable |
|02 |RETENCIÓN |false |0\.03 |



**Ejemplo** 

<Invoice> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.225.png)

… 

`          `<cac:InvoiceLine> 

`                 `… 

<cac:AllowanceCharge> 

<cbc:ChargeIndicator>false</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.05</cbc:MultiplierFactorNumeric> <cbc:Amount currencyID="PEN">71.97</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">1439.48</cbc:BaseAmount> </cac:AllowanceCharge> 

`    `… 

`          `<cac:InvoiceLine> 

… 

</Invoice> 

**41 Cargos por ítem** 

Su propósito es permitir consignar en el comprobante de pago, un cargo a nivel de  línea o ítem. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:Allowancecharge* 

**Descripción UBL** 

- **AllowanceCharge**: Opcional. Cargos aplicados a los ítems facturados en la línea. 
- **ChargeIndicator**: Obligatorio. Si es cargo (“true”). 
- **AllowanceChargeReasonCode**: Obligatorio.  Puede tomar  cualquiera  de  los  siguientes valores establecidos en el catálogo N° 53. 
- **MultiplierFactorNumeric**: Es el porcentaje que le corresponde por el cargo aplicado. Para el caso de retención por ejemplo es 0.03. 
- **Amount**: Monto del descuento del ítem .Se debe especificar la moneda en la que se emite el descuento, para ello se utiliza el atributo ***currencyID*.** 
- **BaseAmount**: Monto sobre el cual se le debe aplicar el descuento del ítem .Se debe especificar la moneda en la que se emite. 

**Valor de Códigos Catálogo N° 53** 



|**Código** |**Descripción** |**Charge Indicator** |**Multiplier FactorNumeric** |
| - | - | :- | :- |
|50 |OTROS CARGOS |true |Variable |
|51 |PERCEPCION VENTA INTERNA |true |0\.02 |
|52 |PERCEPCION A LA ADQUISICION DE COMBUSTIBLE |true |0\.01 |
|53 |PERCEPCION REALIZADA AL AGENTE DE PERCEPCION CON TASA ESPECIAL |true |0\.005 |



**Ejemplo** 

`   `<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.226.png)

`       `…. 

<cac:AllowanceCharge> 

<cbc:ChargeIndicator>true</cbc:ChargeIndicator> 

<cbc:AllowanceChargeReasonCode>50</cbc:ChargeIndicator> 

<cbc: MultiplierFactorNumeric>0.10</cbc: MultiplierFactorNumeric> 

<cbc:Amount currencyID="PEN">44.82</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">448.20</cbc:Amount> 

</cac:AllowanceCharge> 

… 

`      `</cac:InvoiceLine> 

**42 Afectación al IGV por ítem.** 

**Obligatorio.** Indica si el bien transferido, vendido o cedido en uso,  servicio prestado u operación facturable está gravada, exonerada o inafecta al IGV. Se utilizará el Catálogo N° 07: “Código tipo de afectación del IGV”. 



|||
| :- | :- |
|**AFECTACIÓN** |**DESCRIPCIÓN** |
|||
|Gravado - Operación Onerosa |Indicador que la operación **se encuentra** dentro del ámbito de aplicación del impuesto. |
|Gravado – Premio |<p>Indicador de transferencia de bienes a terceros,  **que  no son  bienes  producidos  o  comercializados  por  el transferente**  y  que  están  destinados  a  promocionar  o fidelizar  un  producto  o  marca  a  través  de  sorteos, concursos, loterías, canjes. </p><p>Transferencias señaladas en el primer acápite del primer párrafo  del  inciso  c)  del  Numeral  3  del  Art.  2°  del Reglamento de la Ley del IGV. </p><p>La  afectación  al  IGV  corresponde  cuando  se  ha sobrepasado el límite establecido en el cuarto acápite del segundo párrafo del Numeral 3 del Art. 2° del Reglamento de la Ley del IGV. </p>|
|Gravado – Donación |Indicador de transferencia de bienes a terceros con un fin altruista. |
|Gravado - Retiro |Indicador  para  todos  aquellos  retiros  de  bienes  que  no tengan  una  clasificación  expresa  en  esta  tabla,  por  los cuales existe obligación de emitir un comprobante de pago y que para efectos del IGV se consideran venta en atención a lo dispuesto en el Numeral 2 del Art. 3° del TUO de la Ley del IGV y el Numeral 3 del Art. 2° del Reglamento de la Ley del IGV. |
|Gravado - Publicidad |<p>Indicador  de  transferencia  de  bienes  a  clientes  o  potenciales  clientes  **de  bienes  producidos  o comercializados  por  el  transferente**,  destinados  a promocionar un producto o una marca a través de entregas de muestras, degustaciones. </p><p>Transferencias señaladas en el primer acápite del primer párrafo  del  inciso  c)  del  Numeral  3  del  Art.  2°  del Reglamento de la Ley del IGV. </p><p>La  afectación  al  IGV  corresponde  cuando  se  ha sobrepasado el límite establecido en el cuarto acápite del segundo párrafo del Numeral 3 del Art. 2° del Reglamento de la Ley del IGV. </p>|
|Gravado - Bonificaciones |<p>Indicador  de  transferencia  de  bienes  a  clientes  y  cuya entrega está directamente relacionado con la(s) compra(s), pues a diferencia de la publicidad, la facturación de estos retiros se encuentra en el mismo comprobante de pago de la venta. </p><p>La  afectación  al  IGV  corresponde  cuando  se  ha sobrepasado el límite establecido en el cuarto acápite del segundo párrafo del Numeral 3 del Art. 2° del Reglamento de la Ley del IGV. </p>|
|Gravado - Entrega a trabajadores |<p>Identificación  de  aquellos  bienes  entregados  a  los trabajadores  y  que  **son  de  libre  disposición**  y  **no  son necesarios para la prestación de sus servicios**. </p><p>Transferencias señaladas en el cuarto acápite del primer párrafo  del  inciso  c)  del  Numeral  3  del  Art.  2°  del Reglamento de la Ley del IGV. </p>|



|||
| :- | :- |
|**AFECTACIÓN** |**DESCRIPCIÓN** |
|||
|Exonerado - Operación Onerosa |Indicador general  de  la línea,  tratándose  de  operaciones que  **se  encuentran**  dentro  del  ámbito  de  aplicación  del impuesto  **pero**,  de  acuerdo  a  las  normas  vigentes,  **se excluyen**  del  ámbito  de  aplicación  en  función  a determinada(s) variable(s). |
|Inafecto - Operación Onerosa |Indicador  general de  la  línea,  tratándose  de  operaciones que **no se encuentran** dentro del ámbito de aplicación del impuesto. |
|Inafecto – Premio |<p>Indicador de transferencia de bienes a terceros,  **que  no son  bienes  producidos  o  comercializados  por  el transferente**  y  que  están  destinados  a  promocionar  o fidelizar  un  producto  o  marca  a  través  de  sorteos, concursos, loterías, canjes. </p><p>Transferencias señaladas en el primer acápite del primer párrafo   del   inciso   c)   del   Numeral   3   del   Art.   2° del Reglamento de la Ley del IGV. </p>|
|Inafecto - Publicidad |<p>Indicador  de  transferencia  de  bienes  a  clientes  o  potenciales  clientes  de  bienes  producidos  o  comercializados  por  el  transferente,  destinados  a promocionar un producto o una marca a través de entregas de muestras, degustaciones. </p><p>Transferencias señaladas en el primer acápite del primer párrafo  del  inciso  c)  del  Numeral  3  del  Art.  2°  del Reglamento de la Ley del IGV. </p>|
|Inafecto - Bonificación |Indicador  de  transferencia  de  bienes  a  clientes  y  cuya entrega está directamente relacionado con la(s) compra(s) |
|Inafecto - Retiro |Indicador  para  todos  aquellos  retiros  de  bienes  que  no tengan  una  clasificación  expresa  en  esta  tabla,  por  los cuales existe obligación de emitir un comprobante de pago y  que  para  efectos  del  IGV  no  se  consideran  venta  en atención a lo dispuesto en el Numeral 2 del Art. 3° del TUO de la Ley del IGV y el Numeral 3 del Art. 2° del Reglamento de la Ley del IGV. |
|Inafecto - Muestras Médicas |Identificación de aquellos bienes entregados a título gratuito en  calidad  de  muestras  médicas,  que  no  se  consideran retiros conforme al  Numeral 3 del Art. 2° del Reglamento  de la Ley del IGV. |
|Inafecto - Retiro por Convenio Colectivo |Identificación de aquellos bienes que son entregados a los trabajadores pactados por Convenios Colectivos y que se consideran condición de trabajo y que son indispensables para que el trabajador pueda prestar sus servicios, bienes que no se consideran retiros conforme al Numeral  2 del  Art. 3° del TUO de la Ley del IGV. |
|Exportación |Indicador general de la línea, para operaciones que **no se encuentran**  afectas  al  impuesto  al  tratarse  de transferencias que se realizan fuera del territorio nacional |

Para el caso peruano los elementos para identificar al tributo contenido en: 

.../cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/… Adoptarán los valores “1000”, “IGV” y “VAT” respectivamente. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/ /Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cbc:TaxExemptionReasonCode* 

**Ejemplo** 

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.227.png)

… 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">259.11</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">1439.48</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">259.11</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID 

schemeID="UN/ECE 5305"   

schemeName="Tax Category Identifier" 

schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> 

<cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode  

listAgencyName="PE:SUNAT"  

listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionReason Code> 

<cac:TaxScheme> 

<cbc:ID>1000</cbc:ID> 

<cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

… 

</cac:InvoiceLine> 

**Descripción UBL** 

**cbc:TaxExemptionReasonCode** 

Este campo se consigna dentro de un elemento complejo cac:TaxTotal. Para hacer uso de este elemento, es necesario además colocar datos que permitan identificar el tributo que se está informando y el monto del tributo (cbc:TaxAmount), el cual es obligatorio de acuerdo al estándar  UBL.  Además,  se  debe  tomar  en  cuenta  que  el  campo  cbc:TaxAmount  se consigna  a  nivel  del  cac:TaxTotal  y  a  nivel  del  cac:TaxSubtotal.  En  los  dos  casos  los importes serán iguales ya que corresponden a un mismo ítem.  

**43 Sistema de ISC por ítem** 

**Opcional.** Indica el tipo de sistema de cálculo del ISC, utilizado para determinar la base imponible cuando el bien transferido o vendido esta gravado con el ISC. Se utilizará el Catálogo No. 08: “Códigos de Tipos de Sistema de Cálculo del ISC”. 

Para el caso peruano los elementos para identificar al tributo contenido en: 

.../cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/… 

Adoptarán los valores “2000”, “ISC” y “EXC” respectivamente. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cbc:TierRange* 

**Ejemplo** 

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.228.png)

… 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">1750.52</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">8752.60</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">1750.52</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID 

schemeID="UN/ECE 5305"   

schemeName="Tax Category Identifier" 

schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> 

<cbc:Percent>20.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName=" SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionReason Code> 

<cbc:TierRange>01</cbc:TierRange> 

<cac:TaxScheme> 

<cbc:ID>2000</cbc:ID> 

<cbc:Name>ISC</cbc:Name> 

<cbc:TaxTypeCode>EXC</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

… 

</cac:InvoiceLine> 

**Descripción UBL**  

**cbc:TierRange** 

Este campo se consigna el código de tipo de Sistema de ISC Aplicado, puede tomar los siguientes valores: 

01- Sistema al valor (Apéndice IV, lit. A – T.U.O IGV e ISC) 

02- Aplicación del Monto Fijo (Apéndice IV, lit. B – T.U.O IGV e ISC) 

03- Sistema de Precios de Venta al Público (Apéndice IV, lit. C – T.U.O IGV e ISC) 

**IMPORTANTE ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.229.png)**

*La  factura  electrónica  deberá  tener  información  de  los  por  lo  menos  uno  de  siguientes campos definidos como opcionales: 18. Total valor de venta – operaciones gravadas, 19. Total  valor  de  venta  –  operaciones  inafectas  o  20.  Total  valor  de  vento  -  operaciones exoneradas.* 

**44 Descripción detallada.**  

**Obligatorio.** Descripción detallada del servicio prestado, bien vendido o cedido en uso, indicando el nombre y las características, tales como marca del bien vendido o cedido en uso. 

Otras consideraciones: 

- Se deberá colocar el número de serie y/o número de motor, si se trata de un bien identificable, de corresponder, salvo que no fuera posible su consignación al momento  de la emisión del comprobante de pago. 
- Tratándose  de  la  venta  de  medicamentos  y/o  insumos  para  tratamiento  de enfermedades  oncológicas  y  del  VIH/SIDA,  se  consignará  adicionalmente  la(s) partida(s) arancelaria(s) correspondiente(s). En este casoel comprobante de pago no podrá incluir bienes que no sean materia de dicho beneficio. 
- Si el emisor electrónico lleva por lo menos un Registro de Inventario Permanente en Unidades Físicas, al amparo de las normas del Impuesto a la Renta, podrá consignar en reemplazo de la descripción detallada, la descripción requerida por el Reglamento de Comprobantes de  Pago para las facturas, en la medida que  añada  el código     que  las normas que regulan el llevado de libros  y registros denominan como código de existencia. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:Item/cbc:Description* 

**Ejemplo** 

<cac:Item> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.230.png)

… 

<cbc:Description><![CDATA[CAPTOPRIL 25mg X 30]]></cbc:Description> … 

</cac:Item> 

**Descripción UBL** 

**cbc:Description** 

Este campo se encuentra ubicado en el elemento complejo cac:InvoiceLine, aquí se detalla en forma detallada la descripción del ítem que se está vendiendo. 

**45 Código de producto del Ítem.**  

**Opcional.** Código del producto de acuerdo al tipo de codificación interna que se utilice. 

Su  uso  será  obligatorio  si  el  emisor  electrónico,  opta  por  consignar  este  código,  en reemplazo de la descripción detallada. Para tal efecto el código a usar será aquél, que las normas que regulan el llevado de libros y registros, denominan como *código de existencia*. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:Item/cac:SellersItemIdentification/cbc:ID* **Ejemplo** 

<cac:SellersItemIdentification> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.231.png)

… 

<cbc:ID>Cap-258963</cbc:ID> 

… 

</cac:SellersItemIdentification> 

**Descripción UBL** 

**cac:SellersItemIdentification** 

Este elemento se encuentra ubicado en el elemento complejo cac:InvoiceLine.  

**46 Código de producto SUNAT.**  

**Opcional.** Código del producto de acuerdo al estándar internacional de la ONU denominado: United  Nations  Standard  Products  and  Services  Code  -  Código  de  productos  y  servicios estándar de las Naciones Unidas - UNSPSC v14\_0801, a que hace referencia el catálogo N° 15  del  Anexo  N°  8  de  la  Resolución  de  Superintendencia  N°  097-2012/SUNAT  y modificatorias. 

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode*

**Ejemplo** 

<cac:CommodityClassification> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.232.png)

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">51121703</cbc:ItemClassificationCode> 

</cac:CommodityClassification> 

**Descripción UBL**  

**cbc:ItemClassificationCode** 

Este elemento se encuentra ubicado en el elemento complejo cac:InvoiceLine. 

**Atributos** 



|listID |"UNSPSC" |
| - | - |
|listAgencyName |"GS1 US" |
|listName |"Item Classification" |

**Valor de Códigos cbc:ID Catálogo N° 25** 



|**Código** |**Descripción** |
| - | - |
|83111507 |Servicios de buró de central de llamadas (call center) |
|84131500 |Servicios de Seguros para Estructuras y Propiedades y Posesiones |
|80111617 |Servicios temporales de arquitectura |
|93151501 |Servicios Financieros o de Gestión Administrativa de Empresas |
|32101617 |Publicas |
|78111802 |Tarjetas Inteligentes |
|44121701 |Servicios de Buses con Horarios Programados |
|50202301 |Bolígrafos |
|56101703 |Agua |
|43211508 |Escritorios |
|43191504 |Computadores personales |
|15101506 |Gasolina |

El resto de códigos se pueden consultar en el siguiente link[: Clic Aquí.](https://www.colombiacompra.gov.co/sites/default/files/manuales/UNSPSC_Spanish_v14_0801.pdf) 

**47 Propiedades Adicionales del Ítem** 

A través de este elemento se podrá indicar información adicional al ítem el cual es materia de comunicación. A su vez tiene diferentes elementos que se usaran de acuerdo a lo que corresponda informar. Para tal caso tener en cuenta el último párrafo del presente numeral.  

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:Item/cac:AdditionalItemProperty* 

**Ejemplo** 

|**Elemento** |**Valor** |
| - | - |
|Recursos Hidrobiológicos - Nombre y matrícula de la embarcación |Luana II, Matricula: CO-10955-PM |
|Recursos Hidrobiológicos – cantidad de especie vendida |185\.85 TM |
|Recursos Hidrobiológicos - Lugar de Descarga |Planta Pesquera de PESQUERA DIAMANTE S.A, Puerto Mollendo |
|Recursos Hidrobiológicos-Fecha de descarga (aa/mm/dd) |2017-05-23 |

<cac:PaymentMeans> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.233.png)

<cac:PayeeFinancialAccount> 

<cbc:ID>192999821</cbc:ID> 

</cac:PayeeFinancialAccount> 

</cac:PaymentMeans> 

<cac:PaymentTerms> 

<cbc:ID  

schemeName="SUNAT:Codigo de detraccion" 

schemeAgencyName="PE:SUNAT"  schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo54">004</cbc:ID> <cbc:PaymentPercent>9.00</cbc:PaymentPercent> 

<cbc:Amount>2208.96</cbc:Amount> 

</cac:PaymentTerms> 

…. 

<cac:InvoiceLine> 

<cac:Item> 

… 

<cac:AdditionalItemProperty > 

<Name>Detracciones: Recursos Hidrobiológicos - Nombre y Matrícula de la Embarcación</Name> <NameCode 

listName="SUNAT :Identificador de la propiedad del ítem"  

listAgencyName="PE:SUNAT">3002</NameCode> 

<Value>LuanaII, Matricula: CO-10955-PM</Value> 

</cac:AdditionalItemProperty> 

<cac:AdditionalItemProperty > 

<Name>Detracciones: Cantidad de Especies Marinas</Name> 

<NameCode 

listName="SUNAT :Identificador de la propiedad del ítem"  

listAgencyName="PE:SUNAT">3003</NameCode> 

<Value>185.85 TM</Value> 

</cac:AdditionalItemProperty> 

<cac:AdditionalItemProperty > 

<Name>Detracciones: Recursos Hidrobiológicos - Lugar de descarga</Name> 

<NameCode 

listName="SUNAT :Identificador de la propiedad del ítem"  

listAgencyName="PE:SUNAT">3004</NameCode> 

<Value>Planta Pesquera de PESQUERA DIAMANTE S.A, Puerto Mollendo</Value> </cac:AdditionalItemProperty> 

<cac:AdditionalItemProperty > 

<Name> Detracciones: Recursos Hidrobiológicos - Fecha de descarga</Name> 

<NameCode 

listName="SUNAT :Identificador de la propiedad del ítem"  

listAgencyName="PE:SUNAT">3005</NameCode> 

<StartDate>2017-05-23</StartDate> 

</cac:AdditionalItemProperty> 

… 

</cac:Item> 

</cac:InvoiceLine> 

**Descripción UBL** 

**cbc:Name** 

Obligatorio. Este elemento indicará el nombre de la propiedad materia de envío, para tal caso tener en cuenta el catálogo N° 55.  

**cbc:NameCode** 

Obligatorio. Es el elemento descrito en el párrafo anterior pero representado a través de un 

código, para tal caso tener en cuenta el catálogo N° 55. 

**Atributos** 



|listName |"SUNAT:Identificador de la propiedad del ítem" |
| - | - |
|listAgencyName |"PE:SUNAT" |

**cbc:Value** 

De corresponder. Es el elemento se utiliza para indicar el valor que corresponde al dato que se informa.No es utilizado en los siguientes códigos, dado que se informa a través de otro elemento: 3005, 4003-4006 y 8001.  

**Ubicación** 

*//Invoice/cac:InvoiceLine/cac:Item/cac:AdditionalItemProperty/cac:UsabilityPeriod* 

**cbc:StartDate** 

De corresponder. Es de naturaleza de fecha (xsd:date). Se utiliza para informar los siguientes supuestos: 



|**Código** |**Descripción** |
| - | - |
|3005 |Detracciones: Recursos Hidrobiológicos - Fecha de descarga |
|4003 |Beneficio Hospedajes: Fecha de Ingreso al Establecimiento |
|4006 |Beneficio Hospedajes: Fecha de Consumo |
|8001 |Gastos Intereses Hipotecarios: Fecha de Otorgamiento del Crédito |

**cbc:EndDate** 

De corresponder. Es de naturaleza de fecha (xsd:date). Se utiliza para informar los siguientes supuestos: 



|**Código** |**Descripción** |
| - | - |
|4004 |Beneficio Hospedajes: Fecha de Salida del Establecimiento |

**cbc:DurationMeasure** 

De corresponder. Se utiliza para informar los días de permanencia que se tuvo en un hospedaje, para efectos de los beneficios tributarios que correspondan a este sector. 



|**Código** |**Descripción** |
| - | - |
|4005 |Beneficio Hospedajes: Número de Días de Permanencia |

En resumen, se tendrá en cuenta la siguiente tabla: 

**No. ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.234.png)**

**Catálogo**  Código de propiedad del ítem  **.../cac:AdditionalItemProperty  .../cac:AdditionalItemProperty/** 

**cac:UsabilityPeriod** 

**Código  Descripción  cbc:  cbc:Name  cbc:  cbc:Start  cbc:End  cbc:Duration** 

**Name  Code  Value  Date  Date  Measure** 

Detracciones: Recursos Hidrobiológicos - 

3002  Nombre y Matrícula de la Embarcación  x  x  x 

3003  Detracciones: Cantidad de Especies Marinas  x  x  x 

3004  D- Lugetracciar deon deess: Rcargecuarsos Hidrobiológicos  x  x  x 

Detracciones: Recursos Hidrobiológicos 

3005  - Fecha de descarga  x  x  x 

3006  Detracciones: Transporte Bienes  x  x  x 

vía terrestre – Numero Registro MTC 

3007  Detracciones: Transporte Bienes  x  x  x 

vía terrestre – Configuración Vehicular 

3008  Detracciones: Transporte Bienes  x  x  x 

vía terrestre – Punto de Origen 

Detracciones: Transporte Bienes 

3009  vía terrestre – Punto Destino  x  x  x 

Detracciones: Transporte Bienes – 

3010  Valor Referencial Preliminar por Viaje  x  x  x 

3011  DValetorracci Reofenreesn: Tcialran Psrpeloimrtein Bar poieners V–ehículo  x  x  x 

3012  DReefteraccirencioalne Ps: Trelrimanisnpar poorte Br TieMn eesn– VViajealor  x  x  x 

3013  DCaretgraccia Efeoctivnesa e: Trnan TsMpo proter V Beiehnícuesl–o   x  x  x 

3014  DCaretgraccia Útoiln eens T: TMran despl Voertheí Bcuileoneens  V– iaje  x  x  x 

4002  BDeíasne dfieci Poe Hrmosanpeednajecias : Número de  x  x  x 

4003  Beneficio Hospedajes: Fecha de  x  x  x 

Ingreso al Establecimiento 

4004  Beneficio Hospedajes: Fecha de  x  x  x 

Salida del Establecimiento 

4005  Beneficio Hospedajes: Número de  x  x  x 

` `Días de Permanencia 

4006  Beneficio Hospedajes: Fecha de Consumo  x  x  x 

5000  Proveedores Estado: Número de Exp.  x  x  x 

5001  Proveedores Estado: Código de Unidad  x  x  x 

Ejecutora 

Proveedores Estado: N° de Proceso de 

5002  Selección  x  x  x 

5003  Proveedores Estado : N° de Contrato  x  x  x 

6000  CoComnceersciióalni Mzaciinóenra de Oro :  Código Unico  x  x  x 

6001  Comercialización de Oro :  N° declaración  x  x  x 

compromiso 

6002  Comercialización de Oro: N° Reg.  x  x  x 

Especial .Comerci. Oro 

6003  Comercialización de Oro: N° Resolución  x  x  x 

que autoriza Planta de Beneficio 

6004  Comercialización de Oro :  x  x  x 

Ley Mineral (% concent. oro) 

7000  Gastos Art. 37 Renta: Número de Placa  x  x  x 

8000  GasNúmetosr Ino dteer Coesenst Hratoipotecarios:  x  x  x 

Gastos Intereses Hipotecarios: 

8001  Fecha de Otorgamiento del Crédito  x  x  x 

**48 Valor unitario por ítem.**  

**Obligatorio.**  Se  consignará  el  importe  correspondiente  al  valor  o  monto  unitario  del  bien vendido, cedido o servicio prestado, indicado en una línea o ítem de la factura. Este importe no incluye los tributos (IGV, ISC y otros Tributos)  ni los cargos globales. Ubicación 

*//Invoice/cac:InvoiceLine/cac:Price/cbc:PriceAmount* **Ejemplo** 

<Invoice> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.235.png)

… 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">678.0</cbc:PriceAmount> </cac:Price> 

… 

</Invoice> 

**Descripción UBL** 

**cbc:PriceAmount** 

Este elemento se encuentra ubicado en el elemento complejo cac:InvoiceLine. 

**B.2  Detalle de elementos complejos** 

En  esta  sección  se  describe  aquellos  tag  que  por  su  complejidad  requieren  de  una  mayor explicación. 

B.2.1 Tag UBLExtension 

Uno    o    más    <ext:UBLExtension>   están    contenidos    dentro    de    un    elemento <ext:UBLExtensions> descendiente directo del elemento raíz del documento. Estos elementos están disponibles en UBL 2.1 para la inclusión de datos no [UBL], como es nuestro caso. 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.236.png)

Se hará uso de este tipo de componente de extensión para especificar  solamente la firma digital. 

**1.  ext:UBLExtension/ext:ExtensionContent/ds:Signature** 

No es objeto de este informe especificar el tipo de firma que se utilizará en el contexto de la factura electrónica, sin embargo se sientan las bases para declarar un certificado y se tomará como ejemplo una firma sencilla XMLdSig. 

La firma digital será alojada dentro del elemento <ext:UBLExtension> 

- **ExtensionContent.** Dentro de éste elemento es donde se incluyen las firmas [XMLDSig] de todos los firmantes del documento. Por tanto, en el documento únicamente habrá un solo <ext:UBLExtension> para la inclusión de firmas. 
- La  firma  se  realizará  sobre  el  documento  completo  y  podrá  llevarse  a  cabo  con  un componente propio o externo de firma de documentos XML. En cualquier caso la firma satisfará  como  mínimo  los  requerimientos  de  “Firma  Electrónica”.  Se  deberá  utilizar [XMLDSig]. 
- Se utilizará para firmar la clave privada de un certificado digital X509 válido no vencido. Se firma todo el documento (nodo raíz). En esta implementación no podrán añadirse nuevos datos al documento después de firmar, ni siquiera extensiones en el formato acordado, puesto que la validación fallaría. 
- Puesto que una firma digital XML es un proceso matemático por el que los datos a firmar se transforman  siguiendo  una  serie  de  reglas  y  cálculos  basados  en  una  clave  y  cuyos resultados son guardados en elementos XML y adjuntados o no a los datos primitivos del 

  proceso, en el estándar [XMLDSig22] encontramos: 

- Definición de la estructura XML en la que almacenar la firma 
- Definición del proceso de firma 
- Definición del proceso de validación de firma 
- Agrupación y aceptación de los algoritmos y procesos para la transformación en forma canónica de los datos firmados y de la firma 
- Agrupación y aceptación de los algoritmos y procesos de transformación para  la obtención de la firma 

A continuación se mencionan el detalle de los elementos de la extensión: 

` `![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.237.png)

2

El esquema de datos XML del estándar puede encontrarse en[: http://www.w3.org/TR/xmldsig-core/ ](http://www.w3.org/TR/xmldsig-core/)

- **ds:Signature:** Es un elemento simple que contiene información de lo que se está firmando, la propia firma, las claves utilizadas para firmar. A continuación veremos sus atributos y elementos uno por uno: 

El atributo **Id** es opcional pero es muy útil para identificar la firma dentro de un documento, sobre todo cuando se trabaja con firmas múltiples. 

Por ejemplo: <ds:Signature Id="signatureKG"> 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.238.png)

1. **ds:SignedInfo:**  Este elemento puede dividirse en dos partes desde el punto  de vista conceptual: información sobre el valor de la firma e información sobre los datos a firmar. 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.239.png)

1. **ds:CanonicalizationMethod:**  Posee  un  atributo  ***Algorithm***  que indica cómo se  debe  transformar  a

   ` `forma  canónica  el  elemento  ***<ds:SignedInfo>***  antes  de realizar la firma. 

Distintos  XML  pueden  diferir  en  su  forma  de  ser  escritos  y  sin  embargo significar lo mismo. Como la firma se realiza a nivel de bytes, aunque un documento signifique lo mismo y tenga la misma información que otro, ambos pueden tener firmas diferentes si no están escritos exactamente igual. Habrá que elegir entre una de todas las formas posibles de escribir un documento XML, la forma canónica, y transformar los documentos a esta forma sin que su información y significado se vean alterados.  

A este proceso se le llama transformación en forma canónica. Habrá varias formas canónicas dependiendo del algoritmo que se utilice. Dos documentos están  en  la  misma  forma  canónica  si  los  algoritmos  utilizados  para  su obtención son equivalentes. 

2. **ds: SignatureMethod:** Especifica qué tipo de algoritmo de firma se utilizará  para  obtener  la  firma.  La  firma  se  realiza  aplicando  este algoritmo  matemático  sobre  el  elemento  ***<ds:SignedInfo>***  que, puesto que contiene los valores hash de los distintos datos que se quieren firmar –como se verá a continuación-, será diferente en cada caso. 
2. **ds:  Reference:**  Cada  elemento  Reference  incluye  el  hash  de  un objeto de datos y las transformaciones aplicadas a ese objeto para producir  dicho  hash.  El  atributo  ***URI***  (<ds:Reference URI="">)identifica al objeto de datos que se va a firmar. Éste puede ser un objeto fuera del documento en el que está la firma o bien un objeto dentro del propio documento. Si su valor es cadena vacía identifica  al  documento  completo   que   contiene   la   firma.   Por  supuesto  puede  haber   varios 

<ds:Reference> permitiendo a una misma firma [XMLDSig] cubrir múltiples objetos. 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.240.png)

**ds:Transforms:**  es opcional aunque es el elemento con más 

fuerza de <***ds:Reference***>.Si aparece, contendrá una lista   de  <***ds:Transform***> en la que cada uno de sus elementos indica un paso realizado en el procesamiento de cálculo del hash. Cada paso tiene como entrada la salida del anterior y puede incluir operaciones como  transformación  en  forma  canónica, codificación/decodificación,  transformaciones  XSL,  validación  de esquemas, etc. La salida del último <***ds***:***Transform***> es la entrada de la función de cálculo del hash. 

Al  permitir  que  se  puedan  firmar  distintas  porciones  de  un documento,  las  modificaciones  posteriores  a  la  firma  de  las porciones no incluidas no afectarán en nada a la validación de la firma. 

**ds:DigestMethod:** Define la función hash utilizada a través del 

atributo ***Algorithm***. 



**ds: DigestValue:** Es el valor hash codificado en Base64. 

2. **ds:SignatureValue:** contiene la firma codificada en Base64. La firma es el resultado de  una  serie  de  transformaciones  sobre  los  datos  binarios  del  elemento <***ds:SignedInfo***>. El elemento <***ds:SignatureValue***> contiene este valor binario de la firma codificado en Base64. 
2. **ds: KeyInfo:** Es una estructura opcional que identifica al firmante. Su  contenido suele utilizarse en procesos de verificación de firmas, de ahí la importancia de que lo que se incluya en su interior sean los elementos de: 
1. **ds:X509Data:** Contiene información del certificado firmante. 
1. **ds: KeyValue:** Contiene información de la clave pública. 

La  información  que  proporciona  <***ds:KeyInfo***>  en  todos  sus  elementos  debe corresponder al mismo certificado o clave. 

![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.241.png)

En caso de no incluir la estructura <ds:KeyInfo>, la firma no podría considerarse como  “Firma  Electrónica  Avanzada”  puesto  que  el  firmante  no  podría  ser identificado. 

**2.5  Ejemplos de casos identificados** 

1. **Factura con 4 ítems y una bonificación** 

La empresa Soporte Tecnológicos EIRL (Nombre Comercial: *“Tu Soporte”*), identificada con RUC  20100454523,  debe  emitir  la  factura  electrónica  N°  F001-4355  con  la  siguiente información: 

Fecha de Emisión               : 14 de mayo del 2017  

Adquirente o Usuario          : Servicabinas S.A.  

RUC                                    : 20587896411 

Código del Establecimiento: 0000 

Código interno generado por el software de Facturación: 0501002017051400452 Número de Orden de compra: 7852166 

Mercadería vendida: 



|**Código** |<p>**Código** </p><p>**SUNAT** </p>|<p>**Unidad de** </p><p>**Medida** </p>|**Cantidad de  unidades por item** |**Descri pción** |**Afectación  al IGV** |**Precio Unitario  por item** |
| - | - | :-: | :-: | - | :-: | :- |
|GLG199 |52161515 |Unidad |2000 |Grabadora  LG  Externo Modelo: GE20LU10 |Gravado |98\.00 |
|MVS546 |43211902 |Unidad |300 |Monitor LCD ViewSonic VG2028WM 20" |Gravado |620\.00 |
|MPC35 |43202010 |Unidad |250 |Memoria DDR-3 B1333 Kingston |Exonerad o |52\.00 |
|TMS22 |43211706 |Unidad |500 |Teclado Microsoft SideWinder X6 |Gravado |196\.00 |

Información adicional: 

- Los precios son en moneda nacional 
- Descuento de 10% por compras mayores a 1,500 grabadoras 
- Descuento de 15% por compras mayores a 250 monitores 
- Descuento del 5% sobre el total facturado por compras mayores a S/ 250,000 
- Bonificación de un 1 Web  cam Genius iSlim 310 por cada 100 TECLADO Microsoft SideWinder X6 compradas. Web cam con un valor de venta unitario de S/. 30.00 

Información Tributaria 

- Conforme el inciso b) del Art. 14° de la Ley del IGV 

*“ Art.14°…* 

*No forman parte del valor de venta, de construcción o de los ingresos por servicios, en su caso, los conceptos siguientes:* 

*….* 

*b. Los descuentos que consten en el comprobante del pago, en tanto resulten normales en el comercio y siempre que no constituyan retiro de bienes. “* 

**Cálculos:** 

**A  B  C  D  E** 

|**Cant.** |**Valor unitario por item (1)** |<p>**Valor de venta** </p><p>**bruto (2)** </p>|<p>**Descuentos** </p><p>**x item (3)** </p>|**Valor de venta por item (4)** |**IGV (5)** ||||||||
| - | :-: | - | - | :-: | - | :- | :- | :- | :- | :- | :- | :- |
|**a** |2000 |83\.05 |166,101.69 |16,610.17 |149,491.53 |26,908.47 |||||||
|**b** |300 |525\.42 |157,627.12 |23,644.07 |133,983.05 |24,116.95 |||||||
|<p>**c** </p><p>**(exonerado)** </p>|250 |52\.00 |13,000.00 ||13,000.00 |0\.00 |||||||
|**d** |500 |166\.10 |83,050.85 ||83,050.85 |14,949.15 |||||||
|**g** |**Totales** ||**419,779.66** |**40,254.24** |**379,525.42** |**65,974.58** |||||||



|**i** |**Descuento Global 5% (379,525.42)** |**18,976.27** |
| - | - | - |



Factura Electrónica  ~ 85 ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

6) Total valor de venta bruto 
6) Total de descuentos 
6) Total Valor de venta Operaciones Gravadas 
6) Total Valor de venta Operaciones Exoneradas 
6) Sumatoria IGV 

419,779.66

59,230.51 

348,199.15 12,350.00 

62,675.85 

Factura Electrónica  ~  ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]
|**(11)** |Importe Total de la Venta |423,225.00 |
| - | - | - |



1) Precio unitario / 1.18 
1) Valor unitario por item \* cantidad 
1) B(valor vta bruto)\*Descuento x ítem 
1) B (monto valor vta brto) –C (monto descto ítem) 
1) IGV = Valor venta x item\*0.18 
1) Total valor de venta bruto (B) 
1) C (Descuentos x item) + Descuento Global 
1) Total de los ítems gravados (Da+Db+Dd) – 5% dscto global 
1) Total ítems exón(Dc) –  5% dscto global 
1) Total V.Vta.Oper.Gravadas \* 18% 
9) [(6)+(7)+(8)] 
9) suma descuento global(Di)+desctos línea (Cg) 

BONIFICACION 1 WEB CAM, con valor referencial unitario S/.30 (Código WCG01, Código SUNAT: 45121520)

REQUISITO  CASO 1 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.242.png)

Fecha de emision  14/05/2017 



|Firma Digital (Firma electrónica) ||||||
| - | :- | :- | :- | :- | :- |
|||||||
|Apellidos y nombres o denominación o ||||||
|razón social ||||||
|Nombre Comercial ||||||
|||||||
|Número de RUC ||||||
|||||||
|Tipo de document ||||||
|||||||
|Numeración, conformada por serie y ||||||
|número correlativo ||||||
|Tipo y número de documento de identidad ||||||
|del adquirente o usuario ||||||
|Apellidos y nombres o denominación o ||||||
|razón social del adquirente o usuario ||||||
|Número de orden del Ítem ||||||
|||||||
|Unidad de medida por ítem ||||||
|||||||
|Cantidad de unidades por item ||||||
|||||||
|Código de producto ||||||
|||||||
|Descripción  detallada  del  bien  vendido  o ||||||
|cedido en uso, descripción o tipo de servicio ||||||
|prestado por ítem ||||||
|Soporte Tecnológicos EIRL ||||||
|*Tu Soporte* ||||||
|20100454523 ||||||
|01 ||||||
|F001-4355 ||||||
|20587896411 ||||||
|Servicabinas S.A. ||||||
||2 |3 |4 |5 ||
|NIU |NIU |NIU |NIU |NIU ||
|2000 |300 |250 |500 |1 ||
|GLG199 |MVS546 |MPC35 |TMS22 |WCG01 ||
|Grabadora LG Externo Modelo: GE20LU10 |Monitor LCD ViewSonic VG2028WM 20" |Memoria DDR-3 B1333 Kingston |Teclado Microsoft SideWinder X6 |Web cam Genius iSlim 310 ||
|Precio de venta unitario por item  98.00 |620\.00 |52\.00 |196\.00 |0\.00 ||
|Afectación al IGV por ítem  10 |10 |20 |10 |31 ||
|IGV del ítem  26,908.47 |24,116.95 |0\.00 |14,949.15 |0\.00 ||
|Sistema de ISC por ítem ||||||
Total valor de venta - operaciones gravadas  348,199.15 

Total valor de venta - operaciones inafectas 



|Total  valor  de  venta  -  operaciones  12,350.00 <br>exoneradas |||||
| :- | :- | :- | :- | :- |
|Total valor de venta - operaciones gratuitas  30.00 |||||
|Sumatoria IGV  62,675.85 |||||
|Total descuentos  59,230.51 |||||
|Importe total de la venta, de la cesión  en  423,225.00 <br>uso o del servicio prestado |||||
|<p>Leyenda (Monto expresado en letras)  CUATROCIENTOS  VEINTITRES  MIL  DOSCIENTOS  VEINTICINCO  Y </p><p>00/100 </p>|||||
|Valor unitario por ítem  83.05 |525\.42 |52\.00 |166\.10 |0\.00 |
|Valor referencial unitario por ítem en operaciones no onerosas ||||30\.00 |
|Valor de venta por item  149,491.53 |133,983.05 |13,000.00 |83,050.85 |0\.00 |
|Versión del UBL  2.1 |||||
|Versión de la estructura del documento  2.0 |||||
|Tipo de moneda en la cual se emite la  PEN <br>factura electrónica |||||
|Tasa de IGV  18% |||||

***<?xml version="1.0" encoding="ISO-8859-1" standalone="no"?> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.243.png)***

<Invoice xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2" xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateCompon ents-2" xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents -2" 

xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionCompon ents-2" xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2" xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchem aModule:2" 

xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"> 

<ext:UBLExtensions> 

<ext:UBLExtension> 

<ext:ExtensionContent> 

<ds:Signature Id="SignatureSP"> 

<ds:SignedInfo> 

<ds:CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xmlc14n- 20010315"/> 

<ds:SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsasha1"/> <ds:Reference URI=""> 

<ds:Transforms> 

<ds:Transform Algorithm="http://www.w3.org/2000/09/xmldsig#envelopedsignature"/> </ds:Transforms> 

<ds:DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/> <ds:DigestValue>ryg5Vl+6zuSrAlgSQUYr WeaSQjk=</ds:DigestValue> </ds:Reference> 

</ds:SignedInfo> 

<ds:SignatureValue>SOiGQpmVz7hBg GjIOQNlcwyHkQLC4S7R2zBuNnOUj4KjZQb3//xNPJMRB67m8x1mpQE6pffiH85v MzYLJ9nt7MLLZXOfP+rPGfkJBmNbYxaGLj9v3qZWyyEzHFGKS+8OfVSgMsHNwZ3IqfuICzc/xo8L 7sFj+aT16IHf5TYffb0=</ds:SignatureValue> 

<ds:KeyInfo> 

<ds:X509Data> 

<ds:X509SubjectName>1.2 .840.113549.1.9.1=#161a4253554c434140534f55544845524e504552552e434f4d2e5045,C N=Juan 

Robles,OU=20100454523,O=SOPORTE TECNOLOGICOS EIRL,L=LIMA,ST=LIMA, C=PE</ds:X509SubjectName> 

<ds:X509Certificate>MIIESTCCAzGgAwIBAgIKWOC RzgAAAAAAIjANBgkqhkiG9w0BAQUFADAnMRUwEwYKCZImiZPyLGQB GRYFU1VOQVQxDjAMBgNVBAMTBVNVTkFUMB4XDTEwMTIyODE5NTExMFoXDTExMTIyODIwMDExMFow gZUxCzAJBgNVBAYTAlBFMQ0wCwYDVQQIEwRMSU1BMQ0wCwYDVQQHEwRMSU1BMREwDwYDVQQKEwhT T1VUSEVSTjEUMBIGA1UECxMLMjAxMDAxNDc1MTQxFDASBgNVBAMTC0JvcmlzIFN1bGNhMSkwJwYJ Q2VydEVucm9sbC9wY2IyMjZfU1VOQVQuY3J0MDcGCCsGAQUFBzAChitmaWxlOi8vXFxwY2IyMjZc Q2VydEVucm9sbFxwY2IyMjZfU1VOQVQuY3J0MA0GCSqGSIb3DQEBBQUAA4IBAQBI6wJ/QmRpz3C3 rorBflOvA9DOa3GNiiB7rtPIjF4mPmtgfo2pK9gvnxmV2pST3ovfu0nbG2kpjzzaaelRjEodHvkc M3abGsOE53wfxqQF5uf/jkzZA9hbLHtE1aLKBD0Mhzc6cvI072alnE6QU3RZ16ie9CYsHmMrs+sP HMy8DJU5YrdnqHdSn2D3nhKBi4QfT/WURPOuo6DF4iWgrCyMf3eJgmGKSUN3At5fK4HSpfyURT0k boaJKNBgQwy0HhGh5BLM7DsTi/KwfdUYkoFgrY71Pm23+ra+xTow1Vk9gj5NqrlpMY5gAVQXEIo1 ++GxDtaK/5EiVKSqzJ6geIfz</ds:X509Certificate> 

</ds:X509Data> 

</ds:KeyInfo> 

</ds:Signature> 

</ext:ExtensionContent> 

</ext:UBLExtension> 

</ext:UBLExtensions>

Factura Electrónica  ~ 88 ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

<cbc:UBLVersionID>2.1</cbc:UBLVersionID> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.244.png)<cbc:CustomizationID>2.0</cbc:CustomizationID> 

<cbc:ProfileID schemeName="SUNAT:Identificador de Tipo de Operación" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17">0101</cbc:Prof ileID> 

<cbc:ID>F001-4355</cbc:ID> 

<cbc:IssueDate>2017-05-14</cbc:IssueDate> <cbc:IssueTime>13:25:51</cbc:IssueTime> 

<cbc:InvoiceTypeCode listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de Tipo de Documento" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">01</cbc:InvoiceT ypeCode> 

<cbc:Note languageLocaleID="1000">CUATROCIENTOS VEINTITRES MIL DOSCIENTOS VEINTICINCO Y 00/100</cbc:Note> 

<cbc:Note languageLocaleID="3000">0501002017051400452</cbc:Note> <cbc:DocumentCurrencyCode listID="ISO 4217 Alpha" listName="Currency" listAgencyName=" United Nations Economic Commission for Europe">PEN</cbc:DocumentCurrencyCode> <cbc:LineCountNumeric>5</cbc:LineCountNumeric> 

<cac:OrderReference> 

<cbc:ID>7852166</cbc:ID> 

</cac:OrderReference> 

<cac:Signature> 

<cbc:ID>IDSignSP</cbc:ID> 

<cac:SignatoryParty> 

<cac:PartyIdentification> 

<cbc:ID>20100454523</cbc:ID> 

</cac:PartyIdentification> 

<cac:PartyName> 

<cbc:Name>SOPORTE TECNOLOGICO EIRL</cbc:Name> 

</cac:PartyName> 

</cac:SignatoryParty> 

<cac:DigitalSignatureAttachment> 

<cac:ExternalReference> 

<cbc:URI>#SignatureSP</cbc:URI> 

</cac:ExternalReference> 

</cac:DigitalSignatureAttachment> 

</cac:Signature> 

<cac:AccountingSupplierParty> 

<cac:Party> 

<cac:PartyName> 

<cbc:Name>Tu Soporte</cbc:Name> 

</cac:PartyName> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName> 

*<![CDATA[Soporte Tecnológicos EIRL]]>*</cbc:RegistrationName> 

<CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20100454523</C ompanyID> 

<cac:RegistrationAddress> 

<cbc:AddressTypeCode>0000</cbc:AddressTypeCode> 

</cac:RegistrationAddress> 

<cac:TaxScheme> 

<cbc:ID>-</cbc:ID> 

</cac:TaxScheme> 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingSupplierParty> 

<cac:AccountingCustomerParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.245.png)

<cac:Party> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName>SERVICABINAS S.A.</cbc:RegistrationName> 

<CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20587896411</C ompanyID> 

<cac:TaxScheme> 

<cbc:ID>-</cbc:ID> 

</cac:TaxScheme> 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingCustomerParty> 

<cac:AllowanceCharge> 

<cbc:ChargeIndicator>False</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.05</cbc:MultiplierFactorNumeric> <cbc:Amount currencyID="PEN">18976.27</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">379525.42</cbc:BaseAmount> </cac:AllowanceCharge> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">62675.85</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">348199.15</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">62675.85</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">1000</cbc:ID> <cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">12350.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">E</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">9997</cbc:ID> <cbc:Name>EXONERADO</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">30.00</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">O</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">9998</cbc:ID> <cbc:Name>INAFECTO</cbc:Name> 

<cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:LegalMonetaryTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.246.png)

<cbc:LineExtensionAmount currencyID="PEN">419779.66</cbc:LineExtensionAmount> <cbc:TaxInclusiveAmount currencyID="PEN">423225.00</cbc:TaxInclusiveAmount> <cbc:AllowanceTotalAmount currencyID="PEN">59230.51</cbc:AllowanceTotalAmount> <cbc:PayableAmount currencyID="PEN">423225.00</cbc:PayableAmount> </cac:LegalMonetaryTotal>

<cac:InvoiceLine> 

<cbc:ID>1</cbc:ID> 

<cbc:InvoicedQuantity unitCode="NIU" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName=" 

Europe">2000</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">149491.53</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">98.00</cbc:PriceAmount> 

<cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" 

listAgencyName= "PE:SUNAT" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:AllowanceCharge> 

<cbc:ChargeIndicator>false</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.10</cbc:MultiplierFactorNumeric> 

<cbc:Amount currencyID="PEN">16610.17</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">166101.69</cbc:BaseAmount> </cac:AllowanceCharge> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">26908.47</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">149491.53</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">26908.47</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo 

de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionRe asonCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">1000</cbc:ID> <cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> 

<cbc:Description>Grabadora LG Externo Modelo: GE20LU10</cbc:Description> <cac:SellersItemIdentification> 

<cbc:ID>GLG199</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">52161515</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">83.05</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine>

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.247.png)

<cbc:ID>2</cbc:ID> 

<cbc:InvoicedQuantity unitCode="NIU" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName="United Nations Economic Commission for Europe">300</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">133983.05</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">620.00</cbc:PriceAmount> <cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" listAgencyName="PE:SUNAT" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceType Code> 

</cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:AllowanceCharge> 

<cbc:ChargeIndicator>false</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.15</cbc:MultiplierFactorNumeric> 

<cbc:Amount currencyID="PEN">23644.07</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">157627.12</cbc:BaseAmount> </cac:AllowanceCharge> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">24116.95</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">133983.05</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">24116.95</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExempt ionReasonCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">1000</cbc:ID> 

<cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> 

<cbc:Description>Monitor LCD ViewSonic VG2028WM 20</cbc:Description> <cac:SellersItemIdentification> 

<cbc:ID>MVS546</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">43211902</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">525.42</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine> 

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.248.png)

<cbc:ID>3</cbc:ID> 

<cbc:InvoicedQuantity unitCode="NIU" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName="United Nations Economic Commission for Europe">250</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">13000.00</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">52.00</cbc:PriceAmount> 

<cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" listAgencyName="PE:SUNAT" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceTypeC ode> 

</cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">0.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">13000.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">E</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">20</cbc:TaxExempti onReasonCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">9997</cbc:ID> <cbc:Name>EXONERADO</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> 

<cbc:Description>Memoria DDR-3 B1333 Kingston</cbc:Description> <cac:SellersItemIdentification> 

<cbc:ID>MPC35</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">43202010</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">52.00</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine>

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.249.png)

<cbc:ID>4</cbc:ID> 

<cbc:InvoicedQuantity unitCode="NIU" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName="United Nations Economic Commission for Europe">500</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">83050.85</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">196.00</cbc:PriceAmount> <cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" listAgencyName="PE:SUNAT" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceTyp eCode> 

</cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">14949.15</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">83050.85</cbc:TaxableAmount> <cbc:TaxAmount currencyID="PEN">14949.15</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemp tionReasonCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">1000</cbc:ID> 

<cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> 

<cbc:Description>Teclado Microsoft SideWinder X6</cbc:Description> <cac:SellersItemIdentification> 

<cbc:ID>TMS22</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">43211706</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">166.10</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine>

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.250.png)

<cbc:ID>5</cbc:ID> 

<cbc:InvoicedQuantity unitCode="NIU" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName="United Nations Economic Commission for Europe">1</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">0.00</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">30.00</cbc:PriceAmount> <cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" listAgencyName="PE:SUNAT" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">02</cbc:PriceTyp eCode> 

</cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">0.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">O</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">31</cbc:TaxExemp tionReasonCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">9998</cbc:ID> 

<cbc:Name>INAFECTO</cbc:Name> 

<cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> 

<cbc:Description>Web cam Genius iSlim 310VVU</cbc:Description> <cac:SellersItemIdentification> 

<cbc:ID>WCG01</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">45121520</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">0.00</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine> 

</Invoice>

2. **Factura con 2 ítems e ISC** 

La  empresa  Mayorista  CFF  S.  A.-  Distribuidora  San  Camilo,  identificada  con  RUC 20200464529, emite la factura electrónica N° F001-697 con la siguiente información: 

Fecha de Emisión             : 20 de enero del 2017  

Adquirente o Usuario              : Bodega Gemi S.A.  

RUC             : 20546687668 

Código del Establecimiento   : 0000 

Código interno generado por el software de Facturación: 0501002017012000125 Número de Orden de compra: 4574125 

Mercadería vendida: 



|**Código** |**Código SUNAT** |**Unidad de Medida** |**Cantidad** |**Descripción** |**Afectación al IGV** |<p>**Sistema** </p><p>**ISC** </p>|**Precio Unitario** |
| - | - | :-: | - | - | :-: | - | - |
|GLG199 |50202201 |Cajas |2000 |Cerveza “Clásica” x 12 bot. 620 ml. |Gravado |03 |38\.00 |
|MVS546 |50202310 |Cajas |300 |Agua mineral sin gas “San Blas” x 12 bot. 400 ml. |Gravado |01 |20\.00 |

Información adicional: 

- Los precios son en moneda nacional. 
- Descuento de 20% por compras mayores a 500 cajas de cerveza. 
- Descuento de 5% por compras mayores a 250 cajas de agua mineral en cualquier presentación y/o marca. 
- Entrega  de  100  vasos  descartables  con  el  logo  de  la  compañía  de  cerveza. Campaña “Mundial 2014”. Código: PROM23 
- Tasa ISC en sistema de precios de venta al público: **27.8%** de precio de venta sugerido. Precio sugerido: S/. 37. 
- Tasa ISC en sistema al valor para el agua: **17%**. 
- Los bienes fueron trasladados mediante guía de remisión remitente N° 054-6554. 
- Operación Sujeta a percepción; Tasa 2% sobre el precio de venta. Pago al contado 

  por parte del cliente. 

Cálculos: 

**A  B  C  D  E  F  G** 

||**Cant.** |**Valor unitario por item (1)** |<p>**Valor del ISC x** </p><p>**unidad (2)** </p>|**Valor de venta Bruto (3)** |<p>**Descuentos** </p><p>**x item (4)** </p>|**Valor de venta por ítem (5)** |**ISC (6)** |**IGV (7)** |
| :- | - | :-: | - | :-: | - | :-: | - | - |
|<p>a </p><p>(cerveza) </p>|2000 |21\.92 |10\.29 |43,834.78 |8,766.96 |35,067.82 |20,572.00 |10,015.17 |
|b (agua) |300 |14\.49 |2\.46 |4,345.94 |217\.30 |4,128.64 |701\.87 |869\.49 |
|c |**Totales** |||**48,180.72** |**8,984.25** |**39,196.46** |**21,273.87** |**10,884.66**|



8) Valor de venta Bruto  48,180.72 
8) Total de descuentos  8,984.25 
8) Valor de venta Operaciones Gravadas  39,196.46 
8) Sumatoria ISC  21,273.87 
8) Sumatoria IGV  10,884.66 

|(13) ||Importe Total de la Ve|nta |71,354.99 |
| - | :- | - | - | - |



14) Importe de Percepción  1,427.10  
14) Importe Total Cobrado  72,782.09 

    (1) Valor unitario x ítem cerveza (Aa)= S/.38 (precio unitario cerveza)/1.18 – ISC cerveza (Ba)

1) Valor unit.x ítem agua (Ab) = [S/20 (precio unitario) /1.18]/1.17 
1) Ba: S/37 (precio sugerido) \* 27.8%(tasa ISC) 
2) Bb: S/14.49 (valor unitario) \* 17%(tasa ISC) 
2) Valor unitario\* cantidad 
2) Valor venta \* descuento 
2) C-D 
2) Valor ISC unidad \* cantidad 
2) [Valor Vta.Item(E) +ISC (F) ]\*0.18 
2) C 
2) D 
2) E 
2) F 
2) G 
2) [(10)+(11)+(12)] 
2) Percepción 2% (71,354.99) 
2) [(13)+(14)] 

BONIFICACION: 100 vasos descartables. Valor venta unitario S/.0.50 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.251.png)

Total operaciones grauitas = 100\*S/.50= S/50 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.252.png)

Nota: para el ejemplo, S/0.50 es el valor venta unitario que hubiese correspondido a  los vasos, si hubiesen sido vendidos (operación onerosa, Código SUNAT: 52151504) 

REQUISITO  CASO 2 ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.253.png)![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.254.png)

Fecha de emission  20/01/2017 

|Firma Digital (Firma electrónica) |
| - |
||
|Apellidos y nombres o denominación o |
|razón social |
|Nombre Comercial |
||
|Número de RUC |
||
|Tipo de documento |
||
|Numeración, conformada por serie y |
|número correlativo |
|Tipo y número de documento de identidad |
|del adquirente o usuario |
|Apellidos y nombres o denominación o |
|razón social del adquirente o usuario |
|Número de orden del Ítem |
||
|Unidad de medida por ítem |
||
|Cantidad de unidades por item |
||
|Código de producto |

Mayorista CFF S. A. 

Distribuidora San Camilo 

20200464529 

01 

F001-697 

20546687668 

Bodega Gemi S.A. 

1  2  3 

BX  BX  NIU 

2000  300  100 

GLG199  MVS546  PROM23 

Factura Electrónica ![ref2]

~ 98 ~ 
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

Descripción detallada del bien vendido o cedido  en  uso,  descripción  o  tipo  de servicio prestado por ítem 

Precio de venta unitario por item Afectación al IGV por ítem 

IGV del ítem 

Cerveza “Clásica” x 12 bot. 620 ml. 

38\.00 

10 

10,015.17 

Agua mineral sin gas “San Blas” x 12 bot. 400 ml. 

20\.00 

10 

869\.49 

Transferencia Gratuita: Vasos descartables con el logo de la compañía de cerveza.  

0\.00 

36 

0\.00 

Factura Electrónica ![ref2]

~  ~ 
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]
|Sistema de ISC por ítem  03  01 |
| - |
|ISC del Item  20,572.00  701.87 |
|<p>Total  valor  de  venta  -   operaciones </p><p>gravadas  39,196.46 </p>|
|Total valor de venta - operaciones gratuitas  50 |
|Base de Cálculo del IGV  60,470.33 |

Sumatoria IGV  10,884.66 

Base de Cálculo del ISC  78,128.64 

Sumatoria ISC  21,273.87 

Total de Impuestos  32,158.53 

Total descuentos  8,984.25 

Importe total de la venta, de la cesión en 

71,354.99 

uso o del servicio prestado 

Importe de la percepción en moneda 

1,427.10 

nacional 

Monto total cobrado expresado en moneda 

72,782.09 

nacional 

Tipo de la guía de remisión relacionada con 

09 

la operación que se factura 

Número de la guía de remisión relacionada 

con la operación que se factura  054-6554 

Tipo y número de otro documento y  código

relacionado con la operación que se factura 

Leyenda (Monto en Letras)  SETENTA Y UN MIL TRESCIENTOS CINCUENTICUATRO Y 99/100 Leyenda  COMPROBANTE DE PERCEPCIÓN 

Valor unitario por ítem  21.92  14.49  0.00 Valor  referencial  unitario  por  ítem  en  0.50 

operaciones no onerosas 

Valor de venta por ítem  35,067.82  4,128.64  0.00 

Versión del UBL  2.1 

Versión de la estructura del documento  2.0 

Tipo de moneda en la cual se emite la  PEN 

factura electrónica 

Tasa de IGV  18% 

***<?xml***  ***version="1.0" encoding="ISO-8859-1" standalone="no"?> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.255.png)***

<Invoi ce xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2" xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2" xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2" xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"> 

<ext:UBLExtensions> 

<ext:UBLExtension> 

<ext:ExtensionContent> 

<ds:Signature Id="SignatureCF"> 

<ds:SignedInfo> 

<ds:CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xmlc14n- 20010315"/> 

<ds:SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsasha1"/> <ds:Reference URI=""> 

<ds:Transforms> 

<ds:Transform Algorithm="http://www.w3.org/2000/09/xmldsig#envelopedsignature"/> </ds:Transforms> 

<ds:DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/> <ds:DigestValue>ZYhfRQAjGQ4oOf0a+ryuqbuG6bc=</ds:DigestValue> 

</ds:Reference> 

</ds:SignedInfo> 

<ds:SignatureValue> dAsw7ytlJGtxSIWPeVSuN8M8AwjoHVjY3cy9N/3hyTH/Pod7km+WRx52aWEBrGaMc1W4i5IQZFZs ToqoUHXueC3k9SBt94xPEhT2331V8qQsJqCMdW0U5NpZnyoebL8MPISLF12z869TnDlpFrbDuqY+ rPqSueQHyTlhtkVWDVI=</ds:SignatureValue> 

<ds:KeyInfo> 

<ds:X509Data> 

<ds:X509SubjectName> 1.2.840.113549.1.9.1=#161a4253554c434140534f55544845524e504552552e434f4d2e5045, CN=Juan Robles,OU=20200464529,O=MAYORISTAS CFF SA,L=LIMA,ST=LIMA, C=PE</ds:X509SubjectName> 

<ds:X509Certificate> MIIESTCCAzGgAwIBAgIKWOCRzgAAAAAAIjANBgkqhkiG9w0BAQUFADAnMRUwEwYKCZImiZPyLGQB GRYFU1VOQVQxDjAMBgNVBAMTBVNVTkFUMB4XDTEwMTIyODE5NTExMFoXDTExMTIyODIwMDExMFow gZUxCzAJBgNVBAYTAlBFMQ0wCwYDVQQIEwRMSU1BMQ0wCwYDVQQHEwRMSU1BMREwDwYDVQQKEwhT T1VUSEVSTjEUMBIGA1UECxMLMjAxMDAxNDc1MTQxFDASBgNVBAMTC0JvcmlzIFN1bGNhMSkwJwYJ KoZIhvcNAQkBFhpCU1VMQ0FAU09VVEhFUk5QRVJVLkNPTS5QRTCBnzANBgkqhkiG9w0BAQEFAAOB jQAwgYkCgYEAtRtcpfBLzyajuEmYt4mVH8EE02KQiETsdKStUThVYM7g3Lkx5zq3SH5nLH00EKGC tota6RR+V40sgIbnh+Nfs1SOQcAohNwRfWhho7sKNZFR971rFxj4cTKMEvpt8Dr98UYFkJhph6Wn sniGM2tJDq9KJ52UXrlScMfBityx0AsCAwEAAaOCAYowggGGMA4GA1UdDwEB/wQEAwIE8DBEBgkq hkiG9w0BCQ8ENzA1MA4GCCqGSIb3DQMCAgIAgDAOBggqhkiG9w0DBAICAIAwBwYFKw4DAgcwCgYI KoZIhvcNAwcwHQYDVR0OBBYEFG/m6twbiRNzRINavjq+U0j/sZECMBMGA1UdJQQMMAoGCCsGAQUF BwMCMB8GA1UdIwQYMBaAFN9kHQDqWONmozw3xdNSIMFW2t+7MFkGA1UdHwRSMFAwTqBMoEqGImh0 dHA6Ly9wY2IyMjYvQ2VydEVucm9sbC9TVU5BVC5jcmyGJGZpbGU6Ly9cXHBjYjIyNlxDZXJ0RW5y b2xsXFNVTkFULmNybDB+BggrBgEFBQcBAQRyMHAwNQYIKwYBBQUHMAKGKWh0dHA6Ly9wY2IyMjYv Q2VydEVucm9sbC9wY2IyMjZfU1VOQVQuY3J0MDcGCCsGAQUFBzAChitmaWxlOi8vXFxwY2IyMjZc Q2VydEVucm9sbFxwY2IyMjZfU1VOQVQuY3J0MA0GCSqGSIb3DQEBBQUAA4IBAQBI6wJ/QmRpz3C3 rorBflOvA9DOa3GNiiB7rtPIjF4mPmtgfo2pK9gvnxmV2pST3ovfu0nbG2kpjzzaaelRjEodHvkc M3abGsOE53wfxqQF5uf/jkzZA9hbLHtE1aLKBD0Mhzc6cvI072alnE6QU3RZ16ie9CYsHmMrs+sP HMy8DJU5YrdnqHdSn2D3nhKBi4QfT/WURPOuo6DF4iWgrCyMf3eJgmGKSUN3At5fK4HSpfyURT0k boaJKNBgQwy0HhGh5BLM7DsTi/KwfdUYkoFgrY71Pm23+ra+xTow1Vk9gj5NqrlpMY5gAVQXEIo1 ++GxDtaK/5EiVKSqzJ6geIfz</ds:X509Certificate> 

</ds:X509Data> 

</ds:KeyInfo> 

</ds:Signature> 

</ext:ExtensionContent> 

</ext:UBLExtension> 

</ext:UBLExtensions>

<cbc:U BLVersionID>2.1</cbc:UBLVersionID> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.256.png)<cbc:CustomizationID>2.0</cbc:CustomizationID> 

<cbc:ProfileID schemeName="SUNAT:Identificador de Tipo de Operación" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17">0101</cbc:ProfileID> <cbc:ID>F001-697</cbc:ID> 

<cbc:IssueDate>2017-05-14</cbc:IssueDate> 

<cbc:IssueTime>15:42:20</cbc:IssueTime> 

<cbc:InvoiceTypeCode listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de Tipo de Documento" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">01</cbc:InvoiceTypeCode> <cbc:Note languageLocaleID="1000">SETENTA Y UN MIL TRESCIENTOS CINCUENTICUATRO Y 99/100</cbc:Note> 

<cbc:Note languageLocaleID="2000">COMPROBANTE DE PERCEPCION</cbc:Note> 

<cbc:Note languageLocaleID="3000">0501002017012000125</cbc:Note> <cbc:DocumentCurrencyCode listID="ISO 4217 Alpha" listName="Currency" listAgencyName="United Nations Economic Commission for Europe">PEN</cbc:DocumentCurrencyCode> <cbc:LineCountNumeric>3</cbc:LineCountNumeric> 

<cac:OrderReference> 

<cbc:ID>4574125</cbc:ID> 

</cac:OrderReference> 

<cac:DespatchDocumentReference> 

<cbc:ID>054-6554</cbc:ID> 

<cbc:DocumentTypeCode listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de Tipo de Documento" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">09</cbc:DocumentTypeCode> </cac:DespatchDocumentReference> 

<cac:Signature> 

<cbc:ID>IDSignCF</cbc:ID> 

<cac:SignatoryParty> 

<cac:PartyIdentification> 

<cbc:ID>20200464529</cbc:ID> 

</cac:PartyIdentification> 

<cac:PartyName> 

<cbc:Name>MAYORISTA CFF S.A.</cbc:Name> 

</cac:PartyName> 

</cac:SignatoryParty> 

<cac:DigitalSignatureAttachment> 

<cac:ExternalReference> 

<cbc:URI>#SignatureCF</cbc:URI> 

</cac:ExternalReference> 

</cac:DigitalSignatureAttachment> 

</cac:Signature> 

<cac:AccountingSupplierParty> 

<cac:Party> 

<cac:PartyName> 

<cbc:Name>Distribuidora San Camilo</cbc:Name> 

</cac:PartyName> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName> 

*<![CDATA[Mayorista CFF S. A.]]>*</cbc:RegistrationName> 

<CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de 

Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20200464529</CompanyID> <cac:RegistrationAddress> 

<cbc:AddressTypeCode>0000</cbc:AddressTypeCode> 

</cac:RegistrationAddress> 

<cac:TaxScheme> 

<cbc:ID>-</cbc:ID> 

</cac:TaxScheme>  

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingSupplierParty>

Factura Electrónica ![ref2]

~ 101 ~ 
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

<cac:AccountingCustomerParty> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.257.png)

<cac:Party> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName>Bodega Gemi S.A.</cbc:RegistrationName> 

<CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de 

Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20546687668</CompanyID> <cac:TaxScheme> 

<cbc:ID>-</cbc:ID> 

</cac:TaxScheme> 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingCustomerParty> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">32158.53</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">32158.53</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">60470.33</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">1000</cbc:ID> <cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">78128.64</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">21273.87</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">2000</cbc:ID> <cbc:Name>ISC</cbc:Name> 

<cbc:TaxTypeCode>EXC</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">50.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">O</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">9998</cbc:ID> <cbc:Name>INAFECTO</cbc:Name> 

<cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:LegalMonetaryTotal> 

<cbc:LineExtensionAmount currencyID="PEN">39196.46</cbc:LineExtensionAmount> <cbc:TaxInclusiveAmount currencyID="PEN">71354.99</cbc:TaxInclusiveAmount> <cbc:AllowanceTotalAmount currencyID="PEN">8984.25</cbc:AllowanceTotalAmount> <cbc:ChargeTotalAmount currencyID="PEN">1427.10</cbc:ChargeTotalAmount> <cbc:PayableAmount currencyID="PEN">72782.09</cbc:PayableAmount> </cac:LegalMonetaryTotal>

<cac:InvoiceLine> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.258.png)

<cbc:ID>1</cbc:ID> 

<cbc:InvoicedQuantity unitCode="BX" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName="United Nations Economic Commission for Europe">2000</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">43834.78</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">38.00</cbc:PriceAmount> 

<cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" 

listAgencyName= "PE:SUNAT" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:AllowanceCharge> 

<cbc:ChargeIndicator>false</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.20</cbc:MultiplierFactorNumeric> 

<cbc:Amount currencyID="PEN">8766.96</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">43834.78</cbc:BaseAmount> 

</cac:AllowanceCharge> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">30587.17</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">55639.82</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">10015.17</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo 

de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionReas onCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">1000</cbc:ID> <cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">74000.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">20572.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cbc:Percent>0.278</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo 

de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionReas onCode> 

<cbc:TierRange>03</cbc:TierRange> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">2000</cbc:ID> <cbc:Name>ISC</cbc:Name> 

<cbc:TaxTypeCode>EXC</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.259.png)

<cbc:Description>Cerveza “Clásica” x 12 bot. 620 ml.</cbc:Description> <cac:SellersItemIdentification> 

<cbc:ID>GLG199</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">50202201</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">21.92</cbc:PriceAmount> 

</cac:Price> 

<cac:InvoiceLine> 

<cbc:ID>2</cbc:ID> 

<cbc:InvoicedQuantity unitCode="BX" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName="United Nations Economic Commission for Europe">300</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">4345.94</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">20.00</cbc:PriceAmount> 

<cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" 

listAgencyName= "PE:SUNAT" listURI "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">01</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:AllowanceCharge> 

<cbc:ChargeIndicator>false</cbc:ChargeIndicator> <cbc:AllowanceChargeReasonCode>00</cbc:AllowanceChargeReasonCode> <cbc:MultiplierFactorNumeric>0.05</cbc:MultiplierFactorNumeric> 

<cbc:Amount currencyID="PEN">217.30</cbc:Amount> 

<cbc:BaseAmount currencyID="PEN">4345.94</cbc:BaseAmount> </cac:AllowanceCharge> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">1571.36</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">4830.51</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">869.49</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo 

de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemptionR

easonCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">1000</cbc:ID> <cbc:Name>IGV</cbc:Name> 

<cbc:TaxTypeCode>VAT</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

<cac:TaxSubtotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.260.png)

<cbc:TaxableAmount currencyID="PEN">4128.64</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">701.87</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">S</cbc:ID> <cbc:Percent>0.17</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">10</cbc:TaxExemption ReasonCode> 

<cbc:TierRange>01</cbc:TierRange> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">2000</cbc:ID> <cbc:Name>ISC</cbc:Name> 

<cbc:TaxTypeCode>EXC</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> 

<cbc:Description>Agua mineral sin gas “San Blas” x 12 bot. 400 ml.</cbc:Description> 

<cac:SellersItemIdentification> 

<cbc:ID>MVS546</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">50202310</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">14.49</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine> 

<cac:InvoiceLine> 

<cbc:ID>3</cbc:ID> 

<cbc:InvoicedQuantity unitCode="NIU" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName=" 

Europe">100</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">0.00</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">0.50</cbc:PriceAmount> 

<cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" listAgencyName= "PE:SUNAT" listURI "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">02</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">50.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">O</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.261.png)

de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">36</cbc:TaxExemptionReaso nCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">9998</cbc:ID> <cbc:Name>INAFECTO</cbc:Name> 

<cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> 

<cbc:Description>Transferencia Gratuita: Vasos descartables con el logo de la compañía de cerveza</cbc:Description> 

<cac:SellersItemIdentification> 

<cbc:ID>PROM23</cbc:ID> 

</cac:SellersItemIdentification> 

<cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" 

listName="Item Classification">52151504</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">0.00</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine> 

</Invoice> 

3. **Factura de Transferencia Gratuita** 

La empresa Soporte Tecnológicos EIRL, identificada con RUC 2010045452; de emitir la factura electrónica N° FS21-4370 con la siguiente información: 

Factura Electrónica   ~ 107 ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

Fecha de Emisión Adquirente o Usuario RUC 

Motivo 

- 20  de  junio  del  2017 
- Boticas y Bazares S.A. 
- 20889666312 
- Entrega  de  un  televisor plasma  de  42”,  marca  “RCA”;  al  ser elegido  como  ganador,  entre  todos  los  clientes,  en  el  sorteo organizado por la empresa. 

Factura Electrónica   ~  ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

Valor de venta Referencial  : S/. 1,250.00 

Código de establecimiento   : 0001 

Código interno generado por el software de Facturación: 0501002017062000451  

REQUISITO  CASO 3 

|20/06/2017 |
| - |
||
|Soporte Tecnológicos EIRL |
||
|Tu Soporte|
|20100454523 |
||
||
||
|FS21-4370 |
||
|20889666312 |
||
|Boticas y Bazares S. A. |
||
||
||
|NIU |
||
||
||
||
|52161505 |
||
||
||
||
||
||
||
||
||
|1,250.00 |
|0\.00 |
||
|0\.00 |
|TRANSFERENCIA GRATUITA |
|0\.00 |
||
|1,250.00 |
|0\.00 |
|2\.0 |
|2\.0 |
||
|PEN |

Fecha de emisión 



|||||
| :- | :- | :- | :- |
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|usuario ||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
|||||
Código de product SUNAT ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.262.png)



|<p>Televisor  plasma de 42”, marca “RCA” </p><p>Descripción detallada del bien vendido o cedido en uso, descripción </p><p>o tipo de servicio prestado por ítem </p>|
| - |
|<p>Precio de venta unitario por item </p><p>0\.00 </p>|
|<p>Afectación al IGV por ítem </p><p>35 </p>|
|<p>IGV del ítem </p><p>0\.00 </p>|
|<p>Total valor de venta - operaciones gravadas </p><p>0\.00 </p>|

Total valor de venta - operaciones gratuitas ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.263.png)

Sumatoria IGV 

Importe total de la venta, de la cesión en uso o del servicio prestado ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.264.png)

Leyenda ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.265.png)

Valor unitario por ítem 

Valor referencial unitario por ítem en operaciones no onerosas ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.266.png)

Valor de venta por item ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.267.png)

Versión del UBL ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.268.png)

Versión de la estructura del documento 

Tipo de moneda en la cual se emite la factura electrónica ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.269.png)

***<?xml***  ***version="1.0" encoding="ISO-8859-1" standalone="no"?> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.270.png)***

<Invoi ce xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2" 

xmlns: cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" xmlns:cbc="urn:oasis:names:spe cification:ubl:schema:xsd:CommonBasicComponents-2" xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2" xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2" xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"> 

<ext:UBLExtensions> 

<ext:UBLExtension> 

<ext:ExtensionContent> 

<ds:Signature Id="SignST"> 

<ds:SignedInfo> 

<ds:CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n- 20010315"/> 

<ds:SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1"/> <ds:Reference URI=""> 

<ds:Transforms> 

<ds:Transform Algorithm="http://www.w3.org/2000/09/xmldsig#envelopedsignature"/> </ds:Transforms> 

<ds:DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/> <ds:DigestValue>uy0/8Pg/62e+GIQ0ZRVRRCWmPBk=</ds:DigestValue> 

</ds:Reference> 

</ds:SignedInfo> 

<ds:SignatureValue> silqLF655RAWmwtd5llBQ2VqVa4gZus7e53ChvMBtXw+HOyR6oNPySTJKnrCZ0kRpfN3i3OgLlyC b+Xfm9OlVOrVaYv0W4NM10hKrdCfWDxnGzhOxoXbqFL+jmRlhBsEQ+R6lcg9ctn60jyDWm+LtRR7 By6xzluFqdR0C5OtaiU=</ds:SignatureValue> 

<ds:KeyInfo> 

<ds:X509Data> 

<ds:X509SubjectName> 1.2.840.113549.1.9.1=#161a4253554c434140534f55544845524e504552552e434f4d2e5045, CN=Juan Robles,OU=20889666312,O= SOPORTE TECNOLOGICO EIRL,L=LIMA,ST=LIMA, C=PE</ds:X509SubjectName> 

<ds:X509Certificate> MIIESTCCAzGgAwIBAgIKWOCRzgAAAAAAIjANBgkqhkiG9w0BAQUFADAnMRUwEwYKCZImiZPyLGQB GRYFU1VOQVQxDjAMBgNVBAMTBVNVTkFUMB4XDTEwMTIyODE5NTExMFoXDTExMTIyODIwMDExMFow gZUxCzAJBgNVBAYTAlBFMQ0wCwYDVQQIEwRMSU1BMQ0wCwYDVQQHEwRMSU1BMREwDwYDVQQKEwhT T1VUSEVSTjEUMBIGA1UECxMLMjAxMDAxNDc1MTQxFDASBgNVBAMTC0JvcmlzIFN1bGNhMSkwJwYJ KoZIhvcNAQkBFhpCU1VMQ0FAU09VVEhFUk5QRVJVLkNPTS5QRTCBnzANBgkqhkiG9w0BAQEFAAOB jQAwgYkCgYEAtRtcpfBLzyajuEmYt4mVH8EE02KQiETsdKStUThVYM7g3Lkx5zq3SH5nLH00EKGC tota6RR+V40sgIbnh+Nfs1SOQcAohNwRfWhho7sKNZFR971rFxj4cTKMEvpt8Dr98UYFkJhph6Wn sniGM2tJDq9KJ52UXrlScMfBityx0AsCAwEAAaOCAYowggGGMA4GA1UdDwEB/wQEAwIE8DBEBgkq hkiG9w0BCQ8ENzA1MA4GCCqGSIb3DQMCAgIAgDAOBggqhkiG9w0DBAICAIAwBwYFKw4DAgcwCgYI KoZIhvcNAwcwHQYDVR0OBBYEFG/m6twbiRNzRINavjq+U0j/sZECMBMGA1UdJQQMMAoGCCsGAQUF BwMCMB8GA1UdIwQYMBaAFN9kHQDqWONmozw3xdNSIMFW2t+7MFkGA1UdHwRSMFAwTqBMoEqGImh0 Q2VydEVucm9sbFxwY2IyMjZfU1VOQVQuY3J0MA0GCSqGSIb3DQEBBQUAA4IBAQBI6wJ/QmRpz3C3 HMy8DJU5YrdnqHdSn2D3nhKBi4QfT/WURPOuo6DF4iWgrCyMf3eJgmGKSUN3At5fK4HSpfyURT0k boaJKNBgQwy0HhGh5BLM7DsTi/KwfdUYkoFgrY71Pm23+ra+xTow1Vk9gj5NqrlpMY5gAVQXEIo1 ++GxDtaK/5EiVKSqzJ6geIfz</ds:X509Certificate> 

</ds:X509Data> 

</ds:KeyInfo> 

</ds:Signature> 

</ext:ExtensionContent> 

</ext:UBLExtension> 

</ext:UBLExtensions> 

<cbc:UBLVersionID>2.1</cbc:UBLVersionID> <cbc:CustomizationID>2.0</cbc:CustomizationID> 

<cbc:ProfileID schemeName="SUNAT:Identificador de Tipo de Operación" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17">0101</cbc:ProfileID> 

<cbc: ID>FS21-4370</cbc:ID> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.271.png)

<cbc: IssueDate>2017-06-20</cbc:IssueDate> 

<cbc: IssueTime>09:12:31</cbc:IssueTime> 

<cbc: InvoiceTypeCode listAgencyName="PE:SUNAT" listName="SUNAT:Identificador de Tipo de Do cumento" 

listU RI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01">01</cbc:InvoiceTypeCode> <cbc: Note languageLocaleID="1002">TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PREST ADO GRATUITAMENTE</cbc:Note> 

<cbc: Note languageLocaleID="3000">0501002017062000451</cbc:Note> 

<cbc: DocumentCurrencyCode listID="ISO 4217 Alpha" listName="Currency" 

listA gencyName=" United Nations Economic Commission for 

Europ e">PEN</cbc:DocumentCurrencyCode> 

<cbc: LineCountNumeric>1</cbc:LineCountNumeric> 

<cac: Signature> 

<cbc: ID>IDSignKG</cbc:ID> 

<cac: SignatoryParty> 

<cac: PartyIdentification> 

<cbc: ID>20100454523</cbc:ID> 

</cac :PartyIdentification> 

<cac: PartyName> 

<cbc:Name>SOPORTE TECNOLOGICO EIRL</cbc:Name> 

</cac:PartyName> 

</cac:SignatoryParty> 

<cac:DigitalSignatureAttachment> 

<cac:ExternalReference> 

<cbc:URI>#SignST</cbc:URI> 

</cac:ExternalReference> 

</cac:DigitalSignatureAttachment> 

</cac:Signature> 

<cac:AccountingSupplierParty> 

<cac:Party> 

<cac:PartyName> 

<cbc:Name>Tu Soporte</cbc:Name> 

</cac:PartyName> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName> 

*<![CDATA[Soporte Tecnológicos EIRL]]>*</cbc:RegistrationName> 

<CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de 

Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20100454523</CompanyID> <cac:RegistrationAddress> 

<cbc:AddressTypeCode>0001</cbc:AddressTypeCode> 

</cac:RegistrationAddress> 

<cac:TaxScheme> 

<cbc:ID>-</cbc:ID> 

</cac:TaxScheme> 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingSupplierParty> 

<cac:AccountingCustomerParty> 

<cac:Party> 

<cac:PartyTaxScheme> 

<cbc:RegistrationName>Boticas y Bazares S. A.</cbc:RegistrationName> 

<CompanyID schemeID="6" schemeName="SUNAT:Identificador de Documento de 

Identidad" schemeAgencyName="PE:SUNAT" schemeURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06">20889666312</CompanyID> <cac:TaxScheme> 

<cbc:ID>-</cbc:ID> 

</cac:TaxScheme> 

</cac:PartyTaxScheme> 

</cac:Party> 

</cac:AccountingCustomerParty> 

Factura Electrónica   ~ 111 ~ ![ref2]
Guía de elaboración de documentos electrónicos XML - UBL 2.1 ![ref1]

<cac: TaxTotal> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.272.png)

<cbc:TaxAmount currencyID="PE N">0.00</cbc:TaxAmount> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">1250.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">O</cbc:ID> <cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeAgencyID="6">9998</cbc:ID> <cbc:Name>INAFECTO</cbc:Name> 

<cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:LegalMonetaryTotal> 

<cbc:LineExtensionAmount currencyID="PEN">0.00</cbc:LineExtensionAmount> <cbc:TaxInclusiveAmount currencyID="PEN">0.00</cbc:TaxInclusiveAmount> <cbc:AllowanceTotalAmount currencyID="PEN">0.00</cbc:AllowanceTotalAmount> <cbc:ChargeTotalAmount currencyID="PEN">0.00</cbc:ChargeTotalAmount> <cbc:PayableAmount currencyID="PEN">0.00</cbc:PayableAmount> </cac:LegalMonetaryTotal> 

<cac:InvoiceLine> 

<cbc:ID>1</cbc:ID> 

<cbc:InvoicedQuantity unitCode="NIU" unitCodeListID="UN/ECE rec 20" unitCodeListAgencyName=" 

Europe">1</cbc:InvoicedQuantity> 

<cbc:LineExtensionAmount currencyID="PEN">0.00</cbc:LineExtensionAmount> <cac:PricingReference> 

<cac:AlternativeConditionPrice> 

<cbc:PriceAmount currencyID="PEN">1250.00</cbc:PriceAmount> 

<cbc:PriceTypeCode listName="SUNAT:Indicador de Tipo de Precio" 

listAgencyName= "PE:SUNAT" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16">02</cbc:PriceTypeCode> </cac:AlternativeConditionPrice> 

</cac:PricingReference> 

<cac:TaxTotal> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxSubtotal> 

<cbc:TaxableAmount currencyID="PEN">1250.00</cbc:TaxableAmount> 

<cbc:TaxAmount currencyID="PEN">0.00</cbc:TaxAmount> 

<cac:TaxCategory> 

<cbc:ID schemeID="UN/ECE 5305" schemeName="Tax Category Identifier" schemeAgencyName="United Nations Economic Commission for Europe">O</cbc:ID> <cbc:Percent>18.00</cbc:Percent> 

<cbc:TaxExemptionReasonCode listAgencyName="PE:SUNAT" listName="SUNAT:Codigo 

de Tipo de Afectación del IGV" listURI="urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07">35</cbc:TaxExemptionReaso

nCode> 

<cac:TaxScheme> 

<cbc:ID schemeID="UN/ECE 5153" schemeName="Tax Scheme Identifier" schemeAgencyName="United Nations Economic Commission for Europe">9998</cbc:ID> <cbc:Name>INAFECTO</cbc:Name> 

<cbc:TaxTypeCode>FRE</cbc:TaxTypeCode> 

</cac:TaxScheme> 

</cac:TaxCategory> 

</cac:TaxSubtotal> 

</cac:TaxTotal> 

<cac:Item> ![](Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.273.png)

<cbc:Description>Televisor plasma de 42", marca "RCA"</cbc:Description> <cac:CommodityClassification> 

<cbc:ItemClassificationCode listID="UNSPSC" listAgencyName="GS1 US" listName="Item Classification">52161505</cbc:ItemClassificationCode> </cac:CommodityClassification> 

</cac:Item> 

<cac:Price> 

<cbc:PriceAmount currencyID="PEN">0.00</cbc:PriceAmount> 

</cac:Price> 

</cac:InvoiceLine> 

</Invoice> 
Factura Electrónica   ~ 113 ![ref2]

[ref1]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.003.png
[ref2]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.010.png
[ref3]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.026.png
[ref4]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.027.png
[ref5]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.028.png
[ref6]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.029.png
[ref7]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.033.png
[ref8]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.050.png
[ref9]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.053.png
[ref10]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.055.png
[ref11]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.057.png
[ref12]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.058.png
[ref13]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.059.png
[ref14]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.074.png
[ref15]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.075.png
[ref16]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.076.png
[ref17]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.077.png
[ref18]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.078.png
[ref19]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.079.png
[ref20]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.081.png
[ref21]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.082.png
[ref22]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.113.png
[ref23]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.114.png
[ref24]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.119.png
[ref25]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.143.png
[ref26]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.144.png
[ref27]: Aspose.Words.2f823377-1b39-45da-8ed8-e16f778349eb.160.png
