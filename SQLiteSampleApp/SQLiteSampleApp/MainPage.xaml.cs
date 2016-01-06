using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLiteSampleApp.Resources;
using SQLiteSampleApp.ViewModel;
using SQLiteSampleApp.Model;
using System.Collections.ObjectModel;

namespace SQLiteSampleApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<Contacts> DB_ContactList = new ObservableCollection<Contacts>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += ReadContactList_Loaded;  

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void ReadContactList_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllContactsList dbcontacts = new ReadAllContactsList();
            DB_ContactList = dbcontacts.GetAllContacts();//Get all DB contacts
            listBoxobj.ItemsSource = DB_ContactList.OrderByDescending(i => i.Id).ToList();//Latest contact ID can Display first
        }

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxobj.SelectedIndex != -1)
            {
                Contacts listitem = listBoxobj.SelectedItem as Contacts;//Get slected listbox item contact ID
                NavigationService.Navigate(new Uri("/Views/Delete_UpdateContacts.xaml?SelectedContactID=" + listitem.Id, UriKind.Relative));
            }
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
            Db_Helper.DeleteAllContact();//delete all DB contacts
            DB_ContactList.Clear();//Clear collections
            listBoxobj.ItemsSource = DB_ContactList;
        }
        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AddContact.xaml", UriKind.Relative));
        }
    }
}