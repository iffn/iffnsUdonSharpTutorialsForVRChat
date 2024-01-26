#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TutorialPartEditorController : ApplierScript
{
    [Header("Properties")]
    [SerializeField] VariousLanguageText titleTexts;
    [SerializeField] VariousLanguageText descriptionTexts;
    [SerializeField] float width;
    [SerializeField] Material baseMaterial;

    [Header("Unity assignments")]
    [SerializeField] Transform floorAndWallHolder;
    [SerializeField] MeshRenderer wallRenderer;
    [SerializeField] MeshRenderer floorRenderer;
    [SerializeField] LanguageTextSetterCanvas titleTop;
    [SerializeField] LanguageTextSetterCanvas titleBottom;
    [SerializeField] LanguageTextSetterCanvas description;

    //Apply
    public override void ApplyParameters()
    {
        //Floor and wall
        Vector3 floorAndWallScale = floorAndWallHolder.transform.localScale;
        floorAndWallScale.x = width;
        floorAndWallHolder.transform.localScale = floorAndWallScale;

        wallRenderer.sharedMaterial = baseMaterial;
        floorRenderer.sharedMaterial = baseMaterial;

        //Texts
        titleTop.texts = titleTexts;
        titleBottom.texts = titleTexts;
        description.texts = descriptionTexts;
    }
}

#endif