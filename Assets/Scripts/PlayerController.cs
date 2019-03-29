using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ball;
    public float speed = 3.0f;
    public float gravity = -5.0f;
    public float sensHorizontal = 5.0f;

    private CharacterController _characterController;
    private Camera _camera;
    private float _translation;
    private float _straffe;
    private bool _isPicked;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Rotate();

        if (_isPicked)
        {
            var ballPosition = new Vector3(_camera.transform.position.x, _camera.transform.position.y + 0.1f, _camera.transform.position.z + 0.5f);

            ball.transform.position = ballPosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }

        if (Input.GetKey(KeyCode.F))
        {
            _isPicked = true;
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Move()
    {
        _translation = Input.GetAxis("Vertical") * speed;
        _straffe = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(_straffe, gravity, _translation);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _characterController.Move(movement);
    }

    private void Rotate()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
    }

    private void Throw()
    {
        _isPicked = false;
        var rigidBody = ball.GetComponent<Rigidbody>();

        rigidBody.AddForce(0.3f, 0, 0, ForceMode.Impulse);
    }
}