using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUpBase
{
    //constructor
    public PowerUp_Speed()
    {
        name = "Speed";
        Script_Mono.PowerUpList.Add(1, this);
    }

    //changes color of the ball just to test 
    public override void doAction(GameObject ball)
    {
        Debug.Log("speed died");
        ball.GetComponent<MeshRenderer>().material.color = Color.red;

    }

    //Changes color of the power up just to show its working
    public override void test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    //rotates the speed power up different from the others
    public override void rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(4, 0, 0) * Time.deltaTime * 20f);
    }
}
