using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace Tamiaki.ViewModels
{
    public class ProductListPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ProductListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
