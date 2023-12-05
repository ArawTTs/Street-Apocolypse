using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;
    public static bool SpawnDia = false;
    public GameObject dia;


     private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            dia.SetActive(true);
            Time.timeScale = 0f;
            SpawnDia = true;
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
