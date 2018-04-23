﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Map;

namespace DXMap_CustomGeocode {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        #region #RequestLocation
        double latitude;
        double longitude;

        private bool GetRequestArguments() {
            latitude = String.IsNullOrEmpty(tbLatitude.Text) ? 0 : Double.Parse(tbLatitude.Text);
            if ((latitude > 90) || (latitude < -90)) {
                MessageBox.Show("Latitude must be less than or equal to 90 and greater than or equal to - 90. Please, correct the input value.");
                return false;
            }

            longitude = String.IsNullOrEmpty(tbLongitude.Text) ? 0 : Double.Parse(tbLongitude.Text);
            if ((longitude > 180) || (longitude < -180)) {
                MessageBox.Show("Longitude must be less than or equal to 180 and greater than or equal to - 180. Please, correct the input value.");
                return false;
            }

            return true;
        }

        private void RequestLocationInformation() {
            geocodeProvider.RequestLocationInformation(new GeoPoint(latitude, longitude), 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (GetRequestArguments())
                RequestLocationInformation();
        }
        #endregion #RequestLocation

        #region #LocationInformationReceived
        private void geocodeProvider_LocationInformationReceived(object sender, LocationInformationReceivedEventArgs e) {
            mapControl.CenterPoint = new GeoPoint(latitude, longitude);
            mapControl.ZoomLevel = 10;
            GeocodeRequestResult result = e.Result;
            StringBuilder resultList = new StringBuilder("");
            resultList.Append(String.Format("Status: {0}\n", result.ResultCode));
            resultList.Append(String.Format("Fault reason: {0}\n", result.FaultReason));

            if (result.ResultCode == RequestResultCode.Success) {
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

            }

            tbResult.Text = resultList.ToString();
        }
        #endregion #LocationInformationReceived
    }
}
