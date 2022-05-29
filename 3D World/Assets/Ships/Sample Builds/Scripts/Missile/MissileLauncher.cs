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
        Missile = MissilePoolHandler.Instance.GetMissile();
        await Task.Delay(loadingTime);
        Isloaded = true;
        _tM = missile.transform;
        _tM.SetParent(_t);
        _tM.position = _t.position;
        _tM.rotation = _t.rotation;

    }

    public async Task FireMissile(Transform target)
    {
        OpenLauncher();
        await Task.Delay(1000);
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
    }

    void OpenLauncher()
    {
        isOpen = true;
        LauncherAnim.SetBool("isOpen", isOpen); 
    }
    private async void CloseLauncher()
    {
        await Task.Delay(1000);
        isOpen = false;
        LauncherAnim.SetBool("isOpen", isOpen); 
    }

}
