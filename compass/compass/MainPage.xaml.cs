using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using compass.Resources;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace compass
{
    public partial class MainPage : PhoneApplicationPage
    {
        Compass compass;
        public MainPage()
        {
            InitializeComponent();

            if (Compass.IsSupported)
            {
                compass = new Compass();
                compass.TimeBetweenUpdates = TimeSpan.FromMilliseconds(1);
                compass.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<CompassReading>>(compass_CurrentValueChanged);
                compass.Start();
            }

        }

        void compass_CurrentValueChanged(object sender, SensorReadingEventArgs<CompassReading> e)
        {
            Dispatcher.BeginInvoke(() => UpdateUI(e.SensorReading));
        }

        private void UpdateUI(CompassReading compassReading)
        {
            magneticValue.Text = compassReading.MagneticHeading.ToString("0.00");
            trueValue.Text = compassReading.TrueHeading.ToString("0.00");

            magneticLine.X2 = magneticLine.X1 - (200 * Math.Sin(MathHelper.ToRadians((float)compassReading.MagneticHeading)));
            magneticLine.Y2 = magneticLine.Y1 - (200 * Math.Cos(MathHelper.ToRadians((float)compassReading.MagneticHeading)));

            xBlock.Text = "X: " + compassReading.MagnetometerReading.X.ToString("0.00");
            yBlock.Text = "Y: " + compassReading.MagnetometerReading.Y.ToString("0.00");
            zBlock.Text = "Z: " + compassReading.MagnetometerReading.Z.ToString("0.00");
        }
    }
}