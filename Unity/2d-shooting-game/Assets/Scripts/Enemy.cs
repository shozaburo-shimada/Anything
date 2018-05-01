using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
        spaceship = GetComponent<Spaceship>();

        spaceship.Move(transform.up * -1);

        if (spaceship.canShot == false) {
            yield break;
        }

        while (true)
        {
            for (int i = 0; i < transform.childCount; i++){
                Transform shotPosition = transform.GetChild(i);
                spaceship.Shot(shotPosition);
            }

            yield return new WaitForSeconds(spaceship.shotDelay);
        }
		
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName != "Bullet (Player)") return;

        //Bullet(Player)の削除
        Destroy(collision.gameObject);

        spaceship.Explosion();

        //Enemyの削除
        Destroy(gameObject);

        
    }
}
