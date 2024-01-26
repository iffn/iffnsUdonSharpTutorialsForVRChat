
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class AxisInputsBackup : UdonSharpBehaviour
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

        /*
        KeyCode[] joystickButtons = new KeyCode[] { 
            KeyCode.JoystickButton0, KeyCode.JoystickButton1, KeyCode.JoystickButton2, KeyCode.JoystickButton3, KeyCode.JoystickButton4, KeyCode.JoystickButton5, KeyCode.JoystickButton6, KeyCode.JoystickButton7, KeyCode.JoystickButton8, KeyCode.JoystickButton9, KeyCode.JoystickButton10, KeyCode.JoystickButton11, KeyCode.JoystickButton12, KeyCode.JoystickButton13, KeyCode.JoystickButton14, KeyCode.JoystickButton15, KeyCode.JoystickButton16, KeyCode.JoystickButton17, KeyCode.JoystickButton18, KeyCode.JoystickButton19,
            KeyCode.Joystick1Button0, KeyCode.Joystick1Button1, KeyCode.Joystick1Button2, KeyCode.Joystick1Button3, KeyCode.Joystick1Button4, KeyCode.Joystick1Button5, KeyCode.Joystick1Button6, KeyCode.Joystick1Button7, KeyCode.Joystick1Button8, KeyCode.Joystick1Button9, KeyCode.Joystick1Button10, KeyCode.Joystick1Button11, KeyCode.Joystick1Button12, KeyCode.Joystick1Button13, KeyCode.Joystick1Button14, KeyCode.Joystick1Button15, KeyCode.Joystick1Button16, KeyCode.Joystick1Button17, KeyCode.Joystick1Button18, KeyCode.Joystick1Button19,
            KeyCode.Joystick2Button0, KeyCode.Joystick2Button1, KeyCode.Joystick2Button2, KeyCode.Joystick2Button3, KeyCode.Joystick2Button4, KeyCode.Joystick2Button5, KeyCode.Joystick2Button6, KeyCode.Joystick2Button7, KeyCode.Joystick2Button8, KeyCode.Joystick2Button9, KeyCode.Joystick2Button10, KeyCode.Joystick2Button11, KeyCode.Joystick2Button12, KeyCode.Joystick2Button13, KeyCode.Joystick2Button14, KeyCode.Joystick2Button15, KeyCode.Joystick2Button16, KeyCode.Joystick2Button17, KeyCode.Joystick2Button18, KeyCode.Joystick2Button19,
            KeyCode.Joystick3Button0, KeyCode.Joystick3Button1, KeyCode.Joystick3Button2, KeyCode.Joystick3Button3, KeyCode.Joystick3Button4, KeyCode.Joystick3Button5, KeyCode.Joystick3Button6, KeyCode.Joystick3Button7, KeyCode.Joystick3Button8, KeyCode.Joystick3Button9, KeyCode.Joystick3Button10, KeyCode.Joystick3Button11, KeyCode.Joystick3Button12, KeyCode.Joystick3Button13, KeyCode.Joystick3Button14, KeyCode.Joystick3Button15, KeyCode.Joystick3Button16, KeyCode.Joystick3Button17, KeyCode.Joystick3Button18, KeyCode.Joystick3Button19,
            KeyCode.Joystick4Button0, KeyCode.Joystick4Button1, KeyCode.Joystick4Button2, KeyCode.Joystick4Button3, KeyCode.Joystick4Button4, KeyCode.Joystick4Button5, KeyCode.Joystick4Button6, KeyCode.Joystick4Button7, KeyCode.Joystick4Button8, KeyCode.Joystick4Button9, KeyCode.Joystick4Button10, KeyCode.Joystick4Button11, KeyCode.Joystick4Button12, KeyCode.Joystick4Button13, KeyCode.Joystick4Button14, KeyCode.Joystick4Button15, KeyCode.Joystick4Button16, KeyCode.Joystick4Button17, KeyCode.Joystick4Button18, KeyCode.Joystick4Button19,
            KeyCode.Joystick5Button0, KeyCode.Joystick5Button1, KeyCode.Joystick5Button2, KeyCode.Joystick5Button3, KeyCode.Joystick5Button4, KeyCode.Joystick5Button5, KeyCode.Joystick5Button6, KeyCode.Joystick5Button7, KeyCode.Joystick5Button8, KeyCode.Joystick5Button9, KeyCode.Joystick5Button10, KeyCode.Joystick5Button11, KeyCode.Joystick5Button12, KeyCode.Joystick5Button13, KeyCode.Joystick5Button14, KeyCode.Joystick5Button15, KeyCode.Joystick5Button16, KeyCode.Joystick5Button17, KeyCode.Joystick5Button18, KeyCode.Joystick5Button19,
            KeyCode.Joystick6Button0, KeyCode.Joystick6Button1, KeyCode.Joystick6Button2, KeyCode.Joystick6Button3, KeyCode.Joystick6Button4, KeyCode.Joystick6Button5, KeyCode.Joystick6Button6, KeyCode.Joystick6Button7, KeyCode.Joystick6Button8, KeyCode.Joystick6Button9, KeyCode.Joystick6Button10, KeyCode.Joystick6Button11, KeyCode.Joystick6Button12, KeyCode.Joystick6Button13, KeyCode.Joystick6Button14, KeyCode.Joystick6Button15, KeyCode.Joystick6Button16, KeyCode.Joystick6Button17, KeyCode.Joystick6Button18, KeyCode.Joystick6Button19,
            KeyCode.Joystick7Button0, KeyCode.Joystick7Button1, KeyCode.Joystick7Button2, KeyCode.Joystick7Button3, KeyCode.Joystick7Button4, KeyCode.Joystick7Button5, KeyCode.Joystick7Button6, KeyCode.Joystick7Button7, KeyCode.Joystick7Button8, KeyCode.Joystick7Button9, KeyCode.Joystick7Button10, KeyCode.Joystick7Button11, KeyCode.Joystick7Button12, KeyCode.Joystick7Button13, KeyCode.Joystick7Button14, KeyCode.Joystick7Button15, KeyCode.Joystick7Button16, KeyCode.Joystick7Button17, KeyCode.Joystick7Button18, KeyCode.Joystick7Button19,
            KeyCode.Joystick8Button0, KeyCode.Joystick8Button1, KeyCode.Joystick8Button2, KeyCode.Joystick8Button3, KeyCode.Joystick8Button4, KeyCode.Joystick8Button5, KeyCode.Joystick8Button6, KeyCode.Joystick8Button7, KeyCode.Joystick8Button8, KeyCode.Joystick8Button9, KeyCode.Joystick8Button10, KeyCode.Joystick8Button11, KeyCode.Joystick8Button12, KeyCode.Joystick8Button13, KeyCode.Joystick8Button14, KeyCode.Joystick8Button15, KeyCode.Joystick8Button16, KeyCode.Joystick8Button17, KeyCode.Joystick8Button18, KeyCode.Joystick8Button19
        };


        KeyCode[] mainJoystickButtons = new KeyCode[] {
            KeyCode.JoystickButton0, KeyCode.JoystickButton1, KeyCode.JoystickButton2, KeyCode.JoystickButton3, KeyCode.JoystickButton4, KeyCode.JoystickButton5, KeyCode.JoystickButton6, KeyCode.JoystickButton7, KeyCode.JoystickButton8, KeyCode.JoystickButton9, KeyCode.JoystickButton10, KeyCode.JoystickButton11, KeyCode.JoystickButton12, KeyCode.JoystickButton13, KeyCode.JoystickButton14, KeyCode.JoystickButton15, KeyCode.JoystickButton16, KeyCode.JoystickButton17, KeyCode.JoystickButton18, KeyCode.JoystickButton19
        };
        */

        /*
        [UdonSynced, HideInInspector] public float[] axisGroup1 = new float[39];
        [UdonSynced, HideInInspector] public float[] axisGroup2 = new float[40];
        */

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
            /*
            if(axisGroup1.Length != allAxisInProjectSettings1.Length)
            {
                Debug.LogWarning("Error: Axis 1 length missmatch");
            }

            if (axisGroup2.Length != allAxisInProjectSettings2.Length)
            {
                Debug.LogWarning("Error: Axis 2 length missmatch");
            }
            */

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

            //OwnershipButton.gameObject.SetActive(!Networking.IsOwner(gameObject));

            string joystickButtonNameString = "Joystick button names:" + newLine;



            /*
            for(int i = 0; i<mainJoystickButtons.Length; i++)
            {
                //joystickButtonNameString += "" + mainJoystickButtons[i].ToString() + newLIne;
                //joystickButtonNameString += newLIne;
            }
            */

            /*
            foreach(KeyCode keyCode in mainJoystickButtons)
            {
                //joystickButtonNameString += keyCode.ToString() + newLIne;
                joystickButtonNameString += newLIne;
            }
            */

        }

        private void Update()
        {
            string text1 = "Output:" + newLine;
            string text2 = "Output:" + newLine;

            /*
            if (Networking.IsOwner(gameObject))
            {
                for (int i = 0; i < allAxisInProjectSettings1.Length; i++)
                {
                    axisGroup1[i] = Input.GetAxisRaw(allAxisInProjectSettings1[i]);
                }

                for (int i = 0; i < allAxisInProjectSettings2.Length; i++)
                {
                    axisGroup2[i] = Input.GetAxisRaw(allAxisInProjectSettings2[i]);
                }
            }

            foreach (float axis in axisGroup1)
            {
                text1 += $"{axis}" + newLine;
            }

            foreach (float axis in axisGroup2)
            {
                text2 += $"{axis}" + newLine;
            }
            */

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

            /*
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button0).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button1).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button2).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button3).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button4).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button5).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button6).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button7).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button8).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button9).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button10).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button11).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button12).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button13).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button14).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button15).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button16).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button17).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button18).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick1Button19).ToString() + newLIne;

            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button0).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button1).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button2).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button3).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button4).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button5).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button6).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button7).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button8).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button9).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button10).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button11).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button12).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button13).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button14).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button15).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button16).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button17).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button18).ToString() + newLIne;
            joystickButtonValueString += Input.GetKey(KeyCode.Joystick2Button19).ToString() + newLIne;
            */

            joystickButtonValues.text = joystickButtonValueString;

            /*
            foreach (KeyCode keyCode in mainJoystickButtons)
            {
                //joystickButtonNameString += Input.GetKey(keyCode).ToString() + newLIne;
                joystickButtonNameString += newLIne;
            }
            */
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

        /*
        public void IWantToBeTheOwner()
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }

        public override void OnOwnershipTransferred(VRCPlayerApi player)
        {
            OwnershipButton.gameObject.SetActive(!player.isLocal);
        }
        */
    }
}