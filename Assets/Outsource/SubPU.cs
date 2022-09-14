using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
public class SubPU : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] SubPU popUpSub;


    private void Start()
    {
        closeButton.onClick.AddListener(ClosePopUpSub);
    }

    public void ClosePopUpSub()
    {
        popUpSub.gameObject.SetActive(value: false);
    }

    public void ShowPopup(bool isShow = true)
    {
        this.gameObject.SetActive(value: isShow);
    }
    public void OnActionCompletedPurchase(Product product)
    {
        PlayTimeSystem.EnableUnlimitTime();
        PlayTimeSystem.AddUnlimitTime();
    }

    public void OnActionFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Action Failure Product ID {product.definition.id}");
    }
}

