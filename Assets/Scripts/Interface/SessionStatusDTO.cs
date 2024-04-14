namespace Interface
{
    public class SessionStatusDTO
    {
        public string name;

        public int points;

        public int waves;

        public int enemies;

        public string playTime;

        public SessionStatusDTO(
            string name,
            int points,
            int waves,
            int enemies,
            string playTime)
        {
            this.name = name;
            this.points = points;
            this.waves = waves;
            this.enemies = enemies;
            this.playTime = playTime;
        }
    }
}
