using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Small : PowerUpBase, IRotateable
{
    /// <summary>
    /// The constructor of the class
    /// </summary>
    public PowerUp_Small()
    {
        _name = "Speed";
        _powerUpList.Add(3, this);
    }

    /// <summary>
    /// The action of the powerup, in this case change the scale
    /// </summary>
    /// <param name="ball"></param>
    public override void DoAction(GameObject ball)
    {
        ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    /// <summary>
    /// Resize the ball to normal scale
    /// </summary>
    /// <param name="ball"></param>
    public void ReDoSize(GameObject ball)
    {
        if (ball.transform.localScale.x < 1f)
        {
            ball.transform.localScale = Vector3.Lerp(ball.transform.localScale, ball.transform.localScale * 2, Time.deltaTime * 0.2f);
        }
    }

    /// <summary>
    /// Change the powerup color
    /// </summary>
    /// <param name="obj">The powerup gameobject</param>
    public override void PowerUpColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(255.0f, 221.0f, 1.0f, 0.70f);
    }

    /// <summary>
    /// Rotate the powerup
    /// </summary>
    /// <param name="powerUp">The powerup gameobject</param>
    public override void Rotate(GameObject powerUp)
    {
        powerUp.transform.Rotate(new Vector3(4, 0, 0) * Time.deltaTime * 20f);
    }
}
