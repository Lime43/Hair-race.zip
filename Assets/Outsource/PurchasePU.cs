using UnityEngine;

public class PurchasePU : MonoBehaviour
{
    private static PurchasePU _Instance;

    [SerializeField] private ShopPU _shopPU;
    [SerializeField] private SubPU _subPU;

    private void Awake()
    {
        if (!_Instance)
        {
            _Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static void ShowShopPU(bool isShow = true)
    {
        _Instance._shopPU.ShowPopup(isShow);
    }

    public static void ShowSubPU(bool isShow = true)
    {
        _Instance._subPU.ShowPopup(isShow);
    }
}
