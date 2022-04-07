using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float forwardMovementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float accelerationSpeed = 2f;
    [SerializeField] private bool beginRampingMovement = true;

    [Header("Jumping")]
    [SerializeField] private float jumpHeight = 0.1f;
    [SerializeField] private float gravityValue = -60f;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool invinciblePlayer = false;

    [Header("Particles")]
    [SerializeField] private ParticleSystem drivingSmokeParticle;

    private ParticleSystem smokeParticleInstance;
    private Vector3 movementVector;
    private Vector2 movementClampPositions = new Vector2(-7f, 7f);
    private float currentSpeed = 0;
    private float maxSpeed = 30f;

    private CharacterController controller;
    private PlayerRagdollCollision playerRagdollCollision;
    private UIManager uIManager;
    private GameManager gameManager;
    private SoundManager soundManager;
    private ScreenShakeTrigger screenShake;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
        soundManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
        screenShake = GetComponentInChildren<ScreenShakeTrigger>();
        controller = GetComponent<CharacterController>();
        playerRagdollCollision = transform.GetChild(0).GetComponent<PlayerRagdollCollision>();
        maxSpeed = movementSpeed;
        currentSpeed = movementSpeed / 3;
        smokeParticleInstance = Instantiate(drivingSmokeParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), Quaternion.identity);
        smokeParticleInstance.transform.parent = transform;
    }

    void Update()
    {
        GroundCheck();
        Jumping();

        playerVelocity.y += gravityValue * Time.deltaTime;
        // controller.Move(playerVelocity * Time.deltaTime);
        movementVector = new Vector3(Input.GetAxis("Horizontal") * 2, playerVelocity.y, forwardMovementSpeed);
    }

    private void GroundCheck()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    private void Jumping()
    {
        // Changes the height position of the player
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpHeight * -3f * gravityValue;
        }
    }

    void FixedUpdate()
    {
        // movement
        controller.transform.position = ClampedMovement();

        // rotation
        transform.GetChild(0).rotation = FaceTowardsMovementDirection(movementVector);
    }

    private Vector3 ClampedMovement()
    {
        if (beginRampingMovement)
        {
            RampingMovement();
        }
        else
        {
            controller.Move(movementVector * movementSpeed * Time.deltaTime);
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, movementClampPositions[0], movementClampPositions[1]);
        return clampedPosition;
    }

    private void RampingMovement()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed = currentSpeed + accelerationSpeed * Time.deltaTime;
        }
        else
        {
            beginRampingMovement = false;
            currentSpeed = movementSpeed / 3;
        }
        controller.Move(movementVector * currentSpeed * Time.deltaTime);
    }

    private Quaternion FaceTowardsMovementDirection(Vector3 direction)
    {
        if (movementVector != Vector3.zero)
        {
            return Quaternion.Slerp(
                transform.GetChild(0).rotation,
                Quaternion.LookRotation(movementVector),
                Time.deltaTime * rotationSpeed
            );
        }
        return Quaternion.identity;
    }

    private void ModifyPlayerState(bool incomingState)
    {
        // transform.GetChild(0).gameObject.SetActive(incomingState);
        controller.enabled = incomingState;
        GetComponent<PlayerController>().enabled = incomingState;
        playerRagdollCollision.StartRagdoll = true;
        if(gameManager.GetPlayerLives() > 0)
            StartCoroutine(DestroyCorpse());
        else
        {
            //Die
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.transform.tag == "Obstacle" && invinciblePlayer == false)
        {
            screenShake.CrashShake();
            soundManager.CrashSound();
            gameManager.TakeDamage();
            uIManager.UpdateLifes();
            ModifyPlayerState(false);
        }
        
    }

    public void SpawnSafety()
    {
        invinciblePlayer = true;
        StartCoroutine(BecomeVulnerable());
    }

    IEnumerator DestroyCorpse()
    {
        yield return new WaitForSeconds(1);
        gameManager.SpawnPlayer();
        Destroy(gameObject);
    }

    IEnumerator BecomeVulnerable()
    {
        yield return new WaitForSeconds(1.5f);
        invinciblePlayer = false;
    }

    private void ToggleSmokeEffect(bool value)
    {
        if (value)
        {
            smokeParticleInstance.Play();
        }
        else
        {
            smokeParticleInstance.Stop();
        }
    }
}