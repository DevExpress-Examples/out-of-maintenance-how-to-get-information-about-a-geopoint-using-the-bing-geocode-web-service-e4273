Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Map

Namespace GetPointLocationInformation
	Partial Public Class MainPage
		Inherits UserControl
		Private latitude As Double
		Private longitude As Double

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Function GetLocationArguments() As Boolean
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

		Private Sub requestLocation_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If GetLocationArguments() Then
				LocationRequest()
			End If
		End Sub

		Private Sub LocationRequest()
			LocationInformationRequest(New GeoPoint(latitude, longitude))
		End Sub

		Private Sub LocationInformationRequest(ByVal geoPoint As GeoPoint)
			Try
'				#Region "#RequestLocation"
				geocodeProvider.RequestLocationInformation(New GeoPoint(latitude, longitude), 0)
'				#End Region ' #RequestLocation
			Catch ex As Exception
				MessageBox.Show("An error occurs: " & ex.ToString())
			End Try
		End Sub

		Private Sub geocodeProvider_LocationInformationReceived(ByVal sender As Object, ByVal e As LocationInformationReceivedEventArgs)
			mapControl1.CenterPoint = New GeoPoint(latitude, longitude)
			mapControl1.ZoomLevel = 10
			Dim result As GeocodeRequestResult = e.Result
			Dim resultList As New StringBuilder("")
			resultList.Append(String.Format("Status: {0}" & Constants.vbLf, result.ResultCode))
			resultList.Append(String.Format("Fault reason: {0}" & Constants.vbLf, result.FaultReason))

			If result.ResultCode = RequestResultCode.Success Then
				Dim resCounter As Integer = 1

				For Each locations As LocationInformation In result.Locations
					resultList.Append(String.Format("Request Result {0}:" & Constants.vbLf, resCounter))
					resultList.Append(String.Format("Display Name: {0}" & Constants.vbLf, locations.DisplayName))
					resultList.Append(String.Format("Entity Type: {0}" & Constants.vbLf, locations.EntityType))
					resultList.Append(String.Format("Address: {0}" & Constants.vbLf, locations.Address))
					resultList.Append(String.Format("Location: {0}" & Constants.vbLf, locations.Location))
					resultList.Append(String.Format("______________________________" & Constants.vbLf))
					resCounter += 1
				Next locations

			End If

			tbResults.Text = resultList.ToString()
		End Sub

	End Class
End Namespace
