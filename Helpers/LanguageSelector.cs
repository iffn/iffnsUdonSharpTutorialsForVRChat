
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LanguageSelector : UdonSharpBehaviour
{
    public GameObject[] englishTexts;
    public GameObject[] japaneseTexts;
    public GameObject[] tokiponaTexts;

    public void SelectEnglish()
    {
        foreach(GameObject element in englishTexts)
        {
            gameObject.SetActive(true);
        }

        foreach (GameObject element in japaneseTexts)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject element in tokiponaTexts)
        {
            gameObject.SetActive(false);
        }
    }

    public void SelectJapanese()
    {
        foreach (GameObject element in englishTexts)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject element in japaneseTexts)
        {
            gameObject.SetActive(true);
        }

        foreach (GameObject element in tokiponaTexts)
        {
            gameObject.SetActive(false);
        }
    }

    public void SelectTokipona()
    {
        foreach (GameObject element in englishTexts)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject element in japaneseTexts)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject element in tokiponaTexts)
        {
            gameObject.SetActive(true);
        }
    }
}
