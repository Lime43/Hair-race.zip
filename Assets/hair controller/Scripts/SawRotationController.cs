using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotationController : MonoBehaviour
{
    //Serialized Data
    [SerializeField]
    private Vector3 rotationAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationAxis);
    }
}
