Imports DevExpress.Xpf.Map
Imports System
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls

Namespace Geocoding
    Partial Public Class MainPage
        Inherits UserControl

        #Region "#GeocodeRequestImplementation"
        Public Sub New()
            InitializeComponent()
            Me.DataContext = RequestLocation
        End Sub


        Private requestLocation_Renamed As New GeoPoint(40, -120)
        Public Property RequestLocation() As GeoPoint
            Get
                Return requestLocation_Renamed
            End Get
            Set(ByVal value As GeoPoint)
                requestLocation_Renamed = value
            End Set
        End Property

        Private Sub bRequestLocationInformation_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            geocodeProvider.RequestLocationInformation(RequestLocation, Nothing)
        End Sub
        #End Region ' #GeocodeRequestImplementation

        #Region "#LocationInformationReceivedImplementation"
        Private Sub geocodeProvider_LocationInformationReceived(ByVal sender As Object, ByVal e As LocationInformationReceivedEventArgs)
            Dim result As GeocodeRequestResult = e.Result
            Dim resultList As New StringBuilder("")
            resultList.Append(String.Format("Status: {0}" & ControlChars.Lf, result.ResultCode))
            resultList.Append(String.Format("Fault reason: {0}" & ControlChars.Lf, result.FaultReason))
            resultList.Append(String.Format("______________________________" & ControlChars.Lf))

            If result.ResultCode <> RequestResultCode.Success Then
                tbResults.Text = resultList.ToString()
                Return
            End If

            Dim resCounter As Integer = 1
            For Each locations As LocationInformation In result.Locations
                resultList.Append(String.Format("Request Result {0}:" & ControlChars.Lf, resCounter))
                resultList.Append(String.Format("Display Name: {0}" & ControlChars.Lf, locations.DisplayName))
                resultList.Append(String.Format("Entity Type: {0}" & ControlChars.Lf, locations.EntityType))
                resultList.Append(String.Format("Address: {0}" & ControlChars.Lf, locations.Address))
                resultList.Append(String.Format("Location: {0}" & ControlChars.Lf, locations.Location))
                resultList.Append(String.Format("______________________________" & ControlChars.Lf))
                resCounter += 1
            Next locations

            tbResults.Text = resultList.ToString()
        End Sub
        #End Region ' #LocationInformationReceivedImplementation
    End Class
End Namespace
