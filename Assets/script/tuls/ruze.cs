using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ruze : defoltTuls
{
    [Header("def")]
    public SpriteRenderer SR;
    private Camera cam;

    [Header("lys")]
    public float distansia;
    public LayerMask Mask;
    public int drob;
    public float razbros;
    public float uron;

    [Header("nerezarad")]
    public int natron;
    public UnityEvent vistrelEve = new UnityEvent();
    public int nulDef =2;
    public float timeNerazaradka1;
    public float timeNerazaradka2;

    private int nulVramino;
    private float time;

    [Header("efects")]
    public float defoltY;
    public Transform buxPSpos;
    public ParticleSystem buxPS;

    public GameObject prefab;
    public float distansiaNoavleniaEfecta;
    private int NObjacs;
    public List<popadania> popad;
    public float smesenia=0.1f;

    [Header("audio")]
    public AudioSource bux;
    public AudioSource nerezarad1;
    public AudioSource nerezarad2;


    private void Start()
    {
        defoltY = buxPSpos.localPosition.y;
        if (SR)
            SR = GetComponent<SpriteRenderer>();
        nulVramino = nulDef;
        cam = Camera.main;
        if(magazUI.sig)
            magazUI.sig.tuls.AddListener(pocupka);
    }

    private void Update()
    {
        Vector3 diffence = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation = Mathf.Atan2(diffence.y, diffence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);

        bool BNov = Math.Abs(rotation) > 90;
        SR.flipY =BNov;
        buxPSpos.localPosition = new Vector2(buxPSpos.localPosition.x, BNov? -defoltY: defoltY);

        if (time >= 0)
            time -= Time.deltaTime;

        if (time <= 0)
            if (Input.GetMouseButtonDown(0) && natron>0 && !magaz.sig.torg) // svazavania
            {
                vistrel(rotation);
                for (int i = 0; i < drob; i++)
                    vistrel(rotation + UnityEngine.Random.Range(-razbros, razbros));

                nerezaradka();
                NObjacs = 0;
                //efecs
                buxPS.Play(true);
                vistrelEve.Invoke();
                audios.plei(bux);
            }
    }


    private void vistrel(float rotation)
    {
        float rotationn = rotation / Mathf.Rad2Deg;
        Vector2 rot = new Vector2((float)Math.Cos(rotationn), (float)Math.Sin(rotationn));

        if (globalNeramenia.sig.debug) Debug.DrawRay(transform.position, rot * distansia);
        RaycastHit2D[] o = Physics2D.RaycastAll(transform.position, rot, distansia, Mask);
        for (int i = 0; i < o.Length; i++)
        {
            GameObject O = o[i].collider.gameObject;
            RaycastHit2D ry = o[i];

            if (O.tag == "zombi")
            {
                mob m = O.GetComponent<mob>();
                if (m)
                {
                    if(ry.distance < distansiaNoavleniaEfecta)
                        sastisa(ry.point, ry.normal, rotation,m.colKillPS);

                    m.uron(uron / (ry.distance*0.1f + 0.1f));
                    if (!m.kill)
                        return;
                }
            }
            else if(O.tag == "bloc")
            {
                bloc b = O.GetComponent<bloc>();

                if (b)
                {
                    bool v = b.lomat((int)(0.3f * uron / (ry.distance * 0.1f + 0.1f)) +1);

                    if (ry.distance < distansiaNoavleniaEfecta && !v)
                        sastisa(ry.point, ry.normal, rotation, b.colLomatPS);
                    return;
                }
            }
        }
    }

    private void sastisa(Vector2 pos, Vector2 norm,float rot, Color col)
    {
        norm = -norm;
        float rotationn = rot / Mathf.Rad2Deg;
        Vector2 rotss = new Vector2((float)Math.Cos(rotationn), (float)Math.Sin(rotationn));
        Vector2 nov = norm + rotss;

        nov = nov.normalized;

        float i = Mathf.Atan2(nov.y, nov.x) * Mathf.Rad2Deg;

        //Debug.Log(i);
        //Debug.Log(nov);
        //Debug.Log(rotss);
        //Debug.Log(-norm);


        //Debug.Log(i+180);
        //Debug.Log(rot+180);
        //float rote = ((i + 180)  + (rot + 180)) / 2 -180;
        //Debug.Log(rote);
        Quaternion rots = Quaternion.Euler(new Vector3(0, 0, i));

        pos += norm * -smesenia;
        if (popad.Count != 0)
        {
            for (int ii = NObjacs; ii < popad.Count; ii++)
            {
                if (popad[ii].nrigodni())
                {
                    popad[ii].newremectica(pos, rots, col);
                    NObjacs=ii;
                    return;
                }
            }
            NObjacs = popad.Count;
        }
        GameObject gem =  Instantiate(prefab, pos, rots);
        popadania pop = gem.GetComponent<popadania>();
        pop.newremectica(pos, rots, col);
        popad.Add(pop);
    }

    private void nerezaradka()
    {
        natron--;
        time = timeNerazaradka1;
        nulVramino--;
        if (nulVramino == 0)
        {
            time = timeNerazaradka2;
            nulVramino = nulDef;
        }
        else
        {
            StartCoroutine(pleiZdat(nerezarad2));
            return;
        }
        StartCoroutine(pleiZdat(nerezarad1));
    }

    public IEnumerator pleiZdat(AudioSource i)
    {
        yield return new WaitForSeconds(0.1f);
        audios.plei(i);
    }


    private void pocupka(int i)
    {
        if (i != 0) return;
        natron += 10;
        vistrelEve.Invoke();
    }
}
