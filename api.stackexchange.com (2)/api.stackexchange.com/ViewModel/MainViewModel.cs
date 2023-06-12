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

namespace api.stackexchange.com.ViewModel
{    public class MainViewModel : ViewModelBase
    {
        private int page;
        private int pageSize;
        private DateTime fromDate;
        private DateTime toDate;
        private string order;
        private DateTime min;
        private DateTime max;
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

        public int Page { get => page; set => Set(ref page, value); }
        public int PageSize { get => pageSize; set => Set(ref pageSize, value); }
        public DateTime FromDate { get => fromDate; set => Set(ref fromDate, value); }
        public DateTime ToDate { get => toDate;set=> Set(ref toDate, value); }
        public string Order { get => order;set=> Set(ref order, value); }
        public DateTime Min { get => min;set=> Set(ref min, value); }
        public DateTime Max { get => max;set=> Set(ref max, value); }
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
                api.AddParameter("page", page.ToString());
                api.AddParameter("pageSize", pageSize.ToString());
                api.AddParameter("fromDate", fromDate);
                api.AddParameter("toDate", toDate);
                api.AddParameter("order", order);
                api.AddParameter("min", min);
                api.AddParameter("max", max);
                api.AddParameter("sort", sort);
                api.AddParameter("tagged", tagged);
                api.AddParameter("notTagged", notTagged);
                api.AddParameter("inTitle", inTitle);
                api.AddParameter("site", site);

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
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            Min = DateTime.Now;
            Max = DateTime.Now;
            RequestStringStringTab= "https://api.stackexchange.com/2.3/search?order=desc&sort=activity&intitle=beautiful&site=stackoverflow";
        }
    }
}