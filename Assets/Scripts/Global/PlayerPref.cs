using System;
using UnityEngine;

public class PlayerPref<T> where T : System.IConvertible
{
    public T Value
    {
        get
        {
            T result;

            if (typeof(T) == typeof(int))
            {
                result = (T)Convert.ChangeType(PlayerPrefs.GetInt(key), typeof(T));
            }
            else if (typeof(T) == typeof(bool))
            {
                result = (T)(Convert.ChangeType(PlayerPrefs.GetInt(key) == 1, typeof(T)));
            }
            else if (typeof(T) == typeof(float))
            {
                result = (T)Convert.ChangeType(PlayerPrefs.GetFloat(key), typeof(T));
            }
            else
            {
                result = (T)Convert.ChangeType(PlayerPrefs.GetString(key), typeof(T));
            }

            return result;
        }

        set
        {
            if (typeof(T) == typeof(int))
            {
                PlayerPrefs.SetInt(key, (int)Convert.ChangeType(value, typeof(int)));
            }
            else if (typeof(T) == typeof(bool))
            {
                PlayerPrefs.SetInt(key, (bool)Convert.ChangeType(value, typeof(bool)) ? 1 : 0);
            }
            else if (typeof(T) == typeof(float))
            {
                PlayerPrefs.SetFloat(key, (float)Convert.ChangeType(value, typeof(float)));
            }         
            else
            {
                PlayerPrefs.SetString(key, (string)Convert.ChangeType(value, typeof(string)));
            }
        }
    }

    private readonly string key;

    public PlayerPref(string key)
    {
        var chosenType = typeof(T);

        if (chosenType != typeof(int) && 
            chosenType != typeof(float) && 
            chosenType != typeof(string) &&
            chosenType != typeof(bool))
        {
            throw new ArgumentException("PlayerPref of type " + chosenType + " is not allowed!");
        }
        else
        {
            this.key = key;
        }
    }
}
