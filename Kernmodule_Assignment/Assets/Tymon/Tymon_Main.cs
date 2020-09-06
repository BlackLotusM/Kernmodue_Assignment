using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main class where the monobehaviour is located and the other classes are updated
/// </summary>
public class Tymon_Main : MonoBehaviour
{
    /// <summary>
    /// The transform of the pongball (the ball that bounces over the screen)
    /// </summary>
    public Transform pongball;
    /// <summary>
    /// The transform of the player, this one is located on the right side of the screen
    /// </summary>
    public Transform player;
    /// <summary>
    /// The transform of the enemy, this one is located on the left side of the screen
    /// </summary>
    public Transform enemy;

    /// <summary>
    /// Reference to the pongball class
    /// </summary>
    private Tymon_Pongball tymon_pongball;
    /// <summary>
    /// Reference to the player class
    /// </summary>
    private Tymon_Player tymon_player;
    /// <summary>
    /// Reference to the enemy class
    /// </summary>
    private Tymon_Enemy tymon_enemy;

    // Start is called before the first frame update
    void Start()
    {
        // Create a transform array for the ball to check for collisions
        Transform[] arr = { player, enemy };
        // Set the class references/ create the classes
        tymon_pongball = new Tymon_Pongball(pongball, 5f, arr);
        tymon_player = new Tymon_Player(player, 10f, 8f);
        tymon_enemy = new Tymon_Enemy(enemy, pongball, -7f, 9f);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the classes via the Update Methode (Not the monobehaivor Update()!)
        tymon_pongball.Update();
        tymon_player.Update();
        tymon_enemy.Update();
    }
}
