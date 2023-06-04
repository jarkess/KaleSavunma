using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YapiYoneticisi : MonoBehaviour
{

    public static YapiYoneticisi instance;

    public bool turretYerlesti = false;

    void Awake() {
      
      if(instance != null)
      {
        Debug.LogError("sahnede birden fazla yapı yöneticisi var");
        return;
      }  
       

        instance = this;
    }

    //public TurretPlan[] Turrets;

    public GameObject standartTurretPrefab;
    public GameObject fuzeTurretPrefab;
    
    [HideInInspector]
    public TurretPlan turretToBuild;

    public bool CanBuild { get { return turretToBuild != null;} }

    //Seçtiğimiz silahın hangisi olduğunu belirliyor
    public void SelectTurretBuild(TurretPlan turret)
    {
        turretToBuild = turret;

    }

    //Seçtiğimiz silahı, tıklanan node'a yerleştiriyor.
    public void BuildTurretOn (Node node) {

   
      Vector3 gecici = node.GetBuildPosition();
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, gecici, Quaternion.identity);
        node.turret = turret;
        turretYerlesti = true;

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

/*
    public void SelectTurretBuild(TurretPlan turret)
    {
        turretToBuild = turret;

    }*/

      /*if (PlayerStats.Money < turretToBuild.cost){

          Debug.Log("Not enough money to build that!");
			return;
     }*/
}
