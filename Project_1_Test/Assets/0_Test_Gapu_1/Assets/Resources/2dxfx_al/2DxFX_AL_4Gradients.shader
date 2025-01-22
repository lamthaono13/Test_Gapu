Shader "2DxFX/AL/4Gradients" {
	Properties {
		[HideInInspector] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("_Color", Vector) = (1,1,1,1)
		_Color1 ("_Color1", Vector) = (1,1,1,1)
		_Color2 ("_Color2", Vector) = (1,1,1,1)
		_Color3 ("_Color3", Vector) = (1,1,1,1)
		_Color4 ("_Color4", Vector) = (1,1,1,1)
		[HideInInspector] _SrcBlend ("_SrcBlend", Float) = 0
		[HideInInspector] _DstBlend ("_DstBlend", Float) = 0
		[HideInInspector] _BlendOp ("_BlendOp", Float) = 0
		[HideInInspector] _Z ("_Z", Float) = 0
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Sprites-Defaultt"
}