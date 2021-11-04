using System;

using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace AnimalSoundboard
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Cow_Button_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Cow.wav");
            mediaPlayerElement.Source = MediaSource.CreateFromStorageFile(file);
            mediaPlayerElement.MediaPlayer.Play();
        }

        private async void Chicken_Button_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Chicken.wav");
            mediaPlayerElement.Source = MediaSource.CreateFromStorageFile(file);
            mediaPlayerElement.MediaPlayer.Play();
        }
    }
}
