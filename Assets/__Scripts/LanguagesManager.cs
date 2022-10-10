using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

[System.Serializable]
public class LanguagesManager : MonoBehaviour
{
    public static string activeLanguage;

    Keys keys;
    Language language;
    Dictionary<string, string> activeTranslations;

    void Start()
    {
        GetSavedData();

        //LoadActiveTranslations();
    }

    /*void LoadActiveTranslations()
    {
        if (!Directory.Exists("Assets/Keys"))
        {
            Debug.Log("No keys present!");
        }

        string keysAssetName = AssetDatabase.FindAssets("Keys");
        var keysPath = AssetDatabase.GUIDToAssetPath(keysAssetName);
        keys = AssetDatabase.LoadAssetAtPath<Language>(keysPath);

        if (!Directory.Exists("Assets/Languages"))
        {
            Debug.Log("No languages present!");
        }

        string languageAssetName = AssetDatabase.FindAssets(activeLanguage);
        var languagePath = AssetDatabase.GUIDToAssetPath(languageAssetName);
        language = AssetDatabase.LoadAssetAtPath<Language>(languagePath);

        for (int i = 0; i < keys.keys.Count(); i++)
        {
            activeTranslations.Add(keys.keys[i], language.translations[i]);
        }
    }*/

    void GetSavedData()
    {
        GameData savedData = SaveLoad.LoadData();

        if (savedData != null)
        {
            LanguagesManager.activeLanguage = savedData.activeLanguage;
        }
    }
}
