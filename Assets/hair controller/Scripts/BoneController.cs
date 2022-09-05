using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.DuckType.Jiggle;

public class BoneController : MonoBehaviour
{
    public HairBoneController hairBoneController;
    private Jiggle jiggle;
    // Start is called before the first frame update
    void Start()
    {

        hairBoneController = this.GetComponentInParent<HairBoneController>();
        jiggle = this.GetComponent<Jiggle>();
       // downScaleHair();
    }

    // Update is called once per frame
    void Update()
    {
        float scale = hairBoneController.transform.localScale.y;
        if (scale < 3f)
        {
            jiggle.AddWind = false;

        }

    }
    public int downScaleHair()
    {
        int childS = 0;
        Transform parent = this.transform.GetChild(0);
        
        while (parent != null)
        {
            parent = parent.GetChild(0).transform;
            if (parent.GetComponent<BoneController>()!=null)
                childS++;
            else
            {
                hairBoneController.cutHair(childS);
                return childS;
            }
            print("Childs on this gameobject are :" + childS);

        }
        return childS;
    }

}
