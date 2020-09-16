using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Slomo : PowerUpBase, IRotateable
{

    //constructor
    public PowerUp_Slomo()
    {
        _name = "Slomo";
        _powerUpList.Add(0, this);   
    }

    //the color of the sphere changes, just testing
    public override void DoAction(GameObject ball)
    {
        Tymon_Pongball.ChangeSpeed(-2.5f);
    }

    //For now this will set the color of the powerup
    public override void Test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 255.0f, 0.20f);
    }
}
