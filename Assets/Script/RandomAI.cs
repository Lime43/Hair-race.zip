using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : MonoBehaviour
{
    public GameObject[] AIList;
    public Animator MainAnimator;
    Animator characterAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        int ran = Random.Range(0, 2);

        foreach (GameObject ai in AIList)
        {
            ai.SetActive(false);
        }

        AIList[ran].gameObject.SetActive(true);
  

        characterAnimator = AIList[ran].GetComponent<Animator>();
        MainAnimator = characterAnimator.GetComponent<Animator>();

        MainAnimator.avatar = characterAnimator.avatar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
