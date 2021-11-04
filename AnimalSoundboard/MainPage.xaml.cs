using System;
using System.Collections.ObjectModel;

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
        public ObservableCollection<SoundItem> Sounds { get; set; }
        public bool IsTextToSpeech { get; set; } = false;

        public MainPage()
        {
            this.Sounds = new ObservableCollection<SoundItem>();
            this.InitializeComponent();
            this.InitSounds();
        }

        private void InitSounds()
        {
            SoundItem Cow = new SoundItem("Cow.wav", "🐄", "moo moo");
            SoundItem Chicken = new SoundItem("Chicken.wav", "🐔", "bawk bawk");
            SoundItem Elephant = new SoundItem("Elephant.wav", "🐘", "elephant noise");
            SoundItem Owl = new SoundItem("Owl.wav", "🦉", "who who");

            this.Sounds.Add(Cow);
            this.Sounds.Add(Chicken);
            this.Sounds.Add(Elephant);
            this.Sounds.Add(Owl);
        }

        private void SoundItemClick(object sender, ItemClickEventArgs e)
        {
            SoundItem currentSoundItem = e.ClickedItem as SoundItem;
            if (this.IsTextToSpeech)
            {
                this.ReadTextToSpeech(currentSoundItem);
            }
            else
            {
                this.PlaySoundItem(currentSoundItem);
            }
        }

        private async void PlaySoundItem(SoundItem sound)
        {
            MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(sound.AudioFilename);
            mediaPlayerElement.Source = MediaSource.CreateFromStorageFile(file);
            mediaPlayerElement.MediaPlayer.Play();

        }

        private async void ReadTextToSpeech(SoundItem sound)
        {
            MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            synth.Options.SpeakingRate = .7;
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(sound.TextToSpeech);
            mediaPlayerElement.Source = MediaSource.CreateFromStream(stream, stream.ContentType);
            mediaPlayerElement.MediaPlayer.Play();
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            this.IsTextToSpeech = !this.IsTextToSpeech;
        }

        private void Monkey_Button_Click(object sender, RoutedEventArgs e)
        {
            SoundItem Monkey = new SoundItem("Monkey.wav", "🐒", "monke monke");
            this.Sounds.Add(Monkey);
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
