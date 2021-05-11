using AdoptApp.Database;
using AdoptApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AdoptApp.ViewModels
{
    class FamilyListVM : INotifyPropertyChanged
    {
        private ObservableCollection<Family> _lstFams { get; set; }

        public ObservableCollection<Family> lstFams
        {
            get { return _lstFams; }
            set
            {
                _lstFams = value;
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

        public FamilyListVM()
        {
            lstFams = new ObservableCollection<Family>();
        }

        public void GetFamilies()
        {
            try
            {
                AdoptDatabase adoptDB = new AdoptDatabase();
                var fams = adoptDB.GetFamilies().Result;

                if (fams != null && fams.Count > 0)
                {
                    lstFams = new ObservableCollection<Family>();

                    foreach (var fam in fams)
                    {
                        lstFams.Add(new Family
                        {
                            FamilyId = fam.FamilyId,
                            UserName = fam.UserName,
                            Password = fam.Password
                        });
                    }

                    lblInfo = "Total " + fams.Count.ToString() + " record(s) found";
                }
                else
                    lblInfo = "No family records found. Please add one";
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
