using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// The main class where the monobehaviour is located and the other classes are updated
/// </summary>
public class Tymon_Main : MonoBehaviour
{
    public static Tymon_Main INSTANCE { get; set; }
    [Header("Vars")]
    /// <summary>
    /// The score of the player and ai, x = ai, y = player
    /// </summary>
    public Vector2 _score;
    /// <summary>
    /// The speed of the ball, only added when created (cannot be updated)
    /// </summary>
    public float _ballSpeed = 5f;
    [Header("Needed Components")]
    /// <summary>
    /// The transform of the pongball (the ball that bounces over the screen)
    /// </summary>
    public Transform _pongball;
    /// <summary>
    /// The transform of the player, this one is located on the right side of the screen
    /// </summary>
    public Transform _player;
    /// <summary>
    /// The transform of the enemy, this one is located on the left side of the screen
    /// </summary>
    public Transform _enemy;
    /// <summary>
    /// The textmeshprogui component that displays the score
    /// </summary>
    public TextMeshProUGUI _uiScore;

    public ParticleSystem _scoredLeftParticle;
    public ParticleSystem _scoredRightParticle;

    public GameObject _buttonSingleplayer;
    public GameObject _buttonMultiplayer;

    /// <summary>
    /// Reference to the pongball class
    /// </summary>
    private Tymon_Pongball _tymon_pongball;
    /// <summary>
    /// Reference to the player class
    /// </summary>
    private Tymon_Player _tymon_player;
    /// <summary>
    /// Reference to the enemy class
    /// </summary>
    private Tymon_Enemy _tymon_enemy;

    private void Awake()
    {
        INSTANCE = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the classes via the Update Methode (Not the monobehaivor Update()!)
        _tymon_pongball?.Update();
        _tymon_player?.Update();
        _tymon_enemy?.Update();
    }

    /// <summary>
    /// Updates the score and the ui for the score
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public static void UpdateScore(Vector2 scoreToAdd)
    {
        // Add score
        INSTANCE._score += scoreToAdd;
        // Update ui
        INSTANCE._uiScore.text = INSTANCE._score.x.ToString() + " | " + INSTANCE._score.y.ToString();
        // Play particle
        if(scoreToAdd.x > 0)
        {
            INSTANCE._scoredRightParticle.Play();
        }
        else
        {
            INSTANCE._scoredLeftParticle.Play();
        }
    }

    public void ButtonPressedSingleplayer()
    {
        // Disable buttons
        _buttonSingleplayer.SetActive(false);
        _buttonMultiplayer.SetActive(false);
        // Create a transform array for the ball to check for collisions
        Transform[] arr = { _player, _enemy };
        // Set the class references/ create the classes
        _tymon_pongball = new Tymon_Pongball(_pongball, _ballSpeed, arr);
        _tymon_player = new Tymon_Player(_player, 10f, 8f);
        _tymon_enemy = new Tymon_Enemy(_enemy, _pongball, -7f, 9f);
    }

    public void ButtonPressedMultiplayer()
    {
        // Disable buttons
        _buttonSingleplayer.SetActive(false);
        _buttonMultiplayer.SetActive(false);
        // Create a transform array for the ball to check for collisions
        Transform[] arr = { _player, _enemy };
        // Set the class references/ create the classes
        _tymon_pongball = new Tymon_Pongball(_pongball, _ballSpeed, arr);
        _tymon_player = new Tymon_Player(_player, 10f, 8f);
        _tymon_enemy = new Tymon_Player_1(_enemy, _pongball, -7f, 10f);
    }
}
