using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class saveHelper
{
    public static void Save<T>(string key, T saveData) {
        string jsonDataSting = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(key, jsonDataSting);
        PlayerPrefs.Save();
    }
    
    public static T Load<T> (string key) where T: new() {
        if (PlayerPrefs.HasKey(key)) {
            string loadedString = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(loadedString);
        }
        else
            return new T();
    }

    public static String listToString<T>(List<T> list) {
        var listString = string.Join(";", list);
        Debug.Log( " listString: " + listString);
        var list1 = listString?.Split(';')?.Select(Int32.Parse)?.ToList();
        Debug.Log( " listString1: " + list1.Count);
        return listString;
    }

    public static List<int> stringToList (string listString) {
        var list = listString?.Split(';')?.Select(Int32.Parse)?.ToList();
        Debug.Log( " listString: " + listString);
        return list;
    }
}
