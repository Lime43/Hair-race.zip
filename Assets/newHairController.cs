using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newHairController : MonoBehaviour
{
    public GameObject[] hairBones;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "brick")
    //    {
    //        GrowHair();

    //    }


    //}

    public void GrowHair()
    {
        foreach (GameObject hair in hairBones)
        {
            hair.GetComponent<HairBoneController>().growHairBone();
            print("brick collid");

        }
    }
    public void cutHair()
    {
        foreach (GameObject hair in hairBones)
        {
            hair.GetComponent<HairBoneController>().cutHair(1);
            print("brick collid");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
