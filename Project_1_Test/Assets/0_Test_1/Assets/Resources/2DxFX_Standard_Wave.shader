Shader "2DxFX/Standard/Wave" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_OffsetX ("OffsetX", Range(0, 128)) = 0
		_OffsetY ("OffsetY", Range(0, 128)) = 0
		_DistanceX ("DistanceX", Range(0, 1)) = 0
		_DistanceY ("DistanceY", Range(0, 1)) = 0
		_WaveTimeX ("WaveTimeX", Range(0, 360)) = 0
		_WaveTimeY ("WaveTimeY", Range(0, 360)) = 0
		_Color ("Tint", Vector) = (1,1,1,1)
		_Alpha ("Alpha", Range(0, 1)) = 1
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
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
	Fallback "Sprites/Default"
}