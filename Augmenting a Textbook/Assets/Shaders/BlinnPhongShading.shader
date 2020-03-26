Shader "Custom/BlinnPhongShading" {
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
                float3 normal : NORMAL;
                float3 lightDir : TEXCOORD0; 
            };

            // Vertex program 
            v2f vert (appdata_base v) {
                v2f o;

                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = normalize(UnityObjectToWorldNormal(v.normal));

                // Diffuse
                float3 lightPos = float3(unity_4LightPosX0[0],unity_4LightPosY0[0],unity_4LightPosZ0[0]);
                float3 lightDir = normalize(lightPos - o.pos);

                o.lightDir = lightDir;

                return o;
            }

            // Fragment program
            fixed4 frag (v2f i) : COLOR {

                float3 normal = normalize(i.normal);
                float3 lightDir = i.lightDir;
               

                // Diffuse
                half diff = max(0, dot(normal, lightDir));

                // Specular
                float3 viewDir = normalize(_WorldSpaceCameraPos - i.pos);
                float3 reflectDir = reflect(lightDir, normal);
                float spec;

                if (dot(normal, lightDir) < 0.0) {
                   spec = float3(0.0, 0.0, 0.0); 
                }
                else {
                   spec = pow(max(dot(viewDir, reflectDir), 0.0), _Shininess);
                }


                fixed4 color = _Color*0.1 + diff*_Color + spec;

                return color;
            }

            ENDCG
        }
    }
}