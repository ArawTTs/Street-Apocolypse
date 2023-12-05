using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retryscript : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("1stround");
    }

    public void quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
