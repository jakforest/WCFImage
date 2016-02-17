using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageClient.Interfaces;

namespace ImageClient.ViewModel
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected IDataService _dataService;
        protected INavigationService _navigationService;

        public BaseViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
        }

        public virtual void OnNavigating(object parameter)
        { }

    }
}
