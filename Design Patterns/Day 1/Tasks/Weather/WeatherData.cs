namespace Weather
{
    public class WeatherData
    {
        public delegate void WeatherDataDelegate(float tempreature, float humidity, float pressure);
        private event WeatherDataDelegate WeatherDataEvent;
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public void MeasurementsChanged()
        {
            WeatherDataEvent.Invoke(_temperature, _humidity, _pressure);
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            MeasurementsChanged();
        }

        public void Subscribe(WeatherDataDelegate d)
        {
            WeatherDataEvent += d;
        }
    }
}