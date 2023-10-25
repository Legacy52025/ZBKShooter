using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{
    //Изначально применяем для катсцен

    [SerializeField] private Camera _camera1;
    [SerializeField] private Camera _camera2;
    [SerializeField] private Camera _cameraCutScenes;

    public void SwitchCamerasToScene()
    {
        _camera1.enabled = false;
        _camera2.enabled = false;
        _cameraCutScenes.enabled = true;
    }
    




}
