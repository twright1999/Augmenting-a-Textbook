Shader "Custom/GouraudShading" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0.5)
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _Shininess ("Shininess", Range (0.01, 1)) = 0.7
    }

    SubShader {
        Pass {
            Material {
                Diffuse [_Color]
                Ambient [_Color]
                Shininess [_Shininess]
                Specular [_SpecColor]
            }
            Lighting On
            SeparateSpecular On
        }
    }
}
