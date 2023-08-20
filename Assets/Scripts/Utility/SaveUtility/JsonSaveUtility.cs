using System.IO;
using UnityEngine;

public class JsonSaveUtility
{
    public static string SaveFilePath = $"{Application.persistentDataPath}/SaveData.json";

    public static void Save<T>(T data) where T : class
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SaveFilePath, json);
    }

    public static T Load<T>() where T : class
    {
        if(File.Exists(SaveFilePath))
        {
            string json = File.ReadAllText(SaveFilePath);
            return JsonUtility.FromJson<T>(json);
        }
        else
        {
            Debug.LogWarning($"File not found:{SaveFilePath}");
            return null;
        }
    }
    
}
    

