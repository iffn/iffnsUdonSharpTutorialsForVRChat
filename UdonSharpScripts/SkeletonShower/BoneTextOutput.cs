
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BoneTextOutput : UdonSharpBehaviour
{
    [SerializeField] Transform BoneParent;
    Transform[] Bones;
    [SerializeField] TMPro.TextMeshProUGUI BonePositions;
    [SerializeField] TMPro.TextMeshProUGUI BoneRotations;

    string newLine = "\n";

    void Start()
    {
        Bones = new Transform[BoneParent.childCount - 1];

        for(int i = 0; i < Bones.Length; i++)
        {
            Bones[i] = BoneParent.GetChild(i + 1);
        }
    }

    private void Update()
    {
        string positionText = "";
        string rotationText = "";

        positionText += "Local position:" + newLine;
        rotationText += "Local rotation:" + newLine;

        for (int i = 0; i < Bones.Length; i++)
        {
            if (i == 12 || i == 25 || i == 40)
            {
                positionText += newLine;
                rotationText += newLine;
            }
            positionText += Bones[i].localPosition + newLine;
            rotationText += Bones[i].localEulerAngles + newLine;
        }

        BonePositions.text = positionText;
        BoneRotations.text = rotationText;
    }
}
