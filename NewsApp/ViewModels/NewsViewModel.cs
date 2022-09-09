using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsApp.Models;
using NewsApp.Services;
using NewsApp.Views;
using System.Collections.ObjectModel;

namespace NewsApp.ViewModels
{
    public partial class NewsViewModel : BaseViewModel
    {
        private INewsApiService _newsApiService;
        [ObservableProperty]
        string activeCategory;

        [ObservableProperty]
        ObservableCollection<Category> firstCategories;

        [ObservableProperty]
        ObservableCollection<Category> secondCategories;

        public ObservableCollection<Article> SavedArticles { get; set; } = new();

        public ObservableCollection<Article> Articles { get; private set; } = new();

        public NewsViewModel(INewsApiService newsService)
        {
            _newsApiService = newsService;

            GenerateCategories();
            ActiveCategory = "breaking-news";

            _ = GetArticlesFromDb();

            _ = GetNews();
        }

        private void GenerateCategories()
        {
            FirstCategories = new ObservableCollection<Category>()
            {
                new Category(){Title="breaking-news",IsSelected=true},
                new Category(){Title="world",IsSelected=false},
                new Category(){Title="technology",IsSelected=false},
                new Category(){Title="nation",IsSelected=false},
                new Category(){Title="business",IsSelected=false}
            };

            secondCategories = new ObservableCollection<Category>()
            {
                new Category(){Title="sports",IsSelected=false},
                new Category(){Title="science ",IsSelected=false},
                new Category(){Title="entertainment",IsSelected=false},
                new Category(){Title="health ",IsSelected=false}
            };
        }

        [RelayCommand]
        async void SelectCategory(Category category)
        {
            ActiveCategory = category.Title;
            DisableOtherCategories(category);

            await GetNews();
        }
        void DisableOtherCategories(Category selectedCategory)
        {
            foreach (var category in FirstCategories)
            {
                if (category != selectedCategory)
                {
                    category.IsSelected = false;
                }
                else
                {
                    category.IsSelected = true;
                }
            }

            foreach (var category in SecondCategories)
            {
                if (category != selectedCategory)
                {
                    category.IsSelected = false;
                }
                else
                {
                    category.IsSelected = true;
                }
            }
        }

        [RelayCommand]
        async Task GetNews()
        {
            IsBusy = true;
            var _news = await _newsApiService.GetNewsAsync(ActiveCategory);

            if (_news != null)
            {
                Articles.Clear();
                foreach (var article in _news.Articles)
                {
                    Articles.Add(article);
                }
            }

            IsBusy = false;
        }

        [RelayCommand]
        async Task GoToDetailsPage(Article article)
        {
            if (article is null)
                return;

            await Shell.Current.GoToAsync(nameof(NewsDetailsPage), true, new Dictionary<string, object>
            {
                {"Article", article }
            });
        }

        [RelayCommand]
        async Task GetArticlesFromDb()
        {
            var dbArticles = await App.NewsRepository.GetAllArticles();
            if(dbArticles is not null)
            {
                SavedArticles.Clear();
                foreach (var item in dbArticles)
                {
                    SavedArticles.Add(item);
                }
            }
        }
    }
}
