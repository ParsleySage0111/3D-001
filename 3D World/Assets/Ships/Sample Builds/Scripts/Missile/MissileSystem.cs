using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;

public class MissileSystem : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] MissileLauncher[] MissileLaunchers;

    [Header("LauncherSettings")]
    [SerializeField] int LaunchInterval = 1000;

    #region Private Variables
    private bool IsFullyLoaded = false;
    private Task[] loadingTask, firingTask;
    #endregion

    #region TEST Variables
    [SerializeField] Transform target;
    #endregion

    private void Awake()
    {
        GetLaunchers();
    }

    void GetLaunchers()
    {
        if (MissileLaunchers.Length != 0) return;
        MissileLaunchers = GetComponentsInChildren<MissileLauncher>();
    }

    void Start()
    {
        Init();
        LoadMissiles();
        InvokeRepeating(nameof(FireMissiles), 5, 5);
    }

    void Init()
    {
        loadingTask = new Task[MissileLaunchers.Length];
        firingTask = new Task[MissileLaunchers.Length];
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

    async void FireMissiles()
    {
        if (!IsFullyLoaded) return;
        IsFullyLoaded = false;
        for (var c = 0; c < MissileLaunchers.Length; c++)
        {
            int index = Random.Range(0, target.childCount);
            var childTarget = target.GetChild(index);
            firingTask[c] = MissileLaunchers[c].FireMissile(childTarget);
            await Task.Delay(LaunchInterval);
        }
        await Task.WhenAll(firingTask);
        LoadMissiles();
    }
}
