using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private ObjectPool pipePool;

    private void Start()
    {
        InvokeRepeating("Spawn", 3f, timeToSpawn);
    }

    private void Spawn()
    {
        var pipe = pipePool.GetPooledObject();
        pipe.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-4, 5));
        pipe.SetActive(true);
    }
}
