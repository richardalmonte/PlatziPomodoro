using System.Collections.ObjectModel;
using System.Windows.Input;
using PlatziPomodoro.Helpers;
using Xamarin.Forms;

namespace PlatziPomodoro.ViewModels
{
    public class ConfigurationPageViewModel : NotificationObject
    {
        #region Fields

        private ObservableCollection<int> pomodoroDurations;
        private ObservableCollection<int> breakDuration;
        private int selectedPomodoroDuration;
        private int selectedBreakDuration;

        #endregion

        #region Properties

        public ObservableCollection<int> PomodoroDurations
        {
            get { return pomodoroDurations; }
            set
            {
                pomodoroDurations = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<int> BreakDurations
        {
            get { return breakDuration; }
            set
            {
                breakDuration = value;
                OnPropertyChanged();
            }
        }

        public int SelectedPomodoroDuration
        {
            get { return selectedPomodoroDuration; }
            set
            {
                selectedPomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        public int SelectedBreakDuration
        {
            get { return selectedBreakDuration; }
            set
            {
                selectedBreakDuration = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructors

        public ConfigurationPageViewModel()
        {
            LoadPomodoroDurations();
            LoadBreakDurations();
            LoadConfiguration();
            SaveCommand = new Command(SaveCommandExecute);
        }

        #endregion

        #region Methods

        private void LoadBreakDurations()
        {
            BreakDurations = new ObservableCollection<int>() { 1, 5, 10, 25 };
        }

        private void LoadPomodoroDurations()
        {
            PomodoroDurations = new ObservableCollection<int> { 1, 5, 10, 25 };
        }

        private void LoadConfiguration()
        {
            if (Application.Current.Properties.ContainsKey(Literals.PomodoroDuration))
            {
                SelectedPomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            }

            if (Application.Current.Properties.ContainsKey(Literals.BreakDuration))
            {
                SelectedBreakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
            }
        }

        private async void SaveCommandExecute()
        {
            Application.Current.Properties[Literals.PomodoroDuration] = SelectedPomodoroDuration;
            Application.Current.Properties["BreakDuration"] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }

        #endregion
    }
}
