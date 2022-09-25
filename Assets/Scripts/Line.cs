using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    [SerializeField] private LineRenderer _renderer;
    [SerializeField] EdgeCollider2D _collider;

    private readonly List<Vector2> _points = new List<Vector2>(); 

    public int pointCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //line up collider with line
        _collider.transform.position -= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pointCount);
    }

    public void SetPosition(Vector2 pos){
        //check if paused
        if(Time.timeScale == 0f) return;
        //check if it can appen
            if(!CanAppend(pos)) return;
        //add point to point list for renderer
            _points.Add(pos);
        //add point to line renderer
            _renderer.positionCount++;
        //set to new position
            _renderer.SetPosition(_renderer.positionCount -1, pos);

         //create ege collider
         _collider.points = _points.ToArray();
         //add to pointcount for line length... tracks inividual line length
         pointCount++;

    }

    private bool CanAppend(Vector2 pos){
        
        
        //return true if its the first point
        if( _renderer.positionCount == 0) return true;

        //here check if line length too long FUCK THIS TOO HARD
        //if( pointCount > 150) return false;

        //return true if new istance is far enough away from last using RESOLUTION distance
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount -1), pos) > DrawManager.RESOLUTION;


    }
}
