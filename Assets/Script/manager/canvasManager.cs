using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class canvasManager : MonoBehaviour
{
    public static canvasManager Instance;
    [Header("Panels")]
    public GameObject winPanel;
    public GameObject LoosePanel;
    public GameObject gamepanel;
    public RectTransform coinReachPos;
    public ParticleControlScript pS;
    int levelNo = 0;
    int levelShowNo = 1;
    public TextMeshProUGUI levelText,coinText,CoinShopText;
    public Transform shopParent;
    public Sprite[] charIcons;
    public int coins;
    public int coinsNo = 0;
    private void Awake()
    {
        if (!Instance)
            Instance = this;

    }
    private void Start()
    {
        levelNo = SceneManager.GetActiveScene().buildIndex;
        if(AudioManager.instance)
        AudioManager.instance.Play("bg");
        levelShowNo = PlayerPrefs.GetInt("levelshow", 1);
        levelText.text = "Level " + levelShowNo;
        coins = PlayerPrefs.GetInt("coins");
        CoinUpdate();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void CoinUpdate()
    {
        coinText.text = coins.ToString();
        CoinShopText.text = coins.ToString();
    }
    public void RetryMethod()
    {
        //Advertisements.Instance.ShowInterstitial();
        SceneManager.LoadScene(levelNo);
    }

    public void UnlockRandom()
    {
       
        if (coins>=150)
        {
            int random = Random.Range(0, shopParent.childCount);
            shopScript sScript = shopParent.GetChild(random).GetComponent<shopScript>();

            if (!sScript.isUnlocked)
            {
                sScript.BuyButton();
                coins -= 150;
                PlayerPrefs.SetInt("coins", coins);
                print(" you have " + coins);
                CoinUpdate();
            }
            
            
        }
        
    }
    public void Adscoin()
    {
#if UNITY_EDITOR
        coins= PlayerPrefs.GetInt("coins");
        coins += 50;
        PlayerPrefs.SetInt("coins", coins);
        CoinUpdate();
        print("coin added in editor");
        print(" you have " + coins);

#endif
        //if(Advertisements.Instance.IsRewardVideoAvailable())
        //{
        //    Advertisements.Instance.ShowRewardedVideo(CompleteMethod);

        //}
    }
    private void CompleteMethod(bool completed, string advertiser)
    {
        if (completed == true)
        {
            coins = PlayerPrefs.GetInt("coins");
            coins += 50;
            PlayerPrefs.SetInt("coins", coins);
            CoinUpdate();
            print("coin added in editor");
            print(" you have " + coins);
        }
        else
        {
            //no reward
        }
    }

    public void reloadScene()
    {
        levelNo = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelNo);
    }
    public void NextLevel()
    {
        levelNo++;
        levelShowNo++;
        if (levelNo >= 50)
        {
            levelNo = 1;
            PlayerPrefs.SetInt("level", levelNo);
        }
        PlayerPrefs.SetInt("levelshow", levelShowNo);
        PlayerPrefs.SetInt("level", levelNo);

        //Advertisements.Instance.ShowInterstitial();
        SceneManager.LoadScene(levelNo);
    }
    public void FailMethod()
    {
        AudioManager.instance.Pause("bg");
        gamepanel.SetActive(false);
        LoosePanel.SetActive(true);
        //Advertisements.Instance.HideBanner();
        print("hide banner");
    }
    public void WinMethod()
    {
        AudioManager.instance.Pause("bg");
        pS.coinsCount = coinsNo;
        pS.PlayControlledParticles(new Vector2(Screen.width / 2, Screen.height / 2), coinReachPos);
        gamepanel.SetActive(false);
        winPanel.SetActive(true);
        //Advertisements.Instance.HideBanner();
        print("hide banner");

    }
    public void LoadLevel()
    {
        if(PlayerPrefs.HasKey("level"))
        {
         levelNo=   PlayerPrefs.GetInt("level");

            SceneManager.LoadScene(levelNo);
        }else
        {
        levelNo=    PlayerPrefs.GetInt("level", 1);

            SceneManager.LoadScene(levelNo);
        }
       

    }
    public void playButton()
    {
        GameManager.Instance.startGame = true;
        //Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.Adaptive);
        print("show banner");


    }

    public void loopmethod()
    {
        levelNo = 1;
        levelShowNo++;
        PlayerPrefs.SetInt("level", levelNo);
        PlayerPrefs.SetInt("levelshow", levelShowNo);
        //Advertisements.Instance.ShowInterstitial();
        SceneManager.LoadScene(levelNo);
    }
}
