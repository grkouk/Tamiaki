using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using Tamiaki.DataAccess;
using Tamiaki.Helpers;
using Tamiaki.Models;

namespace Tamiaki.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private readonly DatabaseContext _context;
        private readonly IPageDialogService _dialogService;
        private readonly IDbPath _dbPath;
        private string _dbPathValue;

        public ProductPageViewModel(INavigationService navigationService, DatabaseContext context, IPageDialogService dialogService) : base(navigationService)
        {
            _context = context;
            _dialogService = dialogService;
            //_dbPath = dbPath;
            //_dbPathValue = dbPath.GetDbPath();
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
                var n = new CashRegCategory()
                {
                    Id = "Cat_2",
                    Name = "Category 1 Name"
                };
                _context.CashRegCategories.Add(n);
               var ret= await _context.SaveChangesAsync();
               await _dialogService.DisplayAlertAsync("Looks Ok ", ret.ToString(), "Ok");
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
