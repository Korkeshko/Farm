using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector2 _normal;

    public Vector2 Project(Vector2 forward)
    {
        return forward - Vector2.Dot(forward, _normal) * _normal;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        _normal = collision.contacts[0].normal;    
    }
}
