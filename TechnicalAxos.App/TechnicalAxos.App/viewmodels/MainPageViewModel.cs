using Autofac;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TechnicalAxos.App.helpers;
using TechnicalAxos.App.models;
using TechnicalAxos.App.repositories;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TechnicalAxos.App.viewmodels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region [ Commands ]
        public ICommand pickFromGalleryCommand { get; set; }
        #endregion

        #region [ Variables ]
        private readonly UnitOfWork _unitOfWork;

        public ServiceRepository serviceRepo { get; }
        #endregion

        #region [ Properties ]
        private ImageSource _imageSource;

        public ImageSource ImageSource 
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        private string _bundleID;

        public string BundleID
        {
            get { return _bundleID; }
            set { SetProperty(ref _bundleID, value); }
        }

        private ObservableCollection<CountryData> _countriesList;

        public ObservableCollection<CountryData> CountriesList
        {
            get { return _countriesList; }
            set { SetProperty(ref _countriesList, value); }
        }
        #endregion

        #region [ Constructor ]
        public MainPageViewModel()
        {
            _unitOfWork = new UnitOfWork();

            ImageSource = "https://random.dog/af70ad75-24af-4518-bf03-fec4a997004c.jpg";
            
            BundleID = AppInfo.PackageName;

            pickFromGalleryCommand = new Command(async () => await PickFromGalleryCommandExecuteAsync());

            _unitOfWork.ServiceRepo.CountrySuccess += CountrySuccessEvent;
            _unitOfWork.ServiceRepo.CountryError += CountryErrorEvent;

            GetCountries();          
        }

        private async void GetCountries()
        {
            await _unitOfWork.ServiceRepo.GetCountries();
        }

        private async void CountryErrorEvent(object sender, string e)
        {
            await App.ContextApp.DisplayAlert("Información", e, "Aceptar");
        }

        private void CountrySuccessEvent(object sender, List<CountryData> e)
        {
            _unitOfWork.ServiceRepo.CountrySuccess -= CountrySuccessEvent;
            _unitOfWork.ServiceRepo.CountryError -= CountryErrorEvent;

            CountriesList = new ObservableCollection<CountryData>(e);
        }
        #endregion

        #region [ Commands ]
        private async Task PickFromGalleryCommandExecuteAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    string imagePath = result.FullPath;
                    ImageSource = ImageSource.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
