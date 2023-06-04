using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public int cost;

        private Transform target;

        [Header("ozellik")]         //inspector tarafında ayarlama yapabilmek için

        public float atesGucu = 1f;
        private float atesGerisayim = 0f;
        public float menzil = 15f;

        [Header("ivir zivir")]
        
        public string enemyTag = "Enemy"; 
        public Transform Head;  
        public float donmeHizi = 10f;


        public GameObject mermiPrefab;
        public Transform atesNoktasi;

    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("UpdateTarget", 0f, 0.5f); 
    }

    //6 Burada sahnedeki düşmanların pozisyonlarını belirleyip, en yakın olanı seçiyor.
    void UpdateTarget(){ //update icinde yapılabilir ancak her saniye kontrol etmeye gerek yok

     GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //düsmanları bir diziye alıyoruz
     
     float shortestDistance = Mathf.Infinity; //en kısa mesafemiz
     GameObject nearestEnemy = null; 
      
      
       foreach(GameObject enemy in enemies){

        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // dusmana olan mesafe
        if(distanceToEnemy < shortestDistance){ // dusmana mesafemiz azsa 

            shortestDistance = distanceToEnemy;
            nearestEnemy = enemy; // yeni en yakin mesafe
        }

       }

       if(nearestEnemy != null && shortestDistance <= menzil){

         target = nearestEnemy.transform;
       }
       else{

            target = null;
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) // dusman yoksa bisi yapma
            return;



           
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0f , 90f , 0f); //cevirme
        Vector3 rotation = Quaternion.Lerp(Head.rotation, lookRotation, Time.deltaTime * donmeHizi).eulerAngles; // yumusak bir sekilde hareket etmesi
        Head.rotation = Quaternion.Euler(0f,rotation.y, 0f); // bas kismi sadece y ekseninde dönme

        if (atesGerisayim <= 0f)
        {
            Shoot();
            atesGerisayim = 1f/atesGucu;

        }

        atesGerisayim -= Time.deltaTime;

    }

        void Shoot(){

            GameObject mermiGO = (GameObject)Instantiate(mermiPrefab, atesNoktasi.position, atesNoktasi.rotation);
            Mermi mermi = mermiGO.GetComponent<Mermi>();

            if(mermi != null)
            mermi.Seek(target);

        }


    void OnDrawGizmosSelected() { // taretin menzilini görsel olarak gösterebilmek icin 
        
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, menzil);

    }

}
