using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator MainAnimator;
    Animator characterAnimator;
    public string searchTag;
    public List<GameObject> actors = new List<GameObject>();




    void Start()
    {

        if (searchTag != null)
        {
            FindObjectwithTag(searchTag);
        }

    }

    public void FindObjectwithTag(string _tag)
    {
       
        Transform parent = transform;
        GetChildObject(parent, _tag);
    }

    public void GetChildObject(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {

            Transform child = parent.GetChild(i);
            
            if (child.tag == _tag )
            {
                actors.Add(child.gameObject);
                if(child.tag=="Aichar")
                {
                    foreach (GameObject item in actors)
                    {

                        item.gameObject.SetActive(false);

                    }
                    int random = Random.Range(0, actors.Count);
                    actors[random].gameObject.SetActive(true);
                }
            
                if (child.childCount > 0)
                {
                    GetChildObject(child, _tag);
                }
            }
        }
        foreach (GameObject item in actors)
        {
          
            if (item.activeInHierarchy)
            {
              
                characterAnimator = item.GetComponent<Animator>();
                MainAnimator = characterAnimator.GetComponent<Animator>();

                MainAnimator.avatar = characterAnimator.avatar;

            }
        }

    }
   
}