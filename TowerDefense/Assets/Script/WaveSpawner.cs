using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform dogmaNoktasi;
    public float zamanAraligi = 5f; //gruplar arasi zaman 
    private float gerisayim = 2f; // ilk geri sayim
    private int grupIndex = 0;

    public Text grupGerisayim_text;

    public Vector3 offset;

    void Update()
    {

        if (gerisayim <= 0f){

                StartCoroutine(SpawnWave()); // IEnemerator kullandıgımız ıcın spawnwave cagırırken startcoroutine
        
                gerisayim = zamanAraligi;



        }


        //10
        gerisayim -= Time.deltaTime;

        gerisayim = Mathf.Clamp(gerisayim, 0f, Mathf.Infinity);//yuvarlama

        //grupGerisayim_text.text = string.Format("{0:0.00}"); //float sayiyi string yapıyoruz

    }       
        IEnumerator SpawnWave() // Ienumerator wait for seconds icin eklendi
        {

                grupIndex++;            //her yeni dalgada 1 fazla düşman

            for ( int i = 0; i < grupIndex; i ++)  {
                
                SpawnEnemy() ;          

                yield return new WaitForSeconds(0.5f); // yeni dusmanlar ust uste cıkmasın diye
     
        }

            
        
        }

       void SpawnEnemy () {

                Instantiate(enemyPrefab, dogmaNoktasi.position + offset, dogmaNoktasi.rotation);
              
              }



}
