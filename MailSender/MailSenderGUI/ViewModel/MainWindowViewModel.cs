using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SpamLib;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace MailSenderGUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataAccessService _DataAccessService;

        private string _Title = "Заголовок окна";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public ObservableCollection<Recipient> Recipients { get; private set; }
        public ObservableCollection<Shedule> Shedules { get; private set; }

        private Recipient _CurrentRecipient;
        private Sender _CurrentSender;

        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        public Sender CurrentSender
        {
            get => _CurrentSender;
            set => Set(ref _CurrentSender, value);
        }

        public ICommand UpdateDataShedCommand { get; }

        public ICommand UpdateDataCommand { get; }

        public ICommand CreateNewRecipient { get; }

        public ICommand UpdateRecipient { get; }

        public MainWindowViewModel(IDataAccessService DataAccessService)
        {
            _DataAccessService = DataAccessService;

            UpdateDataShedCommand = new RelayCommand(OnUpdateDataShedCommandExecuted, UpdateDataShedCommandCanExecute);

            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, UpdateDataCommandCanExecute);

            CreateNewRecipient = new RelayCommand<Recipient>(OnCreateNewRecipientExecuted, CreateNewRecipientCanExecute);
            UpdateRecipient = new RelayCommand<Recipient>(OnUpdateRecipientExecuted, UpdateRecipientCanExecute);
        }

        private void OnUpdateDataShedCommandExecuted()
        {
            Shedules = _DataAccessService.GetShedules();
            RaisePropertyChanged(nameof(this.Shedules));
        }

        public bool UpdateDataShedCommandCanExecute() => true;

        private void OnUpdateDataCommandExecuted()
        {
            Recipients = _DataAccessService.GetRecipients();
            RaisePropertyChanged(nameof(this.Recipients));
        }

        public bool UpdateDataCommandCanExecute() => true;

        private bool CreateNewRecipientCanExecute(Recipient recipient) => recipient != null;

        private void OnCreateNewRecipientExecuted(Recipient recipient)
        {
            CurrentRecipient = new Recipient();
        }

        private bool UpdateRecipientCanExecute(Recipient recipient) => recipient != null; // || _CurrentRecipient != null;

        private void OnUpdateRecipientExecuted(Recipient recipient)
        {
            if (_DataAccessService.CreateRecipient(recipient) > 0)
                Recipients.Add(recipient);
        }

    }
}
