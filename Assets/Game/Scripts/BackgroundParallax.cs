using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private Transform _motorcycle;
    [SerializeField] private float _parallaxCoef = 0.9f;
    [SerializeField] private float _offsetY = 0f;

    private void Update()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        float x = _motorcycle.position.x * _parallaxCoef;
        float y = _motorcycle.position.y + _offsetY;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
