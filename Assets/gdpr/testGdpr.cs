using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class testGdpr : MonoBehaviour
{

    public GameObject Gdpr;
    public Slider loadingSlider = null;
    public string SceneToLoad = null;
    AsyncOperation asyncLoad = null;
    public string linkPrivacy;
    int levelNo;
    // Start is called before the first frame update
    void Start()
    {
        //if (!Advertisements.Instance.UserConsentWasSet())
        {
            Gdpr.SetActive(true);

        }
        //else
        {
            //Advertisements.Instance.SetUserConsent(true);
            //Advertisements.Instance.Initialize();
            Gdpr.SetActive(false);
            StartCoroutine(load());


        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void privacylinkopen()
    {
        Application.OpenURL(linkPrivacy);
    }
    public void AcceptPrivacy()
    {
        //Advertisements.Instance.SetUserConsent(true);
        //Advertisements.Instance.Initialize();
        Gdpr.SetActive(false);
        StartCoroutine(load());
    }


    IEnumerator load()
    {
        yield return new WaitForSeconds(2);
        if (PlayerPrefs.HasKey("level"))
        {
            levelNo = PlayerPrefs.GetInt("level");
            if (levelNo == 1)
            {
                SceneManager.LoadScene(levelNo + 1);

            }else
            {
                SceneManager.LoadScene(levelNo);
            }


        }
        else
        {
            levelNo = PlayerPrefs.GetInt("level", 1);

            SceneManager.LoadScene(2);
        }
    }
}
