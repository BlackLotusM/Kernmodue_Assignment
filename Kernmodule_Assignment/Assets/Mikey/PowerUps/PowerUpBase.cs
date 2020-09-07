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
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(300, Screen.width - 100), Random.Range(0, Screen.height), 10));
        Spawn = GameObject.Instantiate(obj, screenPosition, Quaternion.identity);
        Spawn.name = name;
        test2(Spawn);
        Script_Mono.GameObjectList.Add(Spawn, type);

        
        //Instantiate(ball, screenPosition, Quaternion.identity);

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
