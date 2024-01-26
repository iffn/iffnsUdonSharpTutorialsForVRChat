using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using System.IO;

public class CsvConverter : MonoBehaviour
{
    [SerializeField] UnityEngine.TextAsset csvAsset;

    [SerializeField] List<VariousLanguageText> additionals;
    [SerializeField] List<VariousLanguageText> tutorialTexts;
    [SerializeField] List<VariousLanguageText> demoTexts;

    readonly char quote = '"';

    public void ExportCsv()
    {
        //Create output string
        string outputString = "Title,English,Japanese,Toki Pona" + "\n";
        outputString += GetLinesFromVariousLanguageTextList(additionals);
        outputString += GetLinesFromVariousLanguageTextList(tutorialTexts);
        outputString += GetLinesFromVariousLanguageTextList(demoTexts);

        //Output
        File.WriteAllText(AssetDatabase.GetAssetPath(csvAsset), outputString);
        EditorUtility.SetDirty(csvAsset);
    }
    
    string GetLinesFromVariousLanguageTextList(List<VariousLanguageText> textList)
    {
        string returnString = "";

        foreach (VariousLanguageText text in textList)
        {
            returnString += GetCsvLineFromVariousLanguageText(text) + "\n";
        }

        return returnString;
    }

    string GetCsvLineFromVariousLanguageText(VariousLanguageText variousLanguageText)
    {
        return $"{quote}{variousLanguageText.name}{quote},{quote}{variousLanguageText.englishText}{quote},{quote}{variousLanguageText.japaneseText}{quote},{quote}{variousLanguageText.tokiponaText}{quote}";
    }
}
