using ContactsApp.Views;
namespace ContactsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
        }
    }
}