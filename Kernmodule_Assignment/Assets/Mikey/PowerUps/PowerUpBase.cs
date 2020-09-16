using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpBase : IRotateable
{
    protected string _name { get; set; }

    private GameObject _prefab;
    private GameObject _ball;
    private GameObject _canvas;
    private PowerUp_Flashbang _power3;
    private PowerUp_Small _power4;


    //The power up list will contain every powerup that exists, this is needed to send data through with the collision. It will decide what action to do on collision
    //The second object will store the gameobjects that have been spawned and contain the index of the PowerUp class associated with it
    protected static Dictionary<int, PowerUpBase> _powerUpList = new Dictionary<int, PowerUpBase>();
    protected static Dictionary<GameObject, int> _gameObjectList = new Dictionary<GameObject, int>();

    private int _powerupsatatime = 2;

    private PowerUpBase _value;

    //This instantiates the prefab
    //Changes the name
    //calls the change color function
    //And adds the gameobject to the dictionary
    public void Spawn(GameObject obj, int type)
    {
        //takes the screen region to spawn between
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(300, Screen.width - 100), Random.Range(0, Screen.height), 10));
        GameObject Spawn = GameObject.Instantiate(obj, screenPosition, Quaternion.identity);
        Spawn.name = _name;
        Test2(Spawn);
        _gameObjectList.Add(Spawn, type);
    }

    public void StartUp(GameObject prefab, GameObject ball, GameObject canvas)
    {
        this._ball = ball;
        this._prefab = prefab;
        this._canvas = canvas;

        //makes the constructor run once to add themself to the dictonary
        PowerUpBase power1 = new PowerUp_Slomo();
        PowerUpBase power2 = new PowerUp_Speed();
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

    //rotates the object
    public virtual void Rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(0, 2, 1) * Time.deltaTime * 11f);
    }

    public virtual void SpawnIn(GameObject PU)
    {
        if (PU.transform.localScale.magnitude < 0.1f)
        {
            PU.transform.localScale = Vector3.Lerp(PU.transform.localScale, PU.transform.localScale * 2, Time.deltaTime * 5);
        }
    }

    //sets the funtion every power up will need
    public virtual void Test2(GameObject t) { }
    public virtual void DoAction(GameObject t) { }

    //checks difference between the sphere and the gameobject
    //Will remove if its close enough otherwise it calls the rotate function
    //will also call the action
    public void CheckCol(GameObject player, GameObject powerup)
    {
        if (Vector3.Distance(player.transform.position, powerup.transform.position) < 0.5 + (player.transform.localScale.x / 2))
        {
            _gameObjectList.Remove(powerup);
            GameObject.Destroy(powerup);
            Camera.main.GetComponent<AudioSource>().Play();
            DoAction(player);
        }
        else
        {
            Rotate(powerup);
            SpawnIn(powerup);
        }
    }
}
