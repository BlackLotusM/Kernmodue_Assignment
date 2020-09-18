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
    private float _playerSpeed;
    /// <summary>
    /// The x-axis postion where the player object is locked in (meaning it cannot change the x-axis position from this)
    /// </summary>
    private float _xPositionLock;
    /// <summary>
    /// Reference to the transform of the player
    /// </summary>
    private Transform _player;

    /// <summary>
    /// Set values for the Player class
    /// </summary>
    /// <param name="player">Reference towords the transform of the player</param>
    /// <param name="playerSpeed">The speed at wich the player can move</param>
    /// <param name="xPositionLock">The x-axis the player is locked on</param>
    public Tymon_Player(Transform player, float playerSpeed, float xPositionLock)
    {
        this._player = player;
        this._playerSpeed = playerSpeed;
        this._xPositionLock = xPositionLock;
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
        _player.position = Vector3.MoveTowards(_player.position, mousePos, _playerSpeed * Time.deltaTime);
        _player.position = new Vector3(_xPositionLock, _player.position.y, _player.position.z);
    }
}
