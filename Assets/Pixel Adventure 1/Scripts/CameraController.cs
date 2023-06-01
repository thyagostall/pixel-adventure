using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Transform bottomLeftLimit;
    [SerializeField] private Transform bottomRightLimit;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        float x = IsCameraExceedingXLimit() ? transform.position.x : playerTransform.position.x;
        float y = IsCameraExceedingYLimit() ? transform.position.y : playerTransform.position.y;

        transform.position = new Vector3(x, y, transform.position.z);
    }

    private bool IsCameraExceedingXLimit()
    {
        float cameraWidth = camera.orthographicSize * camera.aspect;

        return playerTransform.position.x - cameraWidth < bottomLeftLimit.position.x
            || playerTransform.position.x + cameraWidth > bottomRightLimit.position.x;
    }

    private bool IsCameraExceedingYLimit()
    {
        return playerTransform.position.y - camera.orthographicSize < bottomLeftLimit.position.y
            || playerTransform.position.y - camera.orthographicSize < bottomRightLimit.position.y;
    }
}
