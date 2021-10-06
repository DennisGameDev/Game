using System;
using Game.Character.Movement;
using UnityEngine;

namespace Game.Character.Animation
{
    public class CharacterBarefootMoveAnimation
    {
        private Animator anim;
        private readonly float animationSmoothness = 6f;
        private float currentAnimationSpeed;
        private float targetAnimationSpeed;
        
        private static readonly int MovementSpeed = Animator.StringToHash("movementSpeed");

        public CharacterBarefootMoveAnimation(Animator animator, float animationSmoothness)
        {
            anim = animator;
            this.animationSmoothness = animationSmoothness;
        }

        public void UpdateMoveAnimation(float newMovementSpeed)
        {
            targetAnimationSpeed = newMovementSpeed;
            anim.SetFloat(MovementSpeed, currentAnimationSpeed);
            UpdateAnimationSpeed();
        }
        
        private void UpdateAnimationSpeed()
        {
            currentAnimationSpeed = Mathf.Lerp(currentAnimationSpeed, targetAnimationSpeed, animationSmoothness * Time.deltaTime);
        }
    }
}
