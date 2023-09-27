using UnityEngine;

namespace MyProject.Scripts.Weapons.AnimationsParticlesSounds
{
	public class SimpleShootingScript : MonoBehaviour 
	{

		[SerializeField] private int _shootSpeed = 15;
		[SerializeField] private ParticleSystem[] _velocityShootParticles;
		[SerializeField] private ParticleSystem[] _otherParticles;
		[SerializeField] private Light _shootLight;
		[SerializeField] private GameObject _shootFX;
		[SerializeField] private Transform _shootSound;

		private bool _shootOn;
		private float _lightOffTime;

		void Start()
		{
			foreach (ParticleSystem i in _velocityShootParticles)
			{
				i.GetComponent<ParticleSystem>().emissionRate = _shootSpeed;	
			}
		}

		void Update() 
		{
			if (Input.GetButton("Zoom"))
			{
				if (Input.GetButton("Fire1"))
				{
					//ShootFX.SetActive(true);
					ShootNow();

					foreach (ParticleSystem i in _velocityShootParticles)
					{
						i.GetComponent<ParticleSystem>().enableEmission = true;
					}

					foreach (ParticleSystem i in _otherParticles)
					{
						i.GetComponent<ParticleSystem>().enableEmission = true;
					}
				}
				else
				{
					//ShootFX.SetActive(false);

					foreach (ParticleSystem i in _velocityShootParticles)
					{
						i.GetComponent<ParticleSystem>().enableEmission = false;
					}

					foreach (ParticleSystem i in _otherParticles)
					{
						i.GetComponent<ParticleSystem>().enableEmission = false;
					}
				}
			}
		}

		public void ShootNow()
		{
			if (_lightOffTime < Time.time)
			{
				Instantiate(_shootSound, _shootFX.transform.position,_shootFX.transform.rotation);
				_shootLight.enabled = !_shootLight.enabled;
				_lightOffTime = Time.time + 1.0f/ (_shootSpeed * 2);
			}
		}
	}
}
