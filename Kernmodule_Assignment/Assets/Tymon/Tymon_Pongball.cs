using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class of the pongball that bounces in the screen
/// </summary>
public class Tymon_Pongball
{
    /// <summary>
    /// The direction of the ball x-axis
    /// </summary>
    private int dirX = 1;
    /// <summary>
    /// The direction of the ball y-axis
    /// </summary>
    private int dirY = 1;
    /// <summary>
    /// The current movement speed of the ball
    /// </summary>
    private float movementSpeed;

    /// <summary>
    /// Reference to the pongball transform
    /// </summary>
    private Transform pongball;
    /// <summary>
    /// Reference to the transform of the player and enemy (for collision)
    /// </summary>
    private Transform[] bars;

    /// <summary>
    /// Set values when creating this class
    /// </summary>
    /// <param name="pongball">The transform of the pongball</param>
    /// <param name="movementSpeed">The movementspeed of the pongball</param>
    /// <param name="bars">The bars, meaning the player and enemy "blocks" on either side of the screen</param>
    public Tymon_Pongball(Transform pongball, float movementSpeed, Transform[] bars)
    {
        this.pongball = pongball;
        this.movementSpeed = movementSpeed;
        this.bars = bars;
    }

    /// <summary>
    /// Called by Tymon_Main to update this class
    /// </summary>
    public void Update()
    {
        Movement();
        Collision();
    }

    /// <summary>
    /// Moves the pongball in the right direction
    /// </summary>
    private void Movement()
    {
        // Move
        pongball.position = new Vector3(pongball.position.x + dirX * movementSpeed * Time.deltaTime, pongball.position.y + dirY * movementSpeed * Time.deltaTime, 0);
        // Clamp inside camera view
        Vector3 pos = Camera.main.WorldToViewportPoint(pongball.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        pongball.position = Camera.main.ViewportToWorldPoint(pos);
        // Change direction if it reached the edge of screen
        if(pos.x == 0) dirX = 1; else if(pos.x == 1) dirX = -1;
        if(pos.y == 0) dirY = 1; else if(pos.y == 1) dirY = -1;
    }

    /// <summary>
    /// Check for collisions with the ball
    /// </summary>
    private void Collision()
    {
        // Loop trough all transforms to check collision with
        foreach(Transform bar in bars)
        {
            // Check if ball pos hits barpos ( Bounce off),
            // Check x
            if(pongball.position.x <= bar.position.x + bar.localScale.x && pongball.position.x >= bar.position.x - bar.localScale.x)
            {
                // Check y
                if(pongball.position.y <= bar.position.y + bar.localScale.y && pongball.position.y >= bar.position.y - bar.localScale.y)
                {
                    // Collision, bounche off in right direction
                    if(pongball.position.x < bar.position.x) dirX = -1; else dirX = 1;
                    if(pongball.position.y < bar.position.y) dirY = 1; else dirY = -1;
                }
            }
        }
    }
}