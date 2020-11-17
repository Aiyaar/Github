using System.Threading.Tasks;
using PropertyChanged;
using MvvmHelpersBaseViewModel = MvvmHelpers.BaseViewModel;

namespace Github.ViewModels
{
    // Using this attribute from PropertyChanged.Fody takes care of all the INPC stuff for you. It will inject INPC code for all public properties at compile-time.
    // Much more simple source code that will do that exact thing that you had before.
    // See the PropertyChanged.Fody docs for more info. You can also do other cool stuff like [DependsOn(nameof(SomeOtherProperty))] to trigger/chain property change notifications.
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel : MvvmHelpersBaseViewModel
    {
        //Converter
        // Instead of using an inverted bool properties like this, it's better practice to use a converter: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/data-binding/converters
        public bool IsnotBusy => !IsBusy;

        // This method will be called by BasePage.OnAppearing()
        public virtual async Task OnAppearing()
        {
            await Task.CompletedTask;
        }
    }
}
