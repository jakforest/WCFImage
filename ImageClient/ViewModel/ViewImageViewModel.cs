using GalaSoft.MvvmLight.Command;
using ImageClient.Interfaces;
using ImageDataLibrary.Models;
using System;
using System.ComponentModel;

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
                          {
                              ImageData = _image.FullImageData;
                              ImageName = _image._imageName;
                              CanSave = false;
                          }
                      }));
                }
                else
                {
                    _image = new FullImage { _id = guid };
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
                SetCanSave();
            }
        }

        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                if (_imageName == value)
                    return;
                _imageName = value;
                RaisePropertyChanged(() => ImageName);
                SetCanSave();
            }
        }

        private void SetCanSave()
        {
            CanSave = !string.IsNullOrWhiteSpace(ImageName) && (ImageData != null);
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

        private bool _canSave = false;
        private bool CanSave
        {
            get { return _canSave; }
            set
            {
                if (_canSave == value)
                    return;
                _canSave = value;
                SaveImage.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand _saveImage;
        public RelayCommand SaveImage
        {
            get
            {
                return _saveImage ??
                  (_saveImage = new RelayCommand(SaveImageExecute, new Func<bool>(() => { return CanSave; })));
            }
        }

        private void SaveImageExecute()
        {
            CanSave = false;
            if (_image != null)
            {
                _image.FullImageData = ImageData;
                _image._imageName = ImageName;
                if (_image._id == Guid.Empty)
                {
                    _image._imageName = "NewImage";
                    if (_dataService.CreateImage(_image))
                        _navigationService.GoBack();
                }
                else
                {
                    if (_dataService.UpdateImage(_image))
                        _navigationService.GoBack();
                }
            }
        }
        #endregion
    }
}
