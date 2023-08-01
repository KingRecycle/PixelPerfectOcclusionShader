using System;
using System.Collections.Generic;
using UnityEngine;

namespace CharlieMadeAThing.QuantumSpook {
    public class UniqueColorId : MonoBehaviour {
        [SerializeField] uint _id;
        static readonly int UniqueColor = Shader.PropertyToID( "_UniqueColor" );
        static readonly System.Random random = new();
        public static Dictionary<Color, GameObject> IDToGameObject = new();
        Color32 _uniqueColor;

        void Start() {
            var rnderer = GetComponent<Renderer>();
            var thirtyBits = (uint) random.Next(1 << 30);
            var twoBits = (uint) random.Next(1 << 2);
            _id = (thirtyBits << 2) | twoBits;
            
            if (rnderer != null)
            {
                // Create a new MaterialPropertyBlock
                MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

                // Convert the unique ID to a Color
                _uniqueColor = Helpers.UIntToColor(_id);

                // Set the unique color property in the MaterialPropertyBlock
                materialPropertyBlock.SetColor(UniqueColor, _uniqueColor);

                // Set the MaterialPropertyBlock to the Renderer
                rnderer.SetPropertyBlock(materialPropertyBlock);
            }
            IDToGameObject.Add( _uniqueColor, gameObject );
        }
    }
}