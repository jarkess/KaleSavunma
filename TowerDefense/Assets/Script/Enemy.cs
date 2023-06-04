using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hiz = 10f;

    private Transform target;

    private int grup_pointIndex = 0;

     private void Start() {
        
        target = Waypoints.points[0];
    }



    //7 Düşmanlar her seferinde bir sonraki pozisyona doğru ilerliyor.
     private void Update() {
        
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * hiz * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f ){

            GetNextWaypoint();

        }

        // Düşmanların gideceği bir sonraki pozisyon belirleniyor
    void GetNextWaypoint() {

       if(grup_pointIndex >= Waypoints.points.Length ){

        Destroy(gameObject);
       }
       
         grup_pointIndex++;
        target = Waypoints.points[grup_pointIndex]; // ara noktaları geçmeye
      

    }

  
    }

}
