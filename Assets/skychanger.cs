using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skychanger : MonoBehaviour
{
    public Material[] mat;
    // Start is called before the first frame update
    void Start()
    {

        int ran = Random.Range(0, mat.Length);
        RenderSettings.skybox = mat[ran];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
