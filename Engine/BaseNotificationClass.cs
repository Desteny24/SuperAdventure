using System.ComponentModel;

namespace Engine
{
    public class BaseNotificationClass : INotifyPropertyChanged
    {
        /// <summary>
        /// Logic for automatic change in the UI when a property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}