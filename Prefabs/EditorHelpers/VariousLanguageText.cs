using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Various language text")]
public class VariousLanguageText : ScriptableObject
{
    [TextArea(2, 99)]
    public string englishText;

    [TextArea(2, 99)]
    public string japaneseText;

    [TextArea(2, 99)]
    public string tokiponaText;
}
