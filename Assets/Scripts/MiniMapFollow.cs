using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public Vector3 baseOffset = new Vector3(0, 20f, -60f);

    private float referenceX; // 기준 위치 저장

    void Start()
    {
        referenceX = player.position.x; // 시작 위치 기준
    }

    void LateUpdate()
    {
        Vector3 dynamicOffset = baseOffset;

        // 현재 기준보다 왼쪽으로 갔을 경우
        float deltaX = player.position.x - referenceX;

        if (deltaX < 0f)
        {
            // 현재 위치가 기준보다 왼쪽이면, 오른쪽으로 오프셋 보정 (2배 적용)
            float adjust = Mathf.Lerp(0f, 10f, -deltaX / 10f);
            dynamicOffset.x = adjust;
        }

        // 위로 올라갈수록 Y, Z 보정 (2배 적용 유지)
        if (player.position.y > 5f)
        {
            dynamicOffset.y = Mathf.Lerp(20f, 40f, (player.position.y - 5f) / 20f);
            dynamicOffset.z = Mathf.Lerp(-60f, -100f, (player.position.y - 5f) / 20f);
        }

        Vector3 targetPosition = player.position + dynamicOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}



//using UnityEngine;
//public class MiniMapFollow : MonoBehaviour
//{
//public Transform player;
//  private void LateUpdate()
//{
//transform.position = new Vector3(
//      player.position.x,
//  player.position.y,
//transform.position.z
// );

//}
//}
