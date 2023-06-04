using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("Opsiyonel")]
    public GameObject turret; //oyun başında turret yerleştirilmiş olabilir diye public
    private Renderer rend;
    
    private Color startColor;

    YapiYoneticisi yapiYoneticisi;

    //2 Silahları yerleştirmek için tıkladığımızda, tıkladığımız yerdeki node'ları alıp, silahları yerleştiriyoruz.
    void Start ()
    {

       rend = GetComponent<Renderer>();
       startColor = rend.material.color;
       yapiYoneticisi = YapiYoneticisi.instance;
    }

    public Vector3 GetBuildPosition () {

        return transform.position + positionOffset;
    }
    // Mouse tıklandığında
    void OnMouseDown() {

        if(!yapiYoneticisi.CanBuild || yapiYoneticisi.turretYerlesti == true)
            return;


        if(turret != null)
        {
                Debug.Log("Buraya yapı inşa edemezsin!  ");
                return;
        }
         yapiYoneticisi.BuildTurretOn(this);
         yapiYoneticisi.turretYerlesti = true;
    }

    // Mouse üzerindeyken
    void OnMouseEnter() 
   {

        if(!yapiYoneticisi.CanBuild)
        return;
         rend.material.color =  hoverColor;
   }
    
    // Mouse bırakıldığında
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    
}