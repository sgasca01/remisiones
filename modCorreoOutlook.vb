''' <summary>
''' Módulo para envío de mensajes de correo
''' </summary>
''' <remarks></remarks>
Module modCorreoOutlook

    Public Enum ResultadoEnvio As Integer
        correcto = 0
        errorGenerico
        errorRemitente
        errorPassword
        errorDestinatario
        errorCopias
        errorCopiasOcultas
        errorAsunto
        errorCuerpo
        errorAnexos
    End Enum

#Region " variables privadas "

    ' servidor
    ''' <summary>
    ''' Nombre del servidor de coreo
    ''' </summary>
    ''' <remarks></remarks>
    Private _servidor As String = "smtp.office365.com"
    ''' <summary>
    ''' Puerto a través del que se envía el correo
    ''' </summary>
    ''' <remarks></remarks>
    Private _puerto As Integer = 587

    ' remitente
    ''' <summary>
    ''' Cuenta de correo del remitente
    ''' </summary>
    ''' <remarks></remarks>
    Private _usuarioRemitente As String = ""
    ''' <summary>
    ''' Password de la cuenta de correo del remitente
    ''' </summary>
    ''' <remarks></remarks>
    Private _passwordRemitente As String = ""
    ''' <summary>
    ''' Cuenta a la que se responderá el correo de forma automática
    ''' </summary>
    ''' <remarks></remarks>
    Private _replyTo As String = ""
    ''' <summary>
    ''' Firma del usuario para el correo
    ''' </summary>
    ''' <remarks></remarks>
    Private _firma As String = ""

    ' correo electrónico
    ''' <summary>
    ''' Asunto del correo
    ''' </summary>
    ''' <remarks></remarks>
    Private _asunto As String = ""
    ''' <summary>
    ''' Mensaje del correo
    ''' </summary>
    ''' <remarks></remarks>
    Private _cuerpo As String = ""
    ''' <summary>
    ''' Archivo de la imagen1 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Private _imagen1 As String = ""
    ''' <summary>
    ''' Archivo de la imagen2 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Private _imagen2 As String = ""
    ''' <summary>
    ''' Archivo de la imagen3 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Private _imagen3 As String = ""
    ''' <summary>
    ''' Archivo de la imagen4 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Private _imagen4 As String = ""
    ''' <summary>
    ''' Archivo de la imagen5 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Private _imagen5 As String = ""

    ' destinatarios
    ''' <summary>
    ''' Lista de destinatarios principales
    ''' </summary>
    ''' <remarks></remarks>
    Private _destinatarios As String = ""
    ''' <summary>
    ''' Lista de destinatarios con copia
    ''' </summary>
    ''' <remarks></remarks>
    Private _copias As String = ""
    ''' <summary>
    ''' Lista de destinatarios con copia oculta
    ''' </summary>
    ''' <remarks></remarks>
    Private _copiasOcultas As String = ""

    ' resultado
    ''' <summary>
    ''' Mensaje resultado del envío del correo
    ''' </summary>
    ''' <remarks></remarks>
    Private _resultado As String = ""
    ''' <summary>
    ''' Código del resultado del envío
    ''' </summary>
    ''' <remarks></remarks>
    Private _statusResultado As ResultadoEnvio = ResultadoEnvio.correcto

#End Region

