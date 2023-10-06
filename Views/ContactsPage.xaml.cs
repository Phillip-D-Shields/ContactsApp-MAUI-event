using System.Collections.ObjectModel;
using Contact = ContactsApp.Models.Contact;
using ContactRepository = ContactsApp.Models.ContactRepository;


namespace ContactsApp.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
		
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        listContacts.ItemsSource = contacts;
    }


    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }
}