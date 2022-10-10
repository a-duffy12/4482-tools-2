using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;

public class LocalizationWindow : EditorWindow
{
    public static Keys keys { get; set; }
    public static List<Language> languages { get; set; }

    public static string keyToAdd;
    public static string keyToRemove;
    public static string languageToAdd;
    public static string langaugeToRemove;
    public static string languageSwap;

    [MenuItem("Window/Localization")]
    public static void ShowWindow()
    {
        EditorWindow window = (LocalizationWindow)GetWindow<LocalizationWindow>();
        window.minSize = new Vector2(400, 200);
        window.Show();
    }

    void OnEnable() // start equivalent
    {
        LoadKeys();
        LoadLanguages();
    }

    void OnGUI() // update equivalent
    {
        GUILayout.Label("Key Functions");
        GUILayout.BeginHorizontal();
        keyToAdd = EditorGUILayout.TextField(keyToAdd);
        if (GUILayout.Button("Add Key"))
        {
            AddKey();
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        keyToRemove = EditorGUILayout.TextField(keyToRemove);
        if (GUILayout.Button("Remove Key"))
        {
            RemoveKey();
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        GUILayout.Label("Language Functions");
        GUILayout.BeginHorizontal();
        languageToAdd = EditorGUILayout.TextField(languageToAdd);
        if (GUILayout.Button("Add Language"))
        {
            AddLanguage();
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        langaugeToRemove = EditorGUILayout.TextField(langaugeToRemove);
        if (GUILayout.Button("Remove Language"))
        {
            RemoveLanguage();
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.Space();


        GUILayout.Label("Set Active Language");
        GUILayout.BeginHorizontal();
        languageSwap = EditorGUILayout.TextField(languageSwap);
        if (GUILayout.Button("Swap"))
        {
            SetActiveLanguage();
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
        GUILayout.Label("Languages for Localization");
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Keys");
        foreach (Language lang in languages)
        {
            GUILayout.Label(lang.name);
        }
        GUILayout.EndHorizontal();

        for (int i = 0; i < keys.keys.Count(); i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(keys.keys[i]);
            foreach (Language lang in languages)
            {
                lang.translations[i] = EditorGUILayout.TextField(lang.translations[i]);
            }
            GUILayout.EndHorizontal();
        }
    }

    void LoadKeys()
    {
        if (!Directory.Exists("Assets/Resources/Keys"))
        {
            AssetDatabase.CreateFolder("Assets/Resources", "Keys");
        }

        keys = (Keys) ScriptableObject.CreateInstance<Keys>();
        
        string name = (AssetDatabase.FindAssets("Keys", new[] { "Assets/Resources/Keys" }))[0];
        var path = AssetDatabase.GUIDToAssetPath(name);
        keys = AssetDatabase.LoadAssetAtPath<Keys>(path);

        Debug.Log(keys.keys.Count() + " key(s) loaded");
    }

    void LoadLanguages()
    {
        if (!Directory.Exists("Assets/Resources/Languages"))
        {
            AssetDatabase.CreateFolder("Assets/Resources", "Languages");
        }

        languages = new List<Language>();
        
        string[] assetNames = AssetDatabase.FindAssets("", new[] { "Assets/Resources/Languages" });
        foreach (string name in assetNames)
        {
            var path = AssetDatabase.GUIDToAssetPath(name);
            var language = AssetDatabase.LoadAssetAtPath<Language>(path);
            languages.Add(language);
        }
        
        Debug.Log(languages.Count() + " languge(s) loaded");
    }

    void AddKey()
    {
        if (!keys.keys.Any(k => k == keyToAdd)) // key does not already exist
        {
            keys.keys.Add(keyToAdd);

            foreach (Language lang in languages)
            {
                lang.translations.Add("");
            }
        }

        keyToAdd = "";
        LanguagesManager.translationsChanged = true;
    }

    void RemoveKey()
    {
        if (keys.keys.Any(k => k == keyToRemove)) // key does exist
        {
            int index = keys.keys.FindIndex(k => k == keyToRemove);

            keys.keys.Remove(keyToRemove);

            foreach (Language lang in languages)
            {
                lang.translations.RemoveAt(index);
            }
        }

        keyToRemove = "";
        LanguagesManager.translationsChanged = true;
    }

    void AddLanguage()
    {
        if (!languages.Any(l => l.name == languageToAdd)) // language does not already exist
        {
            Language newLanguage = (Language) ScriptableObject.CreateInstance<Language>();
            newLanguage.init(languageToAdd, new List<string> ( new string[keys.keys.Count()]));

            AssetDatabase.CreateAsset(newLanguage, "Assets/Resources/Languages/" + languageToAdd + ".asset");
            AssetDatabase.SaveAssets();

            languages.Add(newLanguage);
        }

        languageToAdd = "";
        LanguagesManager.translationsChanged = true;
    }

    void RemoveLanguage()
    {
        if (languages.Any(l => l.name == langaugeToRemove)) // language does exist
        {
            Language oldLanguage = languages.FirstOrDefault(l => l.name == langaugeToRemove);
            languages.Remove(oldLanguage);

            string name = (AssetDatabase.FindAssets(langaugeToRemove, new[] { "Assets/Resources/Languages" }))[0];
            var path = AssetDatabase.GUIDToAssetPath(name);
            AssetDatabase.DeleteAsset(path);
        }

        langaugeToRemove = "";
        LanguagesManager.translationsChanged = true;
    }

    void SetActiveLanguage()
    {
        if (languages.Any(l => l.name == languageSwap)) // language does exist
        {
            LanguagesManager.activeLanguage = languageSwap;
            SaveLoad.SaveData();
        }

        languageSwap = "";
        LanguagesManager.translationsChanged = true;
    }
}
