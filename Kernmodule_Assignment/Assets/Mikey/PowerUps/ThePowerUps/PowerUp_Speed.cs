using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUpBase, IRotateable
{
    //constructor
    public PowerUp_Speed()
    {
        name = "Speed";
        powerUpList.Add(1, this);
    }

    //changes color of the ball just to test 
    public override void DoAction(GameObject ball)
    {
        Debug.Log("speed died");
    }

    //Changes color of the power up just to show its working
    public override void Test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(255.0f, 1.0f, 1.0f, 0.20f);
    }

    //rotates the speed power up different from the others
    public override void Rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(4, 0, 0) * Time.deltaTime * 20f);
    }
}
