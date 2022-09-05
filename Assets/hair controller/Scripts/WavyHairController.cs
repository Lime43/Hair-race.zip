using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyHairController : MonoBehaviour
{
    private SkinnedMeshRenderer[] skinnedMesh;

    // Start is called before the first frame update
    void Awake()
    {
        skinnedMesh = this.transform.GetComponentsInChildren<SkinnedMeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeColor(Material newMaterial)
    {
        foreach (SkinnedMeshRenderer skinedMeshChild in skinnedMesh)
        {
            print("Yooo Assign new mat");
            skinedMeshChild.material = newMaterial;
        }
    }
}
