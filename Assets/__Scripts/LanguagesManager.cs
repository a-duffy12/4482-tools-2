using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LanguagesManager : MonoBehaviour
{
    static List<string> keys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string> GetKeys()
    {
        return new List<string>(Languages.translations["english"].Keys);
    }

    public void AddLanguage(string language, Dictionary<string, string> keyEntries)
    {
        if (Languages.translations.ContainsKey(language))
        {
            return;
        }
        Languages.translations.Add(language, keyEntries);
    }

    public void ModifyLanguage(string language, Dictionary<string, string> keyEntries)
    {
        if (!Languages.translations.ContainsKey(language))
        {
            return;
        }

        Languages.translations[language] = keyEntries;
    }

    public void RemoveLanguage(string language)
    {
        if (!Languages.translations.ContainsKey(language))
        {
            return;
        }
        Languages.translations.Remove(language);
    }

    public void AddKey(string key, Dictionary<string, string> languageEntries) // takes in a key and a dictionary of language - translation pairs
    { 
        foreach (var language in Languages.translations)
        {
            language.Value.Add(key, languageEntries[language.Key]); // add key and string
        }
    }

    public void ModifyKey(string key, Dictionary<string, string> languageEntries) // takes in a key and a dictionary of language - translation pairs
    {
        foreach (var language in Languages.translations)
        {
            language.Value[key] = languageEntries[language.Key];
        }
    }

    public void RemoveKey(string key)
    {
        foreach (var language in Languages.translations)
        {
            if (!language.Value.ContainsKey(key))
            {
                continue;
            }
            language.Value.Remove(key);
        }   
    }
}
