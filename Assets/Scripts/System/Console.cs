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
                SceneManager.LoadScene(SplitCommand[1]);
            }else{
                ConsoleText.text = ConsoleText.text + "\nScene '" + SplitCommand[1] + "' does not exist.";
            }
        }
        if (SplitCommand[0] == "exit"){
            ConsoleText.text = ConsoleText.text + "\nThis will close the console someday in the future! :)";
        }
        if (SplitCommand[0] == "quit"){
            Application.Quit();
        }
        if (SplitCommand[0] == "help"){
            ConsoleText.text = ConsoleText.text + "\nThese commands are available: \n - ChangeLevel + level name (Changes the level),\n - Exit (Exits console) ,\n - Quit (Quits the application),\n - Help (Shows this screen),\n";
        }
        if (SplitCommand[0] == ""){
            ConsoleText.text = ConsoleText.text + "\nThis cannot be left empty.";
        }
        else
        {
            ConsoleText.text = ConsoleText.text + "\nCommand '" + SplitCommand[0] + "' not found.";
        }
    }


}
