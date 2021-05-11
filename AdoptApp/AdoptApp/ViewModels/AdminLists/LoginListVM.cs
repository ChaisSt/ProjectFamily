using AdoptApp.Database;
using AdoptApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AdoptApp.ViewModels
{
    class LoginListVM : INotifyPropertyChanged
    {
        private ObservableCollection<Login> _lstLogins { get; set; }

        public ObservableCollection<Login> lstLogins
        {
            get { return _lstLogins; }
            set
            {
                _lstLogins = value;
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

        public LoginListVM()
        {
            lstLogins = new ObservableCollection<Login>();
        }

        public void GetLogins()
        {
            try
            {
                AdoptDatabase adoptDB = new AdoptDatabase();
                var logins = adoptDB.GetLogins().Result;

                if (logins != null && logins.Count > 0)
                {
                    lstLogins = new ObservableCollection<Login>();

                    foreach (var login in logins)
                    {
                        lstLogins.Add(new Login
                        {
                            LoginId = login.LoginId,
                            UserName = login.UserName,
                            Password = login.Password,
                            AcctType = login.AcctType
                        });
                    }

                    lblInfo = "Total " + logins.Count.ToString() + " record(s) found";
                }
                else
                    lblInfo = "No login records found. Please add one";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
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