using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hakManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Hak1,Hak2,Hak3;
 public void KalanHaklariKontrolEt(int kalanHak)
    {
        switch(kalanHak)
        {
            case 3:
                Hak1.SetActive(true);
                Hak2.SetActive(true);
                Hak3.SetActive(true);
                break;

            case 2:
                Hak1.SetActive(true);
                Hak2.SetActive(true);
                Hak3.SetActive(false);
                break;

            case 1:
                Hak1.SetActive(true);
                Hak2.SetActive(false);
                Hak3.SetActive(false);
                break;

            case 0:
                Hak1.SetActive(false);
                Hak2.SetActive(false);
                Hak3.SetActive(false);
                break;
        }
    }
}
