using Prism.Commands;
using System;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using Tamiaki.DataAccess;
using Tamiaki.Models;
using Tamiaki.Services;

namespace Tamiaki.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private readonly DatabaseContext _context;
        private readonly IPageDialogService _dialogService;
        private readonly ProductRepository _productRepository;
        private string _dbPathValue;

        public ProductPageViewModel(INavigationService navigationService, DatabaseContext context
            , IPageDialogService dialogService,ProductRepository productRepository) : base(navigationService)
        {
            _context = context;
            _dialogService = dialogService;
            _productRepository = productRepository;
            Title = "Προιόντα";
        }

        public string DbPathValue
        {
            get => _dbPathValue;
            set => SetProperty(ref _dbPathValue, value);
        }
        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(async () => await SaveDataCommand()));

        private async Task SaveDataCommand()
        {
            try
            {
                var li = await _productRepository.GetSyncProductsAsync();
                // await _dialogService.DisplayAlertAsync("Looks Ok ", ret.ToString(), "Ok");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await _dialogService.DisplayAlertAsync("Error", e.ToString(), "Ok");
                //throw;
            }

           

        }
    }
}
