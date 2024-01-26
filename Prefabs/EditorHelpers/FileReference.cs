# if UNITY_EDITOR
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FileReference : ApplierScript
{
    [Header("Properties")]
    [SerializeField] bool UseShortCode;
    [SerializeField] TextAsset normalCodeFile;
    [TextArea(2, 2)]
    [SerializeField] string shortCode;

    [Header("Unity assignments")]
    [SerializeField] TMPro.TMP_InputField linkedNormalCode;
    [SerializeField] TMPro.TMP_InputField linkedShortCode;
    [SerializeField] TMPro.TextMeshProUGUI codeName;

    const float baseHeight = 15f;
    const float lineHeight = 16f;

    public override void ApplyParameters()
    {
        linkedShortCode.gameObject.SetActive(UseShortCode);
        linkedNormalCode.gameObject.SetActive(!UseShortCode);

        //Short code
        RectTransform rect = linkedShortCode.GetComponent<RectTransform>();
        Vector2 size = rect.sizeDelta;
        size.y = baseHeight + (NumberOfLinesInText(shortCode)) * lineHeight;
        size.y *= 1f * linkedShortCode.pointSize / 14;
        rect.sizeDelta = size;
        linkedShortCode.SetTextWithoutNotify(shortCode);
        PrefabUtility.RecordPrefabInstancePropertyModifications(linkedShortCode);


        //Normal code
        if (normalCodeFile)
        {
            string normalCode = normalCodeFile.text;
            linkedNormalCode.SetTextWithoutNotify(normalCode);

            rect = linkedNormalCode.GetComponent<RectTransform>();
            size = rect.sizeDelta;
            size.y = baseHeight + (NumberOfLinesInText(normalCode)) * lineHeight;
            size.y *= 1f * linkedNormalCode.pointSize / 14;
            rect.sizeDelta = size;

            codeName.text = normalCodeFile.name + ".cs";

            PrefabUtility.RecordPrefabInstancePropertyModifications(linkedNormalCode);
            PrefabUtility.RecordPrefabInstancePropertyModifications(codeName);
        }
    }

    static int NumberOfLinesInText(string text)
    {
        return text.Split(System.Environment.NewLine).Length + 1;
    }
}
#endif