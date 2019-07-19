using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFSQLiteDemo.Interfaces;
using XFSQLiteDemo.Views;

namespace XFSQLiteDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public IPageDialogService _pageDialogService;
        public INavigationService _navigationService;
        public Isqlite _sqlite;

        public SQLiteConnection conn;
        public Registration regmodel;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public DateTime DOB { get; set; }
        public DelegateCommand SignUpCommand { get; set; }
        public DelegateCommand DisplayDataCommand { get; set; }
        
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, Isqlite sqlite)
            : base(navigationService)
        {
            Title = "Main Page";
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            _sqlite = sqlite;
            conn = _sqlite.GetConnection();
            conn.CreateTable<Registration>();

            SignUpCommand = new DelegateCommand(SignUp);
            DisplayDataCommand = new DelegateCommand(async()=> await DisplayData());
        }

        private async Task DisplayData()
        {
            await  _navigationService.NavigateAsync(nameof(DisplayPage));
        }

        private void SignUp()
        {
            Registration reg = new Registration();
            reg.FirstName = FirstName;
            reg.LastName = LastName;
            reg.Dob = DOB.Date.ToString();
            reg.Email = Email;
            reg.Password = Password;
            reg.Address = Address;
            int x = 0;
            try
            {
                x = conn.Insert(reg);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (x == 1)
            {

                _pageDialogService.DisplayAlertAsync("Registration", "Thanks for Registration", "Cancel");
            }
            else
            {
                _pageDialogService.DisplayAlertAsync("Registration Failled!!!", "Please try again", "ERROR");
            }
        }
    }
}
