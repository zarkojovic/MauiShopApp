using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiIspitApp.Models;
using MauiIspitApp.Services;

namespace MauiIspitApp.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    private readonly CategoryService _categoryService;

    public HomePageViewModel(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public ObservableCollection<Category> Categories { get; set; } = new();
    public ObservableCollection<Offer> Offers { get; set; } = new();

    public async Task InitializeAsync()
    {
        foreach (var category in await _categoryService.GetMainCategoriesAsync())
        {
            Categories.Add(category);
        }
        foreach (var offer in Offer.GetOffers())
        {
            Offers.Add(offer);
        }
    }
}