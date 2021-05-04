using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltAnim : MonoBehaviour
{
	private Renderer rend;
	private float offsetY;
	[SerializeField] private float speed;

	// Start is called before the first frame update
	void Start()
    {
		rend = GetComponent<Renderer>();
		offsetY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
		offsetY += speed * Time.deltaTime;
		rend.material.SetTextureOffset("_MainTex", new Vector2(0f, offsetY));
    }
}
