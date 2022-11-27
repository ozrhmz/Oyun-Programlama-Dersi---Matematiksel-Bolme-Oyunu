using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject startBtn,exitBtn,sesac,seskapa;
    public AudioSource mzk;
    
    void Start()
    {
        fadeOut();
    }

    public void fadeOut(){
        startBtn.GetComponent<CanvasGroup>().DOFade(1,0.5f);
        exitBtn.GetComponent<CanvasGroup>().DOFade(1,0.8f);
        sesac.GetComponent<CanvasGroup>().DOFade(1,0.5f);
        seskapa.GetComponent<CanvasGroup>().DOFade(1,0.5f);

    }

    public void exitGame(){
        Application.Quit();
    }

    public void startGameLevel(){
        SceneManager.LoadScene("gameLevel");
    }

    public void mzkbasla(){
        mzk.Play();
    }

    public void mzkdurdur(){
        mzk.Stop();
    }
}
