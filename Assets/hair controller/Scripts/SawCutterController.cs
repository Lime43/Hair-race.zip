using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCutterController : MonoBehaviour
{
    [SerializeField]
    private GameObject hairPiece;
    private Transform cutPlace;
    private bool cut = false;
    // Start is called before the first frame update
    Transform hc;
    void Start()
    {
        cutPlace = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int scaler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HairBone"))
        {
             scaler=other.gameObject.GetComponent<BoneController>().downScaleHair();
            makeCutableHairPices(scaler);
        }
        if (other.gameObject.CompareTag("char"))
        {
            hc = other.GetComponent<PlayerHair>().HC.transform;
            makeCutableHairPices(scaler);
        }
    }
    private void makeCutableHairPices(int scaler)
    {
        GameObject hairObj = Instantiate(hairPiece, cutPlace.position-Vector3.forward*3+Vector3.up*5, Quaternion.identity);
        Material material =   hc.GetComponent<HairController>().getCurrentMaterial();

        hairObj.GetComponent<WavyHairController>().changeColor(material);
        Vector3 newScale = hairObj.transform.localScale;
        newScale.y *= scaler;
        hairObj.transform.localScale = newScale;
        hairObj.transform.localEulerAngles = new Vector3(100, 180, 0);
        Destroy(hairObj, 3f);
    }
}
