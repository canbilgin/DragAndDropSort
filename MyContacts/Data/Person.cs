using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyContacts
{
    public class PersonNameComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Person obj)
        {
            throw new NotImplementedException();
        }
    }

    public class Person : INotifyPropertyChanged
	{
        private string name;

        private string position;

        private DateTime dob;

        private Gender gender;

        private bool isFavorite;

        private int _jersey;

		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		public string HeadshotUrl { get; set; }

		public string Name { 
			get { return name; }
			set { SetProperty(ref name, value);	}
		}
		
		public string Position
        {
            get { return position; }
            set { SetProperty(ref position, value); }
        }
		
		public DateTime Dob {
			get { return dob; }
			set { SetProperty(ref dob, value);	}
		}

		public Gender Gender {
			get { return gender; }
			set { SetProperty(ref gender, value); }
		}
		
		public bool IsFavorite {
			get { return isFavorite; }
			set { SetProperty(ref isFavorite, value); }
		}

        public int Jersey
        {
            get { return _jersey; }
            set { SetProperty(ref _jersey, value); }
        }

		/// <summary>
		/// Method to compare and replace a field's value and raise a 
		/// PropertyChanged notification if it was altered.
		/// </summary>
		/// <returns><c>true</c>, if field was set, <c>false</c> otherwise.</returns>
		/// <param name="field">Field.</param>
		/// <param name="value">Value.</param>
		/// <param name="propertyName">Property name.</param>
		/// <typeparam name="T">Field type.</typeparam>
		bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "") 
		{
			if (!object.Equals(field, value)) {
				field = value;
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}
			return false;
		}

		public override string ToString()
		{
		    return this.Name;
		}

        internal void LoadData(Person item)
        {
            Position = item.Position;
            Dob = item.Dob;
            Gender = item.Gender;
            Jersey = item.Jersey;
            IsFavorite = item.IsFavorite;
            HeadshotUrl = item.HeadshotUrl;
        }

        internal Person Clone()
        {
            var target = new Person();
            target.Name = Name;
            target.LoadData(this);

            return target;
        }
    }
    
}
