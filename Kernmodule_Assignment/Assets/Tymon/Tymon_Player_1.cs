using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the enemy class into a second player class
/// </summary>
public class Tymon_Player_1 : Tymon_Enemy
{
    /// <summary>
    /// Set values for this class
    /// </summary>
    /// <param name="enemy">Refrence to the enemy transform</param>
    /// <param name="ball">Reference to the ball transform</param>
    /// <param name="xPositionLock">The x-axis the enemy is locked on</param>
    /// <param name="enemySpeed">The speed at which the enemy can move</param>
    public Tymon_Player_1(Transform enemy, Transform ball, float xPositionLock, float enemySpeed) : base(enemy, ball, xPositionLock, enemySpeed)
    {
        this._enemy = enemy;
        this._ball = ball;
        this._xPositionLock = xPositionLock;
        this._enemySpeed = enemySpeed;
    }

    /// <summary>
    /// Called by Tymon_Main to update this class
    /// </summary>
    public override void Update()
    {
        // Get player input
        int dirY = 0;
        if(Input.GetKey(KeyCode.W)) dirY = 1; else if(Input.GetKey(KeyCode.S)) dirY = -1;
        // Move the player based on input
        _enemy.position = Vector3.MoveTowards(_enemy.position, new Vector3(_xPositionLock, _enemy.position.y + dirY, 0), _enemySpeed * Time.deltaTime);
    }
}
