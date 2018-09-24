using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Console : MonoBehaviour {
    public InputField InputField;
    string Command;
    
    public void NewCommand()
    {
        Command = InputField.text;
        string[] SplitCommand = Command.ToLower().Split(' ');

        if (SplitCommand[0] == "changelevel"){
            if (Application.CanStreamedLevelBeLoaded(SplitCommand[1])){
                SceneManager.LoadScene(SplitCommand[1]);
            }else{
                SceneManager.LoadScene("error");
            }
        }else{
            Debug.Log("Command not found");
        }
    }


}
