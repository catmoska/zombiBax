using System;
using System.Collections;
using UnityEngine;

public class spavn : MonoBehaviour
{
    public GameObject zombiNrefab;
    public Vector2 posSpavna;

    public Vector2 posReicast;
    public Vector2 posSmesenia;
    public float distansia;
    public LayerMask Mask;

    public int deiSpavn =10;
    public float gradusDeiSpavn = 30;
    public float pogresnast = 0.9f;

    public float startTime = 3;
    private float time;
    public bool isDay;

    private void Start()
    {
        time = startTime;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            spavns();
            time = startTime;
        }
    }

    private void spav(Vector2 pos)
    {
        Instantiate(zombiNrefab, pos, Quaternion.identity);
    }

    private void spavns()
    {
        if (!GlobalTime.sig.getBoolDei())
            spav(posSpavna);

        if ((!GlobalTime.sig.getBoolDei() && GlobalTime.sig.getBoolDei() != isDay))
        {
            for (int i = 0; i < deiSpavn; i++)
                spasvnDei();
        }

        isDay = GlobalTime.sig.getBoolDei();
    }


    private void spasvnDei()
    {
        float rotation = -90 + UnityEngine.Random.Range(-gradusDeiSpavn, gradusDeiSpavn);
        float rotationn = rotation / Mathf.Rad2Deg;
        Vector2 rot = new Vector2((float)Math.Cos(rotationn), (float)Math.Sin(rotationn));

        if (globalNeramenia.sig.debug) Debug.DrawRay(posReicast, rot * distansia);
        RaycastHit2D[] o = Physics2D.RaycastAll(posReicast, rot, distansia, Mask);

        if (o.Length == 0)
            return;

        if (o[0].collider.gameObject.tag == "Player")
            return;

        for (int i = 0; i < o.Length; i++)
        {
            if((o[i].normal / Vector2.up).y >= pogresnast)
            {
                spav(o[i].point+ posSmesenia);
                return;
            }
        }

    }
}
