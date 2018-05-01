using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float speed = 5;
    //public GameObject bullet;
    Spaceship spaceship;

    // Use this for initialization
    IEnumerator Start()
    {

        spaceship = GetComponent<Spaceship>();

        while (true)
        {
            spaceship.Shot(transform);
            //Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(spaceship.shotDelay);
        }

    }


    // Update is called once per frame
    void Update()
    {
        //Left, Right
        float x = Input.GetAxisRaw("Horizontal");

        //Top, Bottom
        float y = Input.GetAxisRaw("Vertical");

        //ベクトルの計算
        Vector2 direction = new Vector2(x, y).normalized;

        //Move
        //GetComponent<Rigidbody2D>().velocity = direction * speed;
        spaceship.Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if(layerName == "Bullet (Enemy)")
        {
            //Bulletの削除
            Destroy(collision.gameObject);
        }

        if (layerName == "Bullet (Enemy)" || layerName == "Enemy")
        {
            spaceship.Explosion();
            //Playerの削除
            Destroy(gameObject);
        }



    }
}
