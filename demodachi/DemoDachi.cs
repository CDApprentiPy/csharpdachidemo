namespace demodachi
{
    public class DemoDachi
    {
        public int happyness { get; set;}
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; }
        public string message { get; set; }
        public DemoDachi()
        {
            happyness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
            message = "Yo welcome to teh demodachi experience";
        }

        public void feed()
        {
            meals = meals - 1;
            fullness = fullness + 7;
            message = "You just foodcomad, but not tooo hard";
        }
    }
}