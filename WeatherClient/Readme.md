
# Custom Weather Client Tool

This tool is a custom weather client tool which takes user input as city and gives the weather related information e.g. Temperature , Windspeedetc.

## How to build
After cloning the repo, go to the project directory and run the below command:

    dotnet build -c Release

## How to run
Once the application is built, run the below command:

    .\bin\Release\net6.0\WeatherClient.exe Delhi

You should see the below output:

    {"latitude":28.625,"longitude":77.25,"generationtime_ms":0.2650022506713867,"utc_offset_seconds":0,"timezone":"GMT","timezone_abbreviation":"GMT","elevation":218.0,"current_weather":{"temperature":20.4,"windspeed":1.5,"winddirection":346.0,"weathercode":0,"time":"2023-03-06T19:00"}}


