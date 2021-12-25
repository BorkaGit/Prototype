using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Object = UnityEngine.Object;

public class HittedByRocket : MonoBehaviour
{
    SphereCollider myCollider;
    public Material Orange;
    public LayerMask layerMask;
    public float power = 100.0f;
    
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle") && !other.gameObject.CompareTag("Game Manager") )
        {
            var r = myCollider.radius;
            Collider[] _col = Physics.OverlapSphere(other.transform.position, 2*r,layerMask);
            foreach (var col in _col)
            {
                col.GetComponent<MeshRenderer>().material = Orange;
                Destroy(col.gameObject);
            }
            Destroy(gameObject);
        }
    }


}
