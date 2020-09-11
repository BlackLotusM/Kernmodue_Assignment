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
    private PowerUpBase PowerUps;
    public GameObject panel;


    private void Start()
    {
        //Runs the startup Function to add all the powerups to the dictonary
        PowerUps = new PowerUpBase();
        PowerUps.StartUp(prefab, ball, panel);
    }

    private void Update()
    {
        PowerUps.UpdateAll();
    }
}