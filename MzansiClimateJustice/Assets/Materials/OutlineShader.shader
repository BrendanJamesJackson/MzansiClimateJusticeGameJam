Shader "Custom/OutlineShader"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1)
        _OutlineColor("Outline Color", Color) = (0,1,1,1)
        _OutlineWidth("Outline Width", Range(0.0, 0.1)) = 0.02
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Cull Front

        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            uniform float _OutlineWidth;
            uniform float4 _OutlineColor;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            float4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                float3 norm = normalize(v.normal);
                v.vertex.xyz += norm * _OutlineWidth;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return _OutlineColor;
            }
            ENDCG
        }
    }

        FallBack "Diffuse"
}
