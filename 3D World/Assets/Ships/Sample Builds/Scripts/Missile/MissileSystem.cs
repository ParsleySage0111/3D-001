using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;

public class MissileSystem : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] MissileBase MissilePrefab;
    [SerializeField] MissileLauncher[] MissileLaunchers;

    [Header("LauncherSettings Intervals")]
    [SerializeField] int ReloadTime = 5000;
    [SerializeField] int OpenTime = 1000;

    #region Private Variables
    [SerializeField] Transform target;
    private static ObjectPool<MissileBase> MissilePool;
    private bool IsFullyLoaded = false;
    private Task[] loadingTask, firingTask;
    #endregion

    #region TEST Variables
    [SerializeField] TextMeshProUGUI active;
    [SerializeField] TextMeshProUGUI inactive;
    [SerializeField] TextMeshProUGUI all;
    MissilePoolHandler poolHandler;
    #endregion

    private void Awake()
    {
        GetLaunchers();
        poolHandler = MissilePoolHandler.Instance;
        poolHandler.MissilePrefab = MissilePrefab;
        poolHandler.InitPool();
        MissilePool = poolHandler.MissilePool;
        loadingTask = new Task[MissileLaunchers.Length];
        firingTask = new Task[MissileLaunchers.Length];
    }

    void GetLaunchers()
    {
        if (MissileLaunchers.Length != 0) return;
        MissileLaunchers = GetComponentsInChildren<MissileLauncher>();
    }

    void Start()
    {
        LoadMissiles();
        InvokeRepeating("FireMissiles", 5, 5);
    }

    async void LoadMissiles()
    {
        for (var c = 0; c < MissileLaunchers.Length; c++)
        {
            loadingTask[c] = MissileLaunchers[c].LoadMissile();
        }
        await Task.WhenAll(loadingTask);
        IsFullyLoaded = true;
    }
    private void Update()
    {
        active.SetText(MissilePool.CountActive.ToString());
        inactive.SetText(MissilePool.CountInactive.ToString());
        all.SetText(MissilePool.CountAll.ToString());
    }

    async void FireMissiles()
    {
        if (!IsFullyLoaded) return;
        for (var c = 0; c < MissileLaunchers.Length; c++)
        {
            IsFullyLoaded = false;
            int index = Random.Range(0, target.childCount);
            var childTarget = target.GetChild(index);
            firingTask[c] = MissileLaunchers[c].FireMissile(childTarget);
            await Task.Delay(OpenTime);
        }
        await Task.WhenAll(firingTask);
        LoadMissiles();
    }
}
