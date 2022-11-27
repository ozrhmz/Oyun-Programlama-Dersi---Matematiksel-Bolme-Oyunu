using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sonucManager : MonoBehaviour
{
    public void YenidenBasla()
    {
        SceneManager.LoadScene("gameLevel");
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("menuLevel");
    }
}
