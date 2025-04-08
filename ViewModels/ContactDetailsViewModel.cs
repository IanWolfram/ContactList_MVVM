using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ContactList_MVVM.ViewModels
{
    [QueryProperty(nameof(Contact), "Contact")]
    public partial class ContactDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Contact contact;

        [ObservableProperty]
        private bool isEditing;

        private ContactsViewModel contactsViewModel;
        private Contact originalContact;

        public ContactDetailsViewModel(ContactsViewModel viewModel)
        {
            contactsViewModel = viewModel;
            IsEditing = false;
        }

        partial void OnContactChanged(Contact value)
        {
            if (value != null)
            {
                originalContact = value;
                // Create a copy of the contact to avoid modifying the original directly during editing
                Contact = new Contact
                {
                    Name = value.Name,
                    Email = value.Email,
                    Phone = value.Phone,
                    Description = value.Description
                };
            }
        }

        [RelayCommand]
        void EnableEditing()
        {
            IsEditing = true;
        }

        [RelayCommand]
        async Task SaveChanges()
        {
            if (string.IsNullOrWhiteSpace(Contact.Name) || string.IsNullOrWhiteSpace(Contact.Email))
            {
                await Shell.Current.DisplayAlert("Error", "Name and Email are required", "OK");
                return;
            }

            contactsViewModel.UpdateContact(originalContact, Contact);
            IsEditing = false;

            // Update the original contact reference
            originalContact = Contact;

            await Shell.Current.DisplayAlert("Success", "Contact updated successfully", "OK");
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}