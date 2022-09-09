using UnityEngine;

public class bloc : MonoBehaviour
{
    public bool bedroc;
    [SerializeField] private int Hp;
    [SerializeField] private int HpStart;
    public SpriteRenderer SR;
    public int id;
    public Color colLomatPS;

    private void Start()
    {
        Hp = HpStart;
        if (SR) { 
            SR.sprite = null;
            SR.enabled = false;
        }
    }

    public bool lomat(int ur)
    {
        if (bedroc) return false;
        Hp -= ur;
        if (Hp <= 0)
        {
            kill();
            return true;
        }

        
        if (SR)
        {
            if (HpStart / 2.5 > Hp) SR.sprite = globalNeramenia.sig.SpriteLomat[2];
            else if (HpStart / 1.5 > Hp) SR.sprite = globalNeramenia.sig.SpriteLomat[1];
            else SR.sprite = globalNeramenia.sig.SpriteLomat[0];
            SR.enabled = true;
        }
        return true;
    }

    public void kill()
    {
        Destroy(gameObject);
    }
}
