using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
//using System.Security.Principal;

public class CheatDetector : MonoBehaviour{
    /*public static bool IsAdministrator(){
        return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                  .IsInRole(WindowsBuiltInRole.Administrator);
    }
    private void Awake(){
        if (IsAdministrator()){
            SceneManager.LoadScene("menu");
        }
        else {
            print("Not enough rights, I'm outta here.");
            Application.Quit();
        }        
    }
    */
    
    void Update () {
        Process[] running = Process.GetProcesses();
        foreach (Process process in running){
            try{
                if (!process.HasExited && process.ProcessName.ToLower().Contains("cheat") && process.ProcessName.ToLower().Contains("engine")){
                    process.Kill();
                    process.WaitForExit(1000);
                }
            }
            catch (System.InvalidOperationException){
                UnityEngine.Debug.Log("oHnOsOmEtHiNg WeNt WrOnG!");
            }
        }
    }
}
