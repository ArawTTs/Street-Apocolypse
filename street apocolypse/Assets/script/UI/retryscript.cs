using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retryscript : MonoBehaviour
{
    public string sceneToLoad;
    public void restart()
    {
        SceneManager.LoadScene("1stround");
        SceneManager.LoadScene(sceneToLoad);
    }

    public void quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
