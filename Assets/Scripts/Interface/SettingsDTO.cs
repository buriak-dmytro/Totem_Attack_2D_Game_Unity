namespace Interface
{
    public class SettingsDTO
    {
        public float volumeSFX;
        public float volumeMusic;

        public SettingsDTO(float volumeSFX, float volumeMusic)
        {
            this.volumeSFX = volumeSFX;
            this.volumeMusic = volumeMusic;
        }
    }
}
