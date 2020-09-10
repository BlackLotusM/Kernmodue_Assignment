using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpBase
{
    protected string name { get; set; }

    private GameObject prefab;
    private GameObject ball;

    //The power up list will contain every powerup that exists, this is needed to send data through with the collision. It will decide what action to do on collision
    //The second object will store the gameobjects that have been spawned and contain the index of the PowerUp class associated with it
    protected static Dictionary<int, PowerUpBase> PowerUpList = new Dictionary<int, PowerUpBase>();
    protected static Dictionary<GameObject, int> GameObjectList = new Dictionary<GameObject, int>();

    [SerializeField]
    private int powerupsatatime;

    private PowerUpBase value;

    //This instantiates the prefab
    //Changes the name
    //calls the change color function
    //And adds the gameobject to the dictionary
    public void Spawn(GameObject obj, int type)
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(300, Screen.width - 100), Random.Range(0, Screen.height), 10));
        GameObject Spawn = GameObject.Instantiate(obj, screenPosition, Quaternion.identity);
        Spawn.name = name;
        Test2(Spawn);
        GameObjectList.Add(Spawn, type);
    }

    public void StartUp(GameObject prefab, GameObject ball)
    {
        
        this.ball = ball;
        this.prefab = prefab;

        PowerUpBase Power1 = new PowerUp_Slomo();
        PowerUpBase Power2 = new PowerUp_Speed();
        PowerUpBase Power3 = new test();

        //For every int in powerupsatatime it will spawn on power up in the scene.
        for (int i = 0; i < powerupsatatime; i++)
        {
            //This random int will be between all available powerup indexes
            int typeIndex = Random.Range(0, PowerUpList.Count);
            if (PowerUpList.TryGetValue(typeIndex, out value))
            {
                value.Spawn(prefab, typeIndex);
            }
        }
    }

    public void UpdateAll()
    {
        //For  the moment this block of code will let you spawn a new powerup with pressing r
        if (Input.GetKeyDown(KeyCode.R))
        {
            int r = Random.Range(0, PowerUpList.Count);
            if (PowerUpList.TryGetValue(r, out value))
            {
                value.Spawn(prefab, r);
            }
        }

        if (GameObjectList.Count < 2)
        {
            int r = Random.Range(0, PowerUpList.Count);
            if (PowerUpList.TryGetValue(r, out value))
            {
                value.Spawn(prefab, r);
            }
        }

        //To List is needed because of errors, to list will make a temp list at the beginning of the foreach loop. This will let me remove deleted objects in the base class
        foreach (var element in GameObjectList.ToList())
        {
            if (PowerUpList.TryGetValue(element.Value, out value))
            {
                value.CheckCol(ball, element.Key);
            }
        }
    }

    //rotates the object
    public virtual void Rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(0, 2, 1) * Time.deltaTime * 11f);
    }

    //sets the funtion every power up will need
    public virtual void Test2(GameObject t) { }
    public virtual void DoAction(GameObject t) { }

    //checks difference between the sphere and the gameobject
    //Will remove if its close enough otherwise it calls the rotate function
    //will also call the action
    public void CheckCol(GameObject player, GameObject powerup)
    {
        if (Vector3.Distance(player.transform.position, powerup.transform.position) < 1)
        {            
            GameObjectList.Remove(powerup);
            GameObject.Destroy(powerup);
            DoAction(player);
        }
        else
        {
            Rotate(powerup);
        }
    }
}
