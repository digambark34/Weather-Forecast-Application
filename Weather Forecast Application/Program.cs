using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class WeatherData
{
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public double TemperatureC { get; set; }  // Corrected spelling
    public string Condition { get; set; }

    public double TemperatureF => (TemperatureC * 9 / 5) + 32;

    public void Display(bool ShowFahrenheit = false)
    {
        Console.WriteLine($"Location: {Location}, Date: {Date.ToShortDateString()}, " +
                        $"Temperature: {(ShowFahrenheit ? $"{TemperatureF:F1}°F" : $"{TemperatureC:F1}°C")}, Condition: {Condition}");
    }
}

public class WeatherApp
{
    private List<WeatherData> weatherData = new List<WeatherData>();
    private const string DataFile = "WeatherData.json";

    public void Run()
    {
        LoadData();
        Console.WriteLine("Welcome to Weather Forecast Application");

        while (true)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Add Weather Data");
            Console.WriteLine("2. View Weather Data");
            Console.WriteLine("3. Filter by Location");
            Console.WriteLine("4. View Forecast");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddWeatherData();
                    break;

                case "2":
                    ViewWeatherData();
                    break;

                case "3":
                    FilterByLocation();
                    break;

                case "4":
                    ViewForecast();
                    break;

                case "5":
                    SaveData();
                    Console.WriteLine("Data Saved Successfully........");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.........");
                    break;
            }
        }
    }

    private void AddWeatherData()
    {
        Console.WriteLine("Enter Location:");
        string location = Console.ReadLine();

        Console.WriteLine("Enter Date (yyyy-mm-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid Date");
            return;
        }

        Console.WriteLine("Enter Temperature in Celsius:");
        if (!double.TryParse(Console.ReadLine(), out double temperatureC))
        {
            Console.WriteLine("Invalid Temperature");
            return;
        }

        Console.WriteLine("Enter Weather Condition (sunny, rainy, cloudy):");
        string condition = Console.ReadLine();

        weatherData.Add(new WeatherData
        {
            Location = location,
            Date = date,
            TemperatureC = temperatureC,
            Condition = condition
        });

        Console.WriteLine("Weather Added Successfully");
    }

    private void ViewWeatherData()
    {
        Console.WriteLine("View Temperature in (1) Celsius or (2) Fahrenheit?");
        bool showFahrenheit = Console.ReadLine() == "2";

        if (!weatherData.Any())
        {
            Console.WriteLine("No Weather Data Found");
            return;
        }

        Console.WriteLine("Weather Data:");
        foreach (var weather in weatherData)
        {
            weather.Display(showFahrenheit);
        }
    }

    private void FilterByLocation()
    {
        Console.WriteLine("Enter Location to filter:");
        string location = Console.ReadLine();

        var filteredData = weatherData.Where(w => w.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
        if (!filteredData.Any())
        {
            Console.WriteLine("No data found for the specified location.");
            return;
        }

        Console.WriteLine("View Temperature in (1) Celsius or (2) Fahrenheit?");
        bool showFahrenheit = Console.ReadLine() == "2";

        Console.WriteLine($"Weather Data for {location}:");
        foreach (var weather in filteredData)
        {
            weather.Display(showFahrenheit);
        }
    }

    private void ViewForecast()
    {
        Console.WriteLine("Enter Location to Forecast:");
        string location = Console.ReadLine();

        Console.WriteLine("Enter number of days for forecast:");
        if (!int.TryParse(Console.ReadLine(), out int days) || days <= 0)
        {
            Console.WriteLine("Invalid number of days.");
            return;
        }

        Random rand = new Random();
        Console.WriteLine($"Weather Forecast for {location}:");
        for (int i = 0; i < days; i++)
        {
            var forecast = new WeatherData
            {
                Location = location,
                Date = DateTime.Now.AddDays(i),
                TemperatureC = rand.Next(-10, 35),
                Condition = new[] { "Sunny", "Rainy", "Cloudy", "Stormy" }[rand.Next(4)]
            };
            forecast.Display();
        }
    }

    private void SaveData()
    {
        File.WriteAllText(DataFile, JsonConvert.SerializeObject(weatherData, Formatting.Indented));
        Console.WriteLine("Data saved successfully.");
    }

    private void LoadData()
    {
        if (File.Exists(DataFile))
        {
            weatherData = JsonConvert.DeserializeObject<List<WeatherData>>(File.ReadAllText(DataFile)) ?? new List<WeatherData>();
            Console.WriteLine("Data Loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved data found, starting fresh.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        WeatherApp app = new WeatherApp();
        app.Run();
    }
}