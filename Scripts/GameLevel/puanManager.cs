using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class puanManager : MonoBehaviour
{
    private int toplamPuan;
    private int puanArttır;

    [SerializeField]
    private TextMeshProUGUI puanText;
    void Start()
    {
        puanText.text=toplamPuan.ToString();
    }

    public void PuaniArtir(string zorlukLevel)
    {
        switch(zorlukLevel)
        {
            case "kolay":
                puanArttır = 1;
                break;

            case "orta":
                puanArttır = 2;
                break;

            case "zor":
                puanArttır = 3;
                break;

        }

        toplamPuan += puanArttır;

        puanText.text = toplamPuan.ToString();
    }


}
