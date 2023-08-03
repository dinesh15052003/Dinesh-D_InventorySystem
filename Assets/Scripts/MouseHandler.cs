using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private Transform Camera;

    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;

    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40, 50);

        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        Camera.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}
