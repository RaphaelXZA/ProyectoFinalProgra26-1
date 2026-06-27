using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float accelerationForce = 5f;

    private Rigidbody rb;
    [SerializeField] private float moveDirection = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveDirection * accelerationForce, 0f, 0f), ForceMode.Acceleration);
    }

    public void MoveLeft()
    {
        moveDirection = -1f;
    }

    public void MoveRight()
    {
        moveDirection = 1f;
    }

    public void StopMove()
    {
        moveDirection = 0f;
    }
}
