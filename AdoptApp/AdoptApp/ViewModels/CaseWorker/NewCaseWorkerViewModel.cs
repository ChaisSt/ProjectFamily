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
    public class NewCaseWorkerViewModel : INotifyPropertyChanged
    {
        private CaseWorker _caseWorker { get; set; }
        public CaseWorker caseWorker
        {
            get { return _caseWorker; }
            set
            {
                _caseWorker = value;
                OnPropertyChanged();
            }
        }

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

        public Command btnSaveWorker { get; set; }
        public Command btnClearWorker { get; set; }

        public NewCaseWorkerViewModel()
        {
            caseWorker = new CaseWorker();
            caseWorker.CaseWorkerId = "";
            caseWorker.Agency = "";
            caseWorker.UserName = "";
            caseWorker.Password = "";
            caseWorker.Email = "";
            caseWorker.Name = "";
            caseWorker.City = "";
            caseWorker.State = "";

            lblInfo = "";
            btnSaveWorker = new Command(SaveCaseWorker);
            btnClearWorker = new Command(ClearCaseWorker);
        }

        public void SaveCaseWorker()
        {
            login = new Login();
            login.AcctType = "Worker";
            login.UserName = caseWorker.UserName;
            login.Password = caseWorker.Password;
            try
            {
                AdoptDatabase adoptDatabase = new AdoptDatabase();
                int i = adoptDatabase.SaveCaseWorker(caseWorker).Result;
                int l = adoptDatabase.SaveLogin(login).Result;

                if (i == 1 && l == 1)
                {
                    ClearCaseWorker();
                    lblInfo = "Caseworker Saved Successfully.";
                }
                else
                    lblInfo = "Cannot save Caseworker Information";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void ClearCaseWorker()
        {
            caseWorker = new CaseWorker();
            caseWorker.CaseWorkerId = "";
            caseWorker.Agency = "";
            caseWorker.UserName = "";
            caseWorker.Password = "";
            caseWorker.Email = "";
            caseWorker.Name = "";
            caseWorker.City = "";
            caseWorker.State = "";

            login = new Login();
            login.AcctType = "";
            login.UserName = "";
            login.Password = "";
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

