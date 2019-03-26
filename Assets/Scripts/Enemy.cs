using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Spaceship spaceship;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        spaceship = GetComponent<Spaceship>();
        Move(transform.up * -1);

        if (!spaceship.canShot) {
            yield break;
        }

        while (true) {
            for (int i = 0; i < transform.childCount; i++) {
                Transform shotPosition = transform.GetChild(i);
                spaceship.Shot(shotPosition);
            }
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction*spaceship.speed;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        if (layerName != "Bullet (Player)") return;

        Destroy(c.gameObject);
        spaceship.Explosion();
        Destroy(gameObject);
    }
}
