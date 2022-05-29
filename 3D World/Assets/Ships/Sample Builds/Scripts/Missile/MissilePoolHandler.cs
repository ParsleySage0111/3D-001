using UnityEngine;
using UnityEngine.Pool;

public abstract class MissilePoolHandler: MonoBehaviour
{
    [SerializeField] MissileBase MissilePrefab;
    private static ObjectPool<MissileBase> missilePool;

    public ObjectPool<MissileBase> MissilePool
    {  get { return missilePool; } }
    private void Awake()
    {
        InitMissilePool();
    }
    void InitMissilePool()
    {
        missilePool = new ObjectPool<MissileBase>(
            () => { return Instantiate(MissilePrefab); },
            missile => { missile.gameObject.SetActive(true); },
            missile => { missile.gameObject.SetActive(false); },
            missile => { Destroy(missile.gameObject); },
            false, 10, 50);
    }
}
