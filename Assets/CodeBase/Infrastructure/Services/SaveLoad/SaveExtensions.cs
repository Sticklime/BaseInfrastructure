using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public static class SaveExtensions
    {
        public static string ToJson(this object obj) => 
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}