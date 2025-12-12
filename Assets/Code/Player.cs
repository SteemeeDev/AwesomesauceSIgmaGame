using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float MaxMoveSpeed;

    private Rigidbody rb;

    void Start()
    {
        maxMoveSpeed = MaxMoveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * maxMoveSpeed;

        rb.velocity = movement;
    }
}
