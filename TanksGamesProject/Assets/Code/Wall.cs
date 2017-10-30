using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Structure
{
    public class Wall : MonoBehaviour
    {
        public List<Vector2> newVerticies = new List<Vector2>();

        void Update() { }

        void Awake()
        {
            Camera camera = Camera.main;
            Rect r = camera.pixelRect;
            Vector3 bl = camera.ViewportToWorldPoint(new Vector3(r.xMin, r.yMin, 0));

            newVerticies.Add(new Vector2(bl[0], bl[1]));
            newVerticies.Add(new Vector2(-1f * bl[0], bl[1]));
            newVerticies.Add(new Vector2(-1f * bl[0], -1f * bl[1]));
            newVerticies.Add(new Vector2(bl[0], -1f * bl[1]));
            newVerticies.Add(new Vector2(bl[0], bl[1]));
            gameObject.GetComponent<EdgeCollider2D>().points = newVerticies.ToArray();
        }

        internal void OnCollisionEnter2D(Collision2D other)
        {
       
            if (other.gameObject.GetComponent<Player>() != null) Debug.Log("Work");
        }
    }
}