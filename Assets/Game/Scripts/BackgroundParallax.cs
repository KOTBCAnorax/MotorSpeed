using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public Camera MainCamera;

    [SerializeField] float _parallaxCoef = 0.9f;
    [SerializeField] float _yOffset = 0f;
    [SerializeField] SpriteRenderer _spriteRenderer;

    private float _startX;
    private float _length;

    private void Start()
    {
        _startX = transform.position.x;
        _length = _spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        float dist = MainCamera.transform.position.x * _parallaxCoef;

        float x = _startX + dist;
        float y = MainCamera.transform.position.y + _yOffset;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
