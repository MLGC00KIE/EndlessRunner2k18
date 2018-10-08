using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class BatteryLevel : MonoBehaviour {
    [SerializeField]
    Text Percentage;
    float color1;
    float color2;
    float PCBattery;
    void Update ()
    {
        if (PlayerPrefs.GetInt("Percentage", 0) == 1) {
            PCBattery = SystemInfo.batteryLevel;
            color2 = 1 * PCBattery;
            color1 = -color2 + 1;
            Percentage.color = new Color(color1, color2, 0);
            if (PCBattery < 0) {
                Percentage.text = "<size=18><b><color=blue>[No battery found.]</color></b></size>\n<size=12><color=white>(Are you on a desktop?)</color></size>";
            }else {
                Percentage.text = "[" + (PCBattery * 100) + "%]\n<size=12><color=white>(" + SystemInfo.batteryStatus + ")</color></size>";
            }
        }else{
            Percentage.text = "";
        }
    }
}
