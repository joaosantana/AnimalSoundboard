namespace AnimalSoundboard
{
    public class SoundItem
    {
        public string AudioFilename { get; set; }
        public string PreviewText { get; set; }
        public string TextToSpeech { get; set; }

        public SoundItem(string audio, string prev, string tts)
        {
            this.AudioFilename = audio;
            this.PreviewText = prev;
            this.TextToSpeech = tts;
        }
    }
}
