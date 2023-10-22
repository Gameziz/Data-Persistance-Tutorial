using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody rigid;
    private Animator animate;
    public ParticleSystem smokeFX;
    public ParticleSystem dirtFX;

    public float jumpForce = 100;
    public bool isGrounded = true;
    public bool gameOver = false;

    private AudioSource audioPlayer;
    public AudioClip jumpFX;
    public AudioClip crashFX;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded  && !gameOver) {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animate.SetTrigger("Jump_trig");
            audioPlayer.PlayOneShot(jumpFX, 0.5f);
            dirtFX.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
            dirtFX.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {

            audioPlayer.PlayOneShot(crashFX, 1.0f);
            dirtFX.Stop();
            animate.SetBool("Death_b",true);
            animate.SetInteger("DeathType_int", 1);
            gameOver = true;
            smokeFX.Play();

            Destroy(gameObject, 3);
        }


    }





}
