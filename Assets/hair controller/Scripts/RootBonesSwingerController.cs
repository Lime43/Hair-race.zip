using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.DuckType.Jiggle;
public class RootBonesSwingerController : MonoBehaviour
{
    public CharacterInputController characterInputController;
    private Jiggle jiggle;
    private bool canSwing = true;
    private HairBoneController hairBoneController;
    // Start is called before the first frame update
    void Start()
    {
        characterInputController = this.GetComponentInParent<CharacterInputController>();
        jiggle = this.GetComponent<Jiggle>();
        hairBoneController = GetComponentInParent<HairBoneController>();
    }

    // Update is called once per frame
    void Update()
    {
        jiggle.CenterOfMass.z = 10;

        //if (characterInputController.getTouchesDiference() > 1 && canSwing)
        //{
        //    canSwing = false;
        //    jiggle.CenterOfMass.z = 10;

        //}
        //else if (characterInputController.getTouchesDiference() < -1 && canSwing)
        //{
        //    jiggle.CenterOfMass.z = -10;
        //    canSwing = false;

        //}
        //float parentBoneScale = hairBoneController.transform.localScale.y;
        //if(parentBoneScale>4)
        //returnToIdleState();
        //else
        //{
        //    jiggle.CenterOfMass.z=0;
        //}

    }
    private void returnToIdleState()
    {
        Vector3 idleCenterOfMass = jiggle.CenterOfMass;
        if (idleCenterOfMass.z != 0)
        {
            idleCenterOfMass.z = 0;
            jiggle.CenterOfMass = Vector3.MoveTowards(jiggle.CenterOfMass, Vector3.Lerp(jiggle.CenterOfMass, idleCenterOfMass, 1),1);
        }
        else
        {
            canSwing = true;
        }
       
    }
}
