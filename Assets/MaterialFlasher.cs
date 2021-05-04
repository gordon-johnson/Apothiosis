using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFlasher : MonoBehaviour
{

    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {

        [SerializeField]
        private bool readyToSerialize = false;

        [SerializeField]
        private List<TKey> keys = new List<TKey>();

        [SerializeField]
        private List<TValue> values = new List<TValue>();

        // save the dictionary to lists
        public void OnBeforeSerialize()
        {
            if(!readyToSerialize)
            {
                return;
            }
            keys.Clear();
            values.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        // load dictionary from lists
        public void OnAfterDeserialize()
        {
            this.Clear();

            if (keys.Count != values.Count)
                throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

            for (int i = 0; i < keys.Count; i++)
                this.Add(keys[i], values[i]);
        }
    }

    [Serializable]
    public class MaterialsList : SerializableDictionary<String, Material> { }

    public MaterialsList materialsList;

    public Renderer[] renderers;

    private Material[][] startingMaterials;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        if(renderers.Length < 1)
        {
            renderers = new MeshRenderer[1];
            renderers[0] = GetComponent<MeshRenderer>();
        }
        startingMaterials = new Material[renderers.Length][];
        for(int i = 0; i < startingMaterials.Length; i++)
        {
            startingMaterials[i] = renderers[i].materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].materials = startingMaterials[i];
                }
            }
        }
    }

    public void flash(string materialName, float time)
    {
        /*foreach(Renderer renderer in renderers)
        {
            renderer.material = materialsList[materialName];
        }*/
        for (int i = 0; i < renderers.Length; i++)
        {
            Debug.Log("Renderer " + renderers[i].name + ": " + renderers[i].materials.Length);
            for (int j = 0; j < renderers[i].materials.Length; j++)
            {
                Material[] FlashedMaterial = new Material[renderers[i].materials.Length];
                for(int k = 0; k < FlashedMaterial.Length; k++)
                {
                    FlashedMaterial[k] = materialsList[materialName];
                }
                renderers[i].materials = FlashedMaterial;
            }
        }
        timer = time;
    }
}
