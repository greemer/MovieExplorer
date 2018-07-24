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
            int page = 1;
            
            OmdbSearch.SearchRootObject myMovie = await OmdbSearch.SearchMovie(SearchTarget, page);

            if (myMovie.Response == "True")
            {
                int entries = myMovie.Search.Count;
                int totalEntries = int.Parse(myMovie.totalResults);

                SearchResultTB.Text = "Response: "
                    + myMovie.Response
                    + " " + myMovie.totalResults
                    + " " + myMovie.Search.Count.ToString()
                    + "\r\n";

                while (totalEntries > 10)
                {
                    totalEntries -= 10;

                    OmdbSearch.SearchRootObject myMovie2 = await OmdbSearch.SearchMovie(SearchTarget, page);

                    for (int i = 0; i < 10; i++)
                    {
                        SearchResultTB.Text += myMovie2.Search[i].Title + "\r\n";
                    }
                    page++;
                }
                if (totalEntries != 0)
                {
                    OmdbSearch.SearchRootObject myMovie2 = await OmdbSearch.SearchMovie(SearchTarget, page);
                    for (int i = 0; i < totalEntries; i++)
                    {
                        SearchResultTB.Text += myMovie2.Search[i].Title + "\r\n";
                    }
                }

                //if (myMovie.Search[0].Poster != "N/A")
                //    Result2Image.Source = new BitmapImage(new Uri(myMovie.Search[0].Poster, UriKind.Absolute));

            }
            else
                SearchResultTB.Text = "Sorry, no movies by that name found!";
        }

    }

}
