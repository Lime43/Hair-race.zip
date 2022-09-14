using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class ShopPU : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] ShopPU popUpShop;

    private static readonly string TIMEPLAY_15USD = "15usdgem";
    private static readonly string TIMEPLAY_25USD = "25usdgem";
    private static readonly string TIMEPLAY_35USD = "35usdgem";
    private static readonly string TIMEPLAY_45USD = "45usdgem";

    private Dictionary<string, int> _DictionaryTime = new Dictionary<string, int>()
    {
        {TIMEPLAY_15USD,60 },
        {TIMEPLAY_25USD,300 },
        {TIMEPLAY_35USD,720 },
        {TIMEPLAY_45USD,1440 },
    };


    private void Start()
    {
        closeButton.onClick.AddListener(ClosePopUpShop);
    }

    public void ShowPopup(bool isShow = true)
    {
        this.gameObject.SetActive(value: isShow);
    }


    public void OnActionCompletedPurchase(Product product)
    {
        Debug.Log($"Action Complete Product ID {product.definition.id}");
        if (product.definition.id == TIMEPLAY_15USD)
            PlayTimeSystem.AddTimeToPlay(timePlus: _DictionaryTime[TIMEPLAY_15USD]);
        else if (product.definition.id == TIMEPLAY_25USD)
            PlayTimeSystem.AddTimeToPlay(timePlus: _DictionaryTime[TIMEPLAY_25USD]);
        else if (product.definition.id == TIMEPLAY_35USD)
            PlayTimeSystem.AddTimeToPlay(timePlus: _DictionaryTime[TIMEPLAY_35USD]);
        else if (product.definition.id == TIMEPLAY_45USD)
            PlayTimeSystem.AddTimeToPlay(timePlus: _DictionaryTime[TIMEPLAY_35USD]);
    }

    public void OnActionFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Action Failure Product ID {product.definition.id}");
        if (product.definition.id == TIMEPLAY_15USD)
        {

        }
        else if (product.definition.id == TIMEPLAY_25USD)
        {

        }
        else if (product.definition.id == TIMEPLAY_35USD)
        {

        }
        else if (product.definition.id == TIMEPLAY_45USD)
        {

        }
    }

    public void ClosePopUpShop()
    {
        popUpShop.gameObject.SetActive(value: false);
    }
}


