<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128570909/12.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4273)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/GetPointLocationInformation/MainPage.xaml) (VB: [MainPage.xaml](./VB/GetPointLocationInformation/MainPage.xaml))
* [MainPage.xaml.cs](./CS/GetPointLocationInformation/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/GetPointLocationInformation/MainPage.xaml.vb))
<!-- default file list end -->
# How to get information about a geopoint using the Bing Geocode web service
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4273)**
<!-- run online end -->


<p>This example demonstrates how to obtain information about a geographical point from the Bing Geocode web service using the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapBingGeocodeDataProvider_RequestLocationInformationtopic"><u>BingGeocodeDataProvider.RequestLocationInformation</u></a> method.</p><p>To do this, specify a geographical point (<a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapGeoPoint_Longitudetopic"><u>GeoPoint.Longitude</u></a> and <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapGeoPoint_Latitudetopic"><u>GeoPoint.Latitude</u></a>) in the <strong>TextBox</strong> elements. Then, click the <strong>Request Location </strong>button. It handles the <strong>requestLocation_Click</strong> event and all parameters are passed to the <strong>RequestLocationInformation</strong> method. </p><p>Results contain a location name (<a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_DisplayNametopic"><u>LocationInformation.DisplayName</u></a>), entity type (<a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_EntityTypetopic"><u>LocationInformation.EntityType</u></a>), address (<a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_Addresstopic"><u>LocationInformation.Address</u></a>) and exact coordinates ( <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfMapLocationInformation_Locationtopic"><u>LocationInformation.Location</u></a>) that are shown in the <strong>TextBlock</strong> element below. </p><p>Note that if you run this sample as is, you will get a warning message informing that the specified Bing Maps key is invalid. To learn more about Bing Map keys, please refer to the <a href="http://documentation.devexpress.com/#Silverlight/CustomDocument5975"><u>How to: Get a Bing Maps Key</u></a> tutorial.</p><p></p><p></p>

<br/>


