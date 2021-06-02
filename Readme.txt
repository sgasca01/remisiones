El programa recibe parámetros

L:M163135 P:89991 preview
manual

Parámetros admitidos
P - pedido (99999) (lucmfile.certusu.cepedi). Depricada 20200403. Si existe MANUAL, se utiliza para inicializar el pedido
L - lote (M999999) (lucmfile.certusu.celote). Depricada 20200403. Si existe MANUAL, se utiliza para inicializar el lote
--A - agente (lucmfile.certusu.ceusua). Depricada 20200403
--PREVIEW - muestra el certificado en pantalla. Depricada 20200403, si es interactivo es con preview, además de las indicaciones de cerclpdf
QUIT
S - firma [AP|UV|GP] - indica quien va a firmar el certificado, por defecto Gabriel Posadas
LOGOS - indica si se incluyen o no los logos (banner), por defecto si se imprimen
I - idioma [ES|EN] - idioma del certificado, por defecto Español
--PRINT - indica si se debe enviar a la impresora en automático. Depricada 20200403. Se reemplaza por lo que indique cerclpdf
MANUAL - indica que los parámetros se deben recibir manualmente (no actua en automático con los parámetros P y L)
--PDF - indica que se debe generar el PDF del certificado. Revisa lucmfile.cerclpdf para ver si ya se tiene la ruta especificada. Depricada 20200403. Se reemplaza por lo que indicuq cerclpdf

de manera interna, se utiliza también el diccionario para almacenar valores
CL - Número de cliente
CLIENTE - Nombre del cliente
RUTA - ruta para colocar los archivos PDF
PDF - bandera que indica si se genera PDF
COPIAS - número de copias a imprimir


*casos en los que no se pone el código del articulo en el documento
*
*ModCertificadoCalidad
*
*FillCertificadoAF_EN
*FillCertificadoAF_ES
* Case "664271A", "96707A", "10618A", "11299A"
*                            ' 96707A COCKTAIL DE FRUTAS 96707A de (9145 FREXPORT, S.A. DE C.V.), (9321 SIGMA ALIMENTOS LACTEOS, S.A. DE C.V.), (9347 EMPACADORA LATINOAMERICANA, S.A. DE C.V.)
*                            ' 10618A PURAROME 2  10618A de (9121 PURATOS DE MEXICO, S.A. DE C.V.) 20170720
*                            ' 11299A PURAROME 3 11299A de (9121 PURATOS DE MEXICO, S.A. DE C.V.) 20170720
*                            .LblProducto.Text = GetMuestraName(as400.StrCampo("ftccar"), as400temp.StrCampo("arnomb"))

20180403 se agrega validación de que los artículos no estén en "noarcode", si está el nombre va sin el código. Por lo tanto, se elimina la validación anterior.
insert into lucmfile.noarcode values ('67375A','SABOR CODIGO 67375A (30684)',20180703,'08931 INDUSTRIAS KOSOKUNDAI, S.A.',1)

20181018 se elimina que los certificados salgan con el código del artículo
         también se habilita la nueva forma del certificado en español



DataDynamics.ActiveReports.ActiveReport, ActiveReports6, Version=6.2.3164.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff


Cambios
20190501 Se actualió a ActiveReports 12

20190618 Solicitud 11668 - Cambio de SAGARPA a SADER en certificados de zootecnia, así como el número de clave

20200205 Solicitud 12622 - Generación en automático de certificados
\\192.168.52.5\Certificados PDF\RICOLINO- Barcel
\\192.168.52.5\Certificados PDF\Certificados Sigma Alimentos PDF
\\192.168.52.5\Certificados PDF\CERTIFICADOS MUNDO DULCE
\\192.168.52.5\Certificados PDF\Certificados BAFAR
\\192.168.52.5\Certificados PDF\Certificados American BEEF

\\192.168.52.5\Certificados PDF\Certificados Sigma Alimentos PDF\No. PEDIDO 2020\02462


CETIFICADOS
-- busqueda de facturas por medio del pedido
select clcodi,clnomb,sfnumf,pcnume,supedi,
SFAÑOF || '-' || right('00' || cast(sfmesf as varchar(2)),2) || '-' || right('00' || cast(sfdiaf as varchar(2)),2) as fecha
from lucmfile.facelc where tipodo='F' and pcnume=1686
--and sfAÑOF=2020 and sfmesf=2
fetch first 10 rows only

-- busqueda de pedidos y lotes por medio de la factura
select f.*,
(select cldivi from lucfile.cl where clcodi=f.ftccli) as division
from lucfile.ftcac as f where
ftpedi in (select pcnume from lucmfile.facelc where tipodo='F' and sfnumf=52032)

-- otra versión para tener los datos para generar pedidos, a partir del número de factura
select f.ftpedi,f.ftclot,f.ftccli,f.ftcnki,f.ftccar,f.ftcnom,f.ftcran,
(select cldivi from lucfile.cl where clcodi=f.ftccli) as division,
(select sfnumf from lucmfile.facelc where pcnume = f.ftpedi) as factura
from lucfile.ftcac as f where
ftpedi in (select pcnume from lucmfile.facelc where tipodo='F' and sfnumf=53058)

select * from lucmfile.certusu
select * from lucmfile.cerclpdf

20200521 verificar ruta automática de generación de archivos pdf

