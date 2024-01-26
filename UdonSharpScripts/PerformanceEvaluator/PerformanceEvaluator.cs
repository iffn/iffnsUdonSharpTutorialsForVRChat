
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PerformanceEvaluator : UdonSharpBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI DebugField;
    [SerializeField] GameObject[] PerformanceStations;
    //string newLine = "\n";

    //float betweenTime = 5;
    float stationTime = 10;

    void Start()
    {
        
    }

    public bool testInProgress = false;
    int counter = 0;
    float startTime = 0;

    private void Update()
    {
        string debugText = "";


        if (testInProgress)
        {
            counter++;

            float timeDifference = Time.time - startTime;

            if (timeDifference > stationTime)
            {
                float framerate = 1f * counter / timeDifference;

                debugText = "Framerate = " + framerate;

                testInProgress = false;

            }
            else
            {
                debugText = "Counter = " + counter;
            }
            
            DebugField.text = debugText;
        }
    }

    public override void Interact()
    {
        StartTest();
    }

    public void StartTest()
    {
        if (!testInProgress)
        {
            testInProgress = true;
            counter = 0;
            startTime = Time.time;
        }
    }
}
