using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUpBase, IRotateable
{
    /// <summary>
    /// The contstuctor of the class
    /// </summary>
    public PowerUp_Speed()
    {
        _name = "Speed";
        _powerUpList.Add(1, this);
    }

    /// <summary>
    /// The action of the powerup, in this case change speed
    /// </summary>
    /// <param name="ball">The ball gameobject</param>
    public override void DoAction(GameObject ball)
    {
        Debug.Log("speed died");
        Tymon_Pongball.ChangeSpeed(2.5f);
    }

    /// <summary>
    /// Change the powerup color
    /// </summary>
    /// <param name="obj"></param>
    public override void PowerUpColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(255.0f, 1.0f, 1.0f, 0.20f);
    }

    /// <summary>
    /// Rotate the gameobject
    /// </summary>
    /// <param name="powerUp"></param>
    public override void Rotate(GameObject powerUp)
    {
        powerUp.transform.Rotate(new Vector3(4, 0, 0) * Time.deltaTime * 20f);
    }
}
