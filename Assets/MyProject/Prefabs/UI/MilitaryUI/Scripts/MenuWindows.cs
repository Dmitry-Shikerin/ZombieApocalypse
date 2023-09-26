using UnityEngine;

namespace MilitaryUI.Scripts
{
    public class MenuWindows : MonoBehaviour
    {
        public void EnableWindow(int index)
        {
            switch (index)
            {
                case 0:
                    GetComponent<Animator>().Play("Default");
                    break;
                case 1:
                    GetComponent<Animator>().Play("Preferences");
                    break;
                default:
                    Debug.LogWarning("Window with index " + index + " doesn't exist. Windows count is 2");
                    break;
            }
        }

    }
}
