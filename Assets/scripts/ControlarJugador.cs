using UnityEngine;

public class ControlarJugador : MonoBehaviour
{
    public float speed = 3.5f;
    private float gravity = 10f;
    private CharacterController Controller;

    public Vector3 hitPoint;

    private const float _maxDistance = 10;
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        Controller.Move(velocity * Time.deltaTime); 
    }
}
