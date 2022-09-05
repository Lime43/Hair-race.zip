using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Qualitytarget : MonoBehaviour
{
    int qualityLevel;
    public static int au = 1;

    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerPrefs.HasKey("quality"))
        {
             qualityLevel = PlayerPrefs.GetInt("quality");

        }
        else
        {
            qualityLevel = 0;
            PlayerPrefs.SetInt("quality", qualityLevel);

        }


    }

    public void Mute()
    {
        if (au == 1)
        {
            AudioListener.volume = 0;
            au = 0;
        }
        else
        {
            AudioListener.volume = 1;
            au = 1;

        }
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
#if UNITY_ANDROID

        Application.targetFrameRate = 30;

        QualitySettings.vSyncCount = 0;


        if (qualityLevel == 0)
        {
            print("quality is low");
            QualitySettings.antiAliasing = 0;

            QualitySettings.shadowCascades = 0;
            QualitySettings.shadowDistance = 0;
            QualitySettings.shadowResolution = ShadowResolution.Low;
            QualitySettings.masterTextureLimit = 1;

        }

        else if (qualityLevel == 1)
        {
            print("quality is normal");

            QualitySettings.antiAliasing = 0;

            QualitySettings.shadowCascades = 2;
            QualitySettings.shadowDistance = 70;
            QualitySettings.shadowResolution = ShadowResolution.Medium;
            QualitySettings.masterTextureLimit = 1;
        }
        else if (qualityLevel == 2)
        {
            print("quality is high");

            QualitySettings.antiAliasing = 2;

            QualitySettings.shadowCascades = 4;
            QualitySettings.shadowDistance = 150;
            QualitySettings.shadowResolution = ShadowResolution.High;
            QualitySettings.masterTextureLimit = 0;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

#endif



#if UNITY_STANDALONE_WIN
         
         Application.targetFrameRate = 60;
         QualitySettings.vSyncCount = 1; 
         
         if (qualityLevel == 0)
         {
             QualitySettings.antiAliasing = 0;
         }
         
         if (qualityLevel == 5)
         {
             QualitySettings.antiAliasing = 8;
         }
         
#endif
    }
    public void quality(int qua)
    {
        PlayerPrefs.SetInt("quality", qua);
        Scene scene= SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
    // Update is called once per frame
    
}
