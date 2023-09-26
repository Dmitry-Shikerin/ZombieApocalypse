using UnityEngine;
using UnityEngine.UI;

namespace MilitaryUI.Scripts
{
    public class PlayButtonFlow : MonoBehaviour
    {
        public GameObject SearchingLabel;
        public Image FireParticles;
        public Vector2 SlowSpeed = new Vector2(3, 3);
        public Vector2 FastSpeed = new Vector2(6, 6);

        public void Play()
        {
            SearchingLabel.SetActive(true);
            FireParticles.material.SetVector("_Speed", FastSpeed);
        }

        public void StopSearch()
        {
            SearchingLabel.SetActive(false);
            FireParticles.material.SetVector("_Speed", SlowSpeed);
        }

        private void OnApplicationQuit()
        {
            FireParticles.material.SetVector("_Speed", SlowSpeed);
        }
    }
}
