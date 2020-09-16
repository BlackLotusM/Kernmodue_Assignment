using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Small : PowerUpBase, IRotateable
{
    //constructor
    public PowerUp_Small()
    {
        _name = "Speed";
        _powerUpList.Add(3, this);
    }

    //changes color of the ball just to test 
    public override void DoAction(GameObject ball)
    {
        ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void ReDoSize(GameObject ball)
    {
        if (ball.transform.localScale.x < 1f)
        {
            ball.transform.localScale = Vector3.Lerp(ball.transform.localScale, ball.transform.localScale * 2, Time.deltaTime * 0.2f);
        }
    }

    //Changes color of the power up just to show its working
    public override void Test2(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(255.0f, 221.0f, 1.0f, 0.70f);
    }

    //rotates the speed power up different from the others
    public override void Rotate(GameObject PU)
    {
        PU.transform.Rotate(new Vector3(4, 0, 0) * Time.deltaTime * 20f);
    }
}
