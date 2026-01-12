using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float MaxMoveSpeed;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float RotationThreshold = 5;
    [SerializeField] private Transform PlayerMeshTransform;
    [SerializeField] private Animator PlayerAnimator;

    private CharacterController cc;

    void Start()
    {
        maxMoveSpeed = MaxMoveSpeed;
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movement = input.normalized * maxMoveSpeed;

        if(input.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(input, Vector3.up);

            PlayerMeshTransform.rotation = Quaternion.Slerp(PlayerMeshTransform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

            PlayerAnimator.SetBool("Moving", true);
        }
        else
        {
            PlayerAnimator.SetBool("Moving", false);
        }

        cc.Move(movement * Time.deltaTime);
    }
}
