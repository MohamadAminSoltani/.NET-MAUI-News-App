using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsApp.Models;

namespace NewsApp.ViewModels
{
    public partial class NewsDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        Article article;

        public NewsDetailsViewModel()
        {

        }
       
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }

        [RelayCommand]
        async Task ShareNews()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = Article.Content,
                Title = Article.Title
            });
        }

        [RelayCommand]
        async Task BookmarkArticle()
        {
            await App.NewsRepository.AddNewArticle(Article);

            await Shell.Current.DisplayAlert("Success", $"{Article.Title} has been added to db", "OK");
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var data = query.FirstOrDefault();
            Article = data.Value as Article;
        }
    }
}
