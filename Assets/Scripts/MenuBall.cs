using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuBall : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPos;
    Vector3 camPos;
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        _cam = Camera.main;
        camPos = _cam.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       if(rb.IsSleeping()){ //rb.velocity == Vector2.zero
        BallDeath();
       } 
    }


//death check
    private void OnCollisionEnter2D(Collision2D col)
    {
    if(col.gameObject.tag == "Enemy"){
     BallDeath();
    }
    }

//functions
    public void BallDeath(){
        //Debug.Log("DEATH");
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        //destroy lines
       // GameObject[] names = GameObject.FindGameObjectsWithTag("LineClone");
        //if ( names != null){
        //foreach(GameObject item in names){
        // Destroy(item);
       // }
       // }

    }
}
