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
            numcount = 0;
            updatetimer = 0.1f;

            mCanvas = Instantiate(TCTCards.signalcanvas);
            // works: Instantiate(UIelement, mCanvas.transform);

            

        }

        void OnDestroy()
        {
            Destroy(mCanvas);
            foreach (Element section in elements)
            {
                Destroy(section.UI);
            }
        }
        void test()
        {
            Color c = new Color(0, 1, 0, 1);
            float d = 20f;
            string h = "HE3";
            int x = Addsection(h, c, d);
        }


        void Update()
        {

            updatetimer = updatetimer - Time.deltaTime;

            if (updatetimer <= 0)
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

                    int counter = elements.IndexOf(section) + 1;

                    double c = (counter) / 2;
                    int q = (int)Math.Round(c);
                    int d = (int)Math.Pow((-1), counter);
                    int n = q * 120 * d;
                    rectTransform.anchoredPosition = new Vector2(n, -21);



                    counter = counter + 1;

                }
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

            GameObject t = Instantiate(UIelement, mCanvas.transform);
            TextMeshProUGUI x = t.GetComponentInChildren<TextMeshProUGUI>();
            x.text = e.text;

            Image f = t.GetComponent<Image>();
            f.color = e.color;

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
            

            spawnsection(q);

            numcount++;
            return secnum;
        }














        private List<Element> elements = new List<Element>();
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;
        private GameObject UIelement = TCTCards.signal;
        private GameObject mCanvas;
        private float updatetimer;
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
