using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InitializeAD : MonoBehaviour
{
    private void Awake()
    {
        MobileAds.Initialize(status => {} );
    }
}
