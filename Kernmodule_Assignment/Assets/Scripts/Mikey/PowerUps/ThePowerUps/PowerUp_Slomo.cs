using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Slomo : PowerUpBase, IRotateable
{
    /// <summary>
    /// Contstructor (set values)
    /// </summary>
    public PowerUp_Slomo()
    {
        _name = "Slomo";
        _powerUpList.Add(0, this);   
    }

    /// <summary>
    /// The action of the powerup, in this case change the speed
    /// </summary>
    /// <param name="ball"></param>
    public override void DoAction(GameObject ball)
    {
        Tymon_Pongball.ChangeSpeed(-2.5f);
    }

    /// <summary>
    /// Set the color of the powerup
    /// </summary>
    /// <param name="obj"></param>
    public override void PowerUpColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 255.0f, 0.20f);
    }
}
