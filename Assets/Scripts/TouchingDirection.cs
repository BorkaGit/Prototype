using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    public GameObject canvas;
    private float TimeInterval ;
    private float holdTimer = 0;
    public float scaling ;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject road;
    private float startTime;
    private float elapsedTime;
    Attacking att;

    private void Start()
    {
        att = GameObject.FindGameObjectWithTag("player").GetComponent<Attacking>();
    }

    void Update()
    {
        if (scaling > 2.5)
        {
            canvas.SetActive(true);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                 startTime = Time.time;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                elapsedTime = Time.time - startTime;
                scaling = elapsedTime;
                ScalingObjects();
                att.Attack();
                startTime = 0;
            }
        }
    }
    
    private void ScalingObjects()
    {
        player.transform.localScale -= new Vector3(scaling, scaling, scaling);
        road.transform.localScale -= new Vector3(0, 0, scaling);
    }
}
