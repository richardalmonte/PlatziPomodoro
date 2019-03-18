﻿using System.Collections.ObjectModel;
using System.Windows.Input;
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
            SaveCommand = new Command(SaveCommandExecute);
        }


        #endregion

        #region Methods


        private async void SaveCommandExecute()
        {
            Application.Current.Properties["PomodoroDuration"] = SelectedPomodoroDuration;
            Application.Current.Properties["BreakDuration"] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }

        #endregion
    }
}