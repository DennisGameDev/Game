using System;
using Cinemachine;
using UnityEngine;

namespace Game.Character.Camera
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraController : MonoBehaviour
    {
        private CinemachineVirtualCamera virtualCamera;
    }
}
