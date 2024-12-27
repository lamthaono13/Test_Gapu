Shader "Sprite Shaders Ultimate/Standard/Effect/Shine" {
	Properties {
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Vector) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		[PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
		[KeywordEnum(UV,UV_Raw,Object,Object_Scaled,World,UI_Element,Screen)] _ShaderSpace ("Shader Space", Float) = 0
		_PixelsPerUnit ("Pixels Per Unit", Float) = 100
		_ScreenWidthUnits ("Screen Width Units", Float) = 10
		_RectWidth ("Rect Width", Float) = 100
		_RectHeight ("Rect Height", Float) = 100
		[KeywordEnum(Linear_Default,Linear_Scaled,Linear_FPS,Frequency,Frequency_FPS,Custom_Value)] _TimeSettings ("Time Settings", Float) = 0
		_TimeScale ("Time Scale", Float) = 1
		_TimeFrequency ("Time Frequency", Float) = 2
		_TimeRange ("Time Range", Float) = 0.5
		_TimeFPS ("Time FPS", Float) = 5
		_TimeValue ("Time Value", Float) = 0
		_ShineFade ("Shine: Fade", Range(0, 1)) = 1
		[NoScaleOffset] _ShineShaderMask ("Shine: Shader Mask", 2D) = "white" {}
		[HDR] _ShineColor ("Shine: Color", Vector) = (11.98431,11.98431,11.98431,0)
		_ShineSaturation ("Shine: Saturation", Range(0, 1)) = 0.5
		_ShineContrast ("Shine: Contrast", Float) = 2
		_ShineSmoothness ("Shine: Smoothness", Float) = 2
		_ShineSpeed ("Shine: Speed", Float) = 0.1
		_ShineScale ("Shine: Scale", Float) = 0.05
		_ShineWidth ("Shine: Width", Range(0, 2)) = 0.1
		[ASEEnd] _ShineRotation ("Shine: Rotation", Range(0, 360)) = 0
		[HideInInspector] _texcoord ("", 2D) = "white" {}
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
	//CustomEditor "SpriteShadersUltimate.SingleShaderGUI"
}