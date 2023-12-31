using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]   
public class CharController : MonoBehaviour
{
    public Transform rayStart;
    public GameObject CrystalEffect;

    private Animator Anim;
    private Rigidbody rb;
    private bool walkingRight = true;
    public bool CanJump;
    public float moveSpeed = 0;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public float jumpForce = 5f;

    private AudioSource audioSource;
    public AudioClip PickUpSound;

    public GameManager gameManager;

    public List<Color> backgroundColor;

    public int RoadBlocksCovered;

    public Button JumpButton;
    public Button SwitchButton;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();  
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start() 
    {
        JumpButton.onClick.AddListener(Jump);
        SwitchButton.onClick.AddListener(Switch);
        //gameManager.StartGame();    
        CanJump=true;   
        RoadBlocksCovered = 0;
    }

    private void FixedUpdate()
    {
        if(!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            Anim.SetBool("gameStarted",true);
        }

        rb.transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        
        if(transform.position.z > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            moveSpeed = moveSpeed * speedMultiplier;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, 1))
        {
            Anim.SetBool("isFalling",true);
            CanJump=false;
        }
        else
        {
            Anim.SetBool("isFalling",false);
            CanJump=true;
        }

        if(transform.position.y < -3)
        {
            gameManager.EndGame();
        }
    }

    private void Switch()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }

        walkingRight = !walkingRight; 

        if(walkingRight)
        {
            transform.rotation = Quaternion.Euler(0f, 45f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, -45f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            gameManager.IncreaseScore();

            GameObject g = Instantiate(CrystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
            
            audioSource.PlayOneShot(PickUpSound);

        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag=="Road")
        {
            RoadBlocksCovered++;
            if(RoadBlocksCovered%50 == 1)
            {
                LevelUp();
            }
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log(RoadBlocksCovered);
        }
    }
    public void Jump()
    {
        // Add upward force to the Rigidbody to make it jump
        if(CanJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void LevelUp()
    {
        Camera.main.backgroundColor = backgroundColor[Random.Range(0, backgroundColor.Count + 1)];
    }
}
