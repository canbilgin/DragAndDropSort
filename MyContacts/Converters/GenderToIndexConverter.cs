using System;
using Xamarin.Forms;
using System.Globalization;

namespace MyContacts
{
	public class GenderToIndexConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Gender gender = (Gender)value;
			if (targetType != typeof(int))
				throw new Exception("GenderConverter.Convert expected integer targetType.");
			return (int)gender;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int index = (int)value;
			if (targetType != typeof(Gender))
				throw new Exception("GenderConverter.ConvertBack expected Gender targetType");
			return (Gender)index;
		}
	}

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
		return (bday > today.AddYears(-age)) ? age - 1 : age;
	}

	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		throw new NotImplementedException();
	} }
}

