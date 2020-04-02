using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public TextMeshProUGUI sensText;
    public TextMeshProUGUI resText;
    public int Resolution;
    public bool fs;
    public bool isChecked;
    private int vSyncTog;
    private bool Fullscreen;
    private float Sensitivity;
    public Slider slider;
  
    private void Start()
    {
        if (File.Exists("settings.txt"))
        {
            using(StreamReader sr = new StreamReader("settings.txt"))
            {
                sr.Close();
            }
        }
        else if (!File.Exists("settings.txt"))
        {
            Writer();
            return;
        }
    }
    void Update()
    {
        Sensitivity = slider.value;
        sensText.SetText(Sensitivity.ToString("F0"));
        if (Resolution > 2)
        {
            Resolution = 0;
        }
        if (Resolution < 0)
        {
            Resolution = 2;
        }
        if(Resolution == 0)
        {
            resText.SetText("1920 x 1080");
        }
        if (Resolution == 1)
        {
            resText.SetText("1600 x 900");
        }
        if (Resolution == 2)
        {
            resText.SetText("1280 x 720");
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
    void Writer()
    {
        using (StreamWriter sw = new StreamWriter("settings.txt"))
        {
            sw.WriteLine("False");
            sw.WriteLine("0");
            sw.WriteLine("True");
            sw.WriteLine("5");
            sw.Close();
            return;
        }
    }
    public void ResPlus()
    {
        Resolution += 1;
    }
    public void ToggleFull()
    {
        if(Fullscreen == false)
        {
            Fullscreen = true;
            return;
        }
        if(Fullscreen == true)
        {
            Fullscreen = false;
            return;
        }
    }
    public void vSync()
    {
        if(isChecked == true) // vSync Disable.
        {
            isChecked = false;
            return;
        }
        if(isChecked == false) // vSync Enable.
        {
            isChecked = true;
            return;
        }
    }
    public void Apply() // Applies new user settings. 
    {
        using(StreamWriter sw2 = new StreamWriter("settings.txt"))
        {
            sw2.WriteLine(isChecked); // vSync Enabled / Disabled.
            sw2.WriteLine(Resolution); // Resolution Switch.
            sw2.WriteLine(Fullscreen); // Fullscreen Enabled / Disabled.
            sw2.WriteLine(Sensitivity);
            sw2.Close();
        }
        ReRead();
        // Applying Settings
        QualitySettings.vSyncCount = vSyncTog;
    }
    public void ReRead() // Changes settings.
    {
        using (StreamReader sr = new StreamReader("settings.txt"))
        {
            string[] text2 = File.ReadAllLines("settings.txt");
            sr.Close();
            if(text2[2] == "True")
            {
                Fullscreen = true;
            }
            if(text2[2] == "False")
            {
                Fullscreen = false;
            }
            if(text2[0] == "False")
            {
                vSyncTog = 0;
            }
            else if(text2[0] == "True")
            {
                vSyncTog = 1;
            }
            if(text2[1] == "0")
            {
                resText.SetText("1920 x 1080");
                Screen.SetResolution(1920, 1080, Fullscreen);
            }
            if (text2[1] == "1")
            {
                resText.SetText("1600 x 900");
                Screen.SetResolution(1600, 900, Fullscreen);
            }
            if (text2[1] == "2")
            {
                resText.SetText("1280 x 720");
                Screen.SetResolution(1280, 720, Fullscreen);
            }

        }

    }
    
}
