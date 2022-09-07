using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiAnimaticSpavn : MonoBehaviour
{
    public SpriteRenderer SR;
    public float intesivnast;
    public zombiAnimator ZA;
    public bool kadar;

    public ParticleSystem PS;

    public float TimeDel;

    private void Start()
    {
        SR.color *= new Color(1,1,1,0);
        Destroy(gameObject, TimeDel);
    }


    private void FixedUpdate()
    {
        Color h = SR.color;
        h.a += intesivnast;
        SR.color = h;

        if (!kadar && ZA.sostainia)
        {
            kadar = true;
            PS.Play();
        }
    }

    private void OnDestroy()
    {
        Color h = SR.color;
        h.a += 1;
        SR.color = h;
    }
}
