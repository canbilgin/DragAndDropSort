using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyContacts
{
    public interface IPlayerService
    {
        Task<IEnumerable<Person>> GetPlayersAsync();
    }

    public class PlayersService : IPlayerService
    {
        private List<Person> _contacts = new List<Person>();

        int callCount = 0;

        public Task<IEnumerable<Person>> GetPlayersAsync()
        {
            if (!_contacts.Any())
            {
                _contacts = new List<Person>(PlayerFactory.Players);
            }
            else
            {
                AddPlayer();
            }

            //_contacts[callCount++].Position += "-Updated";

            return Task.FromResult(new List<Person>(_contacts.Select(item=>item.Clone())) as IEnumerable<Person>);
        }

        IEnumerator<Person> _enumerator = null;

        private void AddPlayer()
        {
            if (_enumerator == null)
            {
                _enumerator = PlayerFactory.GetPlayer().GetEnumerator();
                _enumerator.MoveNext();
            }

            _contacts.Add(_enumerator.Current);

            //SetProperty(ref _allContacts, new List<Person>(AllContacts), nameof(AllContacts));

            _enumerator.MoveNext();
        }
    }

    public class AllContactsViewModel: ObservableObject
    {
        private ObservableListCollection<Person> _allContacts = new ObservableListCollection<Person>();

        private IEnumerable<IGrouping<string, Person>> _groupedContacts = null;

        private ObservableListGroupCollection<string, Person> _grouppedCollection = null;

        private PlayersService _service = new PlayersService();

        private Command _editCommand;

        private Command _updateCommand;

        private bool _allowOrdering;

        public IEnumerable<IGrouping<string, Person>> GroupedContacts { 
            get 
            { 
                return _groupedContacts; 
            } 
            set
            {
                SetProperty(ref _groupedContacts, value);
            }
        }

        public ObservableListGroupCollection<string, Person> GroupedCollection
        {
            get
            {
                return _grouppedCollection;
            }
            set
            {
                SetProperty(ref _grouppedCollection, value);
            }
        }

        public ObservableListCollection<Person> AllContacts
        {
            get
            {
                return _allContacts;
            }
            set
            {
                SetProperty(ref _allContacts, value);
            }
        }

        public bool AllowOrdering
        {
            get
            {
                return _allowOrdering;
            }
            set
            {
                SetProperty(ref _allowOrdering, value);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return _editCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand;
            }
        }

        public AllContactsViewModel()
        {
            _editCommand = new Command(() => { AllowOrdering = !AllowOrdering; });
            _updateCommand = new Command(async () => await UpdatePlayers());

            _allContacts = new ObservableListCollection<Person>(Enumerable.Empty<Person>(), new PersonNameComparer(), (person, update) =>
            {
                person.LoadData(update);
                return true;
            });

            _allContacts.OrderChanged += (sender, e) => {
                int jersey = 1;
                foreach(var item in _allContacts)
                {
                    item.Jersey = jersey++;
                }
            };

            _grouppedCollection = new ObservableListGroupCollection<string, Person>(
                Enumerable.Empty<Person>(),
                item => item.Position,
                new PersonNameComparer(),
                (person, update) =>
            {
                person.LoadData(update);
                return true;
            });

            UpdatePlayers().ConfigureAwait(false);
        }

        private async Task UpdatePlayers()
        {
            IEnumerable<Person> serviceResult = Enumerable.Empty<Person>();

            try
            {
                serviceResult = await _service.GetPlayersAsync();
            }
            catch(Exception ex)
            {
                // TODO:
            }

            if(serviceResult?.Any()??false)
            {
                _allContacts.UpdateRange(serviceResult);

                GroupedContacts = serviceResult.GroupBy(item => item.Position);
                GroupedCollection.UpdateItems(serviceResult);
                //var newItems = serviceResult.Where(item => !AllContacts.Any(contact => item.Name == contact.Name));

                //var updatedItems = serviceResult.Where(item => AllContacts.Any(contact => item.Name == contact.Name));

                //foreach (var updateItem in updatedItems)
                //{
                //    var existingItem = AllContacts.FirstOrDefault(contact => contact.Name == updateItem.Name);
                //    existingItem.LoadData(updateItem);
                //}

                //foreach(var item in newItems)
                //{
                //    AllContacts.Add(item);
                //}
            }
        }

        int updateCount = 0;

        private void UpdatePlayer()
        {
            AllContacts[updateCount].Position = AllContacts[updateCount].Position + "(Updated)";

            if (updateCount++ > 10)
            {
                updateCount = 0;
            }
        }
    }

    /// <summary>
    /// Observable object with INotifyPropertyChanged implemented
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        /// <param name="backingStore">Backing store.</param>
        /// <param name="value">Incoming new value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="onChanged">On changed.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected bool SetProperty<T>(
          ref T backingStore,
          T value,
          [CallerMemberName]string propertyName = "",
          Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
