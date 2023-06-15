using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using api.model;
using api.stackexchange.com.Common;
using System.Threading.Tasks;
using Service;
using System.Windows.Media.Converters;

namespace api.stackexchange.com.ViewModel
{    public class MainViewModel : ViewModelBase
    {
        private string page;
        private string pageSize;
        private string fromDate;
        private string toDate;
        private string order;
        private string min;
        private string max;
        private string sort;
        private string tagged;
        private string notTagged;
        private string inTitle;
        private string site;
        private string requestStringParametersTab;
        private string requestStringStringTab;
        private string responseString;
        private ICommand runParametersTab;
        private ICommand runStringTab;
        private ICommand save;
        private ICommand clear;

        public string Page { get => page; set => Set(ref page, value); }
        public string PageSize { get => pageSize; set => Set(ref pageSize, value); }
        public string FromDate { get => fromDate; set => Set(ref fromDate, value); }
        public string ToDate { get => toDate;set=> Set(ref toDate, value); }
        public string Order { get => order;set=> Set(ref order, value); }
        public string Min { get => min;set=> Set(ref min, value); }
        public string Max { get => max;set=> Set(ref max, value); }
        public string Sort { get => sort;set=> Set(ref sort, value); }
        public string Tagged { get => tagged;set=> Set(ref tagged, value); }
        public string NotTagged { get => notTagged;set=> Set(ref notTagged, value); }
        public string InTitle { get => inTitle; set => Set(ref inTitle, value); }
        public string Site { get => site; set => Set(ref site, value); }
        public string RequestStringParametersTab { get => requestStringParametersTab; set => Set(ref requestStringParametersTab, value); }
        public string RequestStringStringTab { get => requestStringStringTab; set => Set(ref requestStringStringTab, value); }
        public string ResponseString { get => responseString;set=> Set(ref responseString, value); }
        public ICommand RunParametersTab => runParametersTab ?? (runParametersTab = new AsyncRelayCommand(RunMethodParametersTab));
        public ICommand RunStringTab => runStringTab ?? (runStringTab = new AsyncRelayCommand(RunMethodStringTab));
        public ICommand Save => save ?? (save = new AsyncRelayCommand(SaveMethod));
        public ICommand Clear => clear ?? (clear = new RelayCommand(ClearMethod));

        private async Task RunMethodParametersTab(){

            using (ApiBase api = new ApiBase("https://api.stackexchange.com/2.3/questions"))
            {
                RequestEntity request = new RequestEntity(page,pageSize,fromDate,toDate,order,min,max,sort,tagged,notTagged,inTitle, site);

                api.AddParameter(request);

                RequestStringParametersTab = api.Parameters;
                ResponseString = await api.SendAsync();
            }
        }

        private async Task RunMethodStringTab()
        {
            using (ApiBase api = new ApiBase(RequestStringStringTab))
            {
                ResponseString = await api.SendAsync();
            }
        }

        private async Task SaveMethod() {

            await SaveToFile.SaveFileAsync(ResponseString);

        }

        private void ClearMethod() {
            ResponseString = string.Empty;
        }

        public MainViewModel()
        {
            Site = "stackoverflow";
            RequestStringStringTab= "https://api.stackexchange.com/2.3/search?order=desc&sort=activity&intitle=beautiful&site=stackoverflow";
        }
    }
}