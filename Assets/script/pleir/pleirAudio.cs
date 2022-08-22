using System.Collections;
using UnityEngine;

public class pleirAudio : MonoBehaviour
{
    public AudioSource[] Audios;
    public float time;
    [SerializeField] private bool xodb;
    private Coroutine cur;

    private void Start()
    {
        pleirControlir.sig.evXodbi.AddListener(xodba);
        pleirControlir.sig.evstop.AddListener(stop);
    }

    private void xodba()
    {
        if (xodb) return;
        xodb = true;
        cur = StartCoroutine(barerc());
    }

    private void stop()
    {
        xodb = false;
        StopCoroutine(cur);
    }

    private IEnumerator barerc()
    {
        while (true)
        {
            if (pleirControlir.sig.isGrqaund)
                audios.plei(Audios[Random.Range(0, Audios.Length)]);

            if (!xodb) yield break;
            yield return new WaitForSeconds(time);

            if (!xodb) yield break;
        }
    }

}
