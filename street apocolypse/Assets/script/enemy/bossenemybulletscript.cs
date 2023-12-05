using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossenemybulletscript : MonoBehaviour
{
    public GameObject bullet;
    public Transform BulletPos;
    private float timer;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if(distance < 8)
        {
            timer += Time.deltaTime;

            if(timer> 5)
            {
                timer = 0;
                shoot();
                timer = 3;
                shoot();
            }
        }

        
    }

    void shoot()
    {
        Instantiate(bullet, BulletPos.position, Quaternion.identity);
    }
}

