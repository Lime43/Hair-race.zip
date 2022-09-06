using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;

public class PlayTimeSystem : MonoBehaviour
{
    public static PlayTimeSystem Instance { get; private set; }

    public static readonly string ID_FREE_TIME_PLAY = "ID_FREE_TIME_PLAY";
    private static readonly string UNLIMITED_TIME = "UNLIMITED_TIME";
    private static readonly string FREE_PLAY_ONE_TIME = "FREE_PLAY_ONE_TIME";
    private static readonly string SUBSCRIPTION25 = "subscription25";
    private static readonly string SUBSCRIPTION50 = "subscription50";
    private static readonly string SUBSCRIPTION75 = "subscription75";
    private static readonly string SUBSCRIPTION = "subscription";
    private static readonly string SUBSCRIPTION100 = "subscription100";
    private static readonly int FREE_30MINS = 30;
    private void Awake()
    {
        _InitializeTicksTime();
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static bool HaveTimeToPlay
    {
        get
        {
            return PlayerPrefs.GetInt(ID_FREE_TIME_PLAY) > 0;
        }
    }

    private void _InitializeTicksTime()
    {
        bool canPlayFree = PlayerPrefs.GetInt(FREE_PLAY_ONE_TIME) == 0 ? true : false;
        if (canPlayFree)
        {
            PlayerPrefs.SetInt(FREE_PLAY_ONE_TIME, 1);
            PlayerPrefs.SetInt(ID_FREE_TIME_PLAY, FREE_30MINS);
        }

        bool isSubscribed = new SubscriptionInfo(SUBSCRIPTION).isSubscribed() == Result.True
            || new SubscriptionInfo(SUBSCRIPTION25).isSubscribed() == Result.True
            || new SubscriptionInfo(SUBSCRIPTION50).isSubscribed() == Result.True
            || new SubscriptionInfo(SUBSCRIPTION75).isSubscribed() == Result.True
            || new SubscriptionInfo(SUBSCRIPTION100).isSubscribed() == Result.True;
        if (isSubscribed)
            AddUnlimitTime();
    }

    private IEnumerator Start() => _IECheckFreeTimePlay();

    IEnumerator _IECheckFreeTimePlay()
    {
        WaitForSecondsRealtime wfs = new WaitForSecondsRealtime(60);
        while (true)
        {
            if (PlayerPrefs.GetInt(ID_FREE_TIME_PLAY) <= 0)
                QuitPU.ShowPopup(isShow: true);
            yield return wfs;
            PlayerPrefs.SetInt(ID_FREE_TIME_PLAY, PlayerPrefs.GetInt(ID_FREE_TIME_PLAY) - 1);
            Debug.Log($"Has removing one minute Current Free Time Play :{PlayerPrefs.GetInt(ID_FREE_TIME_PLAY)}");

        }
    }

    public static void AddTimeToPlay(int timePlus)
    {
        if (PlayerPrefs.GetInt(UNLIMITED_TIME) == 1)
            return;
        PlayerPrefs.SetInt(ID_FREE_TIME_PLAY, PlayerPrefs.GetInt(ID_FREE_TIME_PLAY) + timePlus);
        Debug.Log($"Adding New time Current Minutes Can Play : {PlayerPrefs.GetInt(ID_FREE_TIME_PLAY)}");
    }

    public static void AddUnlimitTime()
    {
        PlayerPrefs.SetInt(ID_FREE_TIME_PLAY, int.MaxValue);
        Debug.Log($"Adding New time Current Minutes Can Play : {PlayerPrefs.GetInt(ID_FREE_TIME_PLAY)}");
    }

    public static void EnableUnlimitTime()
    {
        PlayerPrefs.SetInt(UNLIMITED_TIME, 1);
    }
}
