using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Security.Principal;

public class CheatDetector : MonoBehaviour
{

    public void Update()
    {
        Process[] running = Process.GetProcesses();
        foreach (Process process in running)
        {
            try
            {
                if (!process.HasExited && process.ProcessName.ToLower().Contains("cheat"))
                {
                    UnityEngine.Debug.Log("OH NO ITS A FILTHY CHEATER");
                    Application.Quit();
                }
            }
            catch (System.InvalidOperationException)
            {
                UnityEngine.Debug.Log("oHnOsOmEtHiNg WeNt WrOnG!");
            }
        }
    }
}