Shader "Unlit/Shader_baru"
{
    Properties
    {
       [MainColor]_Warna ("warna", Color) = (245,39,156,1)
    }
    SubShader
    {
        Tags { 
            "RenderType"="Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
        }

        Pass
        {

            Name "Unlit2D"
            Tags { "LightMode" = "Universal2D" }

            HSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            CBUFFER_START(UnityPerMaterial)
                float4 _Warna;
            CBUFFER_END

            struct Atributes
            {
                float4 posisiObjek : POSITION;
            };

            struct keFragment
            {
                float4 posisiClip : SV_POSITION;
            };

            keFragment vert(Atributes IN)
            {
                keFragment OUT;
                OUT.posisiClip = TransformObjectToHClip(IN.posisiObjek.xyz);
                return OUT;
            }

            half4 frag(keFragment IN) : SV_Target
            {
                return (half4)_Warna;
            }
            ENDHLSL
        }
    }
}
