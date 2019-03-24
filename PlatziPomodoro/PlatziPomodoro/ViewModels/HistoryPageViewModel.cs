using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using PlatziPomodoro.Helpers;
using Xamarin.Forms;

namespace PlatziPomodoro.ViewModels
{
    public class HistoryPageViewModel : NotificationObject
    {
        private ObservableCollection<DateTime> pomodoros;

        #region Fields

        #endregion

        #region Properties

        public ObservableCollection<DateTime> Pomodoros
        {
            get => pomodoros;
            set
            {
                pomodoros = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public HistoryPageViewModel()
        {
            LoadHistory();
        }

        #endregion

        #region Methods

        private void LoadHistory()
        {
            if (Application.Current.Properties.ContainsKey(Literals.History ))
            {
                var json = Application.Current.Properties[Literals.History].ToString();
                var history = JsonConvert.DeserializeObject<List<DateTime>>(json);

                Pomodoros = new ObservableCollection<DateTime>(history);
            }
        }

        #endregion
    }
}
