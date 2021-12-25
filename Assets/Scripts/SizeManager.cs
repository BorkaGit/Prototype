using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject road;

    public float scaling ;
    void Start()
    {
        ScalingObjects();
    }

   
    void Update()
    {
       
    }

    private void ScalingObjects()
    {
        player.transform.localScale -= new Vector3(scaling, scaling, scaling);
        road.transform.localScale -= new Vector3(0, 0, scaling);
    }
}
