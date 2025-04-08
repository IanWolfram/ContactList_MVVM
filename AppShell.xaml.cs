namespace ContactList_MVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.ContactDetailsPage), typeof(Views.ContactDetailsPage));
        }
    }
}