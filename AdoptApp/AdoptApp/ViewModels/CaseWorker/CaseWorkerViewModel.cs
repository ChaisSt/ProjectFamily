using AdoptApp.Database;
using AdoptApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AdoptApp.ViewModels
{
        public class CaseWorkerViewModel : INotifyPropertyChanged
        {
            public Command BtnNewWorker { get; set; }

            private string _lblInfo { get; set; }
            public string LblInfo
            {
                get { return _lblInfo; }
                set
                {
                    _lblInfo = value;
                    OnPropertyChanged();
                }
            }

            public CaseWorkerViewModel()
            {

            }

            public void GetCaseWorker()
            {
                
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        }
    }