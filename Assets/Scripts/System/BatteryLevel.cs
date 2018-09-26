using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class BatteryLevel : MonoBehaviour {
    public Text Percentage;
    void Update () {
        if (SystemInfo.batteryLevel < 0)
        {
            Percentage.text = "<color=red><size=18><b>[No battery found.]</b></size></color>\n<size=12>(Are you on a desktop?)</size>";
        }
        else{
            Percentage.text = "["+(SystemInfo.batteryLevel * 100) + "%]\n<size=12>(" + SystemInfo.batteryStatus + ")</size>";
        }
    }
}
