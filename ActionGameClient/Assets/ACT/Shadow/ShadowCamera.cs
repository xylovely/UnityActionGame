using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace MyLib
{
    public class ShadowCamera : MonoBehaviour
    {
        public GameObject player;

        public Vector3 CamPos;
        private Shader shader;
        

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            GetComponent<Camera>().enabled = false;
            shader = Shader.Find("Custom/shadowMap2");
        }

        private List<GameObject> objectList;
        private void Start()
        {
            objectList = new List<GameObject>();

            foreach (Transform t in player.transform)
            {
                if (t.GetComponent<Renderer>() != null && t.name != "playerLight(Clone)")
                {
                    objectList.Add(t.gameObject);
                    //t.gameObject.layer = (int)GameLayer.ShadowMap;
                }
            }
        }

        private void SetObjectLayer(int layer)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                objectList[i].layer = layer;
            }
        }

        void Update()
        {
            //transform.position = Camera.main.transform.position + CamPos;
            //if (nat == null)
            {
                //var player = ObjectManager.objectManager.GetMyPlayer();
                SetObjectLayer(20);

                GetComponent<Camera>().RenderWithShader(shader, null);

                SetObjectLayer(0);
                /*
                if (player != null)
                {
                    nat = player.GetComponent<NpcAttribute>();
                }
                */
            }
            /*
            if (nat != null)
            {
                nat.SetShadowLayer();
                camera.RenderWithShader(shader, null);
                nat.SetNormalLayer();
            }
            */

        }
    }
}