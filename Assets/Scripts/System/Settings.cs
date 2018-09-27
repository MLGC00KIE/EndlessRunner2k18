using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    public Dropdown ResMenu;
    public Dropdown QualMenu;
    public Toggle FullToggle;
    public Toggle Percentage;
    public Toggle FPS;
    public Toggle vSync;
    public Slider MouseMenu;
    public Slider MusicMenu;
    public Slider AudioMenu;
    public Text MouseText;
    public InputField Name;

    private bool fullscreen;
    

    void Awake(){
        Name.text = PlayerPrefs.GetString("Username", "PlayerName");
        MouseMenu.value = PlayerPrefs.GetFloat("MouseSpeed", 0.2f);
        MusicMenu.value = PlayerPrefs.GetFloat("MusicVolume", 0.60f);
        AudioMenu.value = PlayerPrefs.GetFloat("AudioVolume", 0.80f);
        ResMenu.value = PlayerPrefs.GetInt("ResolutionValue", 0);
        QualMenu.value = PlayerPrefs.GetInt("QualityValue", 0);

        if (PlayerPrefs.GetInt("FullScreenMode", 0) == 0){
            FullToggle.isOn = false;
        }else{
            FullToggle.isOn = true;
        }

        if (PlayerPrefs.GetInt("FPS", 0) == 0){
            FPS.isOn = false;
        }else{
            FPS.isOn = true;
        }

        if (PlayerPrefs.GetInt("Percentage", 0) == 0){
            Percentage.isOn = false;
        }else{
            Percentage.isOn = true;
        }

        if (PlayerPrefs.GetInt("vSync", 1) == 0){
            vSync.isOn = false;
        }else{
            vSync.isOn = true;
        }
    }

    void Update(){
        if (FullToggle.isOn)
        {
            PlayerPrefs.SetInt("FullScreenMode", 1);
            Screen.fullScreen = true;
        }
        else
        {
            PlayerPrefs.SetInt("FullScreenMode", 0);
            Screen.fullScreen = false;
        }

        if (vSync.isOn)
        {
            PlayerPrefs.SetInt("vSync", 1);
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            PlayerPrefs.SetInt("vSync", 0);
            QualitySettings.vSyncCount = 0;
        }

        if (FPS.isOn)
        {
            PlayerPrefs.SetInt("FPS", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FPS", 0);
        }

        if (Percentage.isOn)
        {
            PlayerPrefs.SetInt("Percentage", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Percentage", 0);
        }

        PlayerPrefs.Save();
    }

    public void ChangeName(){
        PlayerPrefs.SetString("Username", Name.text.ToUpper());
        Name.text = Name.text.ToUpper();
    }

    //SLIDERS
    public void MouseSpeed(){
        PlayerPrefs.SetFloat("MouseSpeed", MouseMenu.value);
        MouseText.text = "(" + MouseMenu.value.ToString("F2") + ")";
    }
    public void AudioVolume(){
        PlayerPrefs.SetFloat("AudioVolume", AudioMenu.value);
    }
    public void MusicVolume(){
        PlayerPrefs.SetFloat("MusicVolume", MusicMenu.value);
        PlayerPrefs.Save();
    }

    ///////Quality
    public void QualityChange()
    {
        string[] names;
        names = QualitySettings.names;
        if (QualMenu.value == 0){
            ChangeQ(0);
        }
        if (QualMenu.value == 1){
            ChangeQ(1);
        }
        if (QualMenu.value == 2){
            ChangeQ(2);
        }
    }

    public void ChangeQ(int quality){
        PlayerPrefs.SetInt("QualityValue", quality);
        QualitySettings.SetQualityLevel(quality, true);
    }
    ///////Quality


    ///////Resolution
    public void ResolutionChange(){
        if(PlayerPrefs.GetInt("FullScreenMode", 0) == 0){
        fullscreen = false;
        }else{
        fullscreen = true;
        }
        if (ResMenu.value == 0){
            ChangeR(ResMenu.value, 640, 480);
        }
        if (ResMenu.value == 1){
            ChangeR(ResMenu.value, 768, 480);
        }
        if (ResMenu.value == 2){
            ChangeR(ResMenu.value, 1280, 720);
        }
        if (ResMenu.value == 3){
            ChangeR(ResMenu.value, 1920, 1080);
        }
    }

    public void ChangeR(int value, int lenght, int height){
        Screen.SetResolution(lenght, height, fullscreen);
        PlayerPrefs.SetInt("ResolutionValue", value);
    }
    ///////Resolution


    ///////DATA
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Boot");
    }
}
