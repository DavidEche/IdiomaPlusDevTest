using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 cameraOffSet;
 
    private void Start() {
        cameraOffSet = transform.position - target.transform.position;
    }
    private void LateUpdate() {
        Rotate();
    }
    private void Rotate(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.up, mouseX);

        Vector3 newPosition = target.transform.position + cameraOffSet;
        transform.position = newPosition;
    }
}
