using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    public Transform Camera;
    public Transform CameraTarget;

    private void Update()
    {
        Camera.position = Vector3.Lerp(Camera.position, CameraTarget.position + _offset, Time.deltaTime * 5f);
    }
}
