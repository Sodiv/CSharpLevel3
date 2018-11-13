using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PersonLib;
using PersonLib.Data;
using System;
using System.Collections.ObjectModel;
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

        public ICommand UpdateDataCommand { get; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService DataService)
        {
            _DataAccessService = DataService;

            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, UpdateDataCommandCanExecute);
        }

        private bool UpdateDataCommandCanExecute() => true;

        private void OnUpdateDataCommandExecuted()
        {
            Peoples = _DataAccessService.GetPersons();
            RaisePropertyChanged(nameof(this.Peoples));
        }
    }
}