using DevExpress.Xpf.Map;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Geocoding {
    public partial class MainPage : UserControl {
        #region #GeocodeRequestImplementation
        public MainPage() {
            InitializeComponent();
            this.DataContext = RequestLocation;
        }

        GeoPoint requestLocation = new GeoPoint(40, -120);
        public GeoPoint RequestLocation {
            get { return requestLocation; }
            set { requestLocation = value; }
        }

        private void bRequestLocationInformation_Click(object sender, RoutedEventArgs e) {
            geocodeProvider.RequestLocationInformation(RequestLocation, null);
        }
        #endregion #GeocodeRequestImplementation

        #region #LocationInformationReceivedImplementation
        private void geocodeProvider_LocationInformationReceived(object sender, LocationInformationReceivedEventArgs e) {
            GeocodeRequestResult result = e.Result;
            StringBuilder resultList = new StringBuilder("");
            resultList.Append(String.Format("Status: {0}\n", result.ResultCode));
            resultList.Append(String.Format("Fault reason: {0}\n", result.FaultReason));
            resultList.Append(String.Format("______________________________\n"));

            if (result.ResultCode != RequestResultCode.Success) {
                tbResults.Text = resultList.ToString();
                return;
            }

            int resCounter = 1;
            foreach (LocationInformation locations in result.Locations) {
                resultList.Append(String.Format("Request Result {0}:\n", resCounter));
                resultList.Append(String.Format("Display Name: {0}\n", locations.DisplayName));
                resultList.Append(String.Format("Entity Type: {0}\n", locations.EntityType));
                resultList.Append(String.Format("Address: {0}\n", locations.Address));
                resultList.Append(String.Format("Location: {0}\n", locations.Location));
                resultList.Append(String.Format("______________________________\n"));
                resCounter++;
            }

            tbResults.Text = resultList.ToString();
        }
        #endregion #LocationInformationReceivedImplementation
    }
}
