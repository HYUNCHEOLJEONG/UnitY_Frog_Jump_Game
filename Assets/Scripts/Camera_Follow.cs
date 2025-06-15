using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target; // 따라갈 플레이어
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10); //z값은 -10으로 고정

    void LateUpdate()
    {
        // X와 Y 좌표는 플레이어를 모두 따라가게 함
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
