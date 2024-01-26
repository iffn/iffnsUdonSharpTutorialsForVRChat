using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class FunctionSpeedTestCs : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI forOutputField;
    [SerializeField] TMPro.TextMeshProUGUI codeOutputField;
    [SerializeField] TMPro.TextMeshProUGUI timeOutputField;
    [SerializeField] int forRuns = 100;

    void Start()
    {
        RunTest();
    }

    string forString = "";
    string codeString = "";
    string timeString = "";
    const string newLine = "\n";

    void AddForOutput(int forCount, string codeOutput, double timeMs)
    {
        double singleTimeUs = timeMs * 1000 / forCount;

        forString += "for(" + forCount + ")" + newLine;
        codeString += "{ " + codeOutput + "; }" + newLine;
        timeString += "" + singleTimeUs.ToString("0.0000") + "μs" + newLine;
    }

    void AddRepeatOutput(int repeatCount, string codeOutput, double timeMs)
    {
        double singleTimeUs = timeMs * 1000 / repeatCount;

        forString += "" + repeatCount + "x" + newLine;
        codeString += "{" + codeOutput + "}" + newLine;
        timeString += "" + singleTimeUs.ToString("0.0000") + "μs" + newLine;
    }

    void AddEmptyLine()
    {
        forString += newLine;
        codeString += newLine;
        timeString += newLine;
    }

    void WriteOutput()
    {
        forOutputField.text = forString;
        codeOutputField.text = codeString;
        timeOutputField.text = timeString;
    }

    void ClearOutput()
    {
        forString = "";
        codeString = "";
        timeString = "";
    }

    void RunTest()
    {
        ClearOutput();

        Stopwatch stopWatch = new Stopwatch();
        double deltaTime = 0;

        int intTest = 0;
        float floatTest = 0;
        Vector3 vector3Test = Vector3.zero;
        Quaternion quaternionTest = Quaternion.identity;

        stopWatch.Start();
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        intTest += 1;
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddRepeatOutput(repeatCount: 100, codeOutput: "intTest += 1", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        intTest = 0;
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            intTest += 1;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "intTest += 1", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        intTest = 0;
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            intTest++;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "intTest++", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        intTest = 0;
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            intTest++;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "intTest++", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------
        /*
        intTest = 0;
        int[] testArray = new int[forRuns];
        for (int i = 0; i < forRuns; i++)
        {
            testArray[i] = intTest++;
        }
        intTest = 0;
        foreach (int i in testArray)
        {
            intTest++;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        outputString += forRuns + " += int additions with foreach loop = " + deltaTime + "us" + newLine;
        stopWatch.Reset();
        */
        //---------------------

        intTest = 0;
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            intTest = intTest + 1;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "intTest = intTest + 1", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        intTest = 0;
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            intTest = intTest + 1 + intTest;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "intTest = intTest + 1 + intTest", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        intTest = 0;
        int forRunsX2 = forRuns * 2;
        stopWatch.Start();
        for (int i = 0; i < forRunsX2; i++)
        {
            intTest++;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRunsX2, codeOutput: "intTest++", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------
        AddEmptyLine();
        //---------------------

        floatTest = 0;
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            floatTest++;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "floatTest++", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            floatTest = Random.value;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "floatTest = Random.value", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            floatTest = intTest;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "floatTest = intTest", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            intTest = (int)floatTest;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "intTest = (int)floatTest", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------
        AddEmptyLine();
        //---------------------

        vector3Test = new Vector3(1, 2, 3);
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            floatTest = vector3Test.magnitude;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "floatTest = vector3Test.magnitude", timeMs: deltaTime);
        stopWatch.Reset();

        //---------------------

        quaternionTest = Quaternion.Euler(new Vector3(10, 20, 30));
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            vector3Test = quaternionTest * vector3Test;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "vector3Test = quaternionTest * vector3Test", timeMs: deltaTime);
        //outputString += forRuns + "for(" + forRuns + "){} = " + deltaTime + "us" + newLine;
        stopWatch.Reset();

        //---------------------
        AddEmptyLine();
        //---------------------

        Transform myself = transform;
        Transform parent = transform.parent;
        Transform parentOfParent = parent.parent;
        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            transform.parent = transform.parent;
            transform.parent = parentOfParent;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "transform.parent = transform.parent", timeMs: deltaTime);
        //outputString += forRuns + "for(" + forRuns + "){} = " + deltaTime + "us" + newLine;
        stopWatch.Reset();

        //---------------------

        stopWatch.Start();
        for (int i = 0; i < forRuns; i++)
        {
            transform.parent = parent;
            transform.parent = parentOfParent;
        }
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        AddForOutput(forCount: forRuns, codeOutput: "transform.parent = parentOfParent -> and back", timeMs: deltaTime);
        //outputString += forRuns + "for(" + forRuns + "){} = " + deltaTime + "us" + newLine;
        stopWatch.Reset();

        //---------------------

        //AddForOutput(forCount: forRuns, codeOutput: "", timeMs: deltaTime);

        /*
        Vector3 Vector3Test;

        stopWatch.Start();
        intTest = 5 + 6;
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        outputString += "int addition = " + deltaTime + "us" + newLine;
        §
        stopWatch.Restart();
        Vector3 a = new Vector3(3f, 5f, 7f);
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        outputString += "Vector3 creation = " + deltaTime + "us" + newLine;

        Vector3 b = new Vector3(3f, 5f, 7f);
        stopWatch.Restart();
        Vector3Test = a + b;
        stopWatch.Stop();
        deltaTime = stopWatch.Elapsed.TotalMilliseconds;
        outputString += "Vector3 addition = " + deltaTime + "us" + newLine;
        */

        WriteOutput();
    }

    /*
    public override void Interact()
    {
        RunTest();
        //DebugField.text = outputString;
    }
    */
}
