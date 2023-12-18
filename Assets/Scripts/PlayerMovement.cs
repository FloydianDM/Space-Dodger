using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceDodger
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forceMagnitude;
        [SerializeField] private float maximumVelocityMagnitude;
        [SerializeField] private float rotateSpeed;

        private Rigidbody _shipRb;
        private Camera _mainCamera;
        private Vector3 _movementDirection;

        private void Start()
        {
            _mainCamera = Camera.main;
            _shipRb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            ProcessTouchInput();
            KeepShipOnScreen();
            RotateShip();
        }

        private void FixedUpdate() // using this method to calculate physics due to performance improvements
        {
            MoveShip();
        }

        private void ProcessTouchInput()
        {
            if (Touchscreen.current.primaryTouch.press.isPressed)
            {
                Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

                _movementDirection = worldPosition - transform.position;
                _movementDirection.z = 0f;
                _movementDirection.Normalize();
            }
            else
            {
                _movementDirection = Vector3.zero;
            }
        }    

        private void MoveShip()
        {
            if (_movementDirection == Vector3.zero)
            {
                return;
            }

            _shipRb.AddForce(_movementDirection * forceMagnitude, ForceMode.Force);
            _shipRb.velocity = Vector3.ClampMagnitude(_shipRb.velocity, maximumVelocityMagnitude);
        }

        private void KeepShipOnScreen()
        {
            Vector3 newPosition = transform.position;
            Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);

            if (viewportPosition.x > 1)
            {
                newPosition.x = -newPosition.x + 0.1f;
            }
            
            else if (viewportPosition.x < 0)
            {
                newPosition.x = -newPosition.x - 0.1f;
            }

            if (viewportPosition.y > 1)
            {
                newPosition.y = -newPosition.y + 0.1f;
            }
            
            else if (viewportPosition.y < 0)
            {
                newPosition.y = -newPosition.y - 0.1f;
            }
            
            transform.position = newPosition;
        }

        private void RotateShip()
        {
            if (_shipRb.velocity == Vector3.zero)
            {
                return;
            }

            Quaternion targetRotation = Quaternion.LookRotation(_shipRb.velocity, Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}


