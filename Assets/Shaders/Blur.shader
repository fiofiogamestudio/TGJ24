Shader "Custom/Blur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        LOD 100

        Pass
        {

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _BlurSize;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 col = float4(0,0,0,0);
                float2 uv = i.uv;
                float offset = _BlurSize / _ScreenParams.y; // Blur size based on screen height

                // Add weighted samples around the current pixel
                for (int x = -3; x <= 3; x++)
                {
                    for (int y = -3; y <= 3; y++)
                    {
                        float weight = 1.0 / (2.0 * 3.14159265 * _BlurSize * _BlurSize) * exp(-(x*x+y*y)/(2*_BlurSize*_BlurSize));
                        col += tex2D(_MainTex, uv + float2(x, y) * offset) * weight;
                    }
                }

                return col;
            }
            ENDCG
        }
    }
}
