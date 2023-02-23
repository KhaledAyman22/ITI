namespace Weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();

            var currentDisplay = new CurrentConditionsDisplay();
            var statisticsDisplay = new StatisticsDisplay();
            var forecastDisplay = new ForecastDisplay();
            var heatIndexDisplay = new HeatIndexDisplay();

            weatherData.Subscribe(currentDisplay.Set);
            weatherData.Subscribe(statisticsDisplay.Set);
            weatherData.Subscribe(forecastDisplay.Set);
            weatherData.Subscribe(heatIndexDisplay.Set);

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.SetMeasurements(78, 90, 29.2f);

            // Wait for user
            Console.ReadKey();
        }
    }
}