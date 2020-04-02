using UnityEngine;
using System.IO;

public class InitialCreateSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("settings.txt"))
        {
            using (StreamReader sr = new StreamReader("settings.txt"))
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
}
