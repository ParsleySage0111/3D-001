using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [Header("Launcher Settings")]

    [SerializeField] int loadingTime = 1000;

    #region Private Variables
    Animator LauncherAnim;
    bool isOpen = false;
    bool isLoaded = false;
    MissileBase missile;
    Transform _t, _tM;
    MissilePoolHandler missilePool;
    #endregion

    #region Getter & Setter
    public MissileBase Missile { set {  missile = value; } }
    public bool Isloaded { 
        get { return isLoaded; }
        set { isLoaded = value; } }
    #endregion

    private void Awake()
    {
        ComponentsInit();
    }

    public async Task LoadMissile()
    {
        if(Isloaded) return;
        Missile = missilePool.GetMissile();
        Isloaded = true;
        _tM = missile.transform;
        _tM.SetParent(_t);
        _tM.position = _t.position;
        _tM.rotation = _t.rotation;
        await Task.Delay(loadingTime);
    }

    public async Task FireMissile(Transform target)
    {
        OpenLauncher();
        await Task.Delay(2000);
        missile.Target = target;
        missile.FireMissile();
        Missile = null;
        Isloaded = false;
        CloseLauncher();
    }

    void ComponentsInit()
    {
        _t = transform;
        LauncherAnim = GetComponent<Animator>();
        missilePool = MissilePoolHandler.Instance;
    }

    void OpenLauncher()
    {
        isOpen = true;
        LauncherAnim.SetBool("isOpen", isOpen); 
    }
    private async void CloseLauncher()
    {
        await Task.Delay(2000);
        isOpen = false;
        LauncherAnim.SetBool("isOpen", isOpen); 
    }

}
