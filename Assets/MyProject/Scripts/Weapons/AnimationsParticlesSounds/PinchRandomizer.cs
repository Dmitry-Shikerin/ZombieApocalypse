using UnityEngine;

namespace MyProject.Scripts.Weapons.AnimationsParticlesSounds
{
	[RequireComponent(typeof(AudioSource))]
	public class PinchRandomizer : MonoBehaviour 
	{
		[SerializeField] private float _pinchRandom;
	
		private AudioSource _source;
		void Start () 
		{
			_source = GetComponent<AudioSource>();
			_source.pitch += Random.Range(-_pinchRandom,_pinchRandom);
		}
	}
}
