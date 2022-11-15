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
            mCanvas = Instantiate(TCTCards.signalcanvas);
            

            

        }

        void Update()
        {
            foreach (Element section in elements)
            {
                section.activefor = section.activefor - Time.deltaTime;

                if (section.activefor <= 0)
                {
                    Destroy(section.UI);
                    elements.Remove(section);
                }

                GameObject UIsection = section.UI;
                RectTransform rectTransform = UIsection.GetComponent<RectTransform>();
                
            }
        }


        void Updatesection(int secnum, string text, Color color)
        {
            Element element = elements.Find(s => s.num == secnum);
            element.text = text;
            element.color = color;
        }

        void spawnsection(Element e)
        {
            //spawn the UI element
            TextMeshProUGUI x = UIelement.GetComponentInChildren<TextMeshProUGUI>();
            x.text = e.text;
            x.fontSize = 5;
            x.color = e.color;
            RectTransform q = UIelement.AddComponent<RectTransform>();
            q.anchorMax = new Vector2(0.8f, 0.9f);
            q.anchorMin = new Vector2(0.7f, 0.8f);
            
            GameObject t = Instantiate(UIelement, mCanvas.transform);
            e.UI = t;
            elements.Add(e);
            return;

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
            spawnsection(q);

            numcount++;
            return secnum;
        }














        private List<Element> elements;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;
        private GameObject UIelement = TCTCards.signal;
        private GameObject mCanvas;
        public int numcount;
        class Element
        {
            public int num;
            public GameObject UI;
            public string text;
            public Color color;
            public float activefor;
        }




    }
}
