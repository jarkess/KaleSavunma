using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuYoneticisi : MonoBehaviour
{
    //Oyunu başlatma ve oyunu kapatma fonksiyonları
    public void Baslat(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Cikis(){
        Application.Quit();
    }
    //
}
