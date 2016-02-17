using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageClient.Interfaces
{
    public interface INavigationService : GalaSoft.MvvmLight.Views.INavigationService
    {
        //
        void NavigateTo(PageEnum pageKey);
        void NavigateTo(PageEnum pageKey, object parameter);
    }

    public enum PageEnum
    {
        None,
        MainPage,
        ViewImagePage
    }
}
