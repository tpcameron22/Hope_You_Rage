using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4886926");
        //ShowBanner();
    }

    public void ShowBanner(){
        if(Advertisement.IsReady("Banner_iOS")){
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_iOS");
        }
        else {StartCoroutine(RepeatShowBanner());
        }
    }

    IEnumerator RepeatShowBanner(){
        yield return new WaitForSeconds(1);
        ShowBanner();
    }


}
