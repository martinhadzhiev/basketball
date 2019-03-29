using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float minimumVert = -50.0f;
    public float maximumVert = 55.0f;
    public float sensVertical = 5.0f;
    private float rotation;

    void Update()
    {
        rotation -= Input.GetAxis("Mouse Y") * sensVertical;
        rotation = Mathf.Clamp(rotation, minimumVert, maximumVert);

        float rotationY = transform.localEulerAngles.y;

        transform.localEulerAngles = new Vector3(rotation, rotationY, 0);
    }
}
