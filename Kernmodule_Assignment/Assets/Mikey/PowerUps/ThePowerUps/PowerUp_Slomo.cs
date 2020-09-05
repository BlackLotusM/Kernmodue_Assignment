using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Slomo : PowerUpBase
{

    //constructor
    public PowerUp_Slomo()
    {
        name = "Slomo";
        Script_Mono.PowerUpList.Add(0, this);   
    }

    //the color of the sphere changes, just testing
    public override void doAction(GameObject ball)
    {
        Debug.Log("slomo died");
        ball.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    //For now this will set the color of the powerup
    public override void test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
