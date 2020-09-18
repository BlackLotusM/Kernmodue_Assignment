using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class of the enemy, the bar (or gameobject) that is on the left side
/// </summary>
public class Tymon_Enemy
{
    /// <summary>
    /// The speed at which the enemy can move
    /// </summary>
    protected float _enemySpeed;
    /// <summary>
    /// The x-axis the enemy is locked on (cannot move towords other x-axis value)
    /// </summary>
    protected float _xPositionLock;
    /// <summary>
    /// Reference to the enemy transform
    /// </summary>
    protected Transform _enemy;
    /// <summary>
    /// Reference to the ball transform
    /// </summary>
    protected Transform _ball;

    /// <summary>
    /// Set values for this class
    /// </summary>
    /// <param name="enemy">Refrence to the enemy transform</param>
    /// <param name="ball">Reference to the ball transform</param>
    /// <param name="xPositionLock">The x-axis the enemy is locked on</param>
    /// <param name="enemySpeed">The speed at which the enemy can move</param>
    public Tymon_Enemy(Transform enemy, Transform ball, float xPositionLock, float enemySpeed)
    {
        this._enemy = enemy;
        this._ball = ball;
        this._xPositionLock = xPositionLock;
        this._enemySpeed = enemySpeed;
    }

    /// <summary>
    /// Called by Tymon_Main to update this class
    /// </summary>
    public virtual void Update()
    {
        // Move the enemy position y-axis towords the ball y-axis, when the ball is over an x-axis threshold        
        _enemy.position = Vector3.MoveTowards(_enemy.position, _ball.position, _enemySpeed * Time.deltaTime);
        _enemy.position = new Vector3(_xPositionLock, _enemy.position.y, _enemy.position.z);        
    }
}