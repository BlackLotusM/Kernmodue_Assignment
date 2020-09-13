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
    private float enemySpeed;
    /// <summary>
    /// The x-axis the enemy is locked on (cannot move towords other x-axis value)
    /// </summary>
    private float xPositionLock;
    /// <summary>
    /// Reference to the enemy transform
    /// </summary>
    private Transform enemy;
    /// <summary>
    /// Reference to the ball transform
    /// </summary>
    private Transform ball;

    /// <summary>
    /// Set values for this class
    /// </summary>
    /// <param name="enemy">Refrence to the enemy transform</param>
    /// <param name="ball">Reference to the ball transform</param>
    /// <param name="xPositionLock">The x-axis the enemy is locked on</param>
    /// <param name="enemySpeed">The speed at which the enemy can move</param>
    public Tymon_Enemy(Transform enemy, Transform ball, float xPositionLock, float enemySpeed)
    {
        this.enemy = enemy;
        this.ball = ball;
        this.xPositionLock = xPositionLock;
        this.enemySpeed = enemySpeed;
    }

    /// <summary>
    /// Called by Tymon_Main to update this class
    /// </summary>
    public void Update()
    {
        // Move the enemy position y-axis towords the ball y-axis, when the ball is over an x-axis threshold
        
            enemy.position = Vector3.MoveTowards(enemy.position, ball.position, enemySpeed * Time.deltaTime);
            enemy.position = new Vector3(xPositionLock, enemy.position.y, enemy.position.z);
        
    }
}