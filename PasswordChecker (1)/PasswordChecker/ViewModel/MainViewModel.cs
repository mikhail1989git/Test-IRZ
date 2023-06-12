using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PasswordChecker.Classes;
using System.Windows.Input;

namespace PasswordChecker.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string inputText;
        private string outputText;
        private ICommand checkLine;
        public string Input { get=> inputText; set=>Set(ref inputText, value); }
        public string Output { get => outputText; set=>Set(ref outputText, value); }
        public ICommand CheckLine => checkLine ?? (checkLine = new RelayCommand(()=>Output = new Checker().Check(Input)));


        public MainViewModel()
        {
        }
    }
}