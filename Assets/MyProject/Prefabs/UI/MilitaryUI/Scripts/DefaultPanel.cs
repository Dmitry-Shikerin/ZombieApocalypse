using UnityEngine;
using UnityEngine.UI;

namespace MilitaryUI.Scripts
{
    public class DefaultPanel : MonoBehaviour
    {
        public Button[] Buttons;

        private void OnDisable()
        {
            EnableButtons(false);
        }

        public void EnableButtons(bool enable)
        {
            foreach (var button in Buttons)
            {
                button.interactable = enable;
            }
        }

        private void OnEnable()
        {
            EnableButtons(true);
        }
    }
}
