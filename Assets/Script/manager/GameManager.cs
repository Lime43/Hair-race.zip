using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject _PlatFormSpawn;
    public Animator cameraAnim;
    public Transform finalParent;
    int finalCount = 1;
    public List<Mesh> ai_characters;
    public bool startGame = false;
    [Header("AI")]
    public aiScript[] ai = new aiScript[3];
    public PlayerScript player;
    public int playerCharNo = 0;
    [HideInInspector]
    public List<Mesh> dummyMesh = new List<Mesh>();
    [Header("materials")]
    public Material groundMat;
    public Material downMat,water;
    public Texture[] groundTextures;
    public Texture[] downTextures;
    public Texture[] waterTextures;
    [HideInInspector]
    public int matNo = 0;
    int changeBgNo = 0;
     //quality

   
    private void Awake()
    {
        if (!Instance)
            Instance = this;
       
    }
    void Start()
    {
        changeBgNo = PlayerPrefs.GetInt("bg", 0);
        matNo = Random.Range(0, waterTextures.Length);
     int   matNoGround = Random.Range(0, groundTextures.Length);
        int matdown = Random.Range(0, downTextures.Length);
        int matwater = Random.Range(0, waterTextures.Length);

        if (changeBgNo<5)
        {
            changeBgNo++;
            PlayerPrefs.SetInt("bg", changeBgNo);
        }
        else
        {
            

            changeBgNo = 0;
            PlayerPrefs.SetInt("bg", changeBgNo);

        }

        groundMat.SetTexture("_EmissionMap", groundTextures[matNoGround]);
       groundMat.SetTexture("_MainTex", groundTextures[matNoGround]);
       downMat.SetTexture("_EmissionMap", downTextures[matdown]);
       downMat.SetTexture("_MainTex", downTextures[matdown]);
        water.SetTexture("_EmissionMap", waterTextures[matwater]);
       water.SetTexture("_MainTex", waterTextures[matwater]);
        foreach (Transform parts in finalParent)
        {
            Color c = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            parts.GetChild(0).GetComponent<MeshRenderer>().material.color = c;
            parts.name = finalCount.ToString();
            parts.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = finalCount+"X";
            finalCount++;
        }
        player = FindObjectOfType<PlayerScript>();
        ai[0] = GameObject.Find("Ai_1").GetComponent<aiScript>();
     // ai[1] = GameObject.Find("Ai_2").GetComponent<aiScript>();
      //  ai[2] = GameObject.Find("Ai_2").GetComponent<aiScript>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

  
    public IEnumerator SpawnLastBrick()
    {
        foreach (Transform parts in finalParent)
        {
            yield return new WaitForSeconds(.2f);
            parts.gameObject.SetActive(true);
        }

            
    }
}
