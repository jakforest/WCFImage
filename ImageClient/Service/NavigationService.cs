using GalaSoft.MvvmLight.Ioc;
using ImageClient.Interfaces;
using ImageClient.Pages;
using ImageClient.ViewModel;
using System;
using System.Windows.Controls;

namespace ImageClient.Service
{
    public class NavigationService : INavigationService
    {
        private PageEnum _currentPage;
        private Frame _rootFrame;

        public string CurrentPageKey
        {
            get
            {
                return _currentPage.ToString();
            }
        }

        public void GoBack()
        {
            if (EnsureRootFrame())
                _rootFrame.GoBack();
        }

        private bool EnsureRootFrame()
        {
            if (_rootFrame == null)
            {
                MainWindow mw = System.Windows.Application.Current.MainWindow as MainWindow;
                if (mw != null)
                    _rootFrame = mw.RootFrame;
            }
            return _rootFrame != null;
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            PageEnum pageKeyEnum;
            Enum.TryParse(pageKey, out pageKeyEnum);
            NavigateTo(pageKeyEnum, parameter);
        }

        public void NavigateTo(PageEnum pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(PageEnum pageKey, object parameter)
        {
            if (EnsureRootFrame())
            {
                BaseViewModel vm = null;
                switch (pageKey)
                {
                    case PageEnum.ViewImagePage:
                        _rootFrame.Navigate(new ViewImagePage());
                        vm = SimpleIoc.Default.GetInstance<ViewImageViewModel>();
                        break;
                    case PageEnum.MainPage:
                    case PageEnum.None:
                    default:
                        _rootFrame.Navigate(new MainPage());
                        vm = SimpleIoc.Default.GetInstance<MainViewModel>();
                        break;
                }
                if (vm != null)
                    vm.OnNavigating(parameter);
            }
        }
    }
}
