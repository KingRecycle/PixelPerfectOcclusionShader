using System;
using System.Linq;
using UnityEngine;

namespace CharlieMadeAThing.QuantumSpook {
    public class RunVisionComputeShader : MonoBehaviour {
        [SerializeField] ComputeShader visionComputeShader;
        [SerializeField] RenderTexture visionTexture;
        const int THREAD_GROUP_SIZE = 16;

        void Start() {
            var cam = GetComponent<Camera>();
            visionTexture = new RenderTexture( Screen.width, Screen.height, 0 ) {
                antiAliasing = 1,
                filterMode = FilterMode.Point,
                autoGenerateMips = false,
                depth = 24,
                enableRandomWrite = true,
            };
            
            cam.targetTexture = visionTexture;
        }

        void Update() {
            var size = UniqueColorId.IDToGameObject.Count;
            var colorBuffer = new ComputeBuffer(size, sizeof(float) * 4);
            var visibilityBuffer = new ComputeBuffer(size, sizeof(int));

            colorBuffer.SetData( UniqueColorId.IDToGameObject.Keys.ToArray() );
            visibilityBuffer.SetData(new int[size]);
            visionComputeShader.SetBuffer(0, "colors", colorBuffer);
            visionComputeShader.SetBuffer(0, "visibility", visibilityBuffer);
            visionComputeShader.SetInt("size", size);
            visionComputeShader.SetTexture(0, "screenTexture", visionTexture);
            visionComputeShader.Dispatch( 0, visionTexture.width / THREAD_GROUP_SIZE, visionTexture.height / THREAD_GROUP_SIZE, 1 );
            var visibility = new int[size];
            visibilityBuffer.GetData(visibility);
            colorBuffer.Dispose();
            visibilityBuffer.Dispose();
        }
    }
}