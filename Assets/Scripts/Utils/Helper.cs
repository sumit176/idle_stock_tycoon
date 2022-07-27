using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static T FindAndGet<T>(this Transform thisT, string name)
    {
        var t = thisT.Find(name);
        return t != null ? t.GetComponent<T>() : default(T);
    }
}
