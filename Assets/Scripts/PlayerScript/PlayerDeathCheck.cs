using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDeathCheck : MonoBehaviour
{

    public ParticleSystem deadParticle;
    public SpriteRenderer playerSprite;
    public TrailRenderer playerTrail;
    private AudioManager audioManager;
   // private CameraShake cameraShake;
    ButtonsTransition buttonTransition;
    Vector2 startPos;
    private Rigidbody2D rbplayer;
    private PlayerInput playerInput;
    public bool isdead;
    public float respawnTime = 0.5f;
    private void Awake()
    {
        rbplayer = GetComponent<Rigidbody2D>();
        //game = FindObjectOfType<GameUI>();
        playerInput = GetComponent<PlayerInput>(); 
        buttonTransition = FindObjectOfType<ButtonsTransition>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
       // cameraShake = FindObjectOfType<CameraShake>();
    }
    private void Start()
    {   
        startPos = transform.position;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Die();
        }

    }
    void Die()
    {
       // cameraShake.ShakeCamera();
        if (isdead) return;
        Debug.Log("die");
        isdead = true;
        playerInput.Move = 0;
        rbplayer.simulated = false;
        buttonTransition.DisableButtons();
        playerSprite.enabled = false;
        StartCoroutine(Respawn(respawnTime));
        playerTrail.enabled = false;
        PlayDeadParticles();
    }

    IEnumerator Respawn(float duration)
    {
       // cameraShake.Stopshake();
        transform.localScale = new Vector3(0, 0, 0);
        rbplayer.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(duration);
        
        deadParticle.Clear();
        //playerInput.playerControls.Enable();
        transform.position = startPos;
        transform.localScale = new Vector3(1, 1, 1);
        buttonTransition.EnableButtons();
        playerSprite.enabled = true;
        rbplayer.simulated = true;
        playerTrail.enabled = true;
        isdead = false;
    }
    private void PlayDeadParticles()
    {
        audioManager.PlaySFX(audioManager.death);
        deadParticle.transform.position = transform.position;
        deadParticle.Play();
    }
    private void Update()
    {
        if(transform.position.y <-10f && !isdead)
        {
            Die();
        }
    }


}


