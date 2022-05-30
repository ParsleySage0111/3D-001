using UnityEngine;
using UnityEngine.Pool;

public class MissilePoolHandler : MonoBehaviour
{
    [SerializeField] int defaultCapacity = 100;
    [SerializeField] int maxCapacity = 500;

    private static MissilePoolHandler instance;
    public static MissilePoolHandler Instance{
        get {
            if (instance == null)
            {
                instance = new GameObject("MissilePoolStatics").AddComponent<MissilePoolHandler>();
            }
            return instance;
        }
    }

    private MissileBase missilePrefab;
    public MissileBase MissilePrefab
    {
        set { missilePrefab = value; }
    }
    private ObjectPool<MissileBase> missilePool;
    public ObjectPool<MissileBase> MissilePool
    {
        get { return missilePool; }
    }
    public void InitPool()
    {
        missilePool = new ObjectPool<MissileBase>(
            () => { return Instantiate(missilePrefab); },
            missile => { missile.gameObject.SetActive(true); },
            missile => { missile.gameObject.SetActive(false); },
            missile => { Destroy(missile.gameObject); },
            false, defaultCapacity, maxCapacity);
    }

    public MissileBase GetMissile()
    {
        var missile = missilePool.Get();
        return missile;
    }
    public void ReleaseMissile(MissileBase missile)
    {
        missilePool.Release(missile);
    }

}
