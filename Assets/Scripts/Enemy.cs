using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public abstract class Enemy : Unit 
{
    public Color color;

    public float speed = 1.0f;
    public float attackRange = 1.0f;
    public int attackDamage = 1;
    public float attackCooldown = 1.0f;
    public bool canAttack = true;
    public bool isMoving = false;
    public Vector2 destination;

    public AudioSource enemyAudioSource;
    public AudioClip spawnAudio;
    public AudioClip attackAudio;

    protected Transform target;
    protected Player player;

    private GameManager gm;

    protected override void Start() 
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = target.GetComponent<Player>();
        SetColor();
        gm = GameObject.FindObjectOfType<GameManager>();
        enemyAudioSource = gameObject.AddComponent<AudioSource>();
        enemyAudioSource.volume = 0.1f;
        LoadEnemyAudio(spawnAudio, true);
    }

    protected virtual void Update()
    {
        if (gm.isAlive)
        {
            destination = player.transform.position;
        }
        else
        {
            // if the player is dead, make zombie move to random position
            if (!isMoving)
            {
                destination = GetNewDestination();
            }
        }

        var distance = Vector2.Distance(gameObject.transform.position, destination);

        // Move to player until it reach an attack range
        if (Vector2.Distance(gameObject.transform.position, destination) > attackRange)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(transform.position, destination, step);
            isMoving = true;
            
            if (enemyAudioSource.clip != spawnAudio)
            {
                LoadEnemyAudio(spawnAudio, true);
            }
        }
        else
        {
            isMoving = false;
            PlayerInRange();
        }
    }

    // TODO: change function name since it now has a different purpose
    protected virtual void PlayerInRange()
    {
        if (canAttack)
        {
            LoadEnemyAudio(attackAudio);
            player.TakeDamage(attackDamage);
            StartCoroutine(AttackCooldown());
        }
    } 

    protected virtual IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void SetColor()
    {
        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(color.r, color.g, color.b, 1);
    }

    Vector2 GetNewDestination()
    {
        float moveRange = 10.0f;
        Vector2 enemyPos = gameObject.transform.position;

        float newX = enemyPos.x + Random.Range(-moveRange, moveRange);
        float newY = enemyPos.y + Random.Range(-moveRange, moveRange);

        return new Vector2(newX, newY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isMoving = false;
        }
    }

    private void LoadEnemyAudio(AudioClip clip, bool loop = false)
    {
        if (clip != enemyAudioSource.clip)
        {
            enemyAudioSource.clip = clip;
        }

        if (enemyAudioSource.isPlaying)
        {
            enemyAudioSource.Stop();
        }

        enemyAudioSource.loop = loop;
        enemyAudioSource.Play();
    }
}
