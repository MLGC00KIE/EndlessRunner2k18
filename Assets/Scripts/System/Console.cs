using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Console : MonoBehaviour {
    public InputField InputField;
    string Command;
    public Text ConsoleText;

    public void NewCommand(){
        Command = InputField.text;
        InputField.text = "";
        string[] SplitCommand = Command.ToLower().Split(' ');
        if (SplitCommand[0] == "changelevel"){
            if (Application.CanStreamedLevelBeLoaded(SplitCommand[1])){
                ConsoleText.text = "Changing scene to: '" + SplitCommand[1] + "'.\n" + ConsoleText.text;
                SceneManager.LoadScene(SplitCommand[1]);
            }
            else if (SplitCommand[1] == ""){
                ConsoleText.text = "<color=red><b>Please, Specify a stage.</b>\n</color>" + ConsoleText.text;
            }else{
                ConsoleText.text = "Scene <color=red>'" + SplitCommand[1] + "'</color> does <b>not</b> exist.\n" + ConsoleText.text;
            }
        }
        else if (SplitCommand[0] == "exit"){
            ConsoleText.text = "This will close the console someday in the future! :)\n" + ConsoleText.text;
        }
        else if (SplitCommand[0] == "quit"){
            ConsoleText.text = "<b>Quitting application..\n</b>" + ConsoleText.text;
            Application.Quit();
            ConsoleText.text = "<color=red>Warning: FAILED TO QUIT.</color>\n" + ConsoleText.text;
        }
        else if (SplitCommand[0] == "clear"){
            ConsoleText.text = "";
        }
        else if (SplitCommand[0] == "timescale")
        {
            if (float.Parse(SplitCommand[1]) < 0){
                ConsoleText.text = "<color=red>TimeScale cannot be lower than 0.</color>\n" + ConsoleText.text;
            }
            else{
                Time.timeScale = float.Parse(SplitCommand[1]);
                ConsoleText.text = "TimeScale set to: " + SplitCommand[1] + ".\n" + ConsoleText.text;
            }
        }
        else if (SplitCommand[0] == ""){
            ConsoleText.text = "This cannot be left empty.\n" + ConsoleText.text;
        }
        else if (SplitCommand[0] == "help"){
            ConsoleText.text = "________________________________\nThese commands are available: \n - ChangeLevel + [level name]\n - Exit\n - Quit\n - Help\n - Clear\n - TimeScale [ammount]\n" + ConsoleText.text;
        }
        else
        {
            ConsoleText.text = "Unknown command.\nTry using 'Help'.\n" + ConsoleText.text;
        }
    }


}
