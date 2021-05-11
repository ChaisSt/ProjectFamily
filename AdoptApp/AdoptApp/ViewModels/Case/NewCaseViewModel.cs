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
    public class NewCaseViewModel : INotifyPropertyChanged
    {
        private Case _case { get; set; }
        public Case child
        {
            get { return _case; }
            set
            {
                _case = value;
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

        public Command btnSaveCase { get; set; }
        public Command btnClearCase { get; set; }

        public NewCaseViewModel()
        {
            child = new Case();
            child.CaseWorkerId = "";
            child.CaseNum = "";
            //child.Pic = "";
            child.Description = "";
            child.Group = 0;
            child.Name = "";
            child.Age = "";
            child.Gender = "";
            child.State = "";
            child.Race = "";
            child.Language = "";
            child.Bio = "";
            child.Interests = "";

            lblInfo = "";
            btnSaveCase = new Command(SaveCase);
            btnClearCase = new Command(ClearCase);
        }

        public void SaveCase()
        {

            try
            {
                AdoptDatabase adoptDatabase = new AdoptDatabase();
                int i = adoptDatabase.SaveCase(child).Result;

                if (i == 1)
                {
                    ClearCase();
                    lblInfo = "Case Saved Successfully.";
                }
                else
                    lblInfo = "Cannot Save Case Information";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void ClearCase()
        {
            child = new Case
            {
                CaseWorkerId = "",
                CaseNum = "",
                //Pic = "",
                Description = "",
                Group = 0,
                Name = "",
                Age = "",
                Gender = "",
                State = "",
                Race = "",
                Language = "",
                Bio = "",
                Interests = ""
            };
            lblInfo = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}