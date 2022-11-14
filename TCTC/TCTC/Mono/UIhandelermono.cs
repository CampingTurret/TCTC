using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnboundLib.Utils;
using System.Collections.ObjectModel;
using ModdingUtils.RoundsEffects;

namespace TCTC.MonoBehaviors
{
    public class UIhandelermono : MonoBehaviour
    {
        private void Start()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();

            TextMeshProUGUI x = UIelement.GetComponentInChildren<TextMeshProUGUI>();
            x.text = "Hello World!";
            x.fontSize = 5;
            RectTransform q = UIelement.AddComponent<RectTransform>();
            q.anchorMax = new Vector2(0.8f, 0.9f);
            q.anchorMin = new Vector2(0.7f, 0.8f);
            
            UIelement.transform.localScale = new Vector3(100, 100, 100);
            GameObject mCanvas = TCTCards.signalcanvas;
            
            GameObject UISpawned = Instantiate(UIelement, mCanvas.transform);
            

            

        }


        void Updatesection(int secnum, string text, Color color)
        {

        }
        public int Addsection(string text, Color color, float time)
        {
            int secnum = numcount;

            Element q = new Element();
            q.text = text;
            q.activefor = time;
            q.color = color;
            q.num = secnum;

            elements.Add(q);


            numcount++;
            return secnum;
        }














        private List<Element> elements;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;
        private GameObject UIelement = TCTCards.signal;
        public int numcount;
        class Element
        {
            public int num;
            public string text;
            public Color color;
            public float activefor;
        }




    }
}
