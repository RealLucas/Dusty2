// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|normal-4714-RGB,emission-7670-OUT,custl-2410-OUT;n:type:ShaderForge.SFN_Fresnel,id:376,x:32362,y:33232,varname:node_376,prsc:2|NRM-3502-OUT,EXP-6589-OUT;n:type:ShaderForge.SFN_NormalVector,id:3502,x:31690,y:33207,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:3400,x:31680,y:32979,varname:node_3400,prsc:2;n:type:ShaderForge.SFN_Dot,id:1303,x:31971,y:33078,varname:node_1303,prsc:2,dt:1|A-3502-OUT,B-3400-OUT;n:type:ShaderForge.SFN_Tex2d,id:8950,x:32260,y:32756,ptovrint:False,ptlb:node_8950,ptin:_node_8950,varname:_node_8950,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2552f8f1ad35f374da0b77d196a9c544,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7771,x:32562,y:33034,varname:node_7771,prsc:2|A-8950-RGB,B-7972-OUT;n:type:ShaderForge.SFN_HalfVector,id:184,x:31907,y:32649,varname:node_184,prsc:2;n:type:ShaderForge.SFN_Dot,id:8501,x:32137,y:32644,varname:node_8501,prsc:2,dt:1|A-3502-OUT,B-184-OUT;n:type:ShaderForge.SFN_Power,id:4743,x:32489,y:32493,varname:node_4743,prsc:2|VAL-8501-OUT,EXP-6082-OUT;n:type:ShaderForge.SFN_Slider,id:4177,x:31966,y:32386,ptovrint:False,ptlb:specularAmount,ptin:_specularAmount,varname:_specularAmount,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7264928,max:5;n:type:ShaderForge.SFN_Exp,id:6082,x:32338,y:32347,varname:node_6082,prsc:2,et:1|IN-4177-OUT;n:type:ShaderForge.SFN_Multiply,id:7387,x:32719,y:32443,varname:node_7387,prsc:2|A-4743-OUT,B-7495-OUT,C-5174-OUT;n:type:ShaderForge.SFN_Slider,id:7495,x:32413,y:32693,ptovrint:False,ptlb:specularIns,ptin:_specularIns,varname:_specularIns,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1880342,max:5;n:type:ShaderForge.SFN_Add,id:3154,x:32864,y:32783,varname:node_3154,prsc:2|A-7387-OUT,B-7771-OUT,C-6650-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1076,x:31981,y:32944,ptovrint:False,ptlb:node_1076,ptin:_node_1076,varname:_node_1076,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:8587,x:32166,y:33016,varname:node_8587,prsc:2|A-1303-OUT,B-1076-OUT;n:type:ShaderForge.SFN_Add,id:7972,x:32364,y:32974,varname:node_7972,prsc:2|A-1076-OUT,B-8587-OUT;n:type:ShaderForge.SFN_Desaturate,id:565,x:32386,y:32343,varname:node_565,prsc:2|COL-8950-RGB;n:type:ShaderForge.SFN_RemapRange,id:282,x:32600,y:32288,varname:node_282,prsc:2,frmn:0,frmx:1,tomn:-0.5,tomx:1.5|IN-565-OUT;n:type:ShaderForge.SFN_Clamp01,id:5174,x:32800,y:32219,varname:node_5174,prsc:2|IN-282-OUT;n:type:ShaderForge.SFN_Color,id:2982,x:32360,y:33442,ptovrint:False,ptlb:node_2982,ptin:_node_2982,varname:_node_2982,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4558824,c2:0.4558824,c3:0.4558824,c4:1;n:type:ShaderForge.SFN_Multiply,id:6650,x:32542,y:33291,varname:node_6650,prsc:2|A-376-OUT,B-2982-RGB,C-1073-OUT;n:type:ShaderForge.SFN_Slider,id:1073,x:32233,y:33674,ptovrint:False,ptlb:fresnelAmount,ptin:_fresnelAmount,varname:_fresnelAmount,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5982879,max:5;n:type:ShaderForge.SFN_Multiply,id:2410,x:33030,y:32951,varname:node_2410,prsc:2|A-3154-OUT,B-2651-OUT,C-9028-RGB;n:type:ShaderForge.SFN_LightColor,id:9028,x:32858,y:33125,varname:node_9028,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:2651,x:32854,y:32971,varname:node_2651,prsc:2;n:type:ShaderForge.SFN_Slider,id:2378,x:31877,y:33417,ptovrint:False,ptlb:node_2378,ptin:_node_2378,varname:_node_2378,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:5;n:type:ShaderForge.SFN_Exp,id:6589,x:32197,y:33302,varname:node_6589,prsc:2,et:1|IN-2378-OUT;n:type:ShaderForge.SFN_Tex2d,id:4714,x:32918,y:32493,ptovrint:False,ptlb:node_4714,ptin:_node_4714,varname:_node_4714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d0973dd2dbca79b41a94be090a0ba456,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:24,x:33179,y:33368,ptovrint:False,ptlb:node_24,ptin:_node_24,varname:_node_24,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a71895c816a52e94895b5ff2b7971ec7,ntxv:0,isnm:False|UVIN-5683-UVOUT;n:type:ShaderForge.SFN_Panner,id:5683,x:33020,y:33371,varname:node_5683,prsc:2,spu:0,spv:0.5|UVIN-6472-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6472,x:32827,y:33377,varname:node_6472,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:2403,x:33080,y:33658,ptovrint:False,ptlb:node_2403,ptin:_node_2403,varname:_node_2403,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.666667,max:3;n:type:ShaderForge.SFN_Multiply,id:7670,x:33387,y:33424,varname:node_7670,prsc:2|A-24-RGB,B-2403-OUT;proporder:8950-4177-7495-1076-2982-1073-2378-4714-24-2403;pass:END;sub:END;*/

