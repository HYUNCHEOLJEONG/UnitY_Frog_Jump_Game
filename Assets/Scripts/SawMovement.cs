using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float moveDistance = 10f; // 좌우 이동 거리
    public float moveSpeed = 10f;    // 이동 속도

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
   
}
