using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnProtectionRadius;
    [SerializeField] Transform background;

    void Start()
    {
        var mapSize = background.localScale.x;
        for (var i = 0; i < 300; i++)
        {
            var randomPosition = GetRandomPosition(mapSize);
            while (Vector3.Distance(randomPosition, Vector3.zero) < spawnProtectionRadius)
                randomPosition = GetRandomPosition(mapSize);

            var enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemy.transform.localScale = Vector3.one * Random.Range(3f, 20f);
            enemy.transform.SetParent(transform);
            enemy.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);

            enemy.tag = "Enemy";
        }
        static Vector3 GetRandomPosition(float mapSize)
        {
            return new Vector3(
                Random.Range(-mapSize / 2, mapSize / 2),
                Random.Range(-mapSize / 2, mapSize / 2),
                0
            );
        }
    }
}
