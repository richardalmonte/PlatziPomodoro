using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Newtonsoft.Json;
using PlatziPomodoro.Helpers;
using Xamarin.Forms;

namespace PlatziPomodoro.ViewModels
{
    public class PomodoroPageViewModel : NotificationObject
    {
        #region Fields

        private TimeSpan elapsed;
        private Timer timer;
        private bool isRunning;
        private bool isInBreak;
        private int pomodoroDuration;
        private int breakDuration;
        private int duration;

        #endregion

        #region Properties

        public TimeSpan Elapsed
        {
            get { return elapsed; }
            set
            {
                elapsed = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartOrPauseCommand { get; set; }

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                isRunning = value;
                OnPropertyChanged();
            }
        }

        public bool IsInBreak
        {
            get => isInBreak;
            set
            {
                isInBreak = value;
                OnPropertyChanged();
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public PomodoroPageViewModel()
        {
            InitializeTimer();
            LoadConfiguredValues();
            StartOrPauseCommand = new Command(StartOrPauseCommandExecute);
        }

        #endregion

        #region Methods

        private void InitializeTimer()
        {
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Elapsed += Timer_Elapsed;
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Elapsed = Elapsed.Add(TimeSpan.FromSeconds(1));

            if (IsRunning && Elapsed.TotalSeconds == pomodoroDuration * 60)
            {
                isRunning = false;
                IsInBreak = true;
                Elapsed = TimeSpan.Zero;

                await SavePomodoroAsync();
            }

            if (IsInBreak && Elapsed.TotalSeconds == breakDuration * 60)
            {
                IsRunning = true;
                IsInBreak = false;
                Elapsed = TimeSpan.Zero;
            }
        }

        private void StartTimer()
        {
            timer.Start();
            IsRunning = true;
        }

        private void StopTimer()
        {
            timer.Stop();
            IsRunning = false;
        }


        private void StartOrPauseCommandExecute()
        {
            if (IsRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        private void LoadConfiguredValues()
        {
            pomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            breakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
            Duration = pomodoroDuration * 60;
        }

        private async Task SavePomodoroAsync()
        {
            List<DateTime> history;
            if (Application.Current.Properties.ContainsKey(Literals.History))
            {
                var json = Application.Current.Properties[Literals.History].ToString();
                history = JsonConvert.DeserializeObject<List<DateTime>>(json);
            }
            else
            {
                history = new List<DateTime>();
            }
            history.Add(DateTime.Now);

            Application.Current.Properties[Literals.History] = JsonConvert.SerializeObject(history);

            await Application.Current.SavePropertiesAsync();
        }
        #endregion
    }
}
