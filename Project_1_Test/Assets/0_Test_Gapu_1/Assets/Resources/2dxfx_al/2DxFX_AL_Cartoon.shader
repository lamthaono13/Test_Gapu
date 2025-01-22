Shader "2DxFX/AL/Cartoon" {
	Properties {
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Vector) = (1,1,1,1)
		_ColorLevel ("ColorLevel", Range(0, 1)) = 0
		_EdgeSize ("EdgeSize", Range(0, 1)) = 0
		_ColorB ("ColorB", Range(0, 1)) = 0
		_Size ("Size", Range(0, 1)) = 0
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
	Fallback "Transparent/VertexLit"
}