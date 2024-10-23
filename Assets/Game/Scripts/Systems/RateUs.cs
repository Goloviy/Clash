using System;
using System.Collections;
using System.Collections.Generic;
using Gley.RateGame.Internal;
using UnityEngine;

public class RateUs : MonoBehaviour
{
    private Coroutine coroutinePopup;
    private bool whaitOpenPopup = true;

    private void Awake()
    {
        var abc = SaveValues.IsFirstShow();
        Debug.Log(SaveValues.IsFirstShow());
        if (SaveValues.IsFirstShow() == 0)
        {
            coroutinePopup = StartCoroutine(OpenPopup());
        }
       
        Debug.Log(Gley.RateGame.API.CanShowRate());
    }

    private IEnumerator OpenPopup()
    {
        while (whaitOpenPopup)
        {
            if (Gley.RateGame.API.CanShowRate())
            {
                Gley.RateGame.API.ShowRatePopup();
                StopCoroutine(coroutinePopup);
                Debug.Log("show popup");
                //Debug.Log(SaveValues.GetTimeSinceStart() + Time.time);
            }
            yield return new WaitForSeconds(0.1f);
            Debug.Log(SaveValues.GetTimeSinceStart() + Time.time);
        }
        yield return null;
    }
}