using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tymon_Enemy
{
    private float enemySpeed;
    private float xPositionLock;
    private Transform enemy;
    private Transform ball;

    public Tymon_Enemy(Transform enemy, Transform ball, float xPositionLock, float enemySpeed)
    {
        this.enemy = enemy;
        this.ball = ball;
        this.xPositionLock = xPositionLock;
        this.enemySpeed = enemySpeed;
    }

    public void Update()
    {
        enemy.position = Vector3.MoveTowards(enemy.position, ball.position, enemySpeed * Time.deltaTime);
        enemy.position = new Vector3(xPositionLock, enemy.position.y, enemy.position.z);
    }
}
