using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private ObjectPool pipePool;

    private void OnEnable()
    {
        GameManager.Instance.OnGameStart += SpawnPipes;
        GameManager.Instance.OnGameOver += CancelSpawn;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= SpawnPipes;
        GameManager.Instance.OnGameOver -= CancelSpawn;
    }

    private void SpawnPipes()
    {
        InvokeRepeating("Spawn", 1.5f, timeToSpawn);
    }

    private void Spawn()
    {
        var pipe = pipePool.GetPooledObject();
        pipe.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-3, 4));
        pipe.SetActive(true);
    }

    private void CancelSpawn()
    {
        CancelInvoke("Spawn");
    }
}
