namespace ContactsApp.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        // Navigate back to the parent page
        Shell.Current.GoToAsync("..");
    }
}