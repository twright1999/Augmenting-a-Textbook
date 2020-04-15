Shader "Custom/BlinnPhongShading"
{
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0.5)
        _AmbientIntensity ("AmbientIntensity", Float) = 0.1
        _DiffuseIntensity ("DefuseIntensity", Float) = 1.0
        _SpecularIntensity ("SpecularIntensity", Float) = 1.0
        _Shininess ("Shininess", Float) = 12.0 
    }

    SubShader {
        Tags {"RenderType" = "Opaque"}

        Pass {
            Tags {"LightMode" = "ForwardBase"} 

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            fixed4 _Color;
            float _AmbientIntensity;
            float _DiffuseIntensity;
            float _SpecularIntensity;
            float _Shininess;

            struct VertInput {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };

            struct VertOutput {
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
                float3 worldPos : TEXCOORD0;
            };

            VertOutput vert(VertInput i) {
                VertOutput o;


                o.pos = UnityObjectToClipPos(i.pos);
                o.normal = UnityObjectToWorldNormal(i.normal);
                o.worldPos = mul(unity_ObjectToWorld, i.pos);

                return o;
            }

            half4 frag(VertOutput i) : SV_TARGET {
                // ambient
                float3 ambient = _Color;

                // diffuse
                float3 norm = normalize(i.normal);
                float3 lightPos = float3(unity_4LightPosX0[0],unity_4LightPosY0[0],unity_4LightPosZ0[0]);
                float3 lightDir = normalize(lightPos - i.worldPos);
                float3 diffuse = _Color * max(dot(norm, lightDir), 0.0);

                // specular
                float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPos);
                float3 reflectDir = reflect(-lightDir, norm);
                float3 specular;

                if (dot(norm, lightDir) < 0.0) {
                   specular = float3(0.0, 0.0, 0.0); 
                }
                else {
                   specular = pow(max(dot(viewDir, reflectDir), 0.0), _Shininess);
                }

                float3 result = ambient*_AmbientIntensity + diffuse*_DiffuseIntensity + specular*_SpecularIntensity;
                half4 fragColor = half4(result, 1.0);


                return fragColor;
            } 

            ENDCG
        }
    }
    FallBack "Diffuse"
}
