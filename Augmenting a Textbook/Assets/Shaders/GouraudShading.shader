Shader "Custom/GouraudShading"
{
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0.5)
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
            float _Shininess;

            struct VertInput {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };

            struct VertOutput {
                float4 pos : SV_POSITION;
                float3 color : COLOR;
            };

            VertOutput vert(VertInput i) {
                VertOutput o;


                o.pos = UnityObjectToClipPos(i.pos);

                float3 normal = UnityObjectToWorldNormal(i.normal);
                float3 worldPos = mul(unity_ObjectToWorld, i.pos);

                // ambient
                float3 ambient = _Color;

                // diffuse
                float3 norm = normalize(normal);
                float3 lightPos = float3(unity_4LightPosX0[0],
                    unity_4LightPosY0[0],unity_4LightPosZ0[0]);
                float3 lightDir = normalize(lightPos - worldPos);
                float3 diffuse = _Color * max(dot(norm, lightDir), 0.0);

                // specular
                float3 viewDir = normalize(_WorldSpaceCameraPos - worldPos);
                float3 H = normalize((lightDir + viewDir)/2);

                float3 specular = pow(max(dot(norm, H), 0.0), _Shininess);

                float3 result = ambient*0.2 + diffuse + specular;
                
                o.color = half4(result, 1.0);

                return o;
            }

            half4 frag(VertOutput i) : SV_TARGET {

                return half4(i.color, 1.0);
            } 

            ENDCG
        }
    }
    FallBack "Diffuse"
}