using UnityEngine;

namespace MyProject.Scripts.Weapons.AnimationsParticlesSounds
{
	public class SelfDestroy : MonoBehaviour 
	{
		[SerializeField] private float _time = 1.0f;
		void Start () 
		{
			Destroy(this.gameObject, _time);
		}
	}
}
