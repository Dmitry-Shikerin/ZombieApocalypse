using UnityEngine;

namespace MyProject.Prefabs.UI.MilitaryUI.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class MilitaryToggleSlider : MonoBehaviour
    {
        public void SetValue(bool value) {
            var animator = GetComponent<Animator>();
            animator.StopPlayback();
            animator.Play(value ? "Enable" : "Disable");
        }
    }
}
