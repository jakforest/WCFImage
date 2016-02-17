using GalaSoft.MvvmLight.Command;
using ImageClient.Interfaces;
using ImageDataLibrary.Models;
using System;

namespace ImageClient.ViewModel
{
    public class ViewImageViewModel : BaseViewModel
    {
        private FullImage _image;
        public ViewImageViewModel(IDataService dataService, INavigationService navigationService)
            : base(dataService, navigationService)
        { }

        public override void OnNavigating(object parameter)
        {
            base.OnNavigating(parameter);
            if ((parameter != null) && (parameter is Guid))
            {
                Guid guid = (Guid)parameter;
                if (guid != Guid.Empty)
                {
                    _dataService.GetImage(guid, new Action<FullImage, Exception>((image, ex) =>
                      {
                          _image = image;
                          if (_image != null)
                              ImageData = _image.FullImageData;
                      }));
                }
                else
                {

                }
            }
            else
            {
                GoBack.Execute(null);
            }
        }

        #region bindable properties
        private byte[] _imageData;
        public byte[] ImageData
        {
            get { return _imageData; }
            set
            {
                if (_imageData == value)
                    return;
                _imageData = value;
                RaisePropertyChanged(() => ImageData);
            }
        }
        #endregion

        #region Command
        private RelayCommand _goBack;
        public RelayCommand GoBack
        {
            get { return _goBack ?? (_goBack = new RelayCommand(GoBackExecute)); }
        }

        private void GoBackExecute()
        {
            _image = null;
            ImageData = null;
            _navigationService.GoBack();
        }
        #endregion
    }
}
