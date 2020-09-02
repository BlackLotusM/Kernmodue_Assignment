using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tymon_Pongball
{
    private int dirX = 1;
    private int dirY = 1;
    private float movementSpeed;

    private Transform pongball;

    public Tymon_Pongball(Transform pongball, float movementSpeed)
    {
        this.pongball = pongball;
        this.movementSpeed = movementSpeed;
    }

    /// <summary>
    /// Called to update the ball;
    /// </summary>
    public void PongballUpdate()
    {
        // Move
        pongball.position = new Vector3(pongball.position.x + dirX * movementSpeed * Time.deltaTime, pongball.position.y + dirY * movementSpeed * Time.deltaTime, 0);
        // Clamp inside camera view
        Vector3 pos = Camera.main.WorldToViewportPoint(pongball.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        pongball.position = Camera.main.ViewportToWorldPoint(pos);
        // Change dir if reached edge
        if(pos.x == 0) dirX = 1; else if(pos.x == 1) dirX = -1;
        if(pos.y == 0) dirY = 1; else if(pos.y == 1) dirY = -1;
    }
}
