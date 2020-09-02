using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class First_PU {

    public GameObject Powerupblock;

    public First_PU(GameObject powerupblock)
    {
        this.Powerupblock = powerupblock;
    }

    public void changeColor(GameObject t)
    {
        t.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void changeColors()
    {
        this.Powerupblock.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void spawn(string name)
    {
        GameObject p = GameObject.Instantiate(Powerupblock);
        p.name = name;
        changeColor(p);
    }

}
