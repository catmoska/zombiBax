using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turel : MonoBehaviour
{
    [Header("neremenki")]
    public List<mob> mobStralb;
    public Transform ruze;
    public float uron;
    public bloc blo;
    public ParticleSystem ps;

    [Header("Patron")]
    public int startPatron;
    public int Patron;

    [Header("timer")]
    public int momStart;
    private int mom;

    private void Start()
    {
        Patron = startPatron;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        mob m = collision.gameObject.GetComponent<mob>();
        if (m)
            mobStralb.Add(m);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        mob m = collision.gameObject.GetComponent<mob>();
        if (m)
            mobStralb.Remove(m);
    }

    private void FixedUpdate()
    {
        if (mom >= 0)
        {
            mom--;
            return;
        }

        if (Patron <= 0) 
        {
            blo.lomat(1);
            return; 
        }
        
        mom = momStart;
        int Len = mobStralb.Count > 10 ? 10 : mobStralb.Count;

        for(int i = 0; i < Len; i++)
        {
            if (!mobStralb[i]) { mobStralb.RemoveAt(i); i++; }

            if (!mobStralb[i].kill)
            {
                GameObject g = mobStralb[i].gameObject;

                Vector3 diffence = g.transform.position - transform.position;
                float rotation = Mathf.Atan2(diffence.y, diffence.x) * Mathf.Rad2Deg;
                ruze.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
                mobStralb[i].uron(uron);
                ps.Play();
                Patron--;
                return;
            }
        }
    }
}
