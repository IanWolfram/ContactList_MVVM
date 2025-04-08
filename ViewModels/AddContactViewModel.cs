using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ContactList_MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string description;

        private ContactsViewModel contactsViewModel;

        public AddContactViewModel(ContactsViewModel viewModel)
        {
            contactsViewModel = viewModel;
        }

        [RelayCommand]
        async Task SaveContact()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                await Shell.Current.DisplayAlert("Error", "Name and Email are required", "OK");
                return;
            }

            var newContact = new Contact
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Description = Description
            };

            contactsViewModel.AddNewContact(newContact);

            // Clear the fields
            Name = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Description = string.Empty;

            // Navigate to Contacts page
            await Shell.Current.GoToAsync("///ContactsPage");
        }
    }
}