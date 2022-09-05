using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Rndom;
   
    void Awake()
    {
        if (transform.tag == "principale")
        {
            int randomIndex = Random.Range(0, Rndom.Length);
            PlayerPrefs.SetInt("object", randomIndex);
        }
        foreach (GameObject item in Rndom)
        {
            item.SetActive(false);
        }
        int selected = PlayerPrefs.GetInt("object");
        Rndom[selected].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
