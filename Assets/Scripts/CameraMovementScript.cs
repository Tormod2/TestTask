using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public Transform objectTransform;
    public Vector3 offset;

    //Makes camera follow the object keeping the given distance from it
    private void Update()
    {
        transform.position = objectTransform.position + offset;
    }
}
