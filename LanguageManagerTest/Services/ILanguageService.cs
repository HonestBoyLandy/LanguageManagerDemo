using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageManagerTest.Services
{
    public interface ILanguageService
    {
        string this[string name] { get; }

        List<CultureInfo> SupportedLanguages { get; }
        CultureInfo SelectedLanguage { get; set; }
    }
}
