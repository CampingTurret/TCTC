using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TCTC.MonoBehaviors
{

    public class TCTC_Scroll : MonoBehaviour
    {

        [SerializeField]
        public Transform _first, _second, _third;
        [SerializeField]
        private float scrollspeed = 0.5f;
        [SerializeField]
        private float xdiff, xmin, xjump;

        // Start is called before the first frame update
        void Start()
        {
            xdiff = _second.localPosition.x - _first.localPosition.x;
            _third.localPosition = new Vector3(_second.localPosition.x + xdiff, _second.localPosition.y, _second.localPosition.z);
            xjump = _third.localPosition.x;
            xmin = _first.localPosition.x - xdiff;

        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Jump();


        }
        private void Move()
        {
            _first.localPosition = new Vector3(_first.localPosition.x - scrollspeed * Time.deltaTime, _first.localPosition.y, _first.localPosition.z);
            _second.localPosition = new Vector3(_second.localPosition.x - scrollspeed * Time.deltaTime, _second.localPosition.y, _second.localPosition.z);
            _third.localPosition = new Vector3(_third.localPosition.x - scrollspeed * Time.deltaTime, _third.localPosition.y, _third.localPosition.z);

        }
        private void Jump()
        {
            if (_first.localPosition.x < xmin)
            {
                _first.localPosition = new Vector3(xjump, _first.localPosition.y, _first.localPosition.z);
            }
            if (_second.localPosition.x < xmin)
            {
                _second.localPosition = new Vector3(xjump, _second.localPosition.y, _second.localPosition.z);
            }
            if (_third.localPosition.x < xmin)
            {
                _third.localPosition = new Vector3(xjump, _third.localPosition.y, _third.localPosition.z);
            }
        }
    }
}