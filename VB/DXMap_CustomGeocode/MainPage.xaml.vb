Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Map

Namespace DXMap_CustomGeocode
    Partial Public Class MainPage
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        #Region "#RequestLocation"
        Private latitude As Double
        Private longitude As Double

        Private Function GetRequestArguments() As Boolean
            latitude = If(String.IsNullOrEmpty(tbLatitude.Text), 0, Double.Parse(tbLatitude.Text))
            If (latitude > 90) OrElse (latitude < -90) Then
                MessageBox.Show("Latitude must be less than or equal to 90 and greater than or equal to - 90. Please, correct the input value.")
                Return False
            End If

            longitude = If(String.IsNullOrEmpty(tbLongitude.Text), 0, Double.Parse(tbLongitude.Text))
            If (longitude > 180) OrElse (longitude < -180) Then
                MessageBox.Show("Longitude must be less than or equal to 180 and greater than or equal to - 180. Please, correct the input value.")
                Return False
            End If

            Return True
        End Function

        Private Sub RequestLocationInformation()
            geocodeProvider.RequestLocationInformation(New GeoPoint(latitude, longitude), 0)
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If GetRequestArguments() Then
                RequestLocationInformation()
            End If
        End Sub
        #End Region ' #RequestLocation

        #Region "#LocationInformationReceived"
        Private Sub geocodeProvider_LocationInformationReceived(ByVal sender As Object, ByVal e As LocationInformationReceivedEventArgs)
            mapControl.CenterPoint = New GeoPoint(latitude, longitude)
            mapControl.ZoomLevel = 10
            Dim result As GeocodeRequestResult = e.Result
            Dim resultList As New StringBuilder("")
            resultList.Append(String.Format("Status: {0}" & ControlChars.Lf, result.ResultCode))
            resultList.Append(String.Format("Fault reason: {0}" & ControlChars.Lf, result.FaultReason))

            If result.ResultCode = RequestResultCode.Success Then
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

            End If

            tbResult.Text = resultList.ToString()
        End Sub
        #End Region ' #LocationInformationReceived
    End Class
End Namespace
