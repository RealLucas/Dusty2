// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-5414-OUT;n:type:ShaderForge.SFN_TexCoord,id:7858,x:31735,y:32827,varname:node_7858,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:6079,x:31996,y:32697,varname:node_6079,prsc:2,spu:0.1,spv:0|UVIN-7858-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:4770,x:32222,y:32699,ptovrint:False,ptlb:Tex1,ptin:_Tex1,varname:_Tex1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a080508d6c29fce41b1b14caca882243,ntxv:0,isnm:False|UVIN-6079-UVOUT;n:type:ShaderForge.SFN_Panner,id:1981,x:31996,y:32953,varname:node_1981,prsc:2,spu:0,spv:0.5|UVIN-7858-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2840,x:32218,y:32949,ptovrint:False,ptlb:Tex2,ptin:_Tex2,varname:_Tex2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1af45cacbc75a3245b2546bbd8079c97,ntxv:0,isnm:False|UVIN-1981-UVOUT;n:type:ShaderForge.SFN_Add,id:7454,x:32458,y:32837,varname:node_7454,prsc:2|A-4770-R,B-2840-R;n:type:ShaderForge.SFN_Multiply,id:5414,x:32705,y:32696,varname:node_5414,prsc:2|A-991-OUT,B-7454-OUT,C-7829-RGB;n:type:ShaderForge.SFN_Slider,id:991,x:32195,y:32553,ptovrint:False,ptlb:node_991,ptin:_node_991,varname:_node_991,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6837612,max:2;n:type:ShaderForge.SFN_Color,id:7829,x:32548,y:33037,ptovrint:False,ptlb:node_7829,ptin:_node_7829,varname:_node_7829,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7573529,c2:0.2227509,c3:0.2227509,c4:1;proporder:4770-2840-991-7829;pass:END;sub:END;*/

Shader "Shader Forge/HuDun" {
    Properties {
        _Tex1 ("Tex1", 2D) = "white" {}
        _Tex2 ("Tex2", 2D) = "white" {}
        _node_991 ("node_991", Range(0, 2)) = 0.6837612
        [HDR]_node_7829 ("node_7829", Color) = (0.7573529,0.2227509,0.2227509,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Tex1; uniform float4 _Tex1_ST;
            uniform sampler2D _Tex2; uniform float4 _Tex2_ST;
            uniform float _node_991;
            uniform float4 _node_7829;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_169 = _Time;
                float2 node_6079 = (i.uv0+node_169.g*float2(0.1,0));
                float4 _Tex1_var = tex2D(_Tex1,TRANSFORM_TEX(node_6079, _Tex1));
                float2 node_1981 = (i.uv0+node_169.g*float2(0,0.5));
                float4 _Tex2_var = tex2D(_Tex2,TRANSFORM_TEX(node_1981, _Tex2));
                float3 node_5414 = (_node_991*(_Tex1_var.r+_Tex2_var.r)*_node_7829.rgb);
                float3 emissive = node_5414;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
