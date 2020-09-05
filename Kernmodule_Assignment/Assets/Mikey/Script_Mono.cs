using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEngine;

public class Script_Mono : MonoBehaviour
{
    public GameObject prefab;
    public GameObject ball;

    public int powerupsatatime;

    PowerUpBase value;

    //The power up list will contain every powerup that exists, this is needed to send data through with the collision. It will decide what action to do on collision
    //The second object will store the gameobjects that have been spawned and contain the index of the PowerUp class associated with it
    public static Dictionary<int, PowerUpBase> PowerUpList = new Dictionary<int, PowerUpBase>();
    public static Dictionary<GameObject, int> GameObjectList = new Dictionary<GameObject, int>();


    private void Start()
    {
        //Instantsait the classes, this will let the classes loop through their constructor and they will add themself to the Dictionary
        PowerUpBase Power1 = new PowerUp_Slomo();
        PowerUpBase Power2 = new PowerUp_Speed();


        //For every int in powerupsatatime it will spawn on power up in the scene.
        for (int i = 0; i < powerupsatatime; i++)
        {
            //This random int will be between all available powerup indexes
            int r = UnityEngine.Random.Range(0, PowerUpList.Count);
            if (PowerUpList.TryGetValue(r, out value))
            {
                value.spawn(prefab, r);
            }
        }
    }

    private void Update()
    {
        //For  the moment this block of code will let you spawn a new powerup with pressing r
        if (Input.GetKeyDown(KeyCode.R))
        {
            int r = UnityEngine.Random.Range(0, PowerUpList.Count);
            if (PowerUpList.TryGetValue(r, out value))
            {
                value.spawn(prefab, r);
            }
        }

        //To List is needed because of errors, to list will make a temp list at the beginning of the foreach loop. This will let me remove deleted objects in the base class
        foreach (var element in GameObjectList.ToList())
        {
            if (PowerUpList.TryGetValue(element.Value, out value))
            {
                value.checkCol(ball, element.Key);
            }
        }
    }
}