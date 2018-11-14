using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PersonLib;
using PersonLib.Data;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace Person.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _DataAccessService;

        private ObservableCollection<People> _Peoples;
        public ObservableCollection<People> Peoples
        {
            get => _Peoples;
            set => Set(ref _Peoples, value);
        }

        private People _SelectedPeople;
        public People SelectedPeople
        {
            get => _SelectedPeople;
            set => Set(ref _SelectedPeople, value);
        }

        public ICommand UpdateDataCommand { get; }
        public ICommand AddDataCommand { get; }
        public ICommand SaveDataCommand { get; }
        public ICommand OpenFileCommand { get; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService DataService)
        {
            _DataAccessService = DataService;

            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, UpdateDataCommandCanExecute);
            AddDataCommand = new RelayCommand(OnAddDataCommandExecuted);
            SaveDataCommand = new RelayCommand(OnSaveDataCommandExecuted, SaveDataCommandCanExecute);
            OpenFileCommand = new RelayCommand(OnOpenFileCommand);
        }

        private bool UpdateDataCommandCanExecute() => true;

        private async void OnUpdateDataCommandExecuted()
        {
            Peoples = await _DataAccessService.GetPersonsAsync();
            RaisePropertyChanged(nameof(Peoples));
        }

        private void OnAddDataCommandExecuted()
        {
            SelectedPeople = new People();
            Peoples.Add(SelectedPeople);
        }

        private bool SaveDataCommandCanExecute() => false;

        private async void OnSaveDataCommandExecuted()
        {
            SelectedPeople.Id = await _DataAccessService.SavePersonAsync(SelectedPeople);
        }

        private async void OnOpenFileCommand()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string filePath = "";
            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] s = sr.ReadLine().Split(',');
                        People temp = new People
                        {
                            FullName = s[0],
                            Email = s[1],
                            TelNumber = s[2]
                        };
                        if ((temp.Id = await _DataAccessService.SavePersonAsync(temp)) > 0)
                        {
                            Peoples.Add(temp);
                        }
                    }
                }
            }
            else return;
        }
    }
}