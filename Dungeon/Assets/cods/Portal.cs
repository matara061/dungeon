﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;


   

    protected override void OnCollide(Collider2D coll)
    {
        
        if (coll.name == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Portal");
            // teleporta player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            //FindObjectOfType<AudioManager>().Play("Ressurgir");


        }
    }
}
