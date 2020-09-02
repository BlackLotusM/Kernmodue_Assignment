using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tymon_Player
{
    private Transform player;
    private float playerSpeed;
    private float xPositionLock;

    public Tymon_Player(Transform player, float playerSpeed, float xPositionLock)
    {
        this.player = player;
        this.playerSpeed = playerSpeed;
        this.xPositionLock = xPositionLock;
    }

    public void Update()
    {
        // Get mouse pos relative to world
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(mousePos);
        // Move player towords mouse
        player.position = Vector3.MoveTowards(player.position, mousePos, playerSpeed * Time.deltaTime);
        player.position = new Vector3(xPositionLock, player.position.y, player.position.z);
    }
}
