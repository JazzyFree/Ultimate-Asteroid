using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactiviate_Timer = 3f;
    internal bool is_EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {

        if (is_EnemyBullet)
            speed *= -1f;
        Invoke("DeactivateGameObject", deactiviate_Timer);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
     void DeactiviateGameObject()
    {
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet" || target.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }


}
