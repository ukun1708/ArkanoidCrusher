using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InternationalText : MonoBehaviour
{
    [SerializeField]
    string ruText, enText;

    public void Translation()
    {
        if (LanguageManager.instance.currentLanguage == "ru")
        {
            GetComponent<TMP_Text>().text = ruText;
        }
        else if (LanguageManager.instance.currentLanguage == "en")
        {
            GetComponent<TMP_Text>().text = enText;
        }
        else
        {
            GetComponent<TMP_Text>().text = ruText;
        }
    }
}
