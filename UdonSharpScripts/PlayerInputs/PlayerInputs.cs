using UdonSharp;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class PlayerInputs : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI InfoBox;
        [SerializeField] Dropdown dropdown;
        string[] currentInputs;
        string selectedController = "";

        string[] EmptyInputs = new string[]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        };

        string[] KeyboardInputs = new string[]
        {
            "Space = 1, otherwise 0",
            "LMB down = 1, otherwise 0",
            "LMB down = 1, otherwise 0",
            "RMB down = 1, otherwise 0",
            "D = -1, D = 1, otherwise 0",
            "W = 1, S = -1, ottherwise 0",
            "Mouse left...right = -1...1",
            "Mouse fwd...back = 1...-1"
        };

        string[] ViveInputs = new string[]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        };

        string[] IndexInputs = new string[]
        {
            "Right lower button = 1, otherwise 0",
            "LTrigger or RTrigger True, always 0",
            "LGrab or RGrab",
            "-",
            "LJoystick left...right = -1...1",
            "LJoystick up...down = 1...-1",
            "RJoystick left...right = -1...1",
            "RLJoystick up...down = 1...-1"
        };

        string[] XboxOneInputs = new string[]
        {
            "A press = 1, otherwise 0",
            "B press = 1, otherwise 0",
            "B press = 1, otherwise 0",
            "Y press = 1, otherwise 0",
            "LStick Left...Right = -1...1",
            "LStick Fwd...Bwd = 1...-1",
            "RStick Left...Right = -2...2",
            "RStick Fwd...Bwd = 1...-1"
        };

        string[] Ques2tInputs = new string[]
        {
            "Right controller: Lower button = 1, otherwise 0",
            "LTrigger or RTrigger True, always 0",
            "LGrab or RGrab True, always 0",
            "-",
            "LJoystick left...right = -1...1",
            "LJoystick up...down = 1...-1",
            "RJoystick left...right = -1...1",
            "RLJoystick up...down = 1...-1"
        };

        bool jumpValue = false;
        bool useValue = false;
        bool grabValue = false;
        bool dropValue = false;
        float moveHorizontalValue = 0;
        float moveVerticalValue = 0;
        float lookHorizontalValue = 0;
        float lookVerticalValue = 0;

        int jumpUpdateCount = 0;
        int useUpdateCount = 0;
        int grabUpdateCount = 0;
        int dropUpdateCount = 0;
        int moveHorizontalUpdateCount = 0;
        int moveVerticalUpdateCount = 0;
        int lookHorizontalUpdateCount = 0;
        int lookVerticalUpdateCount = 0;

        VRC.Udon.Common.UdonInputEventArgs jumpArguments = new VRC.Udon.Common.UdonInputEventArgs();
        VRC.Udon.Common.UdonInputEventArgs useArguments = new VRC.Udon.Common.UdonInputEventArgs();
        VRC.Udon.Common.UdonInputEventArgs grabArguments = new VRC.Udon.Common.UdonInputEventArgs();
        VRC.Udon.Common.UdonInputEventArgs dropArguments = new VRC.Udon.Common.UdonInputEventArgs();
        VRC.Udon.Common.UdonInputEventArgs moveHorizontalArguments = new VRC.Udon.Common.UdonInputEventArgs();
        VRC.Udon.Common.UdonInputEventArgs moveVerticalArguments = new VRC.Udon.Common.UdonInputEventArgs();
        VRC.Udon.Common.UdonInputEventArgs lookHorizontalArguments = new VRC.Udon.Common.UdonInputEventArgs();
        VRC.Udon.Common.UdonInputEventArgs lookVerticalArguments = new VRC.Udon.Common.UdonInputEventArgs();

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        private void Start()
        {
            currentInputs = KeyboardInputs;
            selectedController = "Keyboard";
        }
        
        private void Update()
        {
            string outputText = "";

            outputText += $"{selectedController} input reference: {currentInputs[0]}{newLine}";
            outputText += "Jump value = " + jumpValue + newLine;
            outputText += "Jump eventType = " + jumpArguments.eventType + newLine;
            outputText += "Jump floatValue = " + jumpArguments.floatValue + newLine;
            outputText += "Jump boolValue = " + jumpArguments.boolValue + newLine;
            outputText += "Jump handType = " + jumpArguments.handType + newLine;
            outputText += "Jump updates = " + jumpUpdateCount + newLine;
            outputText += newLine;

            outputText += $"{selectedController} input reference: {currentInputs[1]}{newLine}";
            outputText += "Use value = " + useValue + newLine;
            outputText += "Use eventType = " + useArguments.eventType + newLine;
            outputText += "Use floatValue = " + useArguments.floatValue + newLine;
            outputText += "Use boolValue = " + useArguments.boolValue + newLine;
            outputText += "Use handType = " + useArguments.handType + newLine;
            outputText += "Use updates = " + useUpdateCount + newLine;
            outputText += newLine;

            outputText += $"{selectedController} input reference: {currentInputs[2]}{newLine}";
            outputText += "Grab value = " + grabValue + newLine;
            outputText += "Grab eventType = " + grabArguments.eventType + newLine;
            outputText += "Grab floatValue = " + grabArguments.floatValue + newLine;
            outputText += "Grab boolValue = " + grabArguments.boolValue + newLine;
            outputText += "Grab handType = " + grabArguments.handType + newLine;
            outputText += "Grab updates = " + grabUpdateCount + newLine;
            outputText += newLine;

            outputText += $"{selectedController} input reference: {currentInputs[3]}{newLine}";
            outputText += "Drop value = " + dropValue + newLine;
            outputText += "Drop eventType = " + dropArguments.eventType + newLine;
            outputText += "Drop floatValue = " + dropArguments.floatValue + newLine;
            outputText += "Drop boolValue = " + dropArguments.boolValue + newLine;
            outputText += "Drop handType = " + dropArguments.handType + newLine;
            outputText += "Drop updates = " + dropUpdateCount + newLine;
            outputText += newLine;

            outputText += $"{selectedController} input reference: {currentInputs[4]}{newLine}";
            outputText += "Move horizontal value = " + moveHorizontalValue + newLine;
            outputText += "Move horizontal eventType = " + moveHorizontalArguments.eventType + newLine;
            outputText += "Move horizontal floatValue = " + moveHorizontalArguments.floatValue + newLine;
            outputText += "Move horizontal boolValue = " + moveHorizontalArguments.boolValue + newLine;
            outputText += "Move horizontal handType = " + moveHorizontalArguments.handType + newLine;
            outputText += "Move horizontal updates = " + moveHorizontalUpdateCount + newLine;
            outputText += newLine;

            outputText += $"{selectedController} input reference: {currentInputs[5]}{newLine}";
            outputText += "Move vertical value = " + moveVerticalValue + newLine;
            outputText += "Move vertical eventType = " + moveVerticalArguments.eventType + newLine;
            outputText += "Move vertical floatValue = " + moveVerticalArguments.floatValue + newLine;
            outputText += "Move vertical boolValue = " + moveVerticalArguments.boolValue + newLine;
            outputText += "Move vertical handType = " + moveVerticalArguments.handType + newLine;
            outputText += "Move vertical updates = " + moveVerticalUpdateCount + newLine;
            outputText += newLine;

            outputText += $"{selectedController} input reference: {currentInputs[6]}{newLine}";
            outputText += "Look horizontal value = " + lookHorizontalValue + newLine;
            outputText += "Look horizontal eventType = " + lookHorizontalArguments.eventType + newLine;
            outputText += "Look horizontal floatValue = " + lookHorizontalArguments.floatValue + newLine;
            outputText += "Look horizontal boolValue = " + lookHorizontalArguments.boolValue + newLine;
            outputText += "Look horizontal handType = " + lookHorizontalArguments.handType + newLine;
            outputText += "Look horizontal updates = " + lookHorizontalUpdateCount + newLine;
            outputText += newLine;

            outputText += $"{selectedController} input reference: {currentInputs[7]}{newLine}";
            outputText += "Look vertical value = " + lookVerticalValue + newLine;
            outputText += "Look vertical eventType = " + lookVerticalArguments.eventType + newLine;
            outputText += "Look vertical floatValue = " + lookVerticalArguments.floatValue + newLine;
            outputText += "Look vertical boolValue = " + lookVerticalArguments.boolValue + newLine;
            outputText += "Look vertical handType = " + lookVerticalArguments.handType + newLine;
            outputText += "Look vertical updates = " + lookVerticalUpdateCount + newLine;

            InfoBox.text = outputText;
        }

        public void SelectInputReference()
        {
            int dropdownIndex = dropdown.value;

            switch (dropdownIndex)
            {
                case 0:
                    selectedController = "Keyboard";
                    currentInputs = KeyboardInputs;
                    break;
                case 1:
                    //Vive
                    selectedController = "Vive";
                    currentInputs = ViveInputs;
                    break;
                case 2:
                    selectedController = "Index";
                    currentInputs = IndexInputs;
                    break;
                case 3:
                    selectedController = "Quest 2";
                    currentInputs = Ques2tInputs;
                    break;
                case 4:
                    selectedController = "Keyboard";
                    currentInputs = KeyboardInputs;
                    break; 
                case 5:
                    selectedController = "XBox One Controller";
                    currentInputs = XboxOneInputs;
                    break;
                case 6:
                    selectedController = "Saitek X52 Pro";
                    currentInputs = EmptyInputs;
                    break;
                case 7:
                    selectedController = "Logitech 3D Extreme Pro";
                    currentInputs = EmptyInputs;
                    break;

            }
        }

        public override void InputJump(bool value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            jumpValue = value;
            jumpArguments = args;
            jumpUpdateCount++;
        }
        public override void InputUse(bool value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            useValue = value;
            useArguments = args;
            useUpdateCount++;
        }
        public override void InputGrab(bool value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            grabValue = value;
            grabArguments = args;
            grabUpdateCount++;
        }
        public override void InputDrop(bool value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            dropValue = value;
            dropArguments = args;
            dropUpdateCount++;
        }
        public override void InputMoveHorizontal(float value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            moveHorizontalValue = value;
            moveHorizontalArguments = args;
            moveHorizontalUpdateCount++;
        }
        public override void InputMoveVertical(float value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            moveVerticalValue = value;
            moveVerticalArguments = args;
            moveVerticalUpdateCount++;
        }
        public override void InputLookHorizontal(float value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            lookHorizontalValue = value;
            lookHorizontalArguments = args;
            lookHorizontalUpdateCount++;
        }
        public override void InputLookVertical(float value, VRC.Udon.Common.UdonInputEventArgs args)
        {
            lookVerticalValue = value;
            lookVerticalArguments = args;
            lookVerticalUpdateCount++;
        }
    }
}