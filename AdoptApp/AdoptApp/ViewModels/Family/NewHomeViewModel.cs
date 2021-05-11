using AdoptApp.Database;
using AdoptApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AdoptApp.ViewModels
{
    public class NewHomeViewModel : INotifyPropertyChanged
    {

        private Home _home { get; set; }
        public Home home
        {
            get { return _home; }
            set
            {
                _home = value;
                OnPropertyChanged();
            }
        }

        private string _lblInfo { get; set; }
        public string lblInfo
        {
            get { return _lblInfo; }
            set
            {
                _lblInfo = value;
                OnPropertyChanged();
            }
        }

        public Command btnSaveHome { get; set; }
        public Command btnClearHome { get; set; }

        //private string username;
        //private string address;
        //private string type;
        //private string owned;
        //private string bedrooms;
        //private string yard;
        //private string yardType;
        //private string additional;

        public NewHomeViewModel()
        {
            home = new Home();
            home.UserName = "";
            home.Address = "";
            home.Type = "";
            home.Owned = "";
            home.Bedrooms = 0;
            home.Yard = "";
            home.YardType = "";
            home.Additional = "";
            lblInfo = "";
            btnSaveHome = new Command(SaveHome);
            btnClearHome = new Command(ClearHome);
        }

        public void SaveHome()
        {
            try
            {
                AdoptDatabase adoptDatabase = new AdoptDatabase();
                int i = adoptDatabase.SaveHome(home).Result;

                if (i == 1)
                {
                    ClearHome();
                    lblInfo = "Home Saved Successfully.";
                }
                else
                    lblInfo = "Cannot Save Home Information";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void ClearHome()
        {
            home = new Home();
            home.UserName = "";
            home.Address = "";
            home.Type = "";
            home.Owned = "";
            home.Bedrooms = 0;
            home.Yard = "";
            home.YardType = "";
            home.Additional = "";
            lblInfo = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
