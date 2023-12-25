using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern string GetLang();

    public string currentLanguage;

    #region Singleton
    public static LanguageManager instance;
    private void Awake()
    {
        instance = this;

        transform.parent = null;
    }
    #endregion       

    [SerializeField]
    InternationalText[] texts;

    private void Start()
    {
        //StartCoroutine(Translate());
    }

    //IEnumerator Translate()
    //{
    //    yield return StartCoroutine(TranslateText());

    //    StartCoroutine(AllTranslate());
    //}

    //IEnumerator TranslateText()
    //{
    //    if (GameManager.instance.relise == true)
    //    {
    //        currentLanguage = GetLang();
    //    }        
    //    yield return null;
    //}

    IEnumerator AllTranslate()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].Translation();
            yield return null;
        }
    }
}
