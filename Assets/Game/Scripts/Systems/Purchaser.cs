using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    private int countPack1 = 150;
    private int countPack2 = 450;
    private int countPack3 = 1000;
    private int countPack4 = 5000;
 
    public void OnPurchaseCompleted(Product _product)
    {
        switch (_product.definition.id)
        {
            case  "gem.package.1":
                AddGems(countPack1);
                break;
            case  "gem.package.2":
                AddGems(countPack2);
                break;
            case  "gem.package.3":
                AddGems(countPack3);
                break;
            case  "gem.package.4":
                AddGems(countPack4);
                break;
            
        }
    }

    private void AddGems(int _countGems)
    {
        GameData.Instance.playerData.saveData.AddCurrency(Currency.GEM, _countGems);
        Debug.Log($"purches {_countGems} gems");
    }
}
