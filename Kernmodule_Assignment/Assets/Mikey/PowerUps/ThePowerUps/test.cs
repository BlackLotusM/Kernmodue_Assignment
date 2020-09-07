using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : PowerUpBase
{
    public test()
    {
        name = "test";
        Script_Mono.PowerUpList.Add(2, this);
    }

    //the color of the sphere changes, just testing
    public override void doAction(GameObject ball)
    {
        Debug.Log("slomo died");
        ball.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    //For now this will set the color of the powerup
    public override void test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public override void rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(2, 0, 8) * Time.deltaTime * 40f);
    }
}
