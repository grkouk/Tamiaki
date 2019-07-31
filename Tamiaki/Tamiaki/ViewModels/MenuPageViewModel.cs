using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Tamiaki.Helpers;
using Tamiaki.Views;
using Tamiaki.Models;
using Xamarin.Forms;

namespace Tamiaki.ViewModels
{
    public class MenuPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        public ObservableCollection<MyMenuItem> MenuItems { get; set; }
        private MyMenuItem _selectedMenuItem;
        public MyMenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }

        public DelegateCommand NavigateCommand { get; private set; }

        public MenuPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MenuItems = new ObservableCollection<MyMenuItem>();

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_viewa",
                PageName = nameof(MainPage),
                Title = "Home"
            });

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_viewb",
                PageName = nameof(ScannerPage),
                Title = "Scan Code"
            });
            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_viewb",
                PageName = nameof(ProductPage),
                Title = "Products Test"
            });
            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_viewb",
                PageName = nameof(ProductListPage),
                Title = "Product List"
            });
            MenuItems.Add(new MyMenuItem()
            {
                Icon = "ic_viewb",
                PageName = nameof(SettingsPage),
                Title = "Settings"
            });

            NavigateCommand = new DelegateCommand(Navigate);
        }
        async void Navigate()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
           // await _navigationService.NavigateAsync( SelectedMenuItem.PageName);

        }
    }
}
