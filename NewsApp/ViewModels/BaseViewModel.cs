using CommunityToolkit.Mvvm.ComponentModel;

namespace NewsApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        //[ObservableProperty]
        //string title;

        //[ObservableProperty]
        //double pageOpacity = 1;

        public bool IsNotBusy => !IsBusy;
    }
}