#Region " propiedades "

    ''' <summary>
    ''' Nombre del servidor de correo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property servidor As String
        Get
            servidor = _servidor
        End Get
        Set(value As String)
            _servidor = value
        End Set
    End Property
    ''' <summary>
    ''' Puerto a través del que se envía el correo
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Puerto As Integer
        Get
            Puerto = _puerto
        End Get
        Set(value As Integer)
            If (0 <= value) Then
                _puerto = value
            End If
        End Set
    End Property

    ' remitente
    ''' <summary>
    ''' Cuenta de correo del remitente
    ''' </summary>
    ''' <remarks></remarks>
    Public Property UsuarioRemitente As String
        Get
            UsuarioRemitente = _usuarioRemitente
        End Get
        Set(value As String)
            _usuarioRemitente = value
        End Set
    End Property
    ''' <summary>
    ''' Password de la cuenta de correo del remitente
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PasswordRemitente As String
        'TODO: modCorreoOutlook.PasswordRemitente - ponerlo encriptado
        Get
            PasswordRemitente = _passwordRemitente
        End Get
        Set(value As String)
            _passwordRemitente = value
        End Set
    End Property
    ''' <summary>
    ''' Cuenta a la que se responderá el correo de forma automática
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ReplyTo As String
        Get
            ReplyTo = _replyTo
        End Get
        Set(value As String)
            _replyTo = value
        End Set
    End Property
    ''' <summary>
    ''' Firma del usuario para el correo
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Firma As String
        Get
            Firma = _firma
        End Get
        Set(value As String)
            _firma = value
        End Set
    End Property


    ' correo electrónico
    ''' <summary>
    ''' Asunto del correo
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Asunto As String
        Get
            Asunto = _asunto
        End Get
        Set(value As String)
            _asunto = value
        End Set
    End Property
    ''' <summary>
    ''' Mensaje del correo
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Cuerpo As String
        Get
            Cuerpo = _cuerpo
        End Get
        Set(value As String)
            _cuerpo = value
        End Set
    End Property
    ''' <summary>
    ''' Archivo de la imagen1 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Imagen1 As String
        Get
            Imagen1 = _imagen1
        End Get
        Set(value As String)
            _imagen1 = value
        End Set
    End Property
    ''' <summary>
    ''' Archivo de la imagen2 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Imagen2 As String
        Get
            Imagen2 = _imagen2
        End Get
        Set(value As String)
            _imagen2 = value
        End Set
    End Property
    ''' <summary>
    ''' Archivo de la imagen3 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Imagen3 As String
        Get
            Imagen3 = _imagen3
        End Get
        Set(value As String)
            _imagen3 = value
        End Set
    End Property
    ''' <summary>
    ''' Archivo de la imagen4 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Imagen4 As String
        Get
            Imagen4 = _imagen4
        End Get
        Set(value As String)
            _imagen4 = value
        End Set
    End Property
    ''' <summary>
    ''' Archivo de la imagen5 que se anexa
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Imagen5 As String
        Get
            Imagen5 = _imagen5
        End Get
        Set(value As String)
            _imagen5 = value
        End Set
    End Property

    ' destinatarios
    ''' <summary>
    ''' Lista de destinatarios principales
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Destinatarios As String
        Get
            Destinatarios = _destinatarios
        End Get
        Set(value As String)
            _destinatarios = value
        End Set
    End Property
    ''' <summary>
    ''' Lista de destinatarios con copia
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Copias As String
        Get
            Copias = _copias
        End Get
        Set(value As String)
            _copias = value
        End Set
    End Property
    ''' <summary>
    ''' Lista de destinatarios con copia oculta
    ''' </summary>
    ''' <remarks></remarks>
    Public Property CopiasOcultas As String
        Get
            CopiasOcultas = _copiasOcultas
        End Get
        Set(value As String)
            _copiasOcultas = value
        End Set
    End Property

    ' resultado
    ''' <summary>
    ''' Mensaje resultado del envío del correo
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Resultado As String
        Get
            Resultado = _resultado
        End Get
    End Property
    ''' <summary>
    ''' Código del resultado del envío
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property StatusResultado As ResultadoEnvio
        Get
            StatusResultado = _statusResultado
        End Get
    End Property


