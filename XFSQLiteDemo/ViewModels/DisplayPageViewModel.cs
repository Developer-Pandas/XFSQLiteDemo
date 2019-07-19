using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using XFSQLiteDemo.Interfaces;

namespace XFSQLiteDemo.ViewModels
{
    public class DisplayPageViewModel : ViewModelBase
    {
        private IPageDialogService _pageDialogService;
        private INavigationService _navigationService;
        private Isqlite _sqlite { get; }

        public SQLiteConnection conn;
        public List<Registration> Registrations;

        public DisplayPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, Isqlite sqlite)
            : base(navigationService)
        {

            Title = "Details Page";

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _sqlite = sqlite;
            conn = _sqlite.GetConnection();
            conn.CreateTable<Registration>();
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            DisplayDetails();
        }

        private async void DisplayDetails()
        {
            var details = (from x in conn.Table<Registration>() select x).ToList();
            await _pageDialogService.DisplayAlertAsync("asdas", details.Count.ToString(), "K.");
            Registrations = details;
        }
    }
}
