using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("player_0");
    }

    void Update()
    {
        // 기본 낙하 속도
        float speed = 0.1f;

        // 상어는 더 빠르게
        if (gameObject.CompareTag("StrongEnemy"))
        {
            speed = 0.13f;
        }

        transform.Translate(0, -speed, 0, Space.World);

        // 화면 밖으로 나가면 삭제
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;

        float distance = Vector2.Distance(p1, p2);

        float r1 = 0.5f;  // 장애물 반경
        float r2 = 1.0f;  // 플레이어 반경

        if (distance < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");

            if (gameObject.CompareTag("Enemy")) // 해파리
            {
                director.GetComponent<GameDirector>().DecreaseHp();
            }
            else if (gameObject.CompareTag("StrongEnemy")) // 상어
            {
                director.GetComponent<GameDirector>().DecreaseHp();
                director.GetComponent<GameDirector>().DecreaseHp();
                director.GetComponent<GameDirector>().DecreaseHp();
            }
            else if (gameObject.CompareTag("Oxygen")) // 산소
            {
                director.GetComponent<GameDirector>().IncreaseHp();
            }

            Destroy(gameObject);
        }
    }
}