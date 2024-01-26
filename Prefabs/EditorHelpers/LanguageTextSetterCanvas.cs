# if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LanguageTextSetterCanvas : ApplierScript
{
    public VariousLanguageText texts;

    public TMPro.TextMeshProUGUI englishTextField;
    public TMPro.TextMeshProUGUI japaneseTextField;
    public TMPro.TextMeshProUGUI tokiponaTextField;

    public override void ApplyParameters()
    {
        englishTextField.text = texts.englishText;
        japaneseTextField.text = texts.japaneseText;
        tokiponaTextField.text = texts.tokiponaText;

        PrefabUtility.RecordPrefabInstancePropertyModifications(englishTextField);
        PrefabUtility.RecordPrefabInstancePropertyModifications(japaneseTextField);
        PrefabUtility.RecordPrefabInstancePropertyModifications(tokiponaTextField);
    }

}
#endif