using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using api.model;
using api.stackexchange.com.Common;
using System.Threading.Tasks;

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
        private string requestString;
        private string responseString;
        private ICommand run;
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
        public string InTitle { get => inTitle;set=> Set(ref inTitle, value); }
        public string RequestString { get => requestString; set => Set(ref requestString, value); }
        public string ResponseString { get => responseString;set=> Set(ref responseString, value); }
        public ICommand Run => run ?? (run = new AsyncRelayCommand(RunMethod));
        public ICommand Save => save ?? (save = new RelayCommand(SaveMethod));
        public ICommand Clear => clear ?? (clear = new RelayCommand(ClearMethod));

        private async Task RunMethod(){
            ApiBase api = new ApiBase("https://api.stackexchange.com/2.3/questions?order=desc&sort=activity&site=stackoverflow");
            ResponseString =await api.SendAsync();

        }

        private void SaveMethod() { 
        
        }
        private void ClearMethod() { 
        
        }


        public MainViewModel()
        {
        }
    }
}