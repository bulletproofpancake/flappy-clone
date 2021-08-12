using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool scaleDownPool;
    [SerializeField] private ObjectPool scaleUpPool;

    private void OnEnable()
    {
        // Ensures that the pool is populated before spawning a power up
        if(scaleUpPool != null && scaleDownPool != null)
            Spawn();
    }

    private void Spawn()
    {
        var random = Random.Range(0, 101);

        // if random is
        // 0 - 80: no power up will spawn
        // 81 - 90: scale down power up will spawn 
        // 91 - 100: scale up power up will spawn

        if (random <= 80) return;

        if (random <= 90)
        {
            var powerUp = scaleDownPool.GetPooledObject();
            powerUp.transform.position = transform.position;
            powerUp.SetActive(true);
        }
        else if (random <= 100)
        {
            var powerUp = scaleUpPool.GetPooledObject();
            powerUp.transform.position = transform.position;
            powerUp.SetActive(true);
        }
    }
}
