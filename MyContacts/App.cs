using Xamarin.Forms;
using System.Linq;

namespace MyContacts
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new AllContacts());
        }
    }
}
