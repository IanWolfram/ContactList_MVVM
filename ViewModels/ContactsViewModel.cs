using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ContactList_MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Contact> contacts;

        [ObservableProperty]
        private Contact selectedContact;

        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
        }

        [RelayCommand]
        async Task AddContact()
        {
            await Shell.Current.GoToAsync("///AddContactPage");
        }

        [RelayCommand]
        async Task ShowContactDetails(Contact contact)
        {
            if (contact == null)
                return;

            SelectedContact = contact;

            var navigationParameter = new Dictionary<string, object>
            {
                { "Contact", contact }
            };

            await Shell.Current.GoToAsync("ContactDetailsPage", navigationParameter);
        }

        public void AddNewContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void UpdateContact(Contact oldContact, Contact updatedContact)
        {
            var index = Contacts.IndexOf(oldContact);
            if (index != -1)
            {
                Contacts[index] = updatedContact;
            }
        }
    }
}