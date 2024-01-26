# if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageTextSetterWorld : ApplierScript
{
    public VariousLanguageText texts;

    public TMPro.TextMeshPro englishTextField;
    public TMPro.TextMeshPro japaneseTextField;
    public TMPro.TextMeshPro tokiponaTextField;

    public override void ApplyParameters()
    {
        englishTextField.text = texts.englishText;
        japaneseTextField.text = texts.japaneseText;
        tokiponaTextField.text = texts.tokiponaText;
    }

}
#endif