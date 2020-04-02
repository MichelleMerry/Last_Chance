using UnityEngine;
using System.IO;
public class LoadSettings : MonoBehaviour
{
    // Start is called before the first frame update
    private int vSyncTog; // vSync Toggle
    public float newSens; // New Sensitivity
    private bool Fullscreen; // Fullscreen Toggle
    void Start()
    {
        using(StreamReader sr = new StreamReader("settings.txt")) // Read the settings file.
        {
            string[] text = File.ReadAllLines("settings.txt"); // Read all lines.
            sr.Close();
            if (text[2] == "True") 
            {
                Fullscreen = true; // Fullscreen = true since [2] (Line 2 is the value for fullscreen)
            }
            if (text[2] == "False")
            {
                Fullscreen = false; // Fullscreen = false
            }
            if (text[0] == "False")
            {
                vSyncTog = 0; // Line 0 in the text file is VSyncTog, so we just check the value here.
            }
            else if (text[0] == "True")
            {
                vSyncTog = 1; // Line 0 in the text file is VSyncTog, so we just check the value here.
            }
            if (text[1] == "0") // if statements for applying resolution. 1920 x 1080
            {
                
                Screen.SetResolution(1920, 1080, Fullscreen); 
            }
            if (text[1] == "1") // 1600 x 900
            {
                
                Screen.SetResolution(1600, 900, Fullscreen);
            }
            if (text[1] == "2") // 1280 x 720
            {
                
                Screen.SetResolution(1280, 720, Fullscreen);
            }
            newSens = float.Parse(text[3]);
            QualitySettings.vSyncCount = vSyncTog;
        }
       
    }
}
