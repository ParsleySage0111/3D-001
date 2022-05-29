using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{

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

    void Start()
    {
        ComponentsInit();
    }

    public async Task LoadMissile(MissileBase missile)
    {
        Missile = missile;
        Isloaded = true;
        _tM = missile.transform;
        _tM.SetParent(_t);
        _tM.position = _t.position;
        _tM.rotation = _t.rotation;
        await Task.Yield();
    }

    public void FireMissile(Transform target)
    {
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

    public void OpenLauncher()
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