#End Region

    ''' <summary>
    ''' Realiza el envío de correos electrónicos, a partir de la información proporcionada en los parámetros
    ''' </summary>
    ''' <param name="asuntoCorreo"></param>
    ''' <param name="mensajeCorreo"></param>
    ''' <param name="imagen1"></param>
    ''' <param name="imagen2"></param>
    ''' <remarks></remarks>
    Public Sub envioOutlook(Optional ByVal asuntoCorreo As String = "",
                            Optional ByVal mensajeCorreo As String = "",
                            Optional imagen1 As String = "",
                            Optional imagen2 As String = "",
                            Optional imagen3 As String = "",
                            Optional imagen4 As String = "",
                            Optional imagen5 As String = "",
                            Optional userAd As String = "")


        Dim msgImagen1 As String = ""
        Dim msgImagen2 As String = ""
        Dim msgImagen3 As String = ""
        Dim msgImagen4 As String = ""
        Dim msgImagen5 As String = ""

        'inicializa los resultados
        _resultado = ""
        _statusResultado = ResultadoEnvio.correcto

        ' validaciones e inicializaciones
        If ("" <> asuntoCorreo) Then
            modCorreoOutlook.Asunto = asuntoCorreo
        End If
        If ("" <> mensajeCorreo) Then
            modCorreoOutlook.Cuerpo = mensajeCorreo
        End If

        ' validación de los datos del remitente
        If ("" = modCorreoOutlook.UsuarioRemitente) Then
            modCorreoOutlook.UsuarioRemitente = InputBox("Usuario remitente", "Datos del remitente", "")
        End If
        If ("" = modCorreoOutlook.PasswordRemitente) Then
            modCorreoOutlook.PasswordRemitente = InputBox("Contraseña del usuario remitente", "Datos del remitente", "")
        End If
        If ("" = modCorreoOutlook.UsuarioRemitente) Then
            _resultado = "No se puede enviar el correo por falta de información del remitente (Usuario)."
            _statusResultado = ResultadoEnvio.errorRemitente
            Exit Sub
        End If
        If ("" = modCorreoOutlook.PasswordRemitente) Then
            _resultado = "No se puede enviar el correo por falta de información del remitente (Password)."
            _statusResultado = ResultadoEnvio.errorPassword
            Exit Sub
        End If
        If ("" = modCorreoOutlook.ReplyTo) Then
            modCorreoOutlook.ReplyTo = modCorreoOutlook.UsuarioRemitente
        End If

        ' otras validaciones
        If ("" = modCorreoOutlook.Asunto) Then
            _resultado = "No se puede enviar el correo por falta de información del correo (Asunto)."
            _statusResultado = ResultadoEnvio.errorAsunto
            Exit Sub
        End If
        If ("" = modCorreoOutlook.Cuerpo) Then
            _resultado = "No se puede enviar el correo por falta de información del correo (Mensaje)."
            _statusResultado = ResultadoEnvio.errorCuerpo
            Exit Sub
        End If

        ' manejo de imágenes anexas
        If ("" = imagen1) Then
            imagen1 = modCorreoOutlook.Imagen1
        Else
            ' modCorreoOutlook.Imagen1 = imagen1
        End If
        If ("" = imagen2) Then
            imagen2 = modCorreoOutlook.Imagen2
        Else
            modCorreoOutlook.Imagen2 = imagen2
        End If
        If ("" = imagen3) Then
            imagen3 = modCorreoOutlook.Imagen3
        Else
            modCorreoOutlook.Imagen3 = imagen3
        End If
        If ("" = imagen4) Then
            imagen4 = modCorreoOutlook.Imagen4
        Else
            modCorreoOutlook.Imagen4 = imagen4
        End If
        If ("" = imagen5) Then
            imagen5 = modCorreoOutlook.Imagen5
        Else
            modCorreoOutlook.Imagen5 = imagen5
        End If
        'If ("" <> imagen1) Then
        '    If System.IO.File.Exists(imagen1) Then
        '        Dim atach2 As New System.Net.Mail.Attachment(imagen1)
        '        mensajeElectronico.Attachments.Add(atach2)

        '        'to embed images, we need to use the prefix 'cid' in the img src value
        '        'the cid value will map to the Content-Id of a Linked resource.
        '        'thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
        '        'msgImagen1 = "<img width='150' height='114' src=cid:companyimagen1 alt='' />"
        '        'msgImagen1 = "<img width='260' height='195' src=cid:companyimagen1 alt='' />"
        '        ''msgImagen1 = "<img src=cid:companyimagen1 alt='' />"
        '    Else
        '        msgImagen1 = "&nbsp;" ' no se encuentra el archivo del logo
        '    End If
        'End If
        If ("" <> imagen2) Then
            If System.IO.File.Exists(imagen2) Then
                msgImagen2 = "<img src=cid:companyimagen2 alt='' />"
            Else
                msgImagen2 = "&nbsp;" ' no se encuentra el archivo del logo
            End If
        End If
        If ("" <> imagen3) Then
            If System.IO.File.Exists(imagen3) Then
                msgImagen3 = "<img src=cid:companyimagen3 alt='' />"
            Else
                msgImagen3 = "&nbsp;" ' no se encuentra el archivo del logo
            End If
        End If
        If ("" <> imagen4) Then
            If System.IO.File.Exists(imagen4) Then
                msgImagen4 = "<img src=cid:companyimagen4 alt='' />"
            Else
                msgImagen4 = "&nbsp;" ' no se encuentra el archivo del logo
            End If
        End If
        If ("" <> imagen5) Then
            If System.IO.File.Exists(imagen5) Then
                msgImagen5 = "<img src=cid:companyimagen5 alt='' />"
            Else
                msgImagen5 = "&nbsp;" ' no se encuentra el archivo del logo
            End If
        End If
        modCorreoOutlook.Cuerpo = Replace(modCorreoOutlook.Cuerpo, "<msgImagen1/>", msgImagen1) ' se replaza la referencia la imagen 1
        modCorreoOutlook.Cuerpo = Replace(modCorreoOutlook.Cuerpo, "<msgImagen2/>", msgImagen2) ' se replaza la referencia la imagen 2
        modCorreoOutlook.Cuerpo = Replace(modCorreoOutlook.Cuerpo, "<msgImagen3/>", msgImagen3) ' se replaza la referencia la imagen 3
        modCorreoOutlook.Cuerpo = Replace(modCorreoOutlook.Cuerpo, "<msgImagen4/>", msgImagen4) ' se replaza la referencia la imagen 4
        modCorreoOutlook.Cuerpo = Replace(modCorreoOutlook.Cuerpo, "<msgImagen5/>", msgImagen5) ' se replaza la referencia la imagen 5

        'first we create the Plain Text part
        Dim plainView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString("" &
            "Este es un contenido de texto simple, visible por aquellos correos que no soportan html/" &
            "This is a plain text content, viewable by those email clients that don't support html", Nothing, "text/plain")
        Dim htmlView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(modCorreoOutlook.Cuerpo & modCorreoOutlook.Firma, Nothing, "text/html")
        Dim correo As New System.Net.Mail.SmtpClient(modCorreoOutlook.servidor, modCorreoOutlook.Puerto)
        Dim mensajeElectronico As New System.Net.Mail.MailMessage()
        Try
            If ("" <> imagen1) Then
                If System.IO.File.Exists(imagen1) Then
                    Dim atach2 As New System.Net.Mail.Attachment(imagen1)
                    mensajeElectronico.Attachments.Add(atach2)
                Else
                End If
            End If

            ' anexamos las imágenes
            If System.IO.File.Exists(imagen1 & "asd") Then
                'create the LinkedResource (embedded image)
                Dim img1 As System.Net.Mail.LinkedResource = Nothing
                Select Case Right(imagen1, 4).ToUpper
                    Case ".JPG"
                        img1 = New System.Net.Mail.LinkedResource(imagen1, System.Net.Mime.MediaTypeNames.Image.Jpeg)
                    Case ".GIF"
                        img1 = New System.Net.Mail.LinkedResource(imagen1, System.Net.Mime.MediaTypeNames.Image.Gif)
                    Case ".XML"
                        img1 = New System.Net.Mail.LinkedResource(imagen1, System.Net.Mime.MediaTypeNames.Text.Xml)
                    Case ".RTF"
                        img1 = New System.Net.Mail.LinkedResource(imagen1, System.Net.Mime.MediaTypeNames.Text.RichText)
                    Case ".PDF"
                        img1 = New System.Net.Mail.LinkedResource(imagen1, System.Net.Mime.MediaTypeNames.Application.Pdf)
                    Case ".ZIP"
                        img1 = New System.Net.Mail.LinkedResource(imagen1, System.Net.Mime.MediaTypeNames.Application.Zip)
                End Select
                img1.ContentId = "companyimagen1"
                'add the LinkedResource to the appropriate view
                htmlView.LinkedResources.Add(img1)
            End If
            If System.IO.File.Exists(imagen2) Then
                'create the LinkedResource (embedded image)
                Dim img2 As System.Net.Mail.LinkedResource = Nothing
                Select Case Right(imagen2, 4).ToUpper
                    Case ".JPG"
                        img2 = New System.Net.Mail.LinkedResource(imagen2, System.Net.Mime.MediaTypeNames.Image.Jpeg)
                    Case ".GIF"
                        img2 = New System.Net.Mail.LinkedResource(imagen2, System.Net.Mime.MediaTypeNames.Image.Gif)
                    Case ".XML"
                        img2 = New System.Net.Mail.LinkedResource(imagen2, System.Net.Mime.MediaTypeNames.Text.Xml)
                    Case ".RTF"
                        img2 = New System.Net.Mail.LinkedResource(imagen2, System.Net.Mime.MediaTypeNames.Text.RichText)
                    Case ".PDF"
                        img2 = New System.Net.Mail.LinkedResource(imagen2, System.Net.Mime.MediaTypeNames.Application.Pdf)
                    Case ".ZIP"
                        img2 = New System.Net.Mail.LinkedResource(imagen2, System.Net.Mime.MediaTypeNames.Application.Zip)
                End Select
                img2.ContentId = "companyimagen2"
                'add the LinkedResource to the appropriate view
                htmlView.LinkedResources.Add(img2)
            End If
            If System.IO.File.Exists(imagen3) Then
                'create the LinkedResource (embedded image)
                Dim img3 As System.Net.Mail.LinkedResource = Nothing
                Select Case Right(imagen3, 4).ToUpper
                    Case ".JPG"
                        img3 = New System.Net.Mail.LinkedResource(imagen3, System.Net.Mime.MediaTypeNames.Image.Jpeg)
                    Case ".GIF"
                        img3 = New System.Net.Mail.LinkedResource(imagen3, System.Net.Mime.MediaTypeNames.Image.Gif)
                    Case ".XML"
                        img3 = New System.Net.Mail.LinkedResource(imagen3, System.Net.Mime.MediaTypeNames.Text.Xml)
                    Case ".RTF"
                        img3 = New System.Net.Mail.LinkedResource(imagen3, System.Net.Mime.MediaTypeNames.Text.RichText)
                    Case ".PDF"
                        img3 = New System.Net.Mail.LinkedResource(imagen3, System.Net.Mime.MediaTypeNames.Application.Pdf)
                    Case ".ZIP"
                        img3 = New System.Net.Mail.LinkedResource(imagen3, System.Net.Mime.MediaTypeNames.Application.Zip)
                End Select
                img3.ContentId = "companyimagen3"
                'add the LinkedResource to the appropriate view
                htmlView.LinkedResources.Add(img3)
            End If
            If System.IO.File.Exists(imagen4) Then
                'create the LinkedResource (embedded image)
                Dim img4 As System.Net.Mail.LinkedResource = Nothing
                Select Case Right(imagen4, 4).ToUpper
                    Case ".JPG"
                        img4 = New System.Net.Mail.LinkedResource(imagen4, System.Net.Mime.MediaTypeNames.Image.Jpeg)
                    Case ".GIF"
                        img4 = New System.Net.Mail.LinkedResource(imagen4, System.Net.Mime.MediaTypeNames.Image.Gif)
                    Case ".XML"
                        img4 = New System.Net.Mail.LinkedResource(imagen4, System.Net.Mime.MediaTypeNames.Text.Xml)
                    Case ".RTF"
                        img4 = New System.Net.Mail.LinkedResource(imagen4, System.Net.Mime.MediaTypeNames.Text.RichText)
                    Case ".PDF"
                        img4 = New System.Net.Mail.LinkedResource(imagen4, System.Net.Mime.MediaTypeNames.Application.Pdf)
                    Case ".ZIP"
                        img4 = New System.Net.Mail.LinkedResource(imagen4, System.Net.Mime.MediaTypeNames.Application.Zip)
                End Select
                img4.ContentId = "companyimagen4"
                'add the LinkedResource to the appropriate view
                htmlView.LinkedResources.Add(img4)
            End If
            If System.IO.File.Exists(imagen5) Then
                'create the LinkedResource (embedded image)
                Dim img5 As System.Net.Mail.LinkedResource = Nothing
                Select Case Right(imagen5, 4).ToUpper
                    Case ".JPG"
                        img5 = New System.Net.Mail.LinkedResource(imagen5, System.Net.Mime.MediaTypeNames.Image.Jpeg)
                    Case ".GIF"
                        img5 = New System.Net.Mail.LinkedResource(imagen5, System.Net.Mime.MediaTypeNames.Image.Gif)
                    Case ".XML"
                        img5 = New System.Net.Mail.LinkedResource(imagen5, System.Net.Mime.MediaTypeNames.Text.Xml)
                    Case ".RTF"
                        img5 = New System.Net.Mail.LinkedResource(imagen5, System.Net.Mime.MediaTypeNames.Text.RichText)
                    Case ".PDF"
                        img5 = New System.Net.Mail.LinkedResource(imagen5, System.Net.Mime.MediaTypeNames.Application.Pdf)
                    Case ".ZIP"
                        img5 = New System.Net.Mail.LinkedResource(imagen5, System.Net.Mime.MediaTypeNames.Application.Zip)
                End Select
                img5.ContentId = "companyimagen5"
                'add the LinkedResource to the appropriate view
                htmlView.LinkedResources.Add(img5)
            End If

            'strMensaje = Me.Body
            mensajeElectronico.From = New System.Net.Mail.MailAddress(modCorreoOutlook.UsuarioRemitente) ' dirección de From
            mensajeElectronico.ReplyToList.Add(modCorreoOutlook.ReplyTo) ' dirección para el ReplyTo
            ' agregamos una a una las direcciones de destinatarios
            Dim strDestinatario As String = ""
            Dim arrDestinatarios As String()
            Dim intDestinatario As Integer = 0

            ' se separa la lista de destinatarios
            strDestinatario = Replace(modCorreoOutlook.Destinatarios, ";", ",") ' para permitir ; o , como separador
            arrDestinatarios = Split(strDestinatario, ",")
            For intDestinatario = 0 To arrDestinatarios.Length - 1
                strDestinatario = arrDestinatarios(intDestinatario).Trim
                If (strDestinatario <> "") Then
                    Try
                        mensajeElectronico.To.Add(strDestinatario)
                    Catch ex As Exception
                        _resultado = ex.ToString & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.Source & vbCrLf & vbCrLf & ex.StackTrace
                        _statusResultado = ResultadoEnvio.errorDestinatario
                        Exit Sub
                    End Try
                End If
            Next

            ' se separa la lista de destinatarios de copia
            strDestinatario = Replace(modCorreoOutlook.Copias, ";", ",") ' para permitir ; o , como separador
            arrDestinatarios = Split(strDestinatario, ",")
            For intDestinatario = 0 To arrDestinatarios.Length - 1
                strDestinatario = arrDestinatarios(intDestinatario).Trim
                If (strDestinatario <> "") Then
                    Try
                        mensajeElectronico.CC.Add(strDestinatario)
                    Catch ex As Exception
                        _resultado = ex.ToString & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.Source & vbCrLf & vbCrLf & ex.StackTrace
                        _statusResultado = ResultadoEnvio.errorCopias
                        Exit Sub
                    End Try
                End If
            Next

            ' se separa la lista de destinatarios de copia oculta
            strDestinatario = Replace(modCorreoOutlook.CopiasOcultas, ";", ",") ' para permitir ; o , como separador
            arrDestinatarios = Split(strDestinatario, ",")
            For intDestinatario = 0 To arrDestinatarios.Length - 1
                strDestinatario = arrDestinatarios(intDestinatario).Trim
                If (strDestinatario <> "") Then
                    Try
                        mensajeElectronico.Bcc.Add(strDestinatario)
                    Catch ex As Exception
                        _resultado = ex.ToString & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.Source & vbCrLf & vbCrLf & ex.StackTrace
                        _statusResultado = ResultadoEnvio.errorCopiasOcultas
                        Exit Sub
                    End Try
                End If
            Next

            'add the views
            mensajeElectronico.AlternateViews.Add(plainView)
            mensajeElectronico.AlternateViews.Add(htmlView)
            'correo.Host = txtServidor.Text
            Dim strServidor As String = "outlook.office365.com"
            Dim intPuerto As Integer = 587
            correo.Host = strServidor
            correo.Port = intPuerto
            correo.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            correo.UseDefaultCredentials = False
            correo.EnableSsl = True


            'correo.Credentials = New Net.NetworkCredential(modCorreoOutlook.UsuarioRemitente, modCorreoOutlook.PasswordRemitente, "lucta.com")
            Dim Cred As New System.Net.NetworkCredential(userAd & "@lucta.com", modCorreoOutlook.PasswordRemitente)
            'correo.UseDefaultCredentials = True
            correo.Credentials = Cred
            mensajeElectronico.Subject = modCorreoOutlook.Asunto
            If (mensajeElectronico.To.Count = 0) Then
                _resultado = "No existe destinatario"
                _statusResultado = ResultadoEnvio.errorDestinatario
            Else
                correo.Send(mensajeElectronico)
                _resultado = "Correo enviado exitosamente"
                _statusResultado = ResultadoEnvio.correcto
            End If
            'correo.Dispose()
            '_estado = status.Ok
        Catch ex As System.Exception
            _resultado = ex.ToString & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.Source & vbCrLf & vbCrLf & ex.StackTrace
            _statusResultado = ResultadoEnvio.errorGenerico
        End Try
        WriteLog("to=[" & mensajeElectronico.To.ToString & "] bcc=[" & mensajeElectronico.CC.ToString & ";" & mensajeElectronico.Bcc.ToString & "] subject=[" & mensajeElectronico.Subject & "] status=[" & _resultado & "]",,
                 "C:\VisualStudio\Visual Studio 2017\Projects\LuctaVS17\CorreosMasivos\log\email_log" & Format(Now, "yyyyMMdd") & ".log")
        correo.Dispose()
        mensajeElectronico.Dispose()
        ' MsgBox(modCorreoOutlook.Resultado)
    End Sub

End Module
