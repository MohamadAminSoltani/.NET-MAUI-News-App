using CommunityToolkit.Mvvm.ComponentModel;

namespace NewsApp.Models
{
    public partial class Category : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isSelected = false;

    }
}
