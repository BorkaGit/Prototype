using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
public class ObstacleRayCast : MonoBehaviour
{
    public List<GameObject> currentHitObjects = new List<GameObject>();
    private float maxDistance=3;
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;
    private float currentHitDistance;
    public bool isObjecthitted = false;
    void FixedUpdate()
    {
        origin = transform.position;
        direction = transform.forward;
        currentHitObjects.Clear();
        RaycastHit[] hits = Physics.SphereCastAll(origin, (float)(transform.localScale.x+0.3), direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
        foreach (RaycastHit hit in hits)
        {
            currentHitObjects.Add(hit.transform.gameObject);
        }
    }
}
    
