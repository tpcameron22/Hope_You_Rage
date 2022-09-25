using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;

    public const float RESOLUTION = 0.001f;

    private Line _currentLine;
    
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse position
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        //create line
        if(Input.GetMouseButtonDown(0)){
            _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
        }
        if(Input.GetMouseButton(0)){
            _currentLine.SetPosition(mousePos);
        }
        

    }
}
