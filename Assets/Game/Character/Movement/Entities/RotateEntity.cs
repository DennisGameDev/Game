using UnityEngine;

namespace Game.Character.Movement.Entities
{
    public class RotateEntity : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10f;
        public void RotateTowardsDirection(Vector2 input)
        {
            Vector3 inputTarget = transform.position + new Vector3(input.x, 0, input.y);
            Vector3 targetDir = inputTarget - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        private Vector2 Get2DLookDirection(Transform target)
        {
            Vector3 dir = (transform.position - target.transform.position).normalized;
            Vector2 dir2D = new Vector2(dir.x, dir.z);
            return -dir2D;
        }
        
        public void RotateWhileMoving(float movementSpeed, Vector2 currentDir, Transform targetFollow)
        {
            RotateTowardsDirection(movementSpeed > 0
                ? currentDir
                : Get2DLookDirection(targetFollow.transform));
        }
    }
}
