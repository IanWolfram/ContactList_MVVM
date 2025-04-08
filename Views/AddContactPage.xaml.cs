using ContactList_MVVM.ViewModels;

namespace ContactList_MVVM.Views
{
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage(AddContactViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}