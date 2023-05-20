using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	// Reference to projectile prefab to shoot
	public GameObject projectile;
	public float power = 10.0f;
	public float power2 = 10.0f;
	public float power3 = 10.0f;


	// Reference to AudioClip to play
	public AudioClip shootSFX1;
	public AudioClip shootSFX2;
	public AudioClip shootSFX3;
	public GameObject gm;
	
	// Update is called once per frame
	void Update () {
		// Detect if fire button is pressed
		if (Input.GetButtonDown("Fire1") && gm.gameObject.GetComponent<GameManager>().ammoCurrent > 0)
		{	
			// if projectile is specified
			if (projectile)
			{
				// Instantiante projectile at the camera + 1 meter forward with camera rotation
				GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

				// if the projectile does not have a rigidbody component, add one
				if (!newProjectile.GetComponent<Rigidbody>()) 
				{
					newProjectile.AddComponent<Rigidbody>();
				}
				// Apply force to the newProjectile's Rigidbody component if it has one
				newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

				// play sound effect if set
				if (shootSFX1 && gm.gameObject.GetComponent<GameManager>().currentWeapon == "Rifle")
				{
					if (newProjectile.GetComponent<AudioSource> ()) { // the projectile has an AudioSource component
						// play the sound clip through the AudioSource component on the gameobject.
						// note: The audio will travel with the gameobject.
						newProjectile.GetComponent<AudioSource> ().PlayOneShot (shootSFX1);
					} else {
						// dynamically create a new gameObject with an AudioSource
						// this automatically destroys itself once the audio is done
						AudioSource.PlayClipAtPoint (shootSFX1, newProjectile.transform.position);
					}
				}
				if (shootSFX2 && gm.gameObject.GetComponent<GameManager>().currentWeapon == "Pistol")
				{
					if (newProjectile.GetComponent<AudioSource>())
					{ // the projectile has an AudioSource component
					  // play the sound clip through the AudioSource component on the gameobject.
					  // note: The audio will travel with the gameobject.
						newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX2);
					}
					else
					{
						// dynamically create a new gameObject with an AudioSource
						// this automatically destroys itself once the audio is done
						AudioSource.PlayClipAtPoint(shootSFX2, newProjectile.transform.position);
					}
				}
				if (shootSFX2 && gm.gameObject.GetComponent<GameManager>().currentWeapon == "MachineGun")
				{
					if (newProjectile.GetComponent<AudioSource>())
					{ // the projectile has an AudioSource component
					  // play the sound clip through the AudioSource component on the gameobject.
					  // note: The audio will travel with the gameobject.
						newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX3);
					}
					else
					{
						// dynamically create a new gameObject with an AudioSource
						// this automatically destroys itself once the audio is done
						AudioSource.PlayClipAtPoint(shootSFX3, newProjectile.transform.position);
					}
				}
				gm.gameObject.GetComponent<GameManager>().ammoCurrent--;
			}
		}
	}
}
