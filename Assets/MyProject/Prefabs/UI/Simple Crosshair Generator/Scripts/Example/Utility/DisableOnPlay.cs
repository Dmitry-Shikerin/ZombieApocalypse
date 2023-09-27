using UnityEngine;

namespace MyProject.Prefabs.UI.Simple_Crosshair_Generator.Scripts.Example.Utility
{
    public class DisableOnPlay : MonoBehaviour
    {
        void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
