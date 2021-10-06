using System;
using System.Linq;
using Game.Character.Movement.Enums;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Character.Movement.Entities
{
    public class MoveEntity : MonoBehaviour
    {
        [Serializable]
        public class MoveEntityVariableSettings
        {
            public float AccelerationSmoothness =  4f;
            public float MaxAngle = 25f;
            public float MovementRayCastStartHeight = 2f;
            public float RaycastDepth = 10f;
        }

        private MoveEntityVariableSettings moveEntitySettings;
        private MoveEntityVariableSettings MoveEntitySettings => moveEntitySettings ??= new MoveEntityVariableSettings();

        private Vector3 originPos;
        private Vector3 destinationPos;

        private Vector2 currentMovementDirection;
        public Vector2 CurrentMovementDirection => currentMovementDirection;
        
        private float timeToMoveToDestination;
        private float accelerationMultiplier;
        private float movementSpeed;
        private float moveTimer;
        private float totalTimeNeededForDistance;
        
        private bool isMoving;

        private const string CollisionTag = "Collision"; //TEMP

        private float GetTimeToMoveToDestination() => 1 / movementSpeed;

        private void Awake()
        {
            originPos = transform.position;
        }

        //Overrides the default settings.
        public void SetMoveSettings(MoveEntityVariableSettings settings)
        {
            moveEntitySettings = settings;
        }
        
        public void Move(Vector2 input, float moveSpeed)
        {
            ValidateIfEntityIsStillMoving();
            
            if (input != Vector2.zero 
                && !isMoving && moveSpeed != 0)
            {
                ValidateDestination(GetDestinationPosition(input), moveSpeed);
            }
            
            if (!isMoving)
            {
                ResetMovementSpeed();
                return;
            }
            
            UpdateMovement();
        }
        
        public void MoveTo(Vector3 destination, float moveSpeed)
        {
            ValidateIfEntityIsStillMoving();
            
            if (destination != transform.position 
                && !isMoving && moveSpeed != 0)
            {
                ValidateDestination(destination, moveSpeed);
            } else if (destination == transform.position)
            {
                isMoving = false;
                ResetMovementSpeed();
            }
            
            if (!isMoving)
            {
                ResetMovementSpeed();
                return;
            }
            
            UpdateMovement();
        }

        private void ValidateDestination(Vector3 destination, float moveSpeed)
        {
            if (CheckIfAngleIsWalkable(destination) && CheckForCollision(destination))
            {
                SetMoveInformation(GetDirection(destination), destination, moveSpeed);
            }
        }

        private void ResetMovementSpeed()
        {
            accelerationMultiplier = 0f;
            movementSpeed = 0f;
        }

        private void UpdateMovement()
        {
            accelerationMultiplier = Mathf.Lerp(accelerationMultiplier, 1, MoveEntitySettings.AccelerationSmoothness * Time.deltaTime);
            moveTimer += Time.deltaTime * accelerationMultiplier;
            
            transform.position = Vector3.Lerp(originPos, destinationPos, moveTimer / totalTimeNeededForDistance);
        }

        private void ValidateIfEntityIsStillMoving()
        {
            if (moveTimer > totalTimeNeededForDistance || !isMoving)
            {
                isMoving = false;
            }
        }

        private Vector2 GetDirection(Vector3 destination)
        {
            var dir = destination - transform.position;
            var normalizedVector = dir.normalized;
            return new Vector2(normalizedVector.x, normalizedVector.z);
        }
        
        private Vector3 GetDestinationPosition(Vector2 input)
        {
            Vector3 origin = transform.position + new Vector3(input.x, MoveEntitySettings.MovementRayCastStartHeight, input.y);
            Ray ray = new Ray(origin, Vector3.down * MoveEntitySettings.RaycastDepth);
            return Physics.Raycast(ray, out var hit) ? hit.point : transform.position;
        }

        private void SetAcceleration(Vector2 input)
        {
            if (Vector2.Distance(currentMovementDirection, input) > 1.5f)
            {
                accelerationMultiplier = 0;
            }
        }
        private bool CheckForCollision(Vector3 destinationPosition)
        {
            Collider[] hitColliders = Physics.OverlapBox(destinationPosition, transform.localScale / 2, Quaternion.identity);
            return !hitColliders.Any(t => t.CompareTag(CollisionTag));
        }

        private bool CheckIfAngleIsWalkable(Vector3 destinationPosition)
        {
            if (destinationPosition == transform.position)
            {
                return false;
            }
            
            Vector3 origin = transform.position;
            Vector3 targetDir = destinationPosition - origin;

            Vector3 otherDir = new Vector3(targetDir.x, 0, targetDir.z);
            
            var angle = Vector3.Angle(targetDir, otherDir);
            
            if (angle > 90) angle = Math.Abs(angle - 180);
            return !(angle > MoveEntitySettings.MaxAngle);
        }

        private void SetMoveInformation(Vector2 input, Vector3 destinationPosition, float moveSpeed)
        {
            SetAcceleration(input);
            isMoving = true;
            moveTimer = 0;
            currentMovementDirection = input;
            originPos = transform.position;
            movementSpeed = moveSpeed;
            destinationPos = destinationPosition;
            timeToMoveToDestination = GetTimeToMoveToDestination();
            totalTimeNeededForDistance = Vector3.Distance(originPos, destinationPos) * timeToMoveToDestination;
        }

        public void ResetOriginPosition()
        {
            originPos = transform.position;
        }
        
        public Vector3 GetMoveOriginPosition()
        {
            return originPos;
        }
        
        public float GetCurrentMovementSpeed()
        {
            return movementSpeed;
        }
    }
}
