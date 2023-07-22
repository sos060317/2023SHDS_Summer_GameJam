using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject rangeObject;
    [SerializeField] private GameObject enemy;

    private BoxCollider rangeCollider;
    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(RandomSpawn());
    }

    IEnumerator RandomSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            Instantiate(enemy, Return_RandomPosition(), Quaternion.identity);
        }
    }
    
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;
        
        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range( (range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);
        
        Vector3 respawnPosition = originPosition + RandomPostion;
        
        float distance = Vector3.Distance(GameManager.Instance.player.transform.position, respawnPosition);

        if (distance < GameManager.Instance.player.GetComponent<PlayerTest>().radius)
            return Return_RandomPosition();
            
        return respawnPosition;
    }
}
