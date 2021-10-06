using Game.Character.Movement.Entities;
using Game.Character.Movement.Enums;
using Game.Character.Movement.Managers;
using UnityEngine;

namespace Game.Character.Animation
{
    public class CharacterAnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private CharacterBarefootMoveAnimation barefootMoveAnimation;
        private CharacterBarefootMoveAnimation BarefootMoveAnimation =>
            barefootMoveAnimation ??= new CharacterBarefootMoveAnimation(animator, moveAnimationSmoothness);

        private float moveAnimationSmoothness = 6f; //Sets the smoothness for animation changes
        
        public void UpdateAnimation(float speed)
        {
            BarefootMoveAnimation.UpdateMoveAnimation(speed);
        }
    }
}
