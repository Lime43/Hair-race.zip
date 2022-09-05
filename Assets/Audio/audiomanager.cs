
using UnityEngine;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour
{

    public AudioSource randomSound;

    public AudioClip[] audioSources;
    private static audiomanager AudioManager;
    public int SwitchMusicAfterXSeconds;

    private void Awake()
    {
        
            DontDestroyOnLoad(this);

            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];

        if (AudioManager == null)
        {
            AudioManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("randomsoundeffect", 0, SwitchMusicAfterXSeconds);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    void randomsoundeffect()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();

    }
}
