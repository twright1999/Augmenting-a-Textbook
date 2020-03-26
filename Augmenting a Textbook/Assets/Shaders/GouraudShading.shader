Shader "Custom/GouraudShading" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0.5)
        _Shininess ("Shininess", Float) = 100

    }
    SubShader {
        Pass {
            Tags {"LightMode"="ForwardBase"}

            CGPROGRAM

            // Tells the program that a vertex and fragment shader are used
            #pragma vertex vert
            #pragma fragment frag
            // Contains common declarations and functions
            #include "UnityCG.cginc"

            // Color of object
            fixed4 _Color;
            // Color of light
            float4 _LightColor0;
            // Shininess
            float _Shininess;

            // Define a vertex to fragment struct
            struct v2f {
                float4 pos : POSITION;
                fixed4 diff : COLOR0;
                fixed4 spec : COLOR1;
            };

            // Vertex program 
            v2f vert (appdata_base v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                half3 normal = UnityObjectToWorldNormal(v.normal);

                // Diffuse
                float3 lightPos = float3(unity_4LightPosX0[0],unity_4LightPosY0[0],unity_4LightPosZ0[0]);
                float3 lightDir = normalize(lightPos - o.pos);
                half diff = max(0, dot(normal, lightDir));

                o.diff = diff;

                // Specular
                float3 viewDir = normalize(_WorldSpaceCameraPos - o.pos);
                float3 reflectDir = reflect(-lightDir, normal);
                float spec = pow(max(dot(viewDir, reflectDir), 0.0), _Shininess);

                o.spec = spec;

                return o;
            }

            // Fragment program
            fixed4 frag (v2f i) : COLOR {
                fixed4 color = _Color*0.1 + i.diff*_Color + i.spec;

                return color;
            }

            ENDCG
        }
    }
}