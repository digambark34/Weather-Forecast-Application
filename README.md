
# Weather Forecast Application

This is a simple console-based weather forecast application that allows users to input and view weather data, filter by location, and view a forecast for multiple days. It stores the weather data in a JSON file for persistence.

## Features

- **Add Weather Data**: Users can input weather data for a specific location, including temperature (in Celsius) and weather condition.
- **View Weather Data**: Displays the weather data either in Celsius or Fahrenheit.
- **Filter by Location**: Allows users to filter and view weather data based on a specific location.
- **View Forecast**: Generate a random weather forecast for the next specified number of days.
- **Save & Load Data**: Weather data is saved in a `WeatherData.json` file, which can be loaded when the application starts.

## Prerequisites

- .NET Core or .NET Framework (for running the application)
- **Newtonsoft.Json** NuGet package for JSON serialization and deserialization.

### To install `Newtonsoft.Json`, run:
```bash
dotnet add package Newtonsoft.Json
```

## How to Run

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/your-username/weather-forecast-app.git
   ```
2. Navigate to the project directory:
   ```bash
   cd weather-forecast-app
   ```
3. Build and run the application using .NET CLI:
   ```bash
   dotnet run
   ```

4. The application will prompt you with a menu of options to:
   - Add weather data
   - View weather data
   - Filter by location
   - View a weather forecast
   - Save and exit

## Application Menu

Once the application starts, you will see a menu with the following options:

1. **Add Weather Data**: Add weather data for a location.
2. **View Weather Data**: View all weather data saved.
3. **Filter by Location**: View weather data for a specific location.
4. **View Forecast**: Generate a weather forecast for a specified number of days.
5. **Save and Exit**: Save the weather data and exit the application.

## Example of Usage

### 1. Adding Weather Data
```
Enter Location: New York
Enter Date (yyyy-mm-dd): 2025-01-21
Enter Temperature in Celsius: 22.5
Enter Weather Condition (sunny, rainy, cloudy): Sunny
Weather Added Successfully
```

### 2. Viewing Weather Data
```
Weather Data:
Location: New York, Date: 21/01/2025, Temperature: 22.5°C, Condition: Sunny
```

### 3. Filtering by Location
```
Enter Location to filter: New York
Weather Data for New York:
Location: New York, Date: 21/01/2025, Temperature: 22.5°C, Condition: Sunny
```

### 4. Viewing Forecast
```
Enter Location to Forecast: New York
Enter number of days for forecast: 5
Weather Forecast for New York:
Cardio: Sunny, Duration: 30 minutes, Calories Burned: 300
```

### 5. Saving and Exiting
```
Data Saved Successfully........
```

## File Structure

- **WeatherData.json**: JSON file that stores the weather data.
- **Program.cs**: Main application file containing the `WeatherApp` class and methods.
- **WeatherData.cs**: Defines the `WeatherData` class used to store weather information.
  
## Contributing

Feel free to fork this repository and make contributions. Please open issues or pull requests for any improvements or bugs.

