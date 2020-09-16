using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEngine;

public class Script_Mono : MonoBehaviour
{
    /// <summary>
    /// Prefab for the powerups to use
    /// </summary>
    public GameObject prefab;

    /// <summary>
    /// Reference to the ball object
    /// </summary>
    public GameObject ball;

    /// <summary>
    /// Reference to the powerup class
    /// </summary>
    private PowerUpBase powerups;

    /// <summary>
    /// Reference to the flashbang powerup
    /// </summary>
    public GameObject panel;


    public Color color1 = Color.black;
    public Color color2 = Color.blue;
    private float duration = 3.0F;

    private void Start()
    {
        //Instantiates the powerup class to run the startup to add everything to the dictonary
        powerups = new PowerUpBase();
        powerups.StartUp(prefab, ball, panel);
    }

    private void Update()
    {
        //Updates the powerups
        powerups.UpdateAll();
        float t = Mathf.PingPong(Time.time, duration) / duration;
        Camera.main.backgroundColor = Color.Lerp(color1, color2, t);
    }
}