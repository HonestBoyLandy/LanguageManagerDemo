using LanguageManagerTest.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace LanguageManagerTest.Manager
{
    public class LanguageManager : ObservableObject, ILanguageService
    {
        //public static ILanguageService Default = new LanguageManager();

        // LanguageManager.Default[nameof(Resources.xxx)]

        private readonly ResourceManager _resourceManager = LanguageManagerTest.Resource.Resources.ResourceManager;

        public List<CultureInfo> SupportedLanguages { get; private set; }

        private CultureInfo _selectedLanguage;
        public CultureInfo SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (SetProperty(ref _selectedLanguage, value))
                {
                    OnPropertyChanged("Item[]");

                    Properties.Settings.Default.SelectedLanguage = SelectedLanguage.Name;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public string this[string name]
        {
            get { return _resourceManager.GetString(name, SelectedLanguage); }
        }

        public LanguageManager()
        {
            SupportedLanguages = new List<CultureInfo>
            {
                new CultureInfo("zh-CN"),
                new CultureInfo("en-US")
            };

            var selectedLanguage = Thread.CurrentThread.CurrentUICulture;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.SelectedLanguage))
            {
                selectedLanguage = new CultureInfo(Properties.Settings.Default.SelectedLanguage);
            }

            SelectedLanguage = selectedLanguage;
        }
    }
}
