using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    private SkinnedMeshRenderer[] skinnedMesh;
    private Material currentMaterial;
    //References
    public static HairController instance;

    private void Awake()
    {
        //if (!instance) instance = this;
        //else if (instance != this) Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
         skinnedMesh = this.transform.GetComponentsInChildren<SkinnedMeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void growHairBones(ref Material  newMaterial)
    {
        print("Haiiiiiiir Grow");
        currentMaterial = newMaterial;
        changeColor(newMaterial);
        int i = 0;
         foreach (Transform child in this.transform)
         {
             HairBoneController hairBonController = child.GetComponent<HairBoneController>();

            hairBonController.growHairBone();
            i++;
            if (i > 11)
                return;
          
         }
         
        
    }
    public void changeColor(Material newMaterial)
    {
        foreach (SkinnedMeshRenderer skinedMeshChild in skinnedMesh)
        {
            print("Yooo Assign new mat");
            skinedMeshChild.material = newMaterial;
        }
    }
    public void resetHair()
    {
        foreach(Transform child in this.transform)
        {
            Vector3 childScale = child.localScale;
            childScale.y = 1;
            child.localScale = childScale;
        }
    }
    public void stretchHair()
    {
        foreach (Transform child in this.transform)
        {
            child.GetComponent<HairBoneController>().gooBackToNormalScale();
        }
    }
    public Material getCurrentMaterial()
    {
        return currentMaterial;
    }

}
