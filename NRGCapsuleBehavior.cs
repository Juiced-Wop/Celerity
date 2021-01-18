using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRGCapsuleBehavior : MonoBehaviour
{

	readonly float spinFactor = 200;
	readonly float NRGSpinFactor = 600;
	readonly float xSpin = -0.25f;
	readonly float ySpin = 1.35f;
	readonly float zSpin = 0;
	readonly float speedOfPlayerMultiplier = 1.3f;
	readonly float distanceToPlayerToDie = 1;
	readonly float brokenCapExplosiveForce = 5;
	readonly float brokenCapFlyAwayForce = 8;
	GameObject player;
	NRGSoundEmitterBehavior mySounds;
	public GameObject myCapsule;
	public GameObject myNRG;
	public GameObject brokenCapsulePrefab;
	public ParticleSystem myParticleSystem;
	public GameObject myPointLight;
	float timeToDieAfterCollected = 2.5f;
	bool collected = false;
	float chaseThePlayerSpeed;
	float chaseThePlayerMinSpeed = 15;
	bool hasBeenCollected = false;

    private void Awake()
    {
        References.startingEnergyCapsuleCount++;
    }

    // Start is called before the first frame update
    void Start()
    {
        //get player
		player = References.thePlayer;

		//get my sound system
		mySounds = transform.Find("NRGSoundEmitter").GetComponent<NRGSoundEmitterBehavior>();

		//get my particle system
		myParticleSystem = myParticleSystem.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
		if (collected)
		{
			//countdown to die
			timeToDieAfterCollected -= Time.deltaTime;

			//set the speed to chase the player
			chaseThePlayerSpeed = player.GetComponent<Rigidbody>().velocity.magnitude * speedOfPlayerMultiplier < chaseThePlayerMinSpeed ?
				chaseThePlayerMinSpeed : 
				player.GetComponent<Rigidbody>().velocity.magnitude * speedOfPlayerMultiplier;

			//chase player
			Vector3 movementToPlayer = (player.transform.position - transform.position).normalized * chaseThePlayerSpeed;
			gameObject.transform.position += movementToPlayer * Time.deltaTime;

			//disappear completely if we made it to the player
			if ((player.transform.position - transform.position).magnitude < distanceToPlayerToDie)
			{
				if (myNRG != null)
				{
					mySounds.collectSound.Play();
					myParticleSystem.Stop();
					if (myPointLight != null)
						Destroy(myPointLight);
					References.theLevelLogic.NRGCollect();
					hasBeenCollected = true;
				}
				
				Destroy(myNRG);
			}

			//die if alive too long
			if (timeToDieAfterCollected <= 0)
			{
				if (!hasBeenCollected)
				{
					References.theLevelLogic.NRGCollect();
					hasBeenCollected = true;
				}
				Destroy(gameObject);
			}
		}
		else
		{
			if (myCapsule != null)
				myCapsule.transform.Rotate(xSpin * Time.deltaTime * spinFactor, ySpin * Time.deltaTime * spinFactor, zSpin * Time.deltaTime * spinFactor, Space.World);
		}
			if (myNRG != null)
				myNRG.transform.Rotate(Vector3.up * -NRGSpinFactor * Time.deltaTime, Space.World);

    }

    public void Collect()
    {
		gameObject.GetComponent<RemoveMeFromListBehavior>().RemoveMeFromAllYeetLists();
		References.currentEnergyCapsuleCount--;
		gameObject.GetComponent<Collider>().enabled = false;
		mySounds.breakSound.Play();
		if (brokenCapsulePrefab != null)
		{
			GameObject myBrokenCapsule = Instantiate(brokenCapsulePrefab, transform.position, myCapsule.transform.rotation);
			Destroy(myCapsule);
			List<GameObject> brokenCapPieces = myBrokenCapsule.GetComponent<BrokenCapBehavior>().myPieces;
			for (int k = 0; k < brokenCapPieces.Count; k++)
			{
				brokenCapPieces[k].GetComponent<Rigidbody>().AddExplosionForce(brokenCapExplosiveForce, transform.position, distanceToPlayerToDie, 0, ForceMode.Impulse);
				brokenCapPieces[k].GetComponent<Rigidbody>().AddForce((transform.position - player.transform.position).normalized * brokenCapFlyAwayForce, ForceMode.VelocityChange);
			}
		}
		else
			Debug.Log("NO BROKEN CAPSULE PREFAB");
		collected = true;
    }

}
