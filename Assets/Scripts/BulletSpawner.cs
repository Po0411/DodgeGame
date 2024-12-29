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
        // timeSpawn�� 0���� �ʱ�ȭ
        timeSpawn = 0f;

        // SpawnRate�� �ּ�, �ִ�Spawn�ð� ������ �������� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // PlayerCtrl�� ���� ���� ������Ʈ�� transform ������Ʈ��
        // transform���� �����ؼ� target�� �Ҵ�
        target = FindObjectOfType<PlayerCtrl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �������� ���� �ð��� ����
        timeSpawn += Time.deltaTime;

        // ���� �ֱ� �̻����� �ð��� �����ϸ�
        if (timeSpawn >= spawnRate)
        {
            // 0���� �ʱ�ȭ�ϰ�
            timeSpawn = 0f;

            // BulletPrefab�� transform ��ġ�� ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            // ������ ���� ������ �ٽ� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}