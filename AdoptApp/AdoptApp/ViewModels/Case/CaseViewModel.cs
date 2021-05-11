using AdoptApp.Database;
using AdoptApp.Models;
using AdoptApp.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdoptApp.ViewModels
{
    public class CaseViewModel : BaseViewModel, INotifyPropertyChanged 
    {
        private Case _selectedCase;

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

        public Command LoadCasesCommand { get; }
        public Command AddCaseCommand { get; }
        public Command<Case> CaseTapped { get; }
        public CaseViewModel()
        {
            lstCases = new ObservableCollection<Case>();
            LoadCasesCommand = new Command(async () => await ExecuteLoadCasesCommand());

            CaseTapped = new Command<Case>(OnCaseSelected);
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

        async Task ExecuteLoadCasesCommand()
        {
            try
            {
                lstCases.Clear();
                AdoptDatabase caseDatabase = new AdoptDatabase();
                var cases = await caseDatabase.GetCases();
                foreach (var child in cases)
                {
                    lstCases.Add(child);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void OnAppearing()
        {
            SelectedCase = null;
        }

        public Case SelectedCase
        {
            get => _selectedCase;
            set
            {
                SetProperty(ref _selectedCase, value);
                OnCaseSelected(value);
            }
        }

        async void OnCaseSelected(Case child)
        {
            if (child == null)
                return;

            // This will push the CaseDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(EmptyCase)}?{nameof(CaseDetailViewModel.Id)}={child.CaseId}");
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