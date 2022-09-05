using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHairPiecesController : MonoBehaviour
{
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponentInChildren<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("char")|| other.gameObject.CompareTag("Aichar")) {

            other.GetComponent<PlayerHair>().Hair.GetComponent<SkinnedMeshRenderer>().material=mat;

            other.GetComponent<PlayerHair>().HC.GetComponent<HairController>().growHairBones(ref mat);


            Destroy(this.gameObject);
        }

    }
}
