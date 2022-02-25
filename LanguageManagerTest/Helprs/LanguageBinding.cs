using LanguageManagerTest.Manager;
using LanguageManagerTest.Services;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LanguageManagerTest.Helprs
{
    public class LanguageBinding : Binding
    {
        private static ILanguageService _languageService;

        public LanguageBinding(string name)
            : base($"[{name}]")
        {
            if (_languageService == null)
            {
                if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                {
                    _languageService = new LanguageManager();
                }
                else
                {
                    _languageService = Ioc.Default.GetService<ILanguageService>();
                }
            }

            Source = _languageService;
        }

        //public LanguageBinding(string name)
        //    : base($"[{name}]")
        //{
        //    Source = LanguageManager.Default;
        //}
    }
}
