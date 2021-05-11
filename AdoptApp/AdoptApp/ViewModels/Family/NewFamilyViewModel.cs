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
    class NewFamilyViewModel : INotifyPropertyChanged
    {
        private Login _login { get; set; }
        public Login login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private Family _family { get; set; }
        public Family family
        {
            get { return _family; }
            set
            {
                _family = value;
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

        public Command btnSaveFamily { get; set; }
        public Command btnClearFamily { get; set; }

        public NewFamilyViewModel()
        {
            family = new Family();
            family.UserName = "";
            family.Password = "";
            family.Email = "";

            family.License = "";
            family.Agency = "";

            family.Pic = "";
            family.Name = "";
            family.Occupation = "";
            family.Languages = "";
            family.Phone = "";
            family.City = "";
            family.State = "";
            family.Children = "";
            family.Pets = "";

            family.Description = "";
            family.Bio = "";
            family.Interests = "";

            

            lblInfo = "";
            btnSaveFamily = new Command(SaveFamily);
            btnClearFamily = new Command(ClearFamily);
        }

        public void SaveFamily()
        {
            login = new Login();
            login.AcctType = "Family";
            login.UserName = family.UserName;
            login.Password = family.Password;
            try
            {
                AdoptDatabase adoptDatabase = new AdoptDatabase();
                int i = adoptDatabase.SaveFamily(family).Result;
                int l = adoptDatabase.SaveLogin(login).Result;

                if (i == 1 && l == 1)
                {
                    ClearFamily();
                    lblInfo = "User Saved Successfully.";
                }
                else
                    lblInfo = "Cannot Save User";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void ClearFamily()
        {
            family = new Family();
            family.UserName = "";
            family.Password = "";
            family.Email = "";

            family.License = "";
            family.Agency = "";

            family.Pic = "";
            family.Name = "";
            family.Occupation = "";
            family.Languages = "";
            family.Phone = "";
            family.City = "";
            family.State = "";
            family.Children = "";
            family.Pets = "";

            family.Description = "";
            family.Bio = "";
            family.Interests = "";

            login.AcctType = "";
            login.Password = "";
            login.UserName = "";

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