Shader "Shader Forge/PlayerShader" {
    Properties {
        _node_8950 ("node_8950", 2D) = "white" {}
        _specularAmount ("specularAmount", Range(0, 5)) = 0.7264928
        _specularIns ("specularIns", Range(0, 5)) = 0.1880342
        _node_1076 ("node_1076", Float ) = 0.3
        _node_2982 ("node_2982", Color) = (0.4558824,0.4558824,0.4558824,1)
        _fresnelAmount ("fresnelAmount", Range(0, 5)) = 0.5982879
        _node_2378 ("node_2378", Range(0, 5)) = 5
        _node_4714 ("node_4714", 2D) = "bump" {}
        _node_24 ("node_24", 2D) = "white" {}
        _node_2403 ("node_2403", Range(0, 3)) = 2.666667
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_8950; uniform float4 _node_8950_ST;
            uniform float _specularAmount;
            uniform float _specularIns;
            uniform float _node_1076;
            uniform float4 _node_2982;
            uniform float _fresnelAmount;
            uniform float _node_2378;
            uniform sampler2D _node_4714; uniform float4 _node_4714_ST;
            uniform sampler2D _node_24; uniform float4 _node_24_ST;
            uniform float _node_2403;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _node_4714_var = UnpackNormal(tex2D(_node_4714,TRANSFORM_TEX(i.uv0, _node_4714)));
                float3 normalLocal = _node_4714_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 node_5931 = _Time;
                float2 node_5683 = (i.uv0+node_5931.g*float2(0,0.5));
                float4 _node_24_var = tex2D(_node_24,TRANSFORM_TEX(node_5683, _node_24));
                float3 node_7670 = (_node_24_var.rgb*_node_2403);
                float3 emissive = node_7670;
                float4 _node_8950_var = tex2D(_node_8950,TRANSFORM_TEX(i.uv0, _node_8950));
                float3 finalColor = emissive + (((pow(max(0,dot(i.normalDir,halfDirection)),exp2(_specularAmount))*_specularIns*saturate((dot(_node_8950_var.rgb,float3(0.3,0.59,0.11))*2.0+-0.5)))+(_node_8950_var.rgb*(_node_1076+(max(0,dot(i.normalDir,lightDirection))*_node_1076)))+(pow(1.0-max(0,dot(i.normalDir, viewDirection)),exp2(_node_2378))*_node_2982.rgb*_fresnelAmount))*attenuation*_LightColor0.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_8950; uniform float4 _node_8950_ST;
            uniform float _specularAmount;
            uniform float _specularIns;
            uniform float _node_1076;
            uniform float4 _node_2982;
            uniform float _fresnelAmount;
            uniform float _node_2378;
            uniform sampler2D _node_4714; uniform float4 _node_4714_ST;
            uniform sampler2D _node_24; uniform float4 _node_24_ST;
            uniform float _node_2403;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _node_4714_var = UnpackNormal(tex2D(_node_4714,TRANSFORM_TEX(i.uv0, _node_4714)));
                float3 normalLocal = _node_4714_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _node_8950_var = tex2D(_node_8950,TRANSFORM_TEX(i.uv0, _node_8950));
                float3 finalColor = (((pow(max(0,dot(i.normalDir,halfDirection)),exp2(_specularAmount))*_specularIns*saturate((dot(_node_8950_var.rgb,float3(0.3,0.59,0.11))*2.0+-0.5)))+(_node_8950_var.rgb*(_node_1076+(max(0,dot(i.normalDir,lightDirection))*_node_1076)))+(pow(1.0-max(0,dot(i.normalDir, viewDirection)),exp2(_node_2378))*_node_2982.rgb*_fresnelAmount))*attenuation*_LightColor0.rgb);
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
