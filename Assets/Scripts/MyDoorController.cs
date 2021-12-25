using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;

    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("Door Open Animation",0,0.0f);
            doorOpen = true;
        }
    }
}
