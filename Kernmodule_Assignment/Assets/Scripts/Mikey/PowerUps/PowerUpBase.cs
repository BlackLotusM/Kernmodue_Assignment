using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpBase : IRotateable
{
    /// <summary>
    /// Name of the powerup
    /// </summary>
    protected string _name { get; set; }

    /// <summary>
    /// The default prefab of the powerup
    /// </summary>
    private GameObject _prefab;
    /// <summary>
    /// The GameObject of the ball
    /// </summary>
    private GameObject _ball;
    /// <summary>
    /// The Canvas of the scene
    /// </summary>
    private GameObject _canvas;

    /// <summary>
    /// Powerup reference
    /// </summary>
    private PowerUpBase _power1;
    /// <summary>
    /// Powerup reference
    /// </summary>
    private PowerUpBase _power2;
    /// <summary>
    /// Powerup reference
    /// </summary>
    private PowerUp_Flashbang _power3;
    /// <summary>
    /// Powerup reference
    /// </summary>
    private PowerUp_Small _power4;


    //The power up list will contain every powerup that exists, this is needed to send data through with the collision. It will decide what action to do on collision
    //The second object will store the gameobjects that have been spawned and contain the index of the PowerUp class associated with it
    protected static Dictionary<int, PowerUpBase> _powerUpList = new Dictionary<int, PowerUpBase>();
    protected static Dictionary<GameObject, int> _gameObjectList = new Dictionary<GameObject, int>();
    /// <summary>
    /// Number of powerups at 1 time
    /// </summary>
    private int _powerupsatatime = 2;
    /// <summary>
    /// The value that is used for the powerupbase index (See StartUp())
    /// </summary>
    private PowerUpBase _value;

    /// <summary>
    /// This instantiates the prefab
    /// Changes the name
    /// calls the change color function
    /// And adds the gameobject to the dictionary
    /// </summary>
    /// <param name="obj">Object to spawn</param>
    /// <param name="type">The type of powerup</param>
    public void Spawn(GameObject obj, int type)
    {
        //takes the screen region to spawn between
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(300, Screen.width - 100), Random.Range(0, Screen.height), 10));
        GameObject spawn = GameObject.Instantiate(obj, screenPosition, Quaternion.identity);
        spawn.name = _name;
        PowerUpColor(spawn);
        _gameObjectList.Add(spawn, type);
    }

    /// <summary>
    /// Called at the start of the game to setup all values
    /// </summary>
    /// <param name="prefab">Prefab of the powerup</param>
    /// <param name="ball">Gameobject of the ball</param>
    /// <param name="canvas">Gameobject of the scene canvas</param>
    public void StartUp(GameObject prefab, GameObject ball, GameObject canvas)
    {
        this._ball = ball;
        this._prefab = prefab;
        this._canvas = canvas;

        //makes the constructor run once to add themself to the dictonary
        _power1 = new PowerUp_Slomo();
        _power2 = new PowerUp_Speed();
        _power3 = new PowerUp_Flashbang(_canvas);
        _power4 = new PowerUp_Small();

        //For every int in powerupsatatime it will spawn on power up in the scene.
        for (int i = 0; i < _powerupsatatime; i++)
        {
            //This random int will be between all available powerup indexes
            int typeIndex = Random.Range(0, _powerUpList.Count);
            if (_powerUpList.TryGetValue(typeIndex, out _value))
            {
                _value.Spawn(_prefab, typeIndex);
            }
        }
    }

    /// <summary>
    /// Gets called in the main script that contains the monobehaivor to update the powerups behavior
    /// </summary>
    public void UpdateAll()
    {
        //updates the flashbang stats
        _power3.CheckFlashBang();
        _power4.ReDoSize(_ball);

        //spawns new powerups if count is under 2
        if (_gameObjectList.Count < 2)
        {
            int r = Random.Range(0, _powerUpList.Count);
            if (_powerUpList.TryGetValue(r, out _value))
            {
                _value.Spawn(_prefab, r);
            }
        }

        //To List is needed because of errors, to list will make a temp list at the beginning of the foreach loop. This will let me remove deleted objects in the base class
        foreach (var element in _gameObjectList.ToList())
        {
            if (_powerUpList.TryGetValue(element.Value, out _value))
            {
                _value.CheckCol(_ball, element.Key);
            }
        }
    }

    /// <summary>
    /// Rotates the powerup gameobject
    /// </summary>
    /// <param name="powerUp"></param>
    public virtual void Rotate(GameObject powerUp)
    {
        powerUp.transform.Rotate(new Vector3(0, 2, 1) * Time.deltaTime * 11f);
    }

    /// <summary>
    /// Spawns in the gameobject in the scene
    /// </summary>
    /// <param name="powerUp"></param>
    public virtual void SpawnIn(GameObject powerUp)
    {
        if (powerUp.transform.localScale.magnitude < 0.1f)
        {
            powerUp.transform.localScale = Vector3.Lerp(powerUp.transform.localScale, powerUp.transform.localScale * 2, Time.deltaTime * 5);
        }
    }

    /// <summary>
    /// Set the color of the powerup
    /// </summary>
    /// <param name="t"></param>
    public virtual void PowerUpColor(GameObject t) { }
    /// <summary>
    /// The void that contains the functionallity of the powerup
    /// </summary>
    /// <param name="t"></param>
    public virtual void DoAction(GameObject t) { }

    /// <summary>
    /// checks difference between the sphere and the gameobject
    /// Will remove if its close enough otherwise it calls the rotate function
    /// will also call the action
    /// </summary>
    /// <param name="player"></param>
    /// <param name="powerUp"></param>
    public void CheckCol(GameObject player, GameObject powerUp)
    {
        if (Vector3.Distance(player.transform.position, powerUp.transform.position) < 0.5 + (player.transform.localScale.x / 2))
        {
            _gameObjectList.Remove(powerUp);
            GameObject.Destroy(powerUp);
            Camera.main.GetComponent<AudioSource>().Play();
            DoAction(player);
        }
        else
        {
            Rotate(powerUp);
            SpawnIn(powerUp);
        }
    }
}
