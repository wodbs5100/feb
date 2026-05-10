using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject jellyfishPrefab;  // 해파리
    public GameObject sharkPrefab;      // 상어
    public GameObject oxygenPrefab;     // 산소

    float span = 1.0f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;

            // 랜덤 선택
            int rand = Random.Range(0, 100);
            GameObject go;

            if (rand < 50)
            {
                go = Instantiate(jellyfishPrefab);
            }
            else if (rand < 75)
            {
                go = Instantiate(sharkPrefab);
            }
            else
            {
                go = Instantiate(oxygenPrefab);
            }

            // 위치 랜덤 생성
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}