using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Unity.MLAgents;
using UnityEngine;
public class JumpScript : MonoBehaviour
{
    public GameObject canvas;
    [Range(1, 50)] private float jumpVelocity=7.5f;
    [SerializeField] private Rigidbody _rigidbody;
    private bool isOnGround=true ;
    private bool hasJumped=false ;
    public LayerMask layerMask;
    private ObstacleRayCast ObsRC;
    [SerializeField] public Transform target;
    [SerializeField] private PhysicsMovement _movement;
    public bool canAttack = false;
    private void Start()
    {
        ObsRC = GetComponent<ObstacleRayCast>();

    }
    void Update()
    {
        if (transform.localScale.x < 0.5)
        {
            canvas.SetActive(true);
        }
        JumpWOCol();
        if (Input.GetKeyDown("space") && isOnGround==true)
        {
            RefreshJump();
        }
        ReadyToJump();
        FlyAhead();
        Stop();
    }
    private void ReadyToJump()
    {
        if (isOnGround == true && hasJumped == false )
        {
            GoAhead();
            Jumping();
        }
    }
    
    
    
    private void JumpWOCol()
    {
        if (ObsRC.currentHitObjects.Count==0)
        {
            hasJumped = false;
            ReadyToJump();
            hasJumped = true;
        }
        else if (ObsRC.currentHitObjects.Count == 1)
        {
            if (ObsRC.currentHitObjects[0] != null)
            {
                var point = ObsRC.currentHitObjects[0].GetComponent<Collider>().bounds.center;
                // var r = _rigidbody.GetComponent<SphereCollider>().radius;
                var r = (float) 5.9;
                //ObsRC.currentHitObjects[0].layer = 12;
                Collider[] _col = Physics.OverlapSphere(point, r, layerMask);
                //ObsRC.currentHitObjects[0].layer = 10;
                if (_col.Length == 1)
                {
                    hasJumped = false;
                    ReadyToJump();
                    hasJumped = true;
                }
            }
        }
    }
    private void RefreshJump()
    {
        hasJumped = false;
    }
    private void FlyAhead()
    {
        if (isOnGround == false && hasJumped == true)
        {
            GoAhead();
        }
    }
    private void Stop()
    {
        if (isOnGround == true && hasJumped == true)
        {
            DontMove();
            canAttack = true;
        }
    }
    private void GoAhead()
    {

        var ahead = target.position - transform.position;
        _movement.Move(ahead);
    }
    private void DontMove()

    {
            var ahead = new Vector3(0,0,0);
            _movement.Move(ahead);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HiIIIIII");
        }
    }
    private void Jumping()
    {
        
            hasJumped = true;
            isOnGround = false;
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        
    }
}
