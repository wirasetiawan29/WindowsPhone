using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLiteSampleApp.ViewModel;
using SQLiteSampleApp.Model;
using SQLite;

namespace SQLiteSampleApp.Views
{
    public partial class AddContact : PhoneApplicationPage
    {

        public AddContact()
        {
            InitializeComponent();
        }

        private async void AddContact_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs
            if (NametxtBx.Text != "" & NimtxtBx.Text != "")
            {
                Db_Helper.Insert(new Contacts(NametxtBx.Text, NimtxtBx.Text));//
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));//after add contact redirect to contact listbox page
            }
            else
            {
                MessageBox.Show("Please fill two fields");//Text should not be empty
            }
        }
    }
}