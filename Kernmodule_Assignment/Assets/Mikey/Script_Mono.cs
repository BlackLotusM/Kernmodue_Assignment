using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Script_Mono : MonoBehaviour
{


    //TO-DO make list gameobject 

    public GameObject PowerUpBlock;
    private First_PU PU;

    int numEnemies = 4;

    public List<First_PU> PowerList;

    private void Start()
    {
        PU = new First_PU(PowerUpBlock);
        PowerList = new List<First_PU>();

        for (int i = 0; i < numEnemies; i++)
        {
            PowerList.Add(new First_PU(PU.Powerupblock));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(PowerList);
            PowerList.Add(new First_PU(PU.Powerupblock));
            Debug.Log(PowerList.Count);

            if(PowerList.Count > 13)
            {
                First_PU p = PowerList[13];
                p.changeColors();
            }
        }        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PU.spawn("" + PowerList.Count);
            PowerList.Add(PU);

            for (int i = 0; i < PowerList.Count; i++)
            {
                First_PU pb = PowerList[i];
            }
        }
    }
}
