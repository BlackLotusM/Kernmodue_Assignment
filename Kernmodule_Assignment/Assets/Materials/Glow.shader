﻿Shader "Glow"{
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _Size("Atmosphere Size Multiplier", Range(0,16)) = 4
        _Rim("Fade Power", Range(0,8)) = 4
        _Light("Lighting Power", Range(0,10)) = 1.4
        _Ambient("Ambient Power", Range(0,6)) = 0.8
    }
        SubShader{
            Tags { "RenderType" = "Transparent" }
            LOD 200

            Cull Front

            CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NegativeLambert fullforwardshadows alpha:fade
        #pragma vertex vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0


        struct Input {
            float3 viewDir;
        };

        half _Size;
        half _Rim;
        half _Light;
        half _Ambient;
        fixed4 _Color;

        void vert(inout appdata_full v) {
            v.vertex.xyz += v.vertex.xyz * _Size / 10;
            v.normal *= -1;
        }

        half4 LightingNegativeLambert(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
            s.Normal = normalize(s.Normal);

            half diff = max(0, dot(-s.Normal, lightDir)) * _Light + _Ambient;

            half4 c;
            c.rgb = (s.Albedo * _LightColor0 * diff) * atten;
            c.a = s.Alpha;
            return c;
        }

        void surf(Input IN, inout SurfaceOutput o) {
            half rim = saturate(dot(1 + normalize(IN.viewDir), o.Normal));

            fixed4 c = _Color;
            o.Albedo = c.rgb;
            o.Alpha = lerp(0, 1, pow(_Rim, _Rim));
        }
        ENDCG
    }
        FallBack "Diffuse"
}