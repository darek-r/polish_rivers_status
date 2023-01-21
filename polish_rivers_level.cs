using System;
using System.Text.Json;
using System.Net.Http.Json;
using System.Collections.Generic;

// http://danepubliczne.imgw.pl/api/data/hydro/

namespace PolishRiversLevel
{
    
    public class RiversStatus
        {
            public IList<StationData>? Stations { get; set; }
        }

    public class StationData
        {
            public int StationId { get; set; }
            public string? StationName { get; set; }
            public string? RiverName { get; set; }
            public string? Voivodeship { get; set; }
            public string? WaterLevel { get; set; }
            public DateTimeOffset WaterLevelDate { get; set; }
            public string? WaterTemp { get; set; }
            public DateTimeOffset WaterTempDate { get; set; }
            public string? IceEvent { get; set; }
            public DateTimeOffset IceEventDate { get; set; }
            public string? OvergrowingEvent { get; set; }
            public DateTimeOffset OvergrowingEventDate { get; set; }
        }


    public class polish_rivers_level
    {
        public static void Main(string[] args)
        {
            jsonString = 
            @"[{""id_stacji"":""151140030"",
                ""stacja"":""Przewo\u017aniki"",
                ""rzeka"":""Skroda"",
                ""wojew\u00f3dztwo"":""lubuskie"",
                ""stan_wody"":""229"",
                ""stan_wody_data_pomiaru"":""2023-01-21 17:00:00"",
                ""temperatura_wody"":null,
                ""temperatura_wody_data_pomiaru"":null,
                ""zjawisko_lodowe"":""0"",
                ""zjawisko_lodowe_data_pomiaru"":""2022-12-08 09:10:00"",
                ""zjawisko_zarastania"":""0"",
                ""zjawisko_zarastania_data_pomiaru"":""2022-09-26 12:00:00""},
            {""id_stacji"":""153190040"",
                ""stacja"":""B\u0105gart"",
                ""rzeka"":""Dzierzgo\u0144"",
                ""wojew\u00f3dztwo"":""pomorskie"",
                ""stan_wody"":""704"",
                ""stan_wody_data_pomiaru"":""2023-01-17 22:00:00"",
                ""temperatura_wody"":null,
                ""temperatura_wody_data_pomiaru"":null,
                ""zjawisko_lodowe"":""0"",
                ""zjawisko_lodowe_data_pomiaru"":""2021-03-03 11:10:00"",
                ""zjawisko_zarastania"":""302"",
                ""zjawisko_zarastania_data_pomiaru"":""2022-09-30 10:10:00""}";

            RiversStatus? riversStatus = JsonSerializer.Deserialize<RiversStatus>(jsonString);
            Console.WriteLine($"Stan wody {riversStatus?.Stations[0]?.WaterLevel}");
            Console.Readline();
        }
    }
}