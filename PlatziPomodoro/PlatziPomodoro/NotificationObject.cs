using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlatziPomodoro
{
    public abstract class NotificationObject : INotifyPropertyChanged
    {

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
