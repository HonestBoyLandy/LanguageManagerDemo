using DialogUtils;
using LanguageManagerTest.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace LanguageManagerTest
{
    class MainViewModel : ObservableObject
    {
        private const string MainDialogHostIdentifier = "MainHost";
        private IDialogHostService _dialogHostService;
        public ILanguageService LanguageService { get; private set; }

        private ICommand _showMessageCommand;
        public ICommand ShowMessageCommand => _showMessageCommand ?? (_showMessageCommand = new RelayCommand(ShowMessageImpl));
        private async void ShowMessageImpl()
        {
            await _dialogHostService.ShowMessageAsync(
                dialogIdentifier: MainDialogHostIdentifier,
                message: $"{LanguageService["Message"]}",
                isNegativeButtonVisible: false);
        }

        public MainViewModel(IDialogHostService dialogHostService, ILanguageService languageService)
        {
            _dialogHostService = dialogHostService;
            LanguageService = languageService;
        }
    }
}
