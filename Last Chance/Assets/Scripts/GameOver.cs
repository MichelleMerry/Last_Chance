using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public void quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }


    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
