using System;
using Game.Character.Animation;
using Game.Character.Movement.Entities;
using Game.Character.Movement.Enums;
using UnityEngine;

namespace Game.Character.Movement.Managers
{
    [RequireComponent(typeof(MoveEntity), typeof(RotateEntity), typeof(CharacterAnimationManager))]
    public class DefaultMovementManager : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] protected MoveEntity moveEntity;
        [SerializeField] protected RotateEntity rotateEntity;

        [SerializeField] private CharacterAnimationManager animationManager;
        
        [Header("Variables")]
        [SerializeField] protected float defaultSpeed = 3f;
        [SerializeField] protected float boostSpeed = 6f;

        protected void UpdateAnimations()
        {
            animationManager.UpdateAnimation(GetCurrentNormalizedSpeed());
        }

        private float GetCurrentNormalizedSpeed()
        {
            return moveEntity.GetCurrentMovementSpeed() / boostSpeed;
        }
    }
}
