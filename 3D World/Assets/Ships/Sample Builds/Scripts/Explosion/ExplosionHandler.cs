using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    ParticleSystem particle;
    float duration;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        duration = particle.main.duration;
    }

    private void OnEnable()
    {
        Invoke("Release", duration);
        particle.Play();
    }
    private void Release()
    {
        ExplosionPoolHandler.Instance.Release(this);
    }

}
