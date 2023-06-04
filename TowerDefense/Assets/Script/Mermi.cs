
using UnityEngine;

public class Mermi : MonoBehaviour
{
    
    private Transform hedef;

    public float hiz = 70f;
    public float patlamaYaricapi = 0f;
    public GameObject patlamaEfekti;

    public int hasar;


    public void Seek (Transform _hedef){

        hedef = _hedef;

    }

    // Update is called once per frame

    //9 Eğer sahnede düşman yoksa mermi yok oluyor. Eğer varsa düşmana doğru gidiyor.
    void Update()
    {
        
        if (hedef == null)
        {

            Destroy(gameObject);
            return;
        }

        Vector3 dir = hedef.position - transform.position;
        float distanceThisFrame = hiz * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){

          hedefVur();
          return;  
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
        


    }

    // Eğer düşmana değerse, düşmanın içindeki fonksiyonu çalıştırıp hasar almasını sağlıyor.
   void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Enemy")){
            col.gameObject.GetComponent<HasarAl>().HasarAlFonksiyonu(hasar);
            Destroy(gameObject);
        }
    }
        // Eğer düşmana değerse yok oluyor ve patlama efekti oluşuyor.
        void hedefVur()
        {
        
        GameObject effectIns = (GameObject)Instantiate(patlamaEfekti, transform.position, transform.rotation);


        if(patlamaYaricapi > 0f ) {

            Patlama();

        }

        else
        {

            Damage(hedef);
        }
        

        Destroy(effectIns, 2f);
        Destroy(gameObject);
       
        }

        void Patlama(){

            Collider[] colliders = Physics.OverlapSphere(transform.position, patlamaYaricapi);
            foreach(Collider collider in colliders) {

                if(collider.tag == "Enemy"){

                    Damage(collider.transform);
                }
            }
        }
        void Damage(Transform enemy){

            Destroy(gameObject);
            Destroy(hedef.gameObject);
        }

        void OnDrawGizmosSelected () {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, patlamaYaricapi);

        }
}
