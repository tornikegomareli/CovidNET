<p align="center">
<img src="https://img.shields.io/badge/License-MIT-yellow.svg">
<img src="https://img.shields.io/badge/language-csharp-red.svg">
<img src="https://img.shields.io/nuget/dt/covidnet?label=nuget-downloads">
</p>  



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://s3.xopic.de/openwho-public/channels/7fSc4JEBeO9H0P4b8d1Cfq/logo_v1.png">
    <img src="https://s3.xopic.de/openwho-public/channels/7fSc4JEBeO9H0P4b8d1Cfq/logo_v1.png" alt="Logo" width="150" height="120">
  </a>

  <h3 align="center">CovidNET</h3>

  <p align="center">
    Single C# library for using different types of COVID19 API's - Work with COVID19 data from sipmle single client
    <br />    ·
    <a href="https://github.com/tornikegomareli/CovidNET/issues">Report Bug</a>
    ·
    <a href="https://github.com/tornikegomareli/CovidNET/issues">Request Feature</a>
  </p>
</p>


<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About The Project

Today's everyone is at home. So developers are using those time to build something creative, or just usefull for another people. 

I just decided to create beautiful wrapper for different types of COVID19 API's (they are a lot), for developers who are concetrated to create projects about today's situation and they need data of course.

Here's why:
* Your time should be focused on creating something amazing. A project that solves a problem and helps others
* You shouldn't be doing the same tasks over and over like creating a API calls and setuping Http layers from scratch
* You should element DRY principles to the rest of your life :smile:

Of course, no any wrapper and library will serve all projects since your needs may be different. So I'll be adding more in the near future. You may also suggest changes by forking this repo and creating a pull request or opening an issue.

### API's which are integrated into the project
* [Covid19](https://github.com/pomber/covid19)
* [covid-api](https://github.com/backtrackbaba/covid-api)
* [covidAPI-heroku](https://github.com/javieraviles/covidAPI)

### Built With
* [net-standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
* [Newtonsoft](https://www.newtonsoft.com/json)
* [NetHttp](https://www.nuget.org/packages/System.Net.Http/)
* [nUnit](https://nunit.org/)



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Installation


This is an example of how to list things you need to use the software and how to install them.
* nuget - [https://www.nuget.org/packages/covidnet/](https://www.nuget.org/packages/covidnet/)


 Package manager console
```sh
Install-Package covidnet -Version 1.0.0
```
.NET CLI
```sh
dotnet add package covidnet --version 1.0.0
```
PackageReference
```sh
<PackageReference Include="covidnet" Version="1.0.0" />
```
paket CLI
```sh
paket add covidnet --version 1.0.0
```

<!-- USAGE EXAMPLES -->
## Usage

Usage of CovidNET is very simple.
You just need one single client instance, which will be abstraction for whole system and you will use this client to perform async calls to different APIS for different types of DATA you will need.

To create CovidNET client in your code you just need to create new instance.
```csharp
var covidClient = new CovidNetClient();
```
After that, you will need to request basic data we need for future operations. So you need to sync data from web-services.

```csharp
await covidClient.InitCovidDataAsync()
```
So here, you already have everything you need to perform library calls to get all the data you need. 

With CovidNET you can use next methods:

* Get list of covidinfo objects based on counry name, where it will be whole timeseries of data from 22 January 2020 - (Confirmed, death, recovered)
```csharp
IEnumerable<CovidInfo> GetCountryTimeSeriesByName(string countryName)
```
* Get world covidinfo about COVID19, based on specific date. (Confirmed, death, recovered)
```csharp
Task<CovidInfo> GetGlobalInfoByDateAsync(DateTime date)
```
* Get latest world covidinfo. (Confirmed, death, recovered)
```csharp
Task<CovidInfo> GetLatestGlobalInfoAsync()
```
* Get specific country time-series in ranged dates, based on country name.
```csharp
IEnumerable<CovidInfo> GetCountryTimeSeries(string country, DateTime from, DateTime to)
```
* Get all detailed country stats where covid19 is active (Country, cases, today cases, deaths, todaydeaths, recovered, active, critical, casesPerOneMillion, deathsPerOneMillion, totalTests, testsPerOneMillion)
```csharp
Task<IEnumerable<CovidCountryStats>> GetCurrentAllCovidCountryStatsAsync()
```
* Get detailed country stat, based on country name;
```csharp
Task<CovidCountryStats> GetCurrentCovidInfoByCountryAsync(string country)
```
* Get specific country covidinfo based on date (Confirmed, deaths, recovered)
```csharp
Task<CovidInfo> GetCovidCountryInfoByDateAsync(string countryName, DateTime dateTime)
```
<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a list of proposed features (and known issues).

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

Please feel free to make contribution for everything you think, it doesn't matter it will be feature, bug or just grammer mistake fix in README.

I'm also very open about integrating new API's or new design changes. 
<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.
<!-- CONTACT -->
## Contact

- Github - [tornikegomareli](https://github.com/tornikegomareli)
- Twitter - [@tornikegomareli](https://twitter.com/tornikegomareli)  
- Email -gomarelidevelopment@gmail.com
- Facebook - [tornikegomareli](https://www.facebook.com/microg)

Project Link: [COVIDNET](https://github.com/tornikegomareli/CovidNET)




