using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tymon_Main : MonoBehaviour
{
    public Transform pongball;
    private Tymon_Pongball p;

    // Start is called before the first frame update
    void Start()
    {
        p = new Tymon_Pongball(pongball, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        p.PongballUpdate();
    }
}
