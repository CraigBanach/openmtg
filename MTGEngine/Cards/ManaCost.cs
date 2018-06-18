namespace MTGEngine.Cards
{
    public class ManaCost
    {
        public int White { get; set; }
        public int Blue { get; set; }
        public int Black { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Colourless { get; set; }
        public int Any { get; set; }

        public int Total ()
        {
            return
                this.Any +
                this.Black +
                this.Blue +
                this.Colourless +
                this.Green +
                this.Red +
                this.White;
        }
    }
}
