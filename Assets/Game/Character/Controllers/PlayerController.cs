using Cinemachine;
using UnityEngine;

namespace Game.Character.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCameraPrefab;
        
        public void Awake()
        {
            CinemachineVirtualCamera cam = Instantiate(virtualCameraPrefab);
            cam.LookAt = transform;
            cam.Follow = transform;
        }
    }
}
