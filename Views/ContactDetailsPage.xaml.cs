using ContactList_MVVM.ViewModels;

namespace ContactList_MVVM.Views
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage(ContactDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}