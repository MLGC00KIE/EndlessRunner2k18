using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Console : MonoBehaviour {
    public InputField InputField;
    string Command;
    public Text ConsoleText;
    
    public void NewCommand()
    {
        Command = InputField.text;
        InputField.text = "";
        string[] SplitCommand = Command.ToLower().Split(' ');
        if (SplitCommand[0] == "changelevel"){
            if (Application.CanStreamedLevelBeLoaded(SplitCommand[1])){
                ConsoleText.text = "Changing scene to: '" + SplitCommand[1] + "'.\n" + ConsoleText.text;
                SceneManager.LoadScene(SplitCommand[1]);
            }else{
                ConsoleText.text = "Scene '" + SplitCommand[1] + "' does not exist.\n" + ConsoleText.text;
            }
        }
        if (SplitCommand[0] == "exit"){
            ConsoleText.text = "This will close the console someday in the future! :)\n" + ConsoleText.text;
        }
        if (SplitCommand[0] == "quit"){
            Application.Quit();
        }
        if (SplitCommand[0] == "help"){
            ConsoleText.text = "These commands are available: \n - ChangeLevel + [level name] (Changes the level)\n - Exit (Exits console) \n - Quit (Quits the application)\n - Help (Shows this screen)\n" + ConsoleText.text;
        }
        if (SplitCommand[0] == ""){
            ConsoleText.text =  "This cannot be left empty.\n" + ConsoleText.text;
        }
        else
        {
            ConsoleText.text = "Command '" + SplitCommand[0] + "' not found.\n" + ConsoleText.text;
        }
    }


}
