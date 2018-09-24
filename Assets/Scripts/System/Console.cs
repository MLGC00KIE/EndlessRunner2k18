using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Console : MonoBehaviour {
    public InputField InputField;
    string Command;
    bool active;
    public Text ConsoleText;

    public void NewCommand(){
        Command = InputField.text;
        InputField.text = "";
        string[] SplitCommand = Command.ToLower().Split(' ');

        if (SplitCommand[0] == "cheats")
        {
            if (SplitCommand[1] == "true" || SplitCommand[1] == "1")
            {
                ConsoleText.text = "Cheats are now: <color=cyan><b>ENABLED</b></color>.\nRemember!\n<color=yellow><b>With great power comes great responsibility</b></color>\n" + ConsoleText.text;
                active = true;
            }
            if (SplitCommand[1] == "false" || SplitCommand[1] == "0")
            {
                ConsoleText.text = "Cheats are now: <color=RED><b>DISABLED</b></color>.\n" + ConsoleText.text;
                active = false;
            }
        }

        else if (active)
        {
            if (SplitCommand[0] == "changelevel")
            {
                if (Application.CanStreamedLevelBeLoaded(SplitCommand[1]))
                {
                    ConsoleText.text = "Changing scene to: '<b>" + SplitCommand[1] + "</b>'.\n" + ConsoleText.text;
                    SceneManager.LoadScene(SplitCommand[1]);
                }
                else if (SplitCommand[1] == "")
                {
                    ConsoleText.text = "<color=red><b>Please, Specify a stage.</b>\n</color>" + ConsoleText.text;
                }
                else
                {
                    ConsoleText.text = "Scene <color=red>'" + SplitCommand[1] + "'</color> does <b>not</b> exist.\n" + ConsoleText.text;
                }
            }
            else if (SplitCommand[0] == "exit")
            {
                ConsoleText.text = "This will close the console someday in the future! :)\n" + ConsoleText.text;
            }
            else if (SplitCommand[0] == "quit")
            {
                ConsoleText.text = "<color=white><b>Quitting application..</b></color>\n" + ConsoleText.text;
                Application.Quit();
                ConsoleText.text = "<color=red><b>Warning:</b> FAILED TO QUIT.</color>\n" + ConsoleText.text;
            }
            else if (SplitCommand[0] == "clear")
            {
                ConsoleText.text = "";
            }
            else if (SplitCommand[0] == "timescale")
            {
                if (float.Parse(SplitCommand[1]) < 0)
                {
                    ConsoleText.text = "<color=red>TimeScale cannot be lower than 0.</color>\n" + ConsoleText.text;
                }
                else if (SplitCommand[1] == "")
                {
                    ConsoleText.text = "<color=red><b>Please, Specify a speed.</b>\n</color>" + ConsoleText.text;
                }
                else
                {
                    Time.timeScale = float.Parse(SplitCommand[1]);
                    ConsoleText.text = "TimeScale set to: " + SplitCommand[1] + ".\n" + ConsoleText.text;
                }
            }
            else if (SplitCommand[0] == "")
            {
                ConsoleText.text = "<color=red>This cannot be left empty.</color>\n" + ConsoleText.text;
            }
            else if (SplitCommand[0] == "help")
            {
                ConsoleText.text = "________________________________\n<size=10><color=magenta><b>These commands are available:</b></color><color=yellow>\n - ChangeLevel <color=magenta>+</color> <color=cyan>[level name]</color>\n - Exit\n - Quit\n - Help\n - Clear\n - TimeScale <color=magenta>+</color> <color=cyan>[ammount]</color></color></size>\n________________________________\n" + ConsoleText.text;
            }
            else
            {
                ConsoleText.text = "<color=red>Unknown command.\nTry using <b><color=yellow>'Help'</color></b>.</color>\n" + ConsoleText.text;
            }
        }

        else
        {
            ConsoleText.text = "<b>You do not have enough premissions to use this menu.</b>\n" + ConsoleText.text;
        }
    }


}
