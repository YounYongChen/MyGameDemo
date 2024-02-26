using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _mainCharacterCamera;

    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private TransformAnchor _mainCharacterTransform;
    [SerializeField]
    private TransformAnchor _mainCameraTransform;


    private void OnEnable()
    {
        _mainCharacterTransform.OnAnchorProvided += SetVirtualCamera;
        _mainCameraTransform.Provide(_mainCamera.transform);
    }

    private void OnDisable()
    {
        _mainCharacterTransform.OnAnchorProvided -= SetVirtualCamera;
        _mainCameraTransform.Unset();
    }

    private void Start()
    {
        SetVirtualCamera();
    }

    private void SetVirtualCamera()
    {
        if (_mainCharacterTransform.isSet) {
            _mainCharacterCamera.Follow = _mainCharacterTransform.Value;
        }
    }
}
