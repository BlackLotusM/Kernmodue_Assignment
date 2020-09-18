using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tymon_Pongball
{
    public static Tymon_Pongball INSTANCE { get; set; }

    /// <summary>
    /// The direction of the ball on the x-axis
    /// </summary>
    private float _dirX = 1;
    /// <summary>
    /// The direction of the ball on the y-axis
    /// </summary>
    private float _dirY = 1;
    /// <summary>
    /// The movement speed of the ball
    /// </summary>
    private float _movementSpeed;
    /// <summary>
    /// Makes the ball go faster the more time gos on (resets when scored)
    /// </summary>
    private float _movementSpeedScaler = 1;
    /// <summary>
    /// Reference to the pongball transform
    /// </summary>
    private Transform _pongball = null;
    /// <summary>
    /// Reference to the player and enemy transform (I call them bars)
    /// </summary>
    private Transform[] _bars = null;

    /// <summary>
    /// Set class values
    /// </summary>
    /// <param name="pongball">Reference to the pongball transform</param>
    /// <param name="movementSpeed">The movement speed of the ball</param>
    /// <param name="bars">Reference to the enemy and player transforms</param>
    public Tymon_Pongball(Transform pongball, float movementSpeed, Transform[] bars)
    {
        this._pongball = pongball;
        this._movementSpeed = movementSpeed;
        this._bars = bars;
        INSTANCE = this;
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
    /// Move the ball in the right direction
    /// </summary>
    private void Movement()
    {
        // Move
        _movementSpeedScaler += Time.deltaTime * 0.1f;
        _pongball.position = new Vector3(_pongball.position.x + _dirX * _movementSpeed * _movementSpeedScaler * Time.deltaTime, _pongball.position.y + _dirY * _movementSpeed * Time.deltaTime, 0);
        // Clamp inside camera view
        Vector3 pos = Camera.main.WorldToViewportPoint(_pongball.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        // Change direction if pongball reached edge, add a point for the other side that scored
        if(pos.x == 0)
        {
            // Hit left wall, reset to middle, inverse dirX and add point for player
            pos.x = 0.5f;
            pos.y = 0.5f;
            _dirX = 1;
            _movementSpeedScaler = 1;
            _movementSpeed = 5f;
            Tymon_Main.UpdateScore(new Vector2(0, 1));
        }
        else if(pos.x == 1)
        {
            // Hit right wall, reset to middle, inverse dirX and add point for enemy
            pos.x = 0.5f;
            pos.y = 0.5f;
            _dirX = -1;
            _movementSpeedScaler = 1;
            _movementSpeed = 5f;
            Tymon_Main.UpdateScore(new Vector2(1, 0));
        }
        if(pos.y == 0) _dirY = 1; else if(pos.y == 1) _dirY = -1;
        // Set ponball position relative to camea viewport
        _pongball.position = Camera.main.ViewportToWorldPoint(pos);
    }

    /// <summary>
    /// Check for a collision with the ball
    /// </summary>
    private void Collision()
    {
        foreach(Transform bar in _bars)
        {
            // Check if ball pos hits barpos ( Bounce off),
            // Check x
            if(_pongball.position.x <= bar.position.x + bar.localScale.x && _pongball.position.x >= bar.position.x - bar.localScale.x)
            {
                // Check y
                if(_pongball.position.y <= bar.position.y + bar.localScale.y && _pongball.position.y >= bar.position.y - bar.localScale.y)
                {
                    // Bounche off in the right direction
                    if(_pongball.position.x < bar.position.x) _dirX = -1; else _dirX = 1;
                    if(_pongball.position.y < bar.position.y) _dirY = -1; else _dirY = 1;
                }
            }
        }
    }

    /// <summary>
    /// Change the current speed of the ball
    /// </summary>
    /// <param name="newSpeed">The new speed in float value</param>
    public static void ChangeSpeed(float newSpeed)
    {
        if(INSTANCE == null)
        {
            Debug.LogError("Tymon_Ponball hasnt been created yet, create it first dummy");
            return;
        }
        INSTANCE._movementSpeed += newSpeed;
        if(INSTANCE._movementSpeed < 4) INSTANCE._movementSpeed = 4;
    }
}
