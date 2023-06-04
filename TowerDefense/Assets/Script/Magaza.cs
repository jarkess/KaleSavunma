using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magaza : MonoBehaviour
{

        public TurretPlan StandartTurret;
        public TurretPlan ikinciTurret;


        YapiYoneticisi yapiYoneticisi;

        
         
         void Start() {

            yapiYoneticisi = YapiYoneticisi.instance;
            
        }

        public void SelectStandartTurret()
        {
            if (PlayerStats.Money < yapiYoneticisi.turretToBuild.cost || yapiYoneticisi.turretYerlesti == false){

            //Debug.Log("Not enough money to build that!");
			return;
            }

            else{
            //Debug.Log("Birinci Turret Satin Alindi");
            yapiYoneticisi.SelectTurretBuild(StandartTurret);
            PlayerStats.Money -= yapiYoneticisi.turretToBuild.cost;
            yapiYoneticisi.turretYerlesti = false;
            }

        
        }
    
     public void SelectFuzeTurret()
        {
            if (PlayerStats.Money < yapiYoneticisi.turretToBuild.cost || yapiYoneticisi.turretYerlesti == false){

            //Debug.Log("Not enough money to build that!");
			return;
            }

            else{
            //Debug.Log("İkinci Turret Satin Alindi");
            yapiYoneticisi.SelectTurretBuild(ikinciTurret);
            PlayerStats.Money -= yapiYoneticisi.turretToBuild.cost;
            yapiYoneticisi.turretYerlesti = false;
            }
        }
    
}
