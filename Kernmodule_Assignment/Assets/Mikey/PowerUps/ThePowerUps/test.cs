using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : PowerUpBase
{
    public test()
    {
        name = "test";
        PowerUpList.Add(2, this);
    }

    //the color of the sphere changes, just testing
    public override void DoAction(GameObject ball)
    {
        Debug.Log("slomo died");
        ball.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    //For now this will set the color of the powerup
    public override void Test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 255.0f, 1.0f, 0.20f);
    }

    public override void Rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(2, 0, 8) * Time.deltaTime * 40f);
    }
}
