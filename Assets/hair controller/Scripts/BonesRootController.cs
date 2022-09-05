using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.DuckType.Jiggle;
public class BonesRootController : MonoBehaviour
{
    int curretChild;
    [SerializeField]
    private GameObject hairBone;
    [SerializeField]
    Jiggle[] bonHairHolders;
    // Start is called before the first frame update
    void Start()
    {
        curretChild = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addNewHairPices()
    {
        int i = 0;

        foreach (Jiggle j in bonHairHolders)
        {
            j.AddWind = true;
            if (i < 1)
                j.SpringStrength = .2f;
            else
                j.SpringStrength = .25f;
            j.RotationInertia = .85f;
            j.Dampening = .65f;
            i++;

        }
        // GameObject newHairChildObj = Instantiate(hairBone, Vector3.zero, Quaternion.identity, this.transform);
        // curretChild++;
    }
    public void resetJiggleSatate()
    {
        foreach (Jiggle j in bonHairHolders)
        {
            j.AddWind = false;
           
            j.SpringStrength = .25f;

            j.RotationInertia = 0;
            j.Dampening = 1f;
        }
    }
    public void disable()
    {
        foreach (Jiggle j in bonHairHolders)
        {
            j.CenterOfMass = new Vector3(-.3f, .1f, 0);
            j.RotationInertia = 1f;
            //j.CenterOfMassInertia = .1f;
            j.Gravity = .15f;
            j.SpringStrength = .05f;

            //j.enabled = false;
        }
    }

}
