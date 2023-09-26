using UnityEngine;

namespace MilitaryUI.Scripts
{
    public class SectionPanels : MonoBehaviour
    {
        public GameObject[] Windows;
        private int _activeWindow = -1;
        private void Start()
        {
            EnableWindow(0);
        }

        private void OnEnable()
        {
            EnableWindow(0);
        }

        public void EnableWindow(int index)
        {
            if (_activeWindow > -1)
            {
                Windows[_activeWindow].SetActive(false);
            }

            if (index >= Windows.Length)
            {
                Debug.LogWarning("Window with index " + index + " doesn't exist. Windows count is " + Windows.Length);
                return;
            }
            _activeWindow = index;
            Windows[index].SetActive(true);
        }

    }
}
