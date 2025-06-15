using UnityEngine;

public class GameClearEffect : MonoBehaviour

{
    public float jumpHeight = 20f;   // 점프 높이 (픽셀 단위)
    public float jumpSpeed = 2f;     // 점프 속도

    private RectTransform rectTransform;
    private Vector3 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;  // UI 기준 위치 저장
    }

    void Update()
    {
        // Mathf.Sin으로 위아레 자연스러운 움직임
        float newY = startPos.y + Mathf.Sin(Time.time * jumpSpeed) * jumpHeight;
        rectTransform.anchoredPosition = new Vector2(startPos.x, newY);
    }
}

