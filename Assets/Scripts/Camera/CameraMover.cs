using System.Collections;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _cameraOffset;

    private void LateUpdate()
    {
        transform.position  = _playerTransform.position + _cameraOffset;
    }
}