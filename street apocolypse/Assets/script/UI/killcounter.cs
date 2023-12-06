using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class killcounter : MonoBehaviour
{
    public Text counterText;
    int kill;

    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Showkills();

        if(kill == 4)
        {
            boss.SetActive(true);
        }

        if(kill == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Showkills()
    {
        counterText.text = kill.ToString();
    }

    public void AddKill()
    {
        kill++;
    }
}
