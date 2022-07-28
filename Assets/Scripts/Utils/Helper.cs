using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Helper
{
    public static T FindAndGet<T>(this Transform thisT, string name)
    {
        var t = thisT.Find(name);
        return t != null ? t.GetComponent<T>() : default(T);
    }

    public static string ScoreShow(double Score)
    {
        string result;
        string[] ScoreNames = new string[] {"", "k","M", "B", "T", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az", "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bk", "bl", "bm", "bn", "bo", "bp", "bq", "br", "bs", "bt", "bu", "bv", "bw", "bx", "by", "bz", };
        int i;
 
        for (i = 0; i < ScoreNames.Length; i++)
            if (Score < 900)
                break;
            else Score = System.Math.Floor(Score / 100f) / 10f;
 
        if (Score == System.Math.Floor(Score))
            result = Score.ToString() + ScoreNames[i];
        else result = Score.ToString("F1") + ScoreNames[i];
        return result;
    }

    public static void Save<T>(T data)
    {
        var json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllTextAsync(Application.persistentDataPath+"playerData.dat", json);
    }

    public static T Load<T>()
    {
        var json = File.ReadAllText(Application.persistentDataPath+"playerData.dat");
        Debug.Log(json);
        return JsonUtility.FromJson<T>(json);
    }

    public static bool HasPlayerData()
    {
        return File.Exists(Application.persistentDataPath+"playerData.dat");
    }
}
