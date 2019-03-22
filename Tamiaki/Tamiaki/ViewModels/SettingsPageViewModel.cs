using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Prism.Navigation;

namespace Tamiaki.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private static ISettings AppSettings => CrossSettings.Current;
        private readonly INavigationService _navigationService;
      

        public SettingsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
        public static string WebApiBaseAddress
        {
            get => AppSettings.GetValueOrDefault(nameof(WebApiBaseAddress), "http://api.villakoukoudis.com/api");
            set => AppSettings.AddOrUpdateValue(nameof(WebApiBaseAddress), value);
        }
        public static string ClientProfileId    
        {
            get => AppSettings.GetValueOrDefault(nameof(ClientProfileId), "TAM01");
            set => AppSettings.AddOrUpdateValue(nameof(ClientProfileId), value);
        }
        public static string ClientProfileName
        {
            get => AppSettings.GetValueOrDefault(nameof(ClientProfileName), "Kiosk Θάσος");
            set => AppSettings.AddOrUpdateValue(nameof(ClientProfileName), value);
        }
        public static string ClientSerial
        {
            get => AppSettings.GetValueOrDefault(nameof(ClientSerial), "0");
            set => AppSettings.AddOrUpdateValue(nameof(ClientSerial), value);
        }

        private string _clientProfSerial;
        public string ClientProfSerial
        {
            get
            {
                _clientProfSerial = ClientSerial;
                return _clientProfSerial;
            }
            set
            {
                ClientSerial = value;
                SetProperty(ref _clientProfSerial, value);
            }
        }

        private string _clientProfName;
        public string ClientProfName
        {
            get
            {
                _clientProfName = ClientProfileName;
                return _clientProfName;
            }
            set
            {
                ClientProfileName = value;
                SetProperty(ref _clientProfName, value);
            }
        }


        private string _clientProfId;
        public string ClientProfId
        {
            get
            {
                _clientProfId = ClientProfileId;
                return _clientProfId;
            }
            set
            {
                ClientProfileId = value;
                SetProperty(ref _clientProfId, value);
            }
        }
    }
}
