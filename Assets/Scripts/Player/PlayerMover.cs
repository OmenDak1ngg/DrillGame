using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    private readonly float _gravityForce = Physics.gravity.y;

    [SerializeField] private UserInput _userInput;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _gravityForceModifier = 2f;

    private Transform _transform;
    private CharacterController _characterController;
    private float _currentGravityForce;

    private void OnEnable()
    {
        _userInput.Moved += Move;
        _userInput.Rotated += Rotate;
    }

    private void OnDisable()
    {
        _userInput.Moved -= Move;
        _userInput.Rotated -= Rotate;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _currentGravityForce = _gravityForce;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleGravity();
    }

    private void Move(float direction)
    {
        if (direction < 0)
            direction = 0;

        Vector3 worldDirection = new Vector3(0, 0, direction);
        Vector3 localDirection = _transform.TransformDirection(worldDirection);

        _characterController.Move(localDirection * _moveSpeed * Time.deltaTime);
    }

    private void Rotate(float direction)
    {
        _transform.Rotate(0, direction * _rotationSpeed * Time.deltaTime, 0);
    }

    private void HandleGravity()
    {
        if (_characterController.isGrounded == false)
        {
            _currentGravityForce = _gravityForce * _gravityForceModifier * Time.deltaTime;
            _characterController.Move(Vector3.up * _currentGravityForce);

        }
        else
            _currentGravityForce = 0f;
    }
}