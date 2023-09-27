using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyProject.Scripts.UI.Player
{
    public class CurrentWeapon : MonoBehaviour
    {
        [SerializeField] private Players.Player _player;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;


        private void Update()
        {
            ChangeText();
            ChangeImage();
        }

        private void ChangeText()
        {
            _text.text = _player.CurrentWeapon.Label;
        }

        private void ChangeImage()
        {
            _image.sprite = _player.CurrentWeapon.Icon;
        }
    }
}
