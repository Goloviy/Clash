using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemRewardFinishGame : MonoBehaviour
{
    [SerializeField] Image imgRarity;
    [SerializeField] Image imgIcon;
    [SerializeField] TextMeshProUGUI tmpCount;
    private long _count;

    public void Init(Sprite rarity, Sprite icon, long count)
    {
        imgRarity.overrideSprite = rarity;
        imgIcon.overrideSprite = icon;
        _count = count;
        tmpCount.text = string.Concat("x", count.ToShortStringK());
    }

    public void Multipliy(int coefficient)
    {
        var count = _count * coefficient;
        tmpCount.text = string.Concat("x", count.ToShortStringK());
    }

}
