using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace PlatziPomodoro.ViewModels
{
    public class RootPageViewModel : NotificationObject
    {
        #region Fields

        private ObservableCollection<string> menuItems;
        private string selectedMenuItem;
        #endregion

        #region Properties

        public ObservableCollection<string> MenuItems
        {
            get { return menuItems; }
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }

        public string SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                selectedMenuItem = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public RootPageViewModel()
        {
            MenuItems = new ObservableCollection<string>
            {
                "Pomodoro",
                "History",
                "Configuration"
            };

            PropertyChanged += RootPageViewModel_PropertyChanged;
        }
        #endregion

        #region Methods

        private void RootPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(SelectedMenuItem))
            {
                if (SelectedMenuItem == "Configuration")
                {
                    MessagingCenter.Send(this, "GoToConfiguration");
                }

                if (SelectedMenuItem == "History")
                {
                    MessagingCenter.Send(this, "GoToHistory");
                }

                if (SelectedMenuItem == "Pomodoro")
                {
                    MessagingCenter.Send(this, "GoToPomodoro");
                }
            }
        }

        #endregion
    }
}
