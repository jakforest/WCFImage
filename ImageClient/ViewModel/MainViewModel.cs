using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ImageClient.Interfaces;
using ImageDataLibrary.Models;
using System.Collections.ObjectModel;

namespace ImageClient.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IDataService dataService, INavigationService navigationService)
            : base(dataService, navigationService)
        {
            _dataService.GetImageList((list, error) =>
            {
                if (error != null)
                {
                    // log error 
                    return;
                }
                ImageList = new ObservableCollection<ImageItem>(list);
            });
        }

        #region Bindable properties
        private ObservableCollection<ImageItem> _imageList;
        public ObservableCollection<ImageItem> ImageList
        {
            get { return _imageList; }
            set
            {
                if (_imageList == value)
                    return;
                _imageList = value;
                RaisePropertyChanged(() => ImageList);
            }
        }
        #endregion

        #region Commands
        private RelayCommand<Guid> _openImage;
        public RelayCommand<Guid> OpenImage
        {
            get { return _openImage ?? (_openImage = new RelayCommand<Guid>(OpenImageExecute)); }
        }

        private void OpenImageExecute(Guid imageId)
        {
            _navigationService.NavigateTo(PageEnum.ViewImagePage, imageId);
        }
    }
    #endregion
}

