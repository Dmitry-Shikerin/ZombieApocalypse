﻿using UnityEngine;

namespace DownloadAssets.Player.Invector_3rdPersonController_LITE._3D_Models.Others.HealthItem
{
    public class vAnimateUV : MonoBehaviour
    {
        public Vector2 speed;
        public Renderer _renderer;
        public string[] textureParameters = new string[] { "_MainTex" };
        private Vector2 offSet;

        void Update()
        {
            offSet.x += speed.x * Time.deltaTime;
            offSet.y += speed.y * Time.deltaTime;
            for (int i = 0; i < textureParameters.Length; i++)
                _renderer.material.SetTextureOffset(textureParameters[i], offSet);
        }
    }
}
