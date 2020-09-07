using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class PowerUpBase
{
    protected string name { get; set; }
    public GameObject Spawn;

    public void DoStart()
    {

    }

    //This instantiates the prefab
    //Changes the name
    //calls the change color function
    //And adds the gameobject to the dictionary
    public void spawn(GameObject obj, int type)
    {
        Spawn = GameObject.Instantiate(obj);
        Spawn.name = name;
        test2(Spawn);
        Script_Mono.GameObjectList.Add(Spawn, type);
    }

    //rotates the object
    public virtual void rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(0, 2, 1) * Time.deltaTime * 11f);
    }

    //sets the funtion every power up will need
    public abstract void test2(GameObject t);
    public abstract void doAction(GameObject t);

    //checks difference between the sphere and the gameobject
    //Will remove if its close enough otherwise it calls the rotate function
    //will also call the action
    public void checkCol(GameObject player, GameObject powerup)
    {
        if (Vector3.Distance(player.transform.position, powerup.transform.position) < 1)
        {            
            Script_Mono.GameObjectList.Remove(powerup);
            GameObject.Destroy(powerup);
            doAction(player);
        }
        else
        {
            rotate(powerup);
        }
    }
}
