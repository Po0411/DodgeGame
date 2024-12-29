using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    Transform target;

    public float spawnRate;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    float timeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // timeSpawn를 0으로 초기화
        timeSpawn = 0f;

        // SpawnRate를 최소, 최대Spawn시간 내에서 랜덤으로 생성
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // PlayerCtrl를 가진 게임 오브젝트의 transform 컴포넌트를
        // transform으로 접근해서 target에 할당
        target = FindObjectOfType<PlayerCtrl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 생성 시점에서 지난 시간이 증가
        timeSpawn += Time.deltaTime;

        // 생성 주기 이상으로 시간이 증가하면
        if (timeSpawn >= spawnRate)
        {
            // 0으로 초기화하고
            timeSpawn = 0f;

            // BulletPrefab를 transform 위치와 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // 생성된 bullet 게임 오브젝트의 정면 방향이 target를 향하도록 회전
            bullet.transform.LookAt(target);

            // 다음번 생성 간격을 다시 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}