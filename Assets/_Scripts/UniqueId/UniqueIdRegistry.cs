using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UniqueIdRegistry
{
    public static Dictionary<String, Int32> Mapping = new Dictionary<String, int>();

    public static void Deregister(String id)
    {
        Mapping.Remove(id);
    }

    public static void Register(String id, Int32 value)
    {
        if (!Mapping.ContainsKey(id))
        {
            Mapping.Add(id, value);
        }
    }

    public static Int32 GetInstanceId(string id)
    {
        return Mapping[id];
    }
}