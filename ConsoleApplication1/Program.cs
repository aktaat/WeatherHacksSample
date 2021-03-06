﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://weather.livedoor.com/forecast/webservice/json/v1";
            string cityname = "130010";

            string url = $"{baseUrl}?city={cityname}";
            string json = new HttpClient().GetStringAsync(url).Result;
            JObject jobj = JObject.Parse(json);

            File.WriteAllText(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tokyo-weather.txt"),
                    jobj.ToString()
                );

        }
    }
}


public class Rootobject
{
    public DateTime publicTime { get; set; }
    public string title { get; set; }
    public Description description { get; set; }
    public string link { get; set; }
    public Forecast[] forecasts { get; set; }
    public Location location { get; set; }
    public Pinpointlocation[] pinpointLocations { get; set; }
    public Copyright copyright { get; set; }
}

public class Description
{
    public string text { get; set; }
    public DateTime publicTime { get; set; }
}

public class Location
{
    public string city { get; set; }
    public string area { get; set; }
    public string prefecture { get; set; }
}

public class Copyright
{
    public Provider[] provider { get; set; }
    public string link { get; set; }
    public string title { get; set; }
    public Image image { get; set; }
}

public class Image
{
    public int width { get; set; }
    public string link { get; set; }
    public string url { get; set; }
    public string title { get; set; }
    public int height { get; set; }
}

public class Provider
{
    public string link { get; set; }
    public string name { get; set; }
}

public class Forecast
{
    public string dateLabel { get; set; }
    public string telop { get; set; }
    public string date { get; set; }
    public Temperature temperature { get; set; }
    public Image1 image { get; set; }
}

public class Temperature
{
    public Min min { get; set; }
    public Max max { get; set; }
}

public class Min
{
    public string celsius { get; set; }
    public string fahrenheit { get; set; }
}

public class Max
{
    public string celsius { get; set; }
    public string fahrenheit { get; set; }
}

public class Image1
{
    public int width { get; set; }
    public string url { get; set; }
    public string title { get; set; }
    public int height { get; set; }
}

public class Pinpointlocation
{
    public string link { get; set; }
    public string name { get; set; }
}
