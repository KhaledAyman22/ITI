namespace Weather
{
    public class CurrentConditionsDisplay : IDisplayElement
    {
        private float _temperature;
        private float _humidity;

        public void Set(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature
                + "F degrees and " + _humidity + "% humidity");
        }
    }
}