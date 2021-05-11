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
    public class WorkerListVM : INotifyPropertyChanged
    {
        private ObservableCollection<CaseWorker> _lstWorkers { get; set; }

        public ObservableCollection<CaseWorker> lstWorkers
        {
            get { return _lstWorkers; }
            set
            {
                _lstWorkers = value;
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

        public WorkerListVM()
        {
            lstWorkers = new ObservableCollection<CaseWorker>();
        }

        public void GetWorkers()
        {
            try
            {
                AdoptDatabase adoptDB = new AdoptDatabase();
                var workers = adoptDB.GetCaseWorkers().Result;

                if (workers != null && workers.Count > 0)
                {
                    lstWorkers = new ObservableCollection<CaseWorker>();

                    foreach (var worker in workers)
                    {
                        lstWorkers.Add(new CaseWorker
                        {
                            WorkerId = worker.WorkerId,
                            UserName = worker.UserName,
                            Password = worker.Password,
                            Name = worker.Name
                        });
                    }

                    lblInfo = "Total " + workers.Count.ToString() + " record(s) found";
                }
                else
                    lblInfo = "No logins records found. Please add one";
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

