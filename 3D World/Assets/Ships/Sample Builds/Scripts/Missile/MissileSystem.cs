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
    #endregion

    #region TEST Variables
    [SerializeField] TextMeshProUGUI active;
    [SerializeField] TextMeshProUGUI inactive;
    [SerializeField] TextMeshProUGUI all;
    #endregion

    void Start()
    {
        InitMissilePool();
        //InitVariables();
        LoadMissiles();
        OpenMissiles();
        Invoke("FireMissiles", 10);
    }
    void InitVariables()
    {

    }

    void InitMissilePool()
    {
        MissilePool = new ObjectPool<MissileBase>(
            () => { return Instantiate(MissilePrefab); },
            missile => { missile.gameObject.SetActive(true); },
            missile => { missile.gameObject.SetActive(false); },
            missile => { Destroy(missile.gameObject); },
            false, 10, 50 );
    }

    private void Update()
    {
        active.SetText(MissilePool.CountActive.ToString());
        inactive.SetText(MissilePool.CountInactive.ToString());
        all.SetText(MissilePool.CountAll.ToString());
    }

    async void LoadMissiles()
    {
        
        foreach (MissileLauncher launcher in MissileLaunchers)
        {
            if(launcher.Isloaded) { continue; }
            var missile = MissilePool.Get();
            await launcher.LoadMissile(missile);
            await Task.Delay(ReloadTime);
        }
    }

    async void OpenMissiles()
    {
        foreach (MissileLauncher launcher in MissileLaunchers)
        {
            launcher.OpenLauncher();
            await Task.Delay(OpenTime);
        }
    }

    async void FireMissiles()
    {
        foreach (MissileLauncher launcher in MissileLaunchers)
        {
            launcher.FireMissile(target);
            await Task.Delay(OpenTime);
        }
    }
}
