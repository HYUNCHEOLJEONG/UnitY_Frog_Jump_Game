using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public SpikeHead spikeHead;

    void Start()
    {
        if (spikeHead == null)
            spikeHead = GetComponentInParent<SpikeHead>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger 감지됨: " + other.name);  // 콘솔에서 확인

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player 감지됨 - SpikeHead 떨어짐!");
            spikeHead.Drop();
        }
    }
}
