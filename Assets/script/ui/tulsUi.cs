using UnityEngine;
using TMPro;

public class tulsUi : MonoBehaviour
{
    public GameObject[] tuls;
    public TMP_Text[] tulsTmp;
    public int nrosli;
    public PleirTuls PT;
    public ruze zuze;

    private void Start()
    {
        PT = pleirSingenlton.pleirObgect.GetComponent<PleirTuls>();
        PT.tulsUndeit.AddListener(uodeitic);
        defoltTuls q = PleirTuls.sig.tuls[1];  // кастил
        zuze = ((ruze)q);
        zuze.vistrelEve.AddListener(()=>
        tulsTmp[1].text = zuze.natron.ToString());
        tulsTmp[1].text = zuze.natron.ToString();

        nrosli = 0;
        for (int i = 1;i< tuls.Length;i++)
            tuls[i].SetActive(false);

        tuls[PT.TulsID].SetActive(true);
    }

    public void uodeitic()
    {
        tuls[nrosli].SetActive(false);
        tuls[PT.TulsID].SetActive(true);
        nrosli = PT.TulsID;
    }
}
