using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject karePrefab;

    [SerializeField]
    private Transform karelerPanel;

    [SerializeField]
    private Transform soruPaneli;

    [SerializeField]
    private TextMeshProUGUI soruText;
    [SerializeField]
    private Sprite[] kareSprites;

    [SerializeField]
    private GameObject sonucPanel;
    
    [SerializeField]
    private AudioSource ses;
    
    public AudioClip ses2;

    public GameObject tutulanKare;

    public GameObject[] karelerdizi=new GameObject[25];

    public GameObject efect;


    
    

    List<int> bolumDegerleriListesi=new List<int>();
    int bolenSayi,bolunenSayi,soruSayac,dogruCevap,btnDeger,kalanHak;
    string zorlukDerece;
    bool btnKontrol;


    hakManager hakManager;
    puanManager puanManager;

    private void Awake(){
        kalanHak=3;
        ses=GetComponent<AudioSource>();
        sonucPanel.GetComponent<RectTransform>().localScale=Vector3.zero;
        hakManager=Object.FindObjectOfType<hakManager>();
        puanManager=Object.FindObjectOfType<puanManager>();
        hakManager.KalanHaklariKontrolEt(kalanHak);
    }


    void Start()
    {
        btnKontrol=false;
        soruPaneli.GetComponent<RectTransform>().localScale=Vector3.zero;
        kareOlustur();
        Invoke("soruPaneliAc",1.6f);
    }

    public void kareOlustur(){
        for(int i=0;i<25;i++){
            GameObject kare=Instantiate(karePrefab,karelerPanel);
            kare.transform.GetChild(1).GetComponent<Image>().sprite=kareSprites[0];
            kare.transform.GetComponent<Button>().onClick.AddListener(()=>BtnClick());
            karelerdizi[i]=kare;
        }
        bolumDegerleriYazdir();
        StartCoroutine(DoFadeRoutine());
    }

    private void BtnClick(){
        if(btnKontrol){
            ses.PlayOneShot(ses2);
            btnDeger=int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
            tutulanKare=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            sonucKontrol();
        }
        
    }

    private void sonucKontrol(){
        if(btnDeger==dogruCevap){
            tutulanKare.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text="";
            tutulanKare.transform.GetChild(1).GetComponent<Image>().enabled=true;
            Instantiate(efect,tutulanKare.transform.position,Quaternion.identity); //efekt var ama yok
            puanManager.PuaniArtir(zorlukDerece);
            bolumDegerleriListesi.RemoveAt(soruSayac);
            if(bolumDegerleriListesi.Count>0){
                soruPaneliAc();
            }else{
                gameFinish();
            }
            
        }else{
            kalanHak--;
            hakManager.KalanHaklariKontrolEt(kalanHak);
        }

        if(kalanHak<=0){
            gameFinish();
        }
    }

    public void gameFinish(){
        btnKontrol=false;
        sonucPanel.GetComponent<RectTransform>().DOScale(1,0.3f).SetEase(Ease.OutBack);
    }
  
    IEnumerator DoFadeRoutine(){
        foreach(var kare in karelerdizi){
            kare.GetComponent<CanvasGroup>().DOFade(1,0.05f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void bolumDegerleriYazdir(){
        foreach(var kare in karelerdizi){
            int rnd=Random.Range(1,13);
            bolumDegerleriListesi.Add(rnd);
            kare.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=rnd.ToString();
        }
    }

    private void soruPaneliAc(){
        soruSor();
        btnKontrol=true;
        soruPaneli.GetComponent<RectTransform>().DOScale(1,0.3f).SetEase(Ease.OutBack);
    }

    private void soruSor(){
        bolenSayi=Random.Range(2,11);
        soruSayac=Random.Range(0,bolumDegerleriListesi.Count);
        dogruCevap=bolumDegerleriListesi[soruSayac];
        bolunenSayi=bolenSayi*dogruCevap;
        if(bolunenSayi<=35){
            zorlukDerece="kolay";
        }else if(bolunenSayi>35 && bolenSayi<=70){
            zorlukDerece="orta";
        }else{
            zorlukDerece="zor";
        }
        soruText.text=bolunenSayi.ToString()+" : "+bolenSayi.ToString();
    }
}
