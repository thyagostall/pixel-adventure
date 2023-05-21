using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, Mathf.Max(playerTransform.position.y, 0), transform.position.z);
    }
}
