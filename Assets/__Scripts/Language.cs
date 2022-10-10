using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLanguage", menuName = "Language", order = 1)]
public class Language : ScriptableObject
{
    public List<string> translations;

    public void init(string name, List<string> translations)
    {
        this.name = name;
        this.translations = translations;
    }
}