using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //pause menu items
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject ball;
    private Vector2 ballspawnpos;

    //unlock level list
    public Button[] levelButtons;

        
        public void Awake(){
         Resume();   
        }
//menu
        public void Menu(){  
         SceneManager.LoadScene("MainMenu");
        }  
//highscores
        public void Highscores(){  
         SceneManager.LoadScene("HighScore");
        }  

//StartGame
        public void StartGame(){  
         SceneManager.LoadScene("Tutorial");
        }  
//QUIT
        public void QuitGame(){
         Debug.Log("QUIT");
         Application.Quit();
        }
//Resume
        public void Resume(){
         pauseMenuUI.SetActive(false);
         Time.timeScale = 1f;
         GameIsPaused = false;
        }
//Pause
        public void Pause(){
         pauseMenuUI.SetActive(true);
         Time.timeScale = 0f;
         GameIsPaused = true;
        }
//destroy lines
        public void DestroyLines(){
                GameObject[] names = GameObject.FindGameObjectsWithTag("LineClone");
                foreach(GameObject item in names){
                Destroy(item);
                }
        }

//Level Select
        public void LevelSelect(){  
         SceneManager.LoadScene("LevelSelect");
        }  
//levels
        public void one(){  
         SceneManager.LoadScene("Level 1");
        }  
        public void two(){  
         SceneManager.LoadScene("Level 2");
        }
        public void three(){  
         SceneManager.LoadScene("Level 3");
        }
        public void four(){  
         SceneManager.LoadScene("Level 4");
        }
        public void five(){  
         SceneManager.LoadScene("Level 5");
        }  
        public void six(){  
         SceneManager.LoadScene("Level 6");
        }  
        public void seven(){  
         SceneManager.LoadScene("Level 7");
        }  
        public void eight(){  
         SceneManager.LoadScene("Level 8");
        }
        public void nine(){  
         SceneManager.LoadScene("Level 9");
        }  
        public void ten(){  
         SceneManager.LoadScene("Level 10");
        }  
        public void eleven(){  
         SceneManager.LoadScene("Level 11");
        }  
        public void twelve(){  
         SceneManager.LoadScene("Level 12");
        }  
        public void thirteen(){  
         SceneManager.LoadScene("Level 13");
        }  
        public void fourteen(){  
         SceneManager.LoadScene("Level 14");
        }  
        public void fifteen(){  
         SceneManager.LoadScene("Level 15");
        }  
        public void sixteen(){  
         SceneManager.LoadScene("Level 16");
        }  


        //unlock levels
        public void Start(){
                
                int levelReached = PlayerPrefs.GetInt("levelReached");
                
                if(levelButtons.Length > 1){
                 for (int i = 0; i < levelButtons.Length; i++)
                 {
                   if(i < levelReached){
                        var image = levelButtons[i].transform.GetChild(1).gameObject;
                        image.GetComponent<Image>().enabled = false;
                   }
                   if(i + 1 > levelReached){
                        levelButtons[i].interactable = false;
                   } 
                        
                 }
                }
        }


}
