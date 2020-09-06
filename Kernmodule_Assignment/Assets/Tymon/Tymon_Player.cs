using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class that contains the player values
/// </summary>
public class Tymon_Player
{
    /// <summary>
    /// The speed the player can move his bar with (bar meaning the block on the right side)
    /// </summary>
    private float playerSpeed;
    /// <summary>
    /// The x-axis postion where the player object is locked in (meaning it cannot change the x-axis position from this)
    /// </summary>
    private float xPositionLock;
    /// <summary>
    /// Reference to the transform of the player
    /// </summary>
    private Transform player;

    /// <summary>
    /// Set values for the Player class
    /// </summary>
    /// <param name="player">Reference towords the transform of the player</param>
    /// <param name="playerSpeed">The speed at wich the player can move</param>
    /// <param name="xPositionLock">The x-axis the player is locked on</param>
    public Tymon_Player(Transform player, float playerSpeed, float xPositionLock)
    {
        this.player = player;
        this.playerSpeed = playerSpeed;
        this.xPositionLock = xPositionLock;
    }

    /// <summary>
    /// Called by Tymon_Main to update this class
    /// </summary>
    public void Update()
    {
        // Get mouse pos relative to world
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //Debug.Log(mousePos);
        // Move player towords mouse
        player.position = Vector3.MoveTowards(player.position, mousePos, playerSpeed * Time.deltaTime);
        player.position = new Vector3(xPositionLock, player.position.y, player.position.z);
    }
}
