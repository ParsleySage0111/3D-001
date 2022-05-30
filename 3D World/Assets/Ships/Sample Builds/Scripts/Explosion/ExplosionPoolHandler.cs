using UnityEngine;
using UnityEngine.Pool;

public class ExplosionPoolHandler : MonoBehaviour
{
    [SerializeField] int defaultCapacity = 100;
    [SerializeField] int maxCapacity = 1000;

    private static ExplosionPoolHandler instance;
    public static ExplosionPoolHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ExplosionPoolStatics").AddComponent<ExplosionPoolHandler>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }
    private ExplosionHandler explosionPrefab;

    public ExplosionHandler ExplosionPrefab
    {
        set { explosionPrefab = value; }
    }
    private ObjectPool<ExplosionHandler> explosionPool;
    public ObjectPool<ExplosionHandler> ExplosionPool
    {
        get { return explosionPool; }
    }

    public void InitPool()
    {
        explosionPool = new ObjectPool<ExplosionHandler>(
            () => { return Instantiate(explosionPrefab); },
            explosion => { explosion.gameObject.SetActive(true); },
            explosion => { explosion.gameObject.SetActive(false); },
            explosion => { Destroy(explosion.gameObject); },
            false, defaultCapacity, maxCapacity);
    }
    public void SpawnExplosion(Transform transform)
    {
        var explosion = explosionPool.Get();
        explosion.transform.position = transform.position;
    }
    public void Release(ExplosionHandler obj)
    {
        explosionPool.Release(obj);
    }
}
