using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public GameObject[] PlayerSkin;
    int characterSelected;
    void Awake()
    {

    // PlayerPrefs.SetInt("charno", 1);

         characterSelected = PlayerPrefs.GetInt("charno", 0);

        print(characterSelected);
        PlayerSkin[characterSelected].SetActive(true);
       

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
