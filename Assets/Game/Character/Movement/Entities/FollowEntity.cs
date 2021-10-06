using UnityEngine;

namespace Game.Character.Movement.Entities
{
    [RequireComponent(typeof(RotateEntity), typeof(MoveEntity))]
    public class FollowEntity : MonoBehaviour
    {
        private RotateEntity rotateEntity;
        private MoveEntity moveEntity;

        [SerializeField] private FollowableEntity target; //TEMP
        
        private void Awake()
        {
            rotateEntity = GetComponent<RotateEntity>();
            moveEntity = GetComponent<MoveEntity>();
        }
    }
}
