using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSilder;
    private float _speed = 5.0f;
    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSilder.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);
            _rigidbody.MovePosition(_rigidbody.position + offset);
    }
}
