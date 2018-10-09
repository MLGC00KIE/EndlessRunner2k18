using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Console : MonoBehaviour {
    [SerializeField]
    InputField InputField;
    string Command;
    bool active;
    [SerializeField]
    Text ConsoleText;
    
    bool Toggle;
    [SerializeField]
    GameObject TargetPos;


    float x;
    float y;
    float z;

    public void Logger(string Text){
        ConsoleText.text = Text + ConsoleText.text;
    }

    private void Update()
    {
        if (Input.GetKeyDown("`"))
        {
            Toggle = !Toggle;
            if (Toggle){
                transform.position = TargetPos.transform.position;
                if (SceneManager.GetActiveScene().name == "game"){
                    Cursor.lockState = CursorLockMode.None;
                }
            }else{
                transform.position = TargetPos.transform.position - new Vector3(0, 0, 2000);
                if (SceneManager.GetActiveScene().name == "game"){
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }

        
    }

    public void NewCommand() {
        Command = InputField.text;
        InputField.text = "";
        string[] SplitCommand = Command.ToLower().Split(' ');
        if (SplitCommand[0] == "spawn" || SplitCommand[0] == "s")
        {
            try
            {
                if (SplitCommand[2] != null && SplitCommand[3] != null && SplitCommand[4] != null)
                {
                    x = float.Parse(SplitCommand[2]);
                    y = float.Parse(SplitCommand[3]);
                    z = float.Parse(SplitCommand[4]);
                }
                else
                {
                    x = 0;
                    y = 0;
                    z = 0;
                }
            }
            catch {
                Logger("Something went horribly wrong..");
            }
            Instantiate(Resources.Load(SplitCommand[1]),new Vector3(x,y,z), Quaternion.identity);
            Logger("Instantiated '" + SplitCommand[1] + "' at: " + x+", " + y+", " + z+".");
        }

            if (SplitCommand[0] == "cheats"|| SplitCommand[0] == "c")
        {
            if (SplitCommand[1] == "true" || SplitCommand[1] == "1")
            {
                Logger("Cheats are now: <color=cyan><b>ENABLED</b></color>.\nRemember!\n<color=yellow><b>With great power comes great responsibilities!</b></color>\n");
                active = true;
            }
            if (SplitCommand[1] == "false" || SplitCommand[1] == "0")
            {
                Logger("Cheats are now: <color=RED><b>DISABLED</b></color>.\n");
                active = false;
            }
        }

        else if (active) {
            if (SplitCommand[0] == "changelevel"|| SplitCommand[0] == "loadlevel" || SplitCommand[0] == "cl" || SplitCommand[0] == "ll") {
                try {
                    if (Application.CanStreamedLevelBeLoaded(SplitCommand[1])) {
                        Logger("Changing scene to: '<b>" + SplitCommand[1] + "</b>'.\n");
                        SceneManager.LoadScene(SplitCommand[1]);
                    } else {
                        Logger("Scene <color=red>'" + SplitCommand[1] + "'</color> does <b>not</b> exist.\n");
                    }
                } catch {
                    Logger("<color=red><b>Something went wrong, Did you specify a stage?</b>\n</color>");
                }
            }
            else if (SplitCommand[0] == "exit") {
                Toggle = !Toggle;
                active = false;
                ConsoleText.text = "--- CLOSED ---" + ConsoleText.text;
            }
            else if (SplitCommand[0] == "quit") {
                try{
                    Logger("<color=white><b>Quitting application..</b></color>\n");
                    Application.Quit();
                    Logger("<color=red><b>Warning:</b> FAILED TO QUIT.</color>\n");
                }catch{
                    Logger("Wow you sure broke things around here.\n");
                }
            }
            else if (SplitCommand[0] == "clear"|| SplitCommand[0] == "cls") {
                ConsoleText.text = "--- CLEARED ---";
            }
            else if (SplitCommand[0] == "timescale" || SplitCommand[0] == "ts") {
                try {
                    if (float.Parse(SplitCommand[1]) < 0) {
                        Logger("<color=red>TimeScale cannot be lower than 0.</color>\n");
                    } else if (float.Parse(SplitCommand[1]) > 100) {
                        Logger("<color=red>TimeScale cannot be higher than 100.</color>\n");
                    } else {
                        Time.timeScale = float.Parse(SplitCommand[1]);
                        Logger("TimeScale set to: " + SplitCommand[1] + ".\n");
                    }
                } catch {
                    Logger("Something went very wrong, Make sure you specify a number.\n");
                }
            }
            else if (SplitCommand[0] == "") {
                Logger("<color=red>This cannot be left empty.</color>\n");
            }
            else if (SplitCommand[0] == "generate") {
                Logger("Generated test file\n");
                System.IO.File.WriteAllText("../dlc.txt", "this is the dlc wow!");
            }
            else if (SplitCommand[0] == "dlc") {
                if (System.IO.File.Exists("dlc.txt")) {
                    Logger("DLC EXISTS!");
                } else {
                    Logger("You do not have the dlc!\n");
                }
            }
            else if (SplitCommand[0] == "help" || SplitCommand[0] == "h"){
                Logger("________________________________\n<size=10><color=magenta><b>These commands are available:</b></color><color=yellow>\n - ChangeLevel <color=magenta>+</color> <color=cyan>[level name]</color>\n - Exit\n - Quit\n - Help\n - Clear\n - TimeScale <color=magenta>+</color> <color=cyan>[ammount]</color>\n - Generate\n - DLC</color></size>\n________________________________\n");
            }
            else{
                Logger("<color=red>Unknown command.\nTry using <b><color=yellow>'Help'</color></b>.</color>\n");
            }
        }

        else{
            Logger("<b>You do not have enough premissions to use this menu.</b>\n");
        }
    }
}
