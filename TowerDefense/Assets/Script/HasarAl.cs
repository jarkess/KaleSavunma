using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarAl : MonoBehaviour
{
    public int can;

    public int money;


    //8 Düşmana mermi değdiğinde canı azalıyor, eğer canı sıfırın altına inerse paramız artıyor ve düşman yok oluyor.
    public void HasarAlFonksiyonu(int hasar){
        can -= hasar;
        if(can <= 0){
            PlayerStats.Money += 10;
            Destroy(gameObject);
        }
    }
}
