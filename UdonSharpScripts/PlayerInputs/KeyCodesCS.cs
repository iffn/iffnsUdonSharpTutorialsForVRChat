using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCodesCS : MonoBehaviour
{
    public string allEnums;

    // Start is called before the first frame update
    void Start()
    {

        allEnums = "";

        foreach (KeyCode foo in Enum.GetValues(typeof(KeyCode)))
        {
            allEnums += foo.ToString() + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
