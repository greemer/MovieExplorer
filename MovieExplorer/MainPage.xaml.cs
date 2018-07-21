using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            RootObject myMovie =
                await OmdbData.GetMovie(50.1, 20.2);
            var myPoster = myMovie.Poster;

            ResultImage.Source = new BitmapImage(new Uri(myPoster, UriKind.Absolute));
            ResultTextBlock.Text = myMovie.Title + " - " + myMovie.Year;
            PosterURLTextBlock.Text = myPoster;
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {

            var SearchTarget = Title.Text;

            ///OmdbSearch.SearchRootObject myMovie = await OmdbSearch.SearchMovie(50.1, 20.2);
            OmdbSearch.SearchRootObject myMovie = await OmdbSearch.SearchMovie(SearchTarget);

            

            ///string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
            ///ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            SearchResultTB.Text = "Response: " + myMovie.Response + " " + myMovie.totalResults + " " + myMovie.Search[0].Title;
            ///SearchResultTB.Text = string(myMovie);
            ///var myPoster = myMovie.Poster;
            ///PosterURLTextBlock.Text = myPoster;
            //SearchResultTB.Text = "Hello";


        }

        private async void TestSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ///OmdbSearch.SearchRootObject myTitle = await OmdbSearch.SearchTitle("terminator");
            ///SearchResultTB.Text = "The Title " + myTitle.Search[0].Title;

        }
    }

}
