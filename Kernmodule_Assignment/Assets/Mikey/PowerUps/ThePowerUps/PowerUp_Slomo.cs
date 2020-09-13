using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Slomo : PowerUpBase
{

    //constructor
    public PowerUp_Slomo()
    {
        name = "Slomo";
        powerUpList.Add(0, this);   
    }

    //the color of the sphere changes, just testing
    public override void DoAction(GameObject ball)
    {
        Debug.Log("slomo died");
        ball.GetComponent<MeshRenderer>().material.color = Color.blue;

    }

    //For now this will set the color of the powerup
    public override void Test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 255.0f, 0.20f);
    }
}
