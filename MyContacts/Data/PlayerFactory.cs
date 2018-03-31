using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyContacts
{   
	public static class PlayerFactory
	{
		public static IList<Person> Players { get; private set; }

        public static IEnumerable<Person> GetPlayer()
        {
            yield return new Person
            {
                Name = "Souza",
                HeadshotUrl = "73741-1473554668.jpg?lm=1473554751",
                Position = "Midfield",
                Dob = new DateTime(1989, 2, 11),
                IsFavorite = false,
                Jersey = 7
            };
            yield return new Person
            {
                Name = "Jermaine Lens",
                HeadshotUrl = "38497-1473555279.jpg?lm=1473555301",
                Position = "Midfield",
                Dob = new DateTime(1987, 10, 24),
                IsFavorite = false,
                Jersey = 8
            };
            yield return new Person
            {
                Name = "Miroslav Stoch",
                HeadshotUrl = "45559-1473555016.jpg?lm=1473555042",
                Position = "Midfield",
                Dob = new DateTime(1989, 10, 19),
                IsFavorite = false,
                Jersey = 9
            };
            yield return new Person
            {
                Name = "Moussa Sow",
                HeadshotUrl = "22382-1473555184.jpg?lm=1473555202",
                Position = "Forward",
                Dob = new DateTime(1986, 01, 19),
                IsFavorite = false,
                Jersey = 10
            };
            yield return new Person
            {
                Name = "Robin van Persie",
                HeadshotUrl = "4380-1473555404.jpg?lm=1473555436",
                Position = "Forward",
                Dob = new DateTime(1983, 9, 6),
                IsFavorite = false,
                Jersey = 11
            };
        }

		static PlayerFactory()
		{
            Players = new List<Person>
                             {
                                 new Person
                                     {
                                         Name = "Volkan Demirel",
                                         HeadshotUrl = "7079-1473554155.jpg?lm=1473554223",
                                         Position = "Keeper",
                                         Dob = new DateTime(1981, 11, 27),
                                         IsFavorite = false,
                    Jersey = 1
                                     },
                                 new Person
                                     {
                                         Name = "Simon Kjaer",
                                         HeadshotUrl = "48859-1473554328.jpg?lm=1473554361",
                                         Position = "Defender",
                                         Dob = new DateTime(1989, 3, 26),
                    IsFavorite = true,
                    Jersey = 2
                                     },
                                 new Person
                                     {
                                         Name = "Martin Skrtel",
                                         HeadshotUrl = "24180-1473554340.jpg?lm=1473554385",
                                         Position = "Defender",
                                         Dob = new DateTime(1984, 12, 15),
                    IsFavorite = true,
                    Jersey = 3
                                     },
                new Person
                            {
                                Name = "Hasan Ali Kaldirim",
                                HeadshotUrl = "55605-1473554474.jpg?lm=1473554515",
                                Position = "Defender",
                                Dob = new DateTime(1989, 12, 9),
                    IsFavorite = true,
                    Jersey = 4
                            },

                new Person
            {
                Name = "Sezer Ozbayrakli",
                HeadshotUrl = "169873-1473554503.jpg?lm=1473554574",
                Position = "Defender",
                Dob = new DateTime(1990, 01, 23),
                    IsFavorite = false,
                    Jersey = 5
            },

            new Person
            {
                Name = "Mehmet Topal",
                HeadshotUrl = "44402-1473554660.jpg?lm=1473554723",
                Position = "Defensive Midfield",
                Dob = new DateTime(1986, 3, 3),
                    IsFavorite = false,
                    Jersey = 6
                }
            };
		}
	}
}

