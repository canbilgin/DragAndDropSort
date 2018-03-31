using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Threading;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MyContacts
{
	public partial class AllContacts : ContentPage
	{
		public AllContacts()
		{
			InitializeComponent();

            BindingContext = new AllContactsViewModel();

            allContacts.BindingContextChanged += (sender, e) => {
                var change = e;
            };

		}
	}
}
