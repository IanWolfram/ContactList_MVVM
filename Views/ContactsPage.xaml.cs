using ContactList_MVVM.ViewModels;

namespace ContactList_MVVM.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage(ContactsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}