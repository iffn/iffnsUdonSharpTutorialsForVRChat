using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using iffnsStuff.iffnsVRCStuff.DebugOutput;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class GenericDebugDisplayDemo : UdonSharpBehaviour
    {
        [SerializeField] SingleScriptDebugState LinkedStateOutput;

        float startTime = 0;
        float time = 0;
        float timeSinceStrart = 0;
        float fps = 0;

        string newLine = "\n";

        private void Start()
        {
            startTime = Time.time;
        }

        private void Update()
        {
            time = Time.time;
            timeSinceStrart = time - startTime;
            fps = 1f / Time.deltaTime;

            PrepareDebugState();
        }

        public void PrepareDebugState()
        {
            if (LinkedStateOutput == null) return;

            if (!LinkedStateOutput.IsReadyForOutput()) return;

            string name = "GenericDebugDisplayDemo";

            string currentState = "";

            currentState += "Start time: " + startTime + newLine;
            currentState += "Time: " + time + newLine;
            currentState += "Time since start: " + timeSinceStrart + newLine;
            currentState += "FPS: " + fps + newLine;

            LinkedStateOutput.SetCurrentState(displayName: name, currentState: currentState);
        }
    }
}