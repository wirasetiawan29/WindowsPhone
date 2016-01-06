using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using alarm_reminder.Resources;
using Microsoft.Phone.Scheduler;

namespace alarm_reminder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        private void AlarmButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ScheduledActionService.Find("newalarm") != null)
                ScheduledActionService.Remove("newalarm");

            Alarm a = new Alarm("newalarm");
            a.Content = "Wira Setiawan Alarm";
            //a.Sound = new Uri("aaa.mp3", UriKind.Relative);
            a.BeginTime = DateTime.Now.AddSeconds(15);
            a.ExpirationTime = DateTime.Now.AddDays(7);
            a.RecurrenceType = RecurrenceInterval.Daily;

            ScheduledActionService.Add(a);
        }

        private void ReminderButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ScheduledActionService.Find("newreminder") != null)
                ScheduledActionService.Remove("newreminder");

            Reminder r = new Reminder("newreminder");
            r.Title = "Reminder";
            r.Content = "Wira Setiawan Reminder";
            r.BeginTime = DateTime.Now.AddSeconds(15);
            r.ExpirationTime = DateTime.Now.AddDays(7);
            r.RecurrenceType = RecurrenceInterval.Daily;

            ScheduledActionService.Add(r);
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