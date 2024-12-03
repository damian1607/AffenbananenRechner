using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using AffenbananenRechner.Pages;
using iNKORE.UI.WPF.Modern.Common.IconKeys;
using iNKORE.UI.WPF.Modern.Controls;
using Page = iNKORE.UI.WPF.Modern.Controls.Page;

namespace AffenbananenRechner.Viewmodels {
    internal class MainVm : INotifyPropertyChanged {

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Binding Variablen
        private Page currentPage;
        public Page CurrentPage {
            get { return currentPage; }
            set {
                if (currentPage != value) {
                    currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }

        private NavigationViewItem? selectedNavItem;
        public NavigationViewItem? SelectedNavItem {
            get { return selectedNavItem; }
            set {
                if (selectedNavItem != value) {
                    selectedNavItem = value;
                    OnPropertyChanged(nameof(SelectedNavItem));
                    updatePage();
                }
            }
        }

        private HomePage homePage = new();
        private SettingsPage settingsPage = new();


        // Konstruktor
        public MainVm(Window window, NavigationView navigationView) {
            currentPage = homePage;
            selectedNavItem = navigationView.MenuItems.OfType<NavigationViewItem>().FirstOrDefault(item => item.Content.ToString() == "Home");
        }

        //Page im Frame updaten
        private void updatePage() {
            if (selectedNavItem.Content.ToString() == "Home") {
                CurrentPage = homePage;
            }
            else if (selectedNavItem.Content.ToString() == "Einstellungen") {
                CurrentPage = settingsPage;
            }
        }

    }
}
