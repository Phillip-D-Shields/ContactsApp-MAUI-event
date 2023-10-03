using ContactsApp.Models;
using Contact = ContactsApp.Models.Contact;

namespace ContactsApp.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		// Navigate back to the parent page
		Shell.Current.GoToAsync("..");
    }

	public string ContactId
	{
		set
		{
            contact = ContactRepository.GetContact(int.Parse(value));
			if (contact != null)
			{
                entryName.Text = contact.Name;
                entryEmail.Text = contact.Email;
                entryPhone.Text = contact.Phone;
                entryAddress.Text = contact.Address;
            }

        }
	}
}