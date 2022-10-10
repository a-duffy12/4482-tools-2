using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class Manager : MonoBehaviour
{
    public static string currentLanguage = "english";

    [Header("Localization")]  
    public List<Language> languages;
    
    [HideInInspector] public Language language { get { return activeLanguage; }}
    Language activeLanguage;

    [Header("UI Objects")]
    [SerializeField] private Text playText;
    [SerializeField] private Text optionsText;
    [SerializeField] private Text quitText;
    [SerializeField] private Text newKeyText0;
    [SerializeField] private Text newKeyText1;
    [SerializeField] private Text newKeyText2;

    void Start()
    {
        if (languages.Any())
        {
            activeLanguage = languages.FirstOrDefault(l => l.name == currentLanguage) ?? languages[0];
        }
        else
        {
            Debug.Log("No languages present!");
        }

        // setup UI
    }

    public void SwitchLanguage(string languageName)
    {
        if (languages.Any())
        {
            activeLanguage = languages.FirstOrDefault(l => l.name == languageName) ?? languages[0];
        }
        else
        {
            Debug.Log("No languages present!");
        }

        currentLanguage = activeLanguage.name;
    }

    /*public void AddLanguage(string languageName)
    {
        List<string> keys = activeLanguage.translations.Select(k => k.key).ToList(); // get all keys
        List<KeyTranslation> translations = new List<KeyTranslation>();
        
        foreach (var key in keys) // add all keys with empty values
        {
            translations.Add(new KeyTranslation(key, ""));
        }

        Language newLanguage = ScriptableObject.CreateInstance("Language") as Language;
        newLanguage.init(languageName, translations);
        languages.Add(newLanguage); // add new language to list
    }

    public void RemoveLanguage(string languageName)
    {
        if (languages.Any())
        {
            var languageToRemove = languages.FirstOrDefault(l => l.name == languageName);

            if (languageToRemove != null)
            {
                languages.Remove(languageToRemove);
            }
        }
        else
        {
            Debug.Log("No languages present!");
        }
    }*/
}
