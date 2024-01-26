
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class AxisInputs : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI nameText1;
        [SerializeField] TMPro.TextMeshProUGUI nameText2;
        [SerializeField] TMPro.TextMeshProUGUI outputText1;
        [SerializeField] TMPro.TextMeshProUGUI outputText2;
        [SerializeField] TMPro.TextMeshProUGUI joystickButtonNames;
        [SerializeField] TMPro.TextMeshProUGUI joystickButtonValues;
        [SerializeField] Dropdown dropdown;
        [SerializeField] GameObject[] orderedInputReferences1;
        [SerializeField] GameObject[] orderedInputReferences2;
        [SerializeField] Button OwnershipButton;

        const string newLine = "\n";

        readonly string[] allAxisInProjectSettings1 = new string[]
        {
        "Horizontal", "Vertical", "Fire1", "Fire2", "Fire3", "Jump", "Mouse X", "Mouse Y", "Mouse ScrollWheel", "Window Shake X", "Window Shake Y", "Shift", "Mouse Horizontal", "Mouse Vertical", "Mouse Wheel", "Submit", "Cancel", "Oculus_GearVR_LThumbstickX", "Oculus_GearVR_LThumbstickY", "Oculus_GearVR_RThumbstickX", "Oculus_GearVR_RThumbstickY", "Oculus_GearVR_DpadX", "Oculus_GearVR_DpadY", "Oculus_GearVR_LIndexTrigger", "Oculus_GearVR_RIndexTrigger", "Oculus_CrossPlatform_Button2", "Oculus_CrossPlatform_Button4", "Oculus_CrossPlatform_PrimaryThumbstick", "Oculus_CrossPlatform_SecondaryThumbstick", "Oculus_CrossPlatform_PrimaryIndexTrigger", "Oculus_CrossPlatform_SecondaryIndexTrigger", "Oculus_CrossPlatform_PrimaryHandTrigger", "Oculus_CrossPlatform_SecondaryHandTrigger", "Oculus_CrossPlatform_PrimaryThumbstickHorizontal", "Oculus_CrossPlatform_PrimaryThumbstickVertical", "Oculus_CrossPlatform_SecondaryThumbstickHorizontal", "Oculus_CrossPlatform_SecondaryThumbstickVertical", "DebugInfoKey2", "DebugInfoKey1"
        };

        readonly string[] allAxisInProjectSettings2 = new string[]
        {
        "Joy1 Axis 1", "Joy1 Axis 2", "Joy1 Axis 3", "Joy1 Axis 4", "Joy1 Axis 5", "Joy1 Axis 6", "Joy1 Axis 7", "Joy1 Axis 8", "Joy1 Axis 9", "Joy1 Axis 10", "Joy2 Axis 1", "Joy2 Axis 2", "Joy2 Axis 3", "Joy2 Axis 4", "Joy2 Axis 5", "Joy2 Axis 6", "Joy2 Axis 7", "Joy2 Axis 8", "Joy2 Axis 9", "Joy2 Axis 10", "Joy3 Axis 1", "Joy3 Axis 2", "Joy3 Axis 3", "Joy3 Axis 4", "Joy3 Axis 5", "Joy3 Axis 6", "Joy3 Axis 7", "Joy3 Axis 8", "Joy3 Axis 9", "Joy3 Axis 10", "Joy4 Axis 1", "Joy4 Axis 2", "Joy4 Axis 3", "Joy4 Axis 4", "Joy4 Axis 5", "Joy4 Axis 6", "Joy4 Axis 7", "Joy4 Axis 8", "Joy4 Axis 9", "Joy4 Axis 10"
        };

        public string allEnums;

        private void Start()
        {
            string text1 = "Axis:" + newLine;
            string text2 = "Axis:" + newLine;

            foreach (string axis in allAxisInProjectSettings1)
            {
                text1 += $"{axis}" + newLine;
            }

            foreach (string axis in allAxisInProjectSettings2)
            {
                text2 += $"{axis}" + newLine;
            }

            nameText1.text = text1;
            nameText2.text = text2;
        }

        private void Update()
        {
            string text1 = "Output:" + newLine;
            string text2 = "Output:" + newLine;

            foreach (string axis in allAxisInProjectSettings1)
            {
                text1 += $"{Input.GetAxisRaw(axis)}" + newLine;
            }

            foreach (string axis in allAxisInProjectSettings2)
            {
                text2 += $"{Input.GetAxisRaw(axis)}" + newLine;
            }

            outputText1.text = text1;
            outputText2.text = text2;

            string joystickButtonValueString = "Joystick button values:" + newLine;

            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton0).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton1).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton2).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton3).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton4).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton5).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton6).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton7).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton8).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton9).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton10).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton11).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton12).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton13).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton14).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton15).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton16).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton17).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton18).ToString() + newLine;
            joystickButtonValueString += Input.GetKey(KeyCode.JoystickButton19).ToString() + newLine;

            joystickButtonValues.text = joystickButtonValueString;
        }

        public void SelectInputReference()
        {
            foreach (GameObject obj in orderedInputReferences1)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in orderedInputReferences2)
            {
                obj.SetActive(false);
            }

            int dropdownIndex = dropdown.value;

            if (dropdownIndex == 0) return;

            orderedInputReferences1[dropdownIndex - 1].SetActive(true);
            orderedInputReferences2[dropdownIndex - 1].SetActive(true);
        }
    }
}