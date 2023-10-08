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
                contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;
                contactCtrl.Phone = contact.Phone;
                contactCtrl.Address = contact.Address;
            }

        }
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

        contact.Name = contactCtrl.Name;
		contact.Email = contactCtrl.Email;
		contact.Phone = contactCtrl.Phone;
		contact.Address = contactCtrl.Address;

		ContactRepository.UpdateContact(contact.ContactId, contact);
		Shell.Current.GoToAsync("..");
    }

	private void contactCtrl_OnError(object sender, string e)
	{
        DisplayAlert("Error", e, "OK");
    }
}