using System;
using Xamarin.Forms;

namespace MyContacts
{
	public class ImageResourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return ImageSource.FromUri(new Uri("https://tmssl.akamaized.net//images/portrait/header/" + (value ?? "")));
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}

