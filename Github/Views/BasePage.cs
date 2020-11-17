using MvvmHelpers;
using Xamarin.Forms;
using BaseViewModel = Github.ViewModels.BaseViewModel; // this is done because MvvmHelpers also contains a BaseVieModel.

namespace Github.Views
{
    public abstract class BasePage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        public TViewModel ViewModel => BindingContext as TViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.OnAppearing().SafeFireAndForget(); // SafeFireAndForget() is the safe way to fire off async code within the body of a non-async (synchronous?) void method.
        }
    }
}