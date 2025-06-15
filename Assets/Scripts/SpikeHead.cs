using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Drop()
    {
        if (!hasFallen)
        {
            Debug.Log("Drop() 호출됨!");
            rb.bodyType = RigidbodyType2D.Dynamic;
            hasFallen = true;
        }
    }
}
