using System.Collections.ObjectModel;
using ContactList_MVVM.Views;
using ContactList_MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace ContactList_MVVM
{
    public partial class App : Application
    {
        public static ObservableCollection<Contact> ContactsCollection { get; } = new ObservableCollection<Contact>();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AddContactPage
            {
                BindingContext = new AddContactViewModel(ContactsCollection) 
            });
        }

        private void OnShellNavigated(object sender, ShellNavigatedEventArgs args)
        {
            if (MainPage is NavigationPage navigationPage &&
                navigationPage.CurrentPage is AddContactPage addContactPage &&
                addContactPage.BindingContext is AddContactViewModel addContactViewModel)
            {
                addContactViewModel.SetNavigation(navigationPage.Navigation);
            }
        }
    }
}
