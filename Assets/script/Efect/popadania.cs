using System.Collections;
using UnityEngine;

public class popadania : MonoBehaviour
{
    public ParticleSystem PS;
    public float propadot;

    public bool nrigodni()
    {
        return !gameObject.activeInHierarchy;
    }

    public void newremectica(Vector2 pos, Quaternion rot, Color col)
    {
        transform.position = pos;
        transform.rotation = rot;
        gameObject.SetActive(true);
        StartCoroutine(kill());
        PS.startColor = col;
    }

    private IEnumerator kill()
    {
        yield return new WaitForSeconds(propadot);
        gameObject.SetActive(false);
    }
}
