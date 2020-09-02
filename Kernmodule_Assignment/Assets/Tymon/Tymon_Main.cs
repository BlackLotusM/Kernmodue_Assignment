using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tymon_Main : MonoBehaviour
{
    public Transform pongball;
    public Transform player;
    public Transform enemy;
    private Tymon_Pongball tymon_pongball;
    private Tymon_Player tymon_player;
    private Tymon_Enemy tymon_enemy;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] arr = { player, enemy };
        tymon_pongball = new Tymon_Pongball(pongball, 5f, arr);
        tymon_player = new Tymon_Player(player, 10f, 8f);
        tymon_enemy = new Tymon_Enemy(enemy, pongball, -7f, 11f);
    }

    // Update is called once per frame
    void Update()
    {
        tymon_pongball.Update();
        tymon_player.Update();
        tymon_enemy.Update();
    }
}
