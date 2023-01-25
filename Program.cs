using System;
using System.Text.Json;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// http://danepubliczne.imgw.pl/api/data/hydro/

namespace PolishRiversLevel
{
    public class StationData
    {
        public string? id_stacji { get; set; }
        public string? stacja { get; set; }
        public string? rzeka { get; set; }
        public string? wojewodztwo { get; set; }
        public string? stan_wody { get; set; }
        public string? stan_wody_data_pomiaru { get; set; }
        public string? temperatura_wody { get; set; }
        public string? temperatura_wody_data_pomiaru { get; set; }
        public string? zjawisko_lodowe { get; set; }
        public string? zjawisko_lodowe_data_pomiaru { get; set; }
        public string? zjawisko_zarastania { get; set; }
        public string? zjawisko_zarastania_data_pomiaru { get; set; }
    }

    public class PolishRiversLevelMain
    {
        public static void Main(string[] args)
        {
            /*
             * String example for testing purpose *

            string jsonString =
            @"[{""id_stacji"":""151140030"",
                ""stacja"":""Przewozaniki"",
                ""rzeka"":""Skroda"",
                ""wojewodztwo"":""lubuskie"",
                ""stan_wody"":""229"",
                ""stan_wody_data_pomiaru"":""2023-01-21 17:00:00"",
                ""temperatura_wody"":null,
                ""temperatura_wody_data_pomiaru"":null,
                ""zjawisko_lodowe"":""0"",
                ""zjawisko_lodowe_data_pomiaru"":""2022-12-08 09:10:00"",
                ""zjawisko_zarastania"":""0"",
                ""zjawisko_zarastania_data_pomiaru"":""2022-09-26 12:00:00""},
            {""id_stacji"":""153190040"",
                ""stacja"":""Bogart"",
                ""rzeka"":""Dzierzgoz"",
                ""wojewodztwo"":""pomorskie"",
                ""stan_wody"":""704"",
                ""stan_wody_data_pomiaru"":""2023-01-17 22:00:00"",
                ""temperatura_wody"":null,
                ""temperatura_wody_data_pomiaru"":null,
                ""zjawisko_lodowe"":""0"",
                ""zjawisko_lodowe_data_pomiaru"":""2021-03-03 11:10:00"",
                ""zjawisko_zarastania"":""302"",
                ""zjawisko_zarastania_data_pomiaru"":""2022-09-30 10:10:00""}]";

            IList<StationData>? riversStatus = JsonSerializer.Deserialize<IList<StationData>>(jsonString);

            foreach (StationData river in riversStatus)
                Console.WriteLine($"River {river.rzeka} level is {river.stan_wody}");

            */

            string jsonStringFromWeb;
            using (var wc = new System.Net.WebClient())
                jsonStringFromWeb = wc.DownloadString("http://danepubliczne.imgw.pl/api/data/hydro/");

            IList<StationData>? riversStatus = JsonSerializer.Deserialize<IList<StationData>>(jsonStringFromWeb);

            if (riversStatus != null && riversStatus.Count > 0 )
            {
                foreach (StationData river in riversStatus)
                    Console.WriteLine($"River {river.rzeka} level is {river.stan_wody}");
            }
                

            Console.ReadLine();
        }
    }
}