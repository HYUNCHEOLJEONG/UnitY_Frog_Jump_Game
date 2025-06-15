using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// namespace 누군가가 만들어논 집합체

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float JumpPower;
    private bool IsJump = false;

    public GameObject Hit_Prefab;
    public GameObject GameOver;

    bool isOver = false;
    public GameObject firstHealth;
    public GameObject secondHealth;
    private static int lives = 2;

    private float moveInput = 0f;  // 좌우 입력값 저장
    private bool jumpInput = false; // 점프 입력 저장
    Animator anim;

    public GameObject FinishUI;
    public GameClearEffect gameClearEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (lives >=1 && firstHealth != null) firstHealth.SetActive(true);
        if (lives >=2 && secondHealth != null) secondHealth.SetActive(true);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isOver == true)
        {
            return;
        }
        // 입력 감지만 Update에서 처리
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            moveInput = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !IsJump)
        {
            jumpInput = true;
        }

        // 낙사 처리(위치는 Updaye에서 체크해도 무방)
        if (transform.position.y < -35.0f)
        {
            lives = 0;
            LoseAllLives();
            Retry_Button();
        }
    }

    void FixedUpdate()
    {
        // 좌우 이동 처리
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // 점프 처리
        if (jumpInput)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpPower);
            IsJump = true;
            jumpInput = false;
        }

        // 점프 상태 해제 조건
        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            IsJump = false;
        }
    }

    //Enemy를 만나 체력이 하나씩 깎일 때
    void LoseLife()
    {
        if (lives == 2 && secondHealth != null)
        {
            secondHealth.SetActive(false);
            Destroy(secondHealth);
        }
        else if (lives == 1 && firstHealth != null)
        {
            firstHealth.SetActive(false);
            Destroy(firstHealth);
        }

        lives--;

        if (lives <= 0)
        {
            GameOver.SetActive(true);
            isOver = true;
            Die();
        }
    }

    void LoseAllLives()
    {
        if (secondHealth != null) secondHealth.SetActive(false);
        if (firstHealth != null) firstHealth.SetActive(false);
        lives = 0;
        Die();
    }

    void Die()
    {
        Debug.Log("플레이어가 사망했습니다.");
        gameObject.SetActive(false);
    }
    public void Retry_Button()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        // Stage1->Stage1 retry
        if(currentScene == "Stage1")
        {
            SceneManager.LoadScene("Stage1");
            lives = 2; // reset
            firstHealth.SetActive(true);
            secondHealth.SetActive(true);
        }
        //Stage2->Stage1 retry
        else if(currentScene == "Stage2")
        {
            SceneManager.LoadScene("Stage1");
            lives = 2; //reset
            firstHealth.SetActive(true);
            secondHealth.SetActive(true);

        }
        //Stage3->Stage1 retry
        else if(currentScene == "Stage3")
        {
            SceneManager.LoadScene("Stage1");
            lives = 2; // reset
            firstHealth.SetActive(true);
            secondHealth.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
            GameObject go = Instantiate(Hit_Prefab, transform.position, Quaternion.identity);
            Destroy(go, 1.0f);

            anim.SetTrigger("IsHIt");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            Debug.Log("성공, 게임 종료!"); 
            
            if (FinishUI != null)
            {
                FinishUI.SetActive(true);
            }
            if (gameClearEffect != null)
            {
                gameClearEffect.GetComponent<GameClearEffect>().enabled=true; // ���� �ݺ� ȿ�� Ȱ��ȭ
                Time.timeScale = 5f;
            }

        }
    }
}


