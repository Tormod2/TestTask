using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public static class DownloadScript 
{
    public static Data GetData()
    {
        var path = Path.Combine(Application.dataPath, "Data.json");
        WebClient webClient = new WebClient();
        if (!File.Exists(path))
        {
            webClient.DownloadFile("https://drive.google.com/uc?export=download&id=1YwwjBNPAs01cMiDj6SZPE20KP8n3QWc1",
                Path.Combine(Application.dataPath, "Data.json"));
        }
        string file = File.ReadAllText(path);
        Data data = JsonConvert.DeserializeObject<Data>(file);
        return data;
    }
}
