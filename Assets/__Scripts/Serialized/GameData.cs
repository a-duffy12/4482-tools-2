using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // properties to save
    public string activeLanguage;

    // function to get all data that needs saving
    public GameData()
    {
        activeLanguage = LanguagesManager.activeLanguage;
    }
}