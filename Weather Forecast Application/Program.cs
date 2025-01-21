using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.CompilerServices;
using System.Numerics;

public class WeatherData
{
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public double TemparatureC { get; set; }
    public string Condition { get; set; }

    public double TemparatureF => (TemparatureC * 9 / 5) + 32;

    public void Display(bool Showfarehit = false)
    {
        Console.WriteLine($"Location: {Location}, Date: {Date.ToShortDateString()}, " +
                        $"Temperature: {(showFahrenheit ? $"{TemperatureF:F1}°F" : $"{TemperatureC:F1}°C")}, Condition: {Condition}");
    }
}

public class WeatherApp
{
    private List<WeatherData> weatherData = new List<WeatherData>();
    private const string Datafile = "WeatherData.json";

    public void Run()
    {
        LoadData();
        Console.WriteLine("Welcome to Weather Forecast Appliacation");

        while (true)
        {
            Console.WriteLine("\n Menu");
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
                    AddweatherData();
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
                    Console.WriteLine("Data Saved Succesfully........");
                    return;

                default:
                    Console.WriteLine("Invalid choice please try again.........");
                    break;
            }
        }
    }

    private void AddweatherData()
    {
        Console.WriteLine("Enter Location");
        string location = Console.ReadLine();

        Console.WriteLine("Enter Date (yyyy-mm-dd)");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid Output ");
            return;
        }

        Console.WriteLine("Enter Temparature in Celcius");
        if (!double.TryParse(Console.ReadLine(), out double temparatureC))
        {
            Console.WriteLine("Invalid Temparaure ");
            return;
        }

        Console.WriteLine("Enter Weather Condition (sunny,Rainy,Cloudy)");
        string condition = Console.ReadLine();
        weatherData.Add(new WeatherData
        {
            Location = location,
            Date = date,
            TemparatureC = temparatureC,
            Condition = condition
        });

        Console.WriteLine("Weather Added Succesfully");
    }

    private void ViewWeatherData()
    {
        Console.WriteLine("View Temparature in (1) Celsius or (2) Fahrenheit? ");
        bool Showfarehit = Console.ReadLine() == "2";

        if (!weatherData.Any())
        {
            Console.WriteLine("No Weather Data Found");
            return;
        }
        Console.WriteLine("Weather Data");
        {
            foreach (var weather in weatherData)
            {
                weather.Display(Showfarehit);
            }
        }
    }

    private void FilterByLocation()
    {
        Console.WriteLine("Enter Location to filter");
        string location = Console.ReadLine();

        var filterData = weatherData.Where(w => w.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
        if (!filterData.Any())
        {
            Console.WriteLine("No data found for the specified location.");
            return;
        }

        Console.WriteLine("View Temparature in  (1) Celsius or (2) Fahrenheit? ");
        bool Showfarehit = Console.ReadLine() == "2";
        Console.WriteLine("Weather Data for {location}");
        foreach (var weather in weatherData)
        {
            weather.Display(Showfarehit);
        }
    }

    private void ViewForecast()
    {
    }
}