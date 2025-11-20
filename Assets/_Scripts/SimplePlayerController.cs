using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;
    public float sprintMultiplier = 1.5f;

    [Header("Camera")]
    public Transform cameraTransform;
    public float lookSensibility = 3f;

    private bool isSprinting;
    private float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Move();
        Look()
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3 (horizontal, 0f, vertical);

        if (inputDir.sqrMagnitude > 1f)
        {
            inputDir.Normalize()
        }
        float currentSpeed = 0f;

        if (isSprinting)
        {
            currentSpeed = speed * sprintMultiplier;
        }
        else 
        {
            currentSpeed = speed;
        }

        Vector3 move = cameraTransform.TransformDirection(inputDir) * Time.dataTime;
        cameraTransform.position += move;
}
