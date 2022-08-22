using UnityEngine;
using TMPro;

public class blocUi : MonoBehaviour
{
    public GameObject[] blocs;
    public int nrosli;
    public PleirTuls PT;
    public TMP_Text text;

    private void Start()
    {
        PT = pleirSingenlton.pleirObgect.GetComponent<PleirTuls>();
        PT.BlocUndeit.AddListener(uodeitic);
        stritelstvo.sig.updeit.AddListener(()=>
            text.text = stritelstvo.sig.getKolisestvoReltaim().ToString()
        );

        nrosli = 0;
        for (int i = 0;i< blocs.Length;i++)
            blocs[i].SetActive(false);

        blocs[stritelstvo.sig.BlocIndex].SetActive(true);
        text.text = stritelstvo.sig.getKolisestvoReltaim().ToString();
    }

    public void uodeitic()
    {
        text.text = stritelstvo.sig.getKolisestvoReltaim().ToString();
        blocs[nrosli].SetActive(false);
        blocs[PT.BlocID+2].SetActive(true);
        nrosli = PT.BlocID+2;
    }
}
