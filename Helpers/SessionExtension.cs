﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShopOnline.Helpers;

public static class SessionExtension
{
    public static void SetObject<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        if (value == null)
            return default(T);
        else
            return JsonConvert.DeserializeObject<T>(value);
    }
}