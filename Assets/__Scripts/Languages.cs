using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Languages : ScriptableObject
{
    public static string currentLanguage = "english";

    public static Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>() 
    {
        ["english"] = new Dictionary<string, string>()
        {
            ["MENU_PLAY"] = "Play",
            ["MENU_OPTIONS"] = "Options",
            ["MENU_QUIT"] = "Quit"
        },
        ["french"] = new Dictionary<string, string>()
        {
            ["MENU_PLAY"] = "Jouer",
            ["MENU_OPTIONS"] = "Options",
            ["MENU_QUIT"] = "Quitter"
        }
    };

}