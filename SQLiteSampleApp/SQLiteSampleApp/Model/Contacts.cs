using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteSampleApp.Model
{
    public class Contacts : INotifyPropertyChanged
    {
       
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        //The Id property is marked as the Primary Key
        private int idValue;
        private string NameValue = String.Empty;
        //private string companyNameValue = String.Empty;
        private string nimNumberValue = String.Empty;
        public string Name
        {
            get { return this.NameValue; }

            set
            {
                if (value != this.NameValue)
                {
                    this.NameValue = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public string NimNumber
        {
            get { return this.nimNumberValue; }

            set
            {
                if (value != this.nimNumberValue)
                {
                    this.nimNumberValue = value;
                    NotifyPropertyChanged("NimNumber");
                }
            }
        }
        
        public string CreationDate {
            get; set; 
        }
        public Contacts()
        {
        }
        public Contacts(string name,string nim_no)
        {
            Name = name;
            NimNumber = nim_no;
            CreationDate = DateTime.Now.ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    } 
}
