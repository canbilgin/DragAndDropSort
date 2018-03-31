using System;
using Xamarin.Forms;

namespace MyContacts
{
	/// <summary>
	/// Simple converter to take a DateTime and calculate how many years old it represents.
	/// </summary>
	public class BirthdayConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DateTime bday = (DateTime)value;
			DateTime today = DateTime.Today;
			int age = today.Year - bday.Year;
			return (bday > today.AddYears(-age)) ? age-1 : age;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
    }
}

