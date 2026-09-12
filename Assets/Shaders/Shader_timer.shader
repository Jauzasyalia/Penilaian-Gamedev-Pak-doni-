Shader "Unlit/Shader_Primer"
{
    Properties
    {
        [PerRendererData]_MainTex ("Texture", 2D) = "white" {}
        _MainColor ("Tint", Color) = (1,1,1,1)
        _KecepatanDenyut ("Kecepatan Denyut", Float) = 3
        _KecepatanGulir ("Kecepatan Gulir UV", Float) = 0
    }
    SubShader
    {
        Tags { 
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                half4 _Tint;
                float4 _MainTex_ST;
                float _KecepatanDenyut;
                float _KecepatanGulir;
            CBUFFER_END

            struct Attributes
            {
                float4 posisiOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 warnaVertex : COLOR;
            };

             struct KeFragment
            {
                float4 posisiClip : SV_POSITION;
                float2 uv : TEXCOORD0;
                half4 warnaVertex : COLOR;
            };

            KeFragment Vert(Atribut masuk)
            {
                KeFragment keluar;
                keluar.posisiClip = TransformObjectToHClip(masuk.posisiObjek.xyz);
                keluar.uv = TRANSFORM_TEX(masuk.uv, _MainTex);
                keluar.warnaVertex = masuk.warnaVertex;
                return keluar;
            }

            half4 Frag(KeFragment masuk) : SV_Target
            {
                float2 uv = masuk.uv;
                uv.x += _Time.y * _KecepatanGulir;

                half4 teks = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv);
                half4 kolom = teks * (half4)_Tint * masuk.warnaVertex;

                // sin() hasilnya -1..1, kita geser jadi 0.6..1 supaya tidak sampai hitam.
                half denyut = 0.6h + 0.4h * (half)sin(_Time.y * _KecepatanDenyut);
                kolom.rgb *= denyut;
                return kolom;
            }
            ENDHLSL
        }
    }
}
