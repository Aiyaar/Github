using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace Github.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged     //This is the Base Class where we are declaring the OnpropertyChanged.
    {

        public BaseViewModel()
        {

        }

        //This Class is Inherited from INotifyPropertyChanged Class which give us
        bool isBusy = false;                                // acess to acess its properties.
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }             //Here i am declaring the Isbusy property for our need this is not included in or project.
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }                           //Same is the Title proeprty
            set { SetProperty(ref title, value); }
        }


        //Converter
        public bool IsnotBusy => !IsBusy;

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        //The main part is this fucntion which is every time called whenever som events occured,
        //Means by Change of state of any view this Onproperty Changed event is called.


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
