using UnityEngine;

public class CameraMovement
{
    public readonly float _smoothCamera = 4;

    public readonly Transform _playerBody;
    public readonly Transform _playerHead;

    public readonly Vector2 _limitCamera;

    public float _xRotation;

    public CameraMovement(float smoothCamera, Transform playerBody, Transform playerHead, Vector2 limitCamera)
    {
        _smoothCamera = smoothCamera;
        _playerBody = playerBody;
        _playerHead = playerHead;
        _limitCamera = limitCamera;
    }

    public void CameraMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * _smoothCamera;
        float mouseY = Input.GetAxis("Mouse Y") * _smoothCamera;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _limitCamera.x, _limitCamera.y);

        _playerHead.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * mouseX );


    }
}