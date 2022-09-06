using System.Collections;
using UnityEngine;

public class QuitPU : MonoBehaviour
{
    private static QuitPU _Instance;
    [SerializeField] UnityEngine.UI.Button quitButton;
    [SerializeField] UnityEngine.UI.Button shopButton;
    [SerializeField] GameObject _popupQuit;

    private void Awake()
    {
        if (!_Instance)
        {
            _Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        shopButton.onClick.AddListener(OpenShopButton);
        StartCoroutine(_IEOnCheckTimeplay());
    }

    private IEnumerator _IEOnCheckTimeplay()
    {
        while (true)
        {
            if (PlayTimeSystem.HaveTimeToPlay)
                ShowPopup(isShow: false);
            yield return new WaitForSeconds(1f);
        }
    }

    public static void ShowPopup(bool isShow = true)
    {
        _Instance._popupQuit.SetActive(value: isShow);
    }


    public void QuitGame()
    {
        //
        Application.Quit();
    }


    public void OpenShopButton()
    {
        //
        PurchasePU.ShowSubPU(isShow: true);
    }
}