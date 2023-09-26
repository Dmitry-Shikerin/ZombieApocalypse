using System;
using System.Collections;
using System.Collections.Generic;
using MyProject.OldScripts.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Player = MyProject.Scripts.Player.Player;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] private Player _player;
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
