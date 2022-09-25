using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    
    public GameObject[] levels;
    private int count = 1;
    private int totalScore;
    private int levelCount = 17;
    public GameObject totalscoreText;
    // Start is called before the first frame update
    void Start()
    {
                  
        foreach(GameObject item in levels){
           var TMP = item.GetComponent<TMP_Text>();
            TMP.text = "" + PlayerPrefs.GetInt("levelScore" + count);
            count++;
        }

        if(!PlayerPrefs.HasKey("totallevelScore")){
            PlayerPrefs.SetInt("totallevelScore", 99);
        }

        for(int i = 1; i < levelCount; i++)
        {
            totalScore += PlayerPrefs.GetInt("levelScore" + i);
        }
        
    if(PlayerPrefs.GetInt("levelReached") >= levelCount -2){
        if( totalScore < PlayerPrefs.GetInt("totallevelScore")) PlayerPrefs.SetInt("totallevelScore", totalScore);
            totalscoreText.GetComponent<TMP_Text>().text = "" + PlayerPrefs.GetInt("totallevelScore");
            totalscoreText.SetActive(true);
    }
    else{
        totalscoreText.SetActive(false);
    }
    }


    //menuButton
        public void Menu(){  
         SceneManager.LoadScene("MainMenu");
        }  
}