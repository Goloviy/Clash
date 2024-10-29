using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPButtonView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI price;

    public void OnProductFetched(Product product)
    {
        if (price != null)
        {
            //price.text = product.metadata.localizedPriceString;
            price.text = $"Purchase with only:\n<size=80> {product.metadata.localizedPriceString}$";
        }
    }
}
