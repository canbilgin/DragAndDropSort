using Xamarin.Forms;

namespace MyContacts
{
    public partial class ContactDetails : ContentPage
    {
		public ContactDetails(Person person)
        {
			BindingContext = person;
            InitializeComponent();
        }
    }
}
