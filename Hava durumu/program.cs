using System;
using System.Net.Http;
using System.Threading.Tasks;
using HAVADURUMU0;
using Newtonsoft.Json;

class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Aşağıda üç büyük ilimizin bugün ve üç gün sonrasına ait hava durumu olmaktadır");

        WeatherData istanbulWeather = await GetWeatherData("https://goweather.herokuapp.com/weather/istanbul");
        WeatherData izmirWeather = await GetWeatherData("https://goweather.herokuapp.com/weather/izmir");
        WeatherData ankaraWeather = await GetWeatherData("https://goweather.herokuapp.com/weather/ankara");

        Console.WriteLine("İstanbul Hava Durumu:");
        PrintWeather(istanbulWeather);

        Console.WriteLine("İzmir Hava Durumu:");
        PrintWeather(izmirWeather);

        Console.WriteLine("Ankara Hava Durumu:");
        PrintWeather(ankaraWeather);

        Console.WriteLine("\nProgram Çıkış Tarihi: " + DateTime.Now);
    }

    public static async Task<WeatherData> GetWeatherData(string apiUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseData);
                return weatherData;
            }
            else
            {
                Console.WriteLine($"API'den veri alınamıyor");
                return null;
            }
        }
    }


    public static void PrintWeather(WeatherData weather)
    {
        if (weather != null)
        {
            Console.WriteLine($"Durum: {weather.Description}");
            Console.WriteLine($"Sıcaklık: {weather.Temperature}°C");
            Console.WriteLine($"Rüzgar: {weather.Wind}");

            Console.WriteLine("3 Günlük Tahmin:");

            
            foreach (var forecast in weather.Forecast)
            {
                Console.WriteLine($"{forecast.Day}:");
                Console.WriteLine($"Durum: {forecast.Description}");
                Console.WriteLine($"Sıcaklık: {forecast.Temperature}°C");
                Console.WriteLine($"Rüzgar: {forecast.Wind}");
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 30));
        }
    }
}