# if UNITY_EDITOR
using System.Collections.Generic;
using UdonSharp;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPartApplier : EditorWindow
{
    [MenuItem("Tools/iffnsStuff/U# Tutorials")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TutorialPartApplier));
    }

    GameObject brokenObject;

    void ApplyParameters(List<Transform> allTransforms)
    {
        brokenObject = null;

        foreach (Transform child in allTransforms)
        {
            if (child.TryGetComponent<ApplierScript>(out var currentController))
            {
                try
                {
                    currentController.ApplyParameters();
                }
                catch
                {
                    if(!brokenObject) brokenObject = currentController.transform.gameObject;
                }

                MarkAsModified(currentController);
            }
        }
    }

    void ApplyLanguages(List<Transform> allTransforms)
    {
        //Get language elements
        List<GameObject> englishReferences = new List<GameObject>();
        List<GameObject> japaneseReferences = new List<GameObject>();
        List<GameObject> tokiponaReferences = new List<GameObject>();

        foreach (Transform child in allTransforms)
        {
            if (child.TryGetComponent<LanguageReference>(out var currentController))
            {
                switch (currentController.language)
                {
                    case LanguageReference.Languages.English:
                        englishReferences.Add(currentController.transform.gameObject);
                        break;
                    case LanguageReference.Languages.Japanese:
                        japaneseReferences.Add(currentController.transform.gameObject);
                        break;
                    case LanguageReference.Languages.Tokipona:
                        tokiponaReferences.Add(currentController.transform.gameObject);
                        break;
                    default:
                        Debug.LogWarning($"Unknown language {currentController.language}. Applying stopped");
                        break;
                }
            }
        }

        //Apply elements
        foreach (Transform child in allTransforms)
        {
            if (child.TryGetComponent<LanguageSelector>(out var currentController))
            {
                currentController.englishTexts = englishReferences.ToArray();
                currentController.japaneseTexts = japaneseReferences.ToArray();
                currentController.tokiponaTexts = tokiponaReferences.ToArray();

                MarkAsModified(currentController);
            }
        }
    }

    

    void OnGUI()
    {
        if (GUILayout.Button(text: "Apply tutorial parts"))
        {
            //Get all transforms
            List<Transform> allTransforms = new List<Transform>();

            foreach (GameObject rootObject in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                allTransforms.Add(rootObject.transform);

                foreach (Transform child in rootObject.transform.GetComponentsInChildren<Transform>(true)) //Very important to add true to include inactive object
                {
                    allTransforms.Add(child);
                }
            }

            //Run functions
            ApplyParameters(allTransforms);
            ApplyLanguages(allTransforms);
        }

        if (brokenObject)
        {
            GUILayout.Label("First broken script");
            brokenObject = EditorGUILayout.ObjectField(
               brokenObject,
               typeof(GameObject),
               true) as GameObject;
        }
        
        
    }

    public static void MarkAsModified(UdonSharpBehaviour target)
    {
        PrefabUtility.RecordPrefabInstancePropertyModifications(target);
        EditorUtility.SetDirty(target);
    }

    public static void MarkAsModified(MonoBehaviour target)
    {
        PrefabUtility.RecordPrefabInstancePropertyModifications(target);
        EditorUtility.SetDirty(target);
    }
}
#endif
