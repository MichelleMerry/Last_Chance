using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Settings()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        if (Application.isEditor == true)
        {
            Debug.Log("This is open in the editor, and therefore can't be closed. The game will close if built.");
        }
        else
        {
            StopAllCoroutines();
            Application.Quit();
        }
    }

}
