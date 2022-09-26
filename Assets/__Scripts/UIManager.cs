using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text playText;
    [SerializeField] private Text optionsText;
    [SerializeField] private Text quitText;
    [SerializeField] private Text newKeyText0;
    [SerializeField] private Text newKeyText1;
    [SerializeField] private Text newKeyText2;

    [SerializeField] [HideInInspector] private Dictionary<string, string> localStrings;

    // Start is called before the first frame update
    void Start()
    {
        localStrings = Languages.translations[Languages.currentLanguage];
        
        playText.text = localStrings["MENU_PLAY"];
        optionsText.text = localStrings["MENU_OPTIONS"];
        quitText.text = localStrings["MENU_QUIT"];
    }

    void ChangeLanguage(string language)
    {
        Languages.currentLanguage = language;
        localStrings = Languages.translations[Languages.currentLanguage];
    }
}
