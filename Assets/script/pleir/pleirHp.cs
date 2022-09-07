using System.Collections;
using UnityEngine;
using TMPro;

public class pleirHp : MonoBehaviour
{
    public static pleirHp sig;

    public float startHP;
    public float Hp;
    public bool kills;
    public Vector2 pos;

    public TMP_Text tex;

    private void Start()
    {
        sig = this;
        pos = pleirSingenlton.signelton.transform.position;
        Hp = startHP;
    }

    public bool yron(float yrons)
    {
        if (kills) return false;
        if (yrons > 0)
        {
            Hp -= yrons;
            if (Hp <= 0)
            {
                Hp = 0;
                StartCoroutine(restart());
                pleirSingenlton.signelton.gameObject.SetActive(false);
                return false;
            }
        }
        return true;
    }


    public IEnumerator restart()
    {
        yield return new WaitForSeconds(1);
        tex.text = "3";
        yield return new WaitForSeconds(1);
        tex.text = "2";
        yield return new WaitForSeconds(1);
        tex.text = "1";
        yield return new WaitForSeconds(1);
        tex.text = "";

        Hp = startHP;
        pleirSingenlton.signelton.gameObject.SetActive(true);
        pleirSingenlton.signelton.transform.position = pos;
    }

}
