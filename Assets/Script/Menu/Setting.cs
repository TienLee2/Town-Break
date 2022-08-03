using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class Setting : MonoBehaviour
{
    public Sprite soundOn, soundOff, vibrationOn, vibrationOff, fps30, fps60, reSD, reHD;
    public Image soundImage, vibrationImage, fpsImage, reImage;
    public TextMeshProUGUI fps30text, fps60text, reSDtext, reHDtext;

    public GameObject tutorial;

    private int l, set;

    void Start()
    {
        // When game starts set the settings to the game.

        set = PlayerPrefs.GetInt("Tutorial1");
        SetTutorial();
        SetSounds();
        SetVibration();
        SetFPS();
        SetResolution();
        SetLanguage();
    }

    public void SetTutorial()
    {
        if(set == 1)
        {
            tutorial.SetActive(false);
        }
    }

    public void Tutorial()
    {
        PlayerPrefs.SetInt("Tutorial1", 1);
    }

    public void Vietnamese()
    {
        
        l = 1;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        ChangeSetting("Language", 0);
    }

    public void English()
    {
        l = 0;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        ChangeSetting("Language", 1);
    }

    public IEnumerator SetLanguage()
    {
        yield return LocalizationSettings.InitializationOperation;
        bool active = GetSetting("Language");
        if (active)
        {
            l = 1;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        }
        else
        {
            l = 0;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
        
    }

    

    public void ChangeResolution()
    {
        bool active = GetSetting("Resolution");

        if (active)
        {
            reImage.sprite = reSD;
            Screen.SetResolution(1280, 720, true);
            reHDtext.enabled = false;
            reSDtext.enabled = true;
            ChangeSetting("Resolution", 0);
        }
        else
        {
            reImage.sprite = reHD;
            Screen.SetResolution(1920, 1080, true);
            reHDtext.enabled = true;
            reSDtext.enabled = false;
            ChangeSetting("Resolution", 1);
        }
    }

    public void fpsto30()
    {
        // Get sounds state.
        bool active = GetSetting("FPS");

        // If fps is active
        if (active)
        {
            // FPS to 60
            fpsImage.sprite = fps60;
            Application.targetFrameRate = 60;
            fps30text.enabled = false;
            fps60text.enabled = true;
            ChangeSetting("FPS", 0);
            
        }
        else
        {
            // FPS default is 30
            fpsImage.sprite = fps30;
            Application.targetFrameRate = 30;
            fps30text.enabled = true;
            fps60text.enabled = false;
            ChangeSetting("FPS", 1);
        }
    }

    // When player selected to change sound state.
    public void ChangeSounds()
    {
        // Get sounds state.
        bool active = GetSetting("Sounds");

        // If sounds is active
        if (active)
        {
            // Disable sounds in the game.
            soundImage.sprite = soundOff;
            AudioListener.volume = 0.0f;
            ChangeSetting("Sounds", 0);
        }
        else
        {
            // Enable sounds in the game.
            soundImage.sprite = soundOn;
            AudioListener.volume = 1.0f;
            ChangeSetting("Sounds", 1);
        }
    }

    // When player selected to change vibration state.
    public void ChangeVibration()
    {
        // Get vibration state.
        bool active = GetSetting("Vibration");

        // If vibration is active
        if (active)
        {
            // Disable vibrations in the game.
            vibrationImage.sprite = vibrationOff;
            ChangeSetting("Vibration", 0);
        }
        else
        {
            // Enable vibrations in the game.
            vibrationImage.sprite = vibrationOn;
            ChangeSetting("Vibration", 1);
        }
    }


    // If player selected to reset all game progress.
    public void Reset()
    {
        // Delete all saved player prefs.
        PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene("Menu");
    }

    // Used to get setting value.
    public static bool GetSetting(string name)
    {
        return PlayerPrefs.GetInt(name, 1) == 1 ? true : false;
    }

    // Used to change setting value.
    private void ChangeSetting(string name, int state)
    {
        PlayerPrefs.SetInt(name, state);
    }

    private void SetResolution()
    {
        QualitySettings.vSyncCount = 0;
        bool active = GetSetting("Resolution");

        if (active)
        {
            reImage.sprite = reHD;
            Screen.SetResolution(1920, 1080, true);
            reHDtext.enabled = true;
            reSDtext.enabled = false;
        }
        else
        {
            reImage.sprite = reSD;
            Screen.SetResolution(1280, 720, true);
            reHDtext.enabled = false;
            reSDtext.enabled = true;
        }
    }

    private void SetFPS()
    {
        // Get sound state.
        bool active = GetSetting("FPS");

        // If sounds is active.
        if (active)
        {
            // Enable sounds.
            fpsImage.sprite = fps30;
            Application.targetFrameRate = 30;
            fps30text.enabled = true;
            fps60text.enabled = false;
        }
        else
        {
            // Disable sounds.
            fpsImage.sprite = fps60;
            Application.targetFrameRate = 60;
            fps30text.enabled = false;
            fps60text.enabled = true;
        }
    }

    // Setting sounds at the start of the game.
    private void SetSounds()
    {
        // Get sound state.
        bool active = GetSetting("Sounds");

        // If sounds is active.
        if (active)
        {
            // Enable sounds.
            soundImage.sprite = soundOn;
            AudioListener.volume = 1.0f;
        }
        else
        {
            // Disable sounds.
            soundImage.sprite = soundOff;
            AudioListener.volume = 0.0f;
        }
    }

    private void SetVibration()
    {
        // Get vibration state.
        bool active = GetSetting("Vibration");

        // If vibration is active.
        if (active)
        {
            // Enable vibration.
            vibrationImage.sprite = vibrationOn;
        }
        else
        {
            // Disable vibration.
            vibrationImage.sprite = vibrationOff;
        }
    }

    public void Credit()
    {
        Application.OpenURL("https://docs.google.com/document/d/1iQw3ZlbtHjV3SCLBc-WwpRcaBpxXBZn61KTxaE-YDpo/edit?usp=sharing");
    }
}
