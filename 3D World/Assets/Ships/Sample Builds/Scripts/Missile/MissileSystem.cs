using UnityEngine;
using UnityEngine.Rendering;

public class MissileSystem : MonoBehaviour
{
    [SerializeField] MissileBase MissilePrefab;
    private ObjectPool<MissileBase> Missiles;
    ObjectPool<GameObject> _pool;
    void Start()
    {
        InstantiatePool();
        InvokeRepeating("Instantiate", 1, 2);
    }

    void InstantiatePool()
    {
        Missiles = new ObjectPool<MissileBase>(
            missile => { missile.gameObject.SetActive(true); },
            missile => { missile.gameObject.SetActive(false); },
            false );
    }


    void Instantiate()
    {
        Missiles.Get();
    }
}
