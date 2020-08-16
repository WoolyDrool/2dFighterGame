using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLdPlayerController : MonoBehaviour
{
	[Header("Variables")]
	public float movementSpeed = 10;
	public float jumpPower = 10;
	public float slamPower = 6;
	public bool isGrounded = true;
	public LayerMask groundLayers;
	public GameObject bloodParticle;
	public AudioClip[] jumpSounds;
	public AudioClip slamSound;
	public float remainingJumps = 1;
	AudioSource src;

	[Header("Component Calls")]
	public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.gravityScale = 1.9f;
		src = gameObject.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update()
	{
		/*Vector2 direction;
		direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
		direction.Normalize();
		transform.Translate(direction*Time.deltaTime*movementSpeed);*/

		float inputX = Input.GetAxisRaw("Horizontal") * movementSpeed;

		transform.Translate(new Vector2(inputX * Time.deltaTime, 0));

		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
			rb2d.velocity = new Vector2(0, jumpPower);
			isGrounded = false;
			PlaySound();
			remainingJumps = 0;
		}
	
	

		if(Input.GetButtonDown("Slam") && isGrounded == false)
		{
			rb2d.velocity = new Vector2(0, -jumpPower);
			src.PlayOneShot(slamSound);
		}

		//Jumping
		isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
				new Vector2(transform.position.x + 0.5f, transform.position.y + 0.51f), groundLayers);
		
    }

	void PlaySound()
	{
		if (isGrounded == false)
		{
			src.clip = jumpSounds[Random.Range(0, jumpSounds.Length)];
			src.PlayOneShot(src.clip);
		}
		
	}
}
