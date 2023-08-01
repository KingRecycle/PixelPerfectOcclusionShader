// UniqueColorShader.shader
Shader "Custom/UniqueColorShader"
{
    Properties
    {
        _UniqueColor("Unique Color", Color) = (1, 1, 1, 1) // Default to white color
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 uniqueColor : COLOR0;
            };
            
            
            fixed4 _UniqueColor;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uniqueColor = _UniqueColor;
                return o;
            }
            

            fixed4 frag(v2f i) : SV_Target
            {
                return i.uniqueColor;
            }
            ENDCG
        }
    }
}
