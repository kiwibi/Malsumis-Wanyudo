using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Bullet;
    public int strafeDirection;
    
    private EnemyStats stats;
    private AudioPlayer audioPlayer;
    private GameObject player;
    private SpriteRenderer enemySprite;
    private BulletSpawn bulletSpawn;
    

    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        stats = GetComponent<EnemyStats>();
        bulletSpawn = GetComponentInChildren<BulletSpawn>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemySprite = GetComponentInChildren<SpriteRenderer>();
        var randomDirection = Random.Range(1, 3);
        if(randomDirection == 1)
        {
            strafeDirection = 1;
        } else
        {
            strafeDirection = -1;
        }
    }

    void Update()
    {
        Move();
        Rotation();
    }

    public void Shoot()
    {
        var bullet = Instantiate(Bullet, new Vector3(bulletSpawn.transform.position.x, bulletSpawn.transform.position.y, 0), Quaternion.identity);
        bullet.GetComponentInChildren<SpriteRenderer>().transform.rotation = enemySprite.transform.rotation;
        bullet.GetComponent<BulletBehavior>().direction = GetComponentInChildren<SpriteRenderer>().transform.up;
        audioPlayer.AudioEvent = stats.shootGunSound;
        audioPlayer.PlaySound();
        
    }

    public void Move()
    {
        Vector3 direction = new Vector3(strafeDirection * stats.StrafeSpeed.Value, -1 * stats.Speed.Value, 0);
        gameObject.transform.Translate(direction * Time.deltaTime);
    }

    public void ChangeDirection()
    {
        strafeDirection *= -1;
    }

    private void Rotation()
    {
       
        Vector3 dir = player.transform.position - transform.position;
        Vector3 up = new Vector3(0, 0, -1);
        var rotation = Quaternion.LookRotation(dir, up);
        rotation.x = 0;
        rotation.y = 0;
        enemySprite.transform.rotation = rotation;
    }
}
