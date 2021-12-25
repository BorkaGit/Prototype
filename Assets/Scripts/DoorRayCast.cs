using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRayCast : MonoBehaviour
{
    private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private MyDoorController raycastedObj;
    private bool doOnce = false;
    private const string InteractableTag = "Door";
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(InteractableTag) && doOnce == false)
            {
                raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                    raycastedObj.PlayAnimation();
                    doOnce = true;
            }
        }
    }
}