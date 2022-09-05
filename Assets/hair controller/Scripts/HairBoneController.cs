using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairBoneController : MonoBehaviour
{

    public BonesRootController bns;
    public Vector3 currentHairScale;
    private bool startStretching;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (startStretching)
        {
            Vector3 reachScale =this.transform.localScale;
            reachScale.y=this.transform.localScale.y+( (currentHairScale.y *2)-this.transform.localScale.y);

            this.transform.localScale = Vector3.Lerp(this.transform.localScale, reachScale, 1f); ;
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "brick")
        //{
        //    growHairBone();
        //    print("brick collid");
        //}

     
    }
    public void growHairBone()
    {
        //bns.addNewHairPices();
       float yScale = this.transform.localScale.y;
        if (yScale > 3f)
        {
            bns.addNewHairPices();
        }
        if (yScale < 15)
            this.transform.localScale += new Vector3(0,2f, 0);
        else
            print("Rechead max value");
        currentHairScale = this.transform.localScale;
    }
    public void cutHair(int value)
    {
        Vector3 newHairScale= this.transform.localScale- new Vector3(0, .5f, 0) * value;
        if (newHairScale.y < 1)
            newHairScale.y = 1;
        this.transform.localScale = newHairScale;
        currentHairScale = this.transform.localScale;

    }
    public void resertHairJiggleConfig()
    {
        bns.resetJiggleSatate();
    }
    public void gooBackToNormalScale()
    {
        // disableJiggle();
        // startStretching = true;
        currentHairScale.y *= 2;
        this.transform.localScale = currentHairScale;
        Invoke("disableJiggle", 1f);
        Invoke("playerWin", 2f);
        Vector3 rotation = this.transform.localEulerAngles;
        rotation.x = 3;
        this.transform.localEulerAngles = rotation;
       
    }
    public void disableJiggle()
    {
        bns.disable();
    }
  

}
