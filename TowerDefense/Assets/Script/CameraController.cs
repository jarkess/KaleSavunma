
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool hareket;
    public float kaydirmaHizi = 30f;
    public float kenar = 10f;
    public float minY;
    public float maxY;
    public float scrollHiz = 5f;

    // Update is called once per frame
    // 1 WASD tuşları veya mouse'un pozisyonuna göre kameranın hareketi sağlanıyor.
    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)) //esc ile hakeket komutunu aç kapa 
            hareket = !hareket;
        if (!hareket)
            return; 
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - kenar) //kenara 10cm yakın mı degil mi
        {     
            transform.Translate(Vector3.forward * kaydirmaHizi * Time.deltaTime, Space.World); //time delta time bilgisayar farklarında sıkıntı cıkmasın diye
        }
         if(Input.GetKey("s") || Input.mousePosition.y <= kenar) 
        {
            transform.Translate(-Vector3.forward * kaydirmaHizi * Time.deltaTime, Space.World);
        }
         if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - kenar) 
        {         
            transform.Translate(Vector3.right * kaydirmaHizi * Time.deltaTime, Space.World);
        }
         if(Input.GetKey("a") || Input.mousePosition.x <= kenar){         
            transform.Translate(Vector3.left * kaydirmaHizi * Time.deltaTime, Space.World);
        }

    float scroll = Input.GetAxis("Mouse ScrollWheel"); // input managerden ismi aldık

    Vector3 pos = transform.position;
    
    pos.y -= scroll * 1000 * scrollHiz * Time.deltaTime;
    pos.y = Mathf.Clamp(pos.y, minY, maxY);

    transform.position = pos;
}

}