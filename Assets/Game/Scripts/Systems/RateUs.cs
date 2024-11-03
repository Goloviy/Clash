using System;
using System.Collections;
using Gley.RateGame.Internal;
using UnityEngine;
using UnityEngine.Events;

public class RateUs : MonoBehaviour
{
    private const string PATH_TIME = "Path_time";
    private Coroutine coroutinePopup;
    private bool whaitOpenPopup = true;
    private UnityAction closedPopup;
    private float timeForSecondShow = 10;//minutuse
    private float timeForShowPopup;

    private void Awake()
    {
        switch (SaveValues.IsFirstShow())
        {
            case 0:
                coroutinePopup = StartCoroutine(WaitFirsTime());
                closedPopup += WaitSecondTime;
                break;
            case 1:
                WaitSecondTime();
                break;
            case 2:
                break;
        }

        Debug.Log(Gley.RateGame.API.CanShowRate());
    }

    private IEnumerator WaitFirsTime()
    {
        while (whaitOpenPopup)
        {
            if (Gley.RateGame.API.CanShowRate())
            {
                Gley.RateGame.API.ShowRatePopup(closedPopup);
                StopCoroutine(coroutinePopup);
            }

            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

    private IEnumerator SecondTime()
    {
        timeForShowPopup = PlayerPrefs.GetFloat(PATH_TIME);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            timeForShowPopup -= 0.1f;
            PlayerPrefs.SetFloat(PATH_TIME, timeForShowPopup);
            Debug.Log(timeForShowPopup);
            if (timeForShowPopup <= 0)
            {
                Gley.RateGame.API.ShowRatePopup();
                StopCoroutine(coroutinePopup);
            }
        }
       
    }

    private void WaitSecondTime()
    {
        closedPopup -= WaitSecondTime;
        if (SaveValues.IsFirstShow() == 1)
        {
            if (PlayerPrefs.HasKey(PATH_TIME))
            {
                coroutinePopup = StartCoroutine(SecondTime());
            }
            else
            {
                PlayerPrefs.SetFloat(PATH_TIME,timeForSecondShow * 60);
                coroutinePopup = StartCoroutine(SecondTime());
            }
        }
    }
}