using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBackground : MonoBehaviour
{
    public Camera MainCamera;

    void Update()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        float x = transform.position.x;
        float y = MainCamera.transform.position.y * 0.9f;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
