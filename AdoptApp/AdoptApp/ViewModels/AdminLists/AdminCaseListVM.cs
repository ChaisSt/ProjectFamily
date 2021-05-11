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
    class AdminCaseListVM : INotifyPropertyChanged
    {

        private ObservableCollection<Case> _lstCases { get; set; }

        public ObservableCollection<Case> lstCases
        {
            get { return _lstCases; }
            set
            {
                _lstCases = value;
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

        public AdminCaseListVM()
        {
            lstCases = new ObservableCollection<Case>();
        }

        public void GetCases()
        {
            try
            {
                AdoptDatabase caseDatabase = new AdoptDatabase();
                var cases = caseDatabase.GetCases().Result;

                if (cases != null && cases.Count > 0)
                {
                    lstCases = new ObservableCollection<Case>();

                    foreach (var child in cases)
                    {
                        lstCases.Add(new Case
                        {
                            CaseNum = child.CaseNum,
                            Pic = child.Pic,
                            Description = child.Description,
                            Group = child.Group,
                            Name = child.Name,
                            Age = child.Age,
                            Gender = child.Gender,
                            State = child.State,
                            Race = child.Race,
                            Language = child.Language,
                            Bio = child.Bio,
                            Interests = child.Interests
                        });
                    }

                    lblInfo = "Total " + cases.Count.ToString() + " record(s) found";
                }
                else
                    lblInfo = "No case records found. Please add one";
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
