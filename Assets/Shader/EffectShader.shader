Shader "Custom/EffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "UnityShaderVariables.cginc"

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            uniform int playerIsDead;
            uniform float startTime;
            uniform float currentTime;
            uniform float blendDuration;
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                if(playerIsDead == 1){
                    fixed grey = (col.r + col.b + col.g)/3.0;
                    if(currentTime < (startTime + blendDuration)) {

                        /* fixed r = col.r;
                        fixed g = col.g;
                        fixed b = col.b; 
                        fixed mul = (currentTime - startTime) / blendDuration; // mul == [0.0, 1.0]

                        if (col.r > grey) r -= (col.r - grey) * mul;
                        else r += (grey - col.r) * mul;

                        if (col.g > grey) g -= (col.g - grey) * mul;
                        else g += (grey - col.g) * mul;

                        if (col.b > grey) b -= (col.b - grey) * mul;
                        else b += (grey - col.b) * mul;
                        
                        col = fixed4(r, g, b, col.a); */

                        // OR

                        fixed desaturation = (currentTime - startTime) / blendDuration; // mul == [0.0, 1.0]
                        col = lerp(col, grey, desaturation);

                    } else {
                        col = fixed4(grey, grey, grey, col.a);
                    }
                }
                
                return col;
            }
            ENDCG
        }
    }
}
