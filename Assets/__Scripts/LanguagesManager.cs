using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class LanguagesManager : MonoBehaviour
{
    public static string activeLanguage;
    public static bool translationsChanged;

    Keys keys;
    Language language;
    Dictionary<string, string> activeTranslations;

    [Header("UI Objects")]
    [SerializeField] private Text keyText0;
    [SerializeField] private Text keyText1;
    [SerializeField] private Text keyText2;
    [SerializeField] private Text keyText3;
    [SerializeField] private Text keyText4;
    [SerializeField] private Text keyText5;

    void Start()
    {
        GetSavedData();

        LoadActiveTranslations();
    }

    void Update()
    {
        if (translationsChanged) // localization window has changed the translations
        {
            LoadActiveTranslations();
            translationsChanged = false;
        }

        SetupText();
    }

    void LoadActiveTranslations()
    {
        if (string.IsNullOrEmpty(activeLanguage))
        {
            Debug.Log("No active language selected");
        }
        else
        {
            keys = Resources.Load<Keys>("Keys/Keys");
            language = Resources.Load<Language>("Languages/" + activeLanguage);
            activeTranslations = new Dictionary<string, string>();

            if (keys != null && language != null)
            {
                for (int i = 0; i < keys.keys.Count(); i++)
                {
                    activeTranslations.Add(keys.keys[i], language.translations[i]);
                }
            }
            
            if (language == null)
            {
                for (int i = 0; i < keys.keys.Count(); i++)
                {
                    activeTranslations.Add(keys.keys[i], "");
                }
            }
        }  
    }

    void GetSavedData()
    {
        GameData savedData = SaveLoad.LoadData();

        if (savedData != null)
        {
            LanguagesManager.activeLanguage = savedData.activeLanguage;
        }
    }

    void SetupText()
    {
        if (keys.keys.Count() >= 1)
        {
            keyText0.text = activeTranslations[keys.keys[0]] ?? keys.keys[0] ?? "Key 0";
        }
        else
        {
            keyText0.text = "Key 0";
        }

        if (keys.keys.Count() >= 2)
        {
            keyText1.text = activeTranslations[keys.keys[1]] ?? keys.keys[1] ?? "Key 1";
        }
        else
        {
            keyText1.text = "Key 1";
        }

        if (keys.keys.Count() >= 3)
        {
            keyText2.text = activeTranslations[keys.keys[2]] ?? keys.keys[2] ?? "Key 2";
        }
        else
        {
            keyText2.text = "Key 2";
        }

        if (keys.keys.Count() >= 4)
        {
            keyText3.text = activeTranslations[keys.keys[3]] ?? keys.keys[3] ?? "Key 3";
        }
        else
        {
            keyText3.text = "Key 3";
        }

        if (keys.keys.Count() >= 5)
        {
            keyText4.text = activeTranslations[keys.keys[4]] ?? keys.keys[4] ?? "Key 4";
        }
        else
        {
            keyText4.text = "Key 4";
        }

        if (keys.keys.Count() >= 6)
        {
            keyText5.text = activeTranslations[keys.keys[5]] ?? keys.keys[5] ?? "Key 5";
        }
        else
        {
            keyText5.text = "Key 5";
        }  
    }
}
