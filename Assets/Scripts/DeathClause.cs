using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathClause : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPos;
    Vector3 camPos;
    private Camera _cam;

    //collectable
    private GameObject collectable;
    public GameObject importedCollectable;
    public Vector2 colspawnpos;
    //if collectable has been collected
    private bool collected = false;
    
    //boost
    private float boostSpeed = 50f;
    private Vector2 boostforward;
    private Vector2 boostback;
    private Vector2 boostup;
    private Vector2 boostdown;
    private Vector2 boostline;

    //upate death count
    private int deathCount;
    public TextMeshPro textMeshPro;
    public TextMeshPro highscoreText;
  
    //highscore
    public int levelNumber;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        _cam = Camera.main;
        camPos = _cam.transform.position;

        //spawn location of collectable 
        collectable = GameObject.Find("Collectable");
        colspawnpos = collectable.transform.position;
        
        //boost
        boostforward = new Vector2(boostSpeed, 0f);
        boostback = new Vector2(-1 * boostSpeed, 0f);
        boostup = new Vector2(0f, 100f);
        boostdown = new Vector2(0f, -1 * boostSpeed);
        boostline = new Vector2(boostSpeed, -1f * boostSpeed);

        //highscore
        int levelscoresave = PlayerPrefs.GetInt("levelScore" + levelNumber);
        if(!PlayerPrefs.HasKey("levelScore" + levelNumber)){
            PlayerPrefs.SetInt("levelScore" + levelNumber, 99);
        }
        highscoreText.text = "" + levelscoresave;       

       
    }

    // Update is called once per frame
    void Update()
    {
       if(rb.IsSleeping()){ //rb.velocity == Vector2.zero
        Death();
       } 
    }


//collisions
    private void OnTriggerEnter2D(Collider2D col)
    {
//collectable check
    if(col.gameObject.tag == "Collectable")
    {
     Destroy(col.gameObject);
     collected = true;
    }
//finish check
    if(col.gameObject.tag == "Finish" && collected){
     Finish();
    }
    else if(col.gameObject.tag == "Finish" && !collected){
     Death();
    } 
//boost check
    if(col.gameObject.tag == "Fboost" ){
     rb.AddForce(boostforward, ForceMode2D.Impulse);
    }
    if(col.gameObject.tag == "Bboost" ){
     rb.AddForce(boostback, ForceMode2D.Impulse);
    } 
    if(col.gameObject.tag == "Dboost" ){
     rb.AddForce(boostdown, ForceMode2D.Impulse);
    } 
    if(col.gameObject.tag == "Uboost" ){
     rb.AddForce(boostup, ForceMode2D.Impulse);
    } 
    if(col.gameObject.tag == "Lboost" ){
     rb.AddForce(boostline, ForceMode2D.Impulse);
    }
     if(col.gameObject.tag == "-Lboost" ){
     rb.AddForce(-1 * boostline, ForceMode2D.Impulse);
    } 
    }
    
//death check
    private void OnCollisionEnter2D(Collision2D col)
    {
    if(col.gameObject.tag == "Enemy"){
     Death();
    }
    }

//functions
    public void Death(){
        //Debug.Log("DEATH");
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        //destroy lines
        //if(GameObject.Find("Line(Clone)") != null) Destroy(GameObject.Find("Line(Clone)"));
        GameObject[] names = GameObject.FindGameObjectsWithTag("LineClone");
        foreach(GameObject item in names){
         Destroy(item);
        }
        //reset collected
        if(collected){
            collected = false;
            Instantiate(importedCollectable, colspawnpos, Quaternion.identity);
        }
        //ad one to death count
        deathCount++;
        textMeshPro.text = "" + deathCount;
    }

    public void Finish(){
        //Debug.Log("Finish");

        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings -1){
            SceneManager.LoadScene("MainMenu");
        }else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Destroy(GameObject.Find("Line(Clone)"));


        //unlock level 2
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1") && PlayerPrefs.GetInt("levelReached") < 2) PlayerPrefs.SetInt("levelReached", 2);
        //unlock level 3
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2") && PlayerPrefs.GetInt("levelReached") < 3) PlayerPrefs.SetInt("levelReached", 3);
        //unlock level 4
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 3") && PlayerPrefs.GetInt("levelReached") < 4) PlayerPrefs.SetInt("levelReached", 4);
        //unlock level 5
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 4") && PlayerPrefs.GetInt("levelReached") < 5) PlayerPrefs.SetInt("levelReached", 5);
        //unlock level 6
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 5") && PlayerPrefs.GetInt("levelReached") < 6) PlayerPrefs.SetInt("levelReached", 6);
        //unlock level 7
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 6") && PlayerPrefs.GetInt("levelReached") < 7) PlayerPrefs.SetInt("levelReached", 7);
        //unlock level 8
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 7") && PlayerPrefs.GetInt("levelReached") < 8) PlayerPrefs.SetInt("levelReached", 8);
        //unlock level 9
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 8") && PlayerPrefs.GetInt("levelReached") < 9) PlayerPrefs.SetInt("levelReached", 9);
        //unlock level 10
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 9") && PlayerPrefs.GetInt("levelReached") < 10) PlayerPrefs.SetInt("levelReached", 10);
        //unlock level 11
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 10") && PlayerPrefs.GetInt("levelReached") < 11) PlayerPrefs.SetInt("levelReached", 11);
        //unlock level 12
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 11") && PlayerPrefs.GetInt("levelReached") < 12) PlayerPrefs.SetInt("levelReached", 12);
        //unlock level 13
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 12") && PlayerPrefs.GetInt("levelReached") < 13) PlayerPrefs.SetInt("levelReached", 13);
        //unlock level 14
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 13") && PlayerPrefs.GetInt("levelReached") < 14) PlayerPrefs.SetInt("levelReached", 14);
        //unlock level 15
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 14") && PlayerPrefs.GetInt("levelReached") < 15) PlayerPrefs.SetInt("levelReached", 15);
        //unlock level 16
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 15") && PlayerPrefs.GetInt("levelReached") < 16) PlayerPrefs.SetInt("levelReached", 16);


        //highscore
        if(deathCount < PlayerPrefs.GetInt("levelScore" + levelNumber)) PlayerPrefs.SetInt("levelScore" + levelNumber, deathCount);
    }
}
