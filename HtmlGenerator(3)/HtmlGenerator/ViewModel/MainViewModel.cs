using GalaSoft.MvvmLight;
using HtmlGenerator.Common;
using Services;
using Services.Common;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HtmlGenerator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string result;
        ICommand open;
        ICommand save;

        public string Result { get => result; set => Set(ref result, value); }
        public ICommand Open => open ?? (open = new AsyncRelayCommand(OpenMethod));
        public ICommand Save => save ?? (save = new AsyncRelayCommand(SaveMethod));


        private async Task OpenMethod(){

            var generator = new ObjectToHtmlGenerator();

            Result = await generator.Generate(await ReadFile.ReadAsync().ConfigureAwait(false));
        }

        private async Task SaveMethod() { 
            await SaveToFile.SaveFileAsync(Result).ConfigureAwait(false);
        }

        public MainViewModel()
        {
        }
    }
}