using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AffenbananenRechner.Pages;
using iNKORE.UI.WPF.Modern;

namespace AffenbananenRechner.Viewmodels {
    internal class SettingsPageVm : INotifyPropertyChanged {

        SettingsPage settingsPage;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Commands

        //Binding Variablen
        private bool isDarkModeEnabled;
        public bool IsDarkModeEnabled {
            get { return isDarkModeEnabled; }
            set {
                if (isDarkModeEnabled != value) {
                    isDarkModeEnabled = value;
                    OnPropertyChanged(nameof(IsDarkModeEnabled));
                    switchTheme();
                }
            }
        }

        //Konstruktor
        public SettingsPageVm(SettingsPage page) {
            settingsPage = page;
            isDarkModeEnabled= true;
            CreateCommandBindings();
        }

        private void CreateCommandBindings() {
        }

        // Command Funktionen
        private void switchTheme() {
            if (isDarkModeEnabled) {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            }
            else {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
            }
        }
    }
}
