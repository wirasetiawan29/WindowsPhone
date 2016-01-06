using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using device_status.Resources;
using Microsoft.Phone.Info;

namespace device_status
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DeviceManufacturer.Text = DeviceStatus.DeviceManufacturer;
            DeviceName.Text = DeviceStatus.DeviceName;
            FirmwareVersion.Text = DeviceStatus.DeviceFirmwareVersion;
            HardwareVersion.Text = DeviceStatus.DeviceHardwareVersion;
            DeviceTotalMemory.Text = DeviceStatus.DeviceTotalMemory.ToString();
            ApplicationCurrentMemoryUsage.Text = DeviceStatus.ApplicationCurrentMemoryUsage.ToString();
            ApplicationMemoryUsageLimit.Text = DeviceStatus.ApplicationMemoryUsageLimit.ToString();
            ApplicationPeakMemoryUsage.Text = DeviceStatus.ApplicationPeakMemoryUsage.ToString();
            IsKeyboardPresent.Text = DeviceStatus.IsKeyboardPresent.ToString();
            IsKeyboardDeployed.Text = DeviceStatus.IsKeyboardDeployed.ToString();
            PowerSource.Text = DeviceStatus.PowerSource.ToString();
            DeviceStatus.PowerSourceChanged += new EventHandler(DeviceStatus_PowerSourceChanged);
            DeviceStatus.KeyboardDeployedChanged += new EventHandler(DeviceStatus_KeyboardDeployedChanged);

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void DeviceStatus_KeyboardDeployedChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(() => IsKeyboardDeployed.Text = DeviceStatus.IsKeyboardDeployed.ToString());
        }

        void DeviceStatus_PowerSourceChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(() => PowerSource.Text = DeviceStatus.PowerSource.ToString());
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}