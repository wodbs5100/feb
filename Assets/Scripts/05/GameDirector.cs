using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject[] bubbles; // UI 버블 5개
    int hp = 5;

    int score = 0;
    float scoreTimer = 0;

    // 사운드 변수
    public AudioClip oxygenSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateUI();
    }

    public void DecreaseHp()
    {
        hp--;

        if (hp < 0)
            hp = 0;

        UpdateUI();

        if (hp == 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }

    public void IncreaseHp()
    {
        hp++;

        if (hp > 5)
            hp = 5;

        // 산소 먹을 때 소리
        audioSource.PlayOneShot(oxygenSound);

        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < bubbles.Length; i++)
        {
            bubbles[i].SetActive(i < hp);
        }
    }

    void Update()
    {
        // 점수 증가
        scoreTimer += Time.deltaTime;

        if (scoreTimer >= 1.0f)
        {
            score += 10;
            scoreTimer = 0;

            Debug.Log("Score: " + score);
        }

        // 게임오버 상태에서 스페이스로 재시작
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}