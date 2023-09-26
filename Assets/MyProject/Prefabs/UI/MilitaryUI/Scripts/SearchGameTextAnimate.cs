using UnityEngine;
using UnityEngine.UI;

namespace MilitaryUI.Scripts
{
    public class SearchGameTextAnimate : MonoBehaviour
    {
        private Text _text;
        public int DotCount;
        private string _initialString;

        private void Start()
        {
            _text = GetComponent<Text>();
            _initialString = _text.text;
        }

        private void Update()
        {
            string result = "";
            for (int i = 0; i < DotCount; i++)
            {
                result += ".";
            }

            _text.text = _initialString + result;
        }
    }
}
