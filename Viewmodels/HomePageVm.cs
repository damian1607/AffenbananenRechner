using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AffenbananenRechner.Pages;
using iNKORE.UI.WPF.Modern.Common.IconKeys;
using iNKORE.UI.WPF.Modern.Controls;
using Page = iNKORE.UI.WPF.Modern.Controls.Page;

namespace AffenbananenRechner.Viewmodels {
    internal class HomePageVm : INotifyPropertyChanged {

        HomePage homePage;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // Commands
        public ICommand CommandCalculate { get; }
        public ICommand CommandClear { get; }
        public ICommand CommandAddSymbol { get; }

        //Binding Variablen
        private string calcText;
        public string CalcText {
            get { return calcText; }
            set {
                if (calcText != value) {
                    calcText = value;
                    OnPropertyChanged(nameof(CalcText));
                }
            }
        }

        //Konstruktor
        public HomePageVm(HomePage page) {
            homePage = page;
            CommandCalculate = new RoutedUICommand("", "CommandCalculate", typeof(MainVm));
            CommandClear = new RoutedUICommand("", "CommandClear", typeof(MainVm));
            CommandAddSymbol = new RoutedUICommand("", "CommandAddSymbol", typeof(MainVm));
            CreateCommandBindings();
        }

        private void CreateCommandBindings() {
            homePage.CommandBindings.Add(new CommandBinding(CommandCalculate, calculateResult, canCalculate));
            homePage.CommandBindings.Add(new CommandBinding(CommandClear, clearCalcText, canCalculate));
            homePage.CommandBindings.Add(new CommandBinding(CommandAddSymbol, addSymbol));
        }

        // Command Funktionen
        private void calculateResult(object sender, ExecutedRoutedEventArgs e) {
            try {
                var result = new DataTable().Compute(CalcText.Replace(',', '.'), null);
                CalcText = result.ToString();
            }
            catch {
                CalcText = "Error";
            }
        }

        private void clearCalcText(object sender, ExecutedRoutedEventArgs e) {
            CalcText = string.Empty;
        }

        private void addSymbol(object sender, ExecutedRoutedEventArgs e) {
            string buttonParam = e.Parameter as string;
            CalcText += buttonParam;
        }

        // CanExecutes
        private void canCalculate(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !string.IsNullOrWhiteSpace(CalcText);
        }

    }
}
