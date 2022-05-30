using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        UpdateQuaternion();
    }

    private void UpdateQuaternion()
    {
        transform.rotation = Quaternion.identity;
    }
}
