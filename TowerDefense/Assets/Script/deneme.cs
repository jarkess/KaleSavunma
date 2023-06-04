using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public float speed;
    public float height;
    public Vector3 newPos;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        height = Random.Range(-height , height);
        newPos = new Vector3(transform.position.x , height , transform.position.z);
        StartCoroutine("vectorChange");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position , newPos , speed * Time.deltaTime);
        /*if(transform.position.y == newPos.y){
            newPos.y *= -1f;
            //transform.position = Vector3.Lerp(transform.position , newPos , speed * Time.deltaTime);
        }*/
    }

    IEnumerator vectorChange(){
        while(true){
        newPos = new Vector3(newPos.x , newPos.y * -1f , newPos.z);
        timer = Random.Range(timer / 2f , timer * 2f);
        yield return new WaitForSeconds(timer);
        }
    }
}
