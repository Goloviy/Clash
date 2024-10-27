using System.Collections;
using Gley.RateGame.Internal;
using UnityEngine;
using UnityEngine.Events;

public class RateUs : MonoBehaviour
{
    private Coroutine coroutinePopup;
    private bool whaitOpenPopup = true;
    private UnityAction closedPopup;

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
            Debug.Log("tick");
        }
        yield return null;
    }

    private void WaitSecondTime()
    {
        closedPopup -= WaitSecondTime;
        if (SaveValues.IsFirstShow() == 1)
        {
            
        }
        Debug.Log("Closed action");
    }
}