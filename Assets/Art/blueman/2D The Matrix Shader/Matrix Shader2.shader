Shader "Custom/2D/MatrixGlyph_RainTint"
{
    Properties
    {
        _MainTex        ("Character Sprite", 2D) = "white" {}
        _GlyphTex       ("Glyph Atlas (white glyphs)", 2D)  = "white" {}
        _AtlasGlyphPixelSize ("Atlas glyph tile size (px)", Float) = 16
        _GlyphDisplaySize ("Glyph display size (px)", Float) = 8
        _GlyphDensity   ("Glyph Density (1=normal, >1=tighter)", Range(0.5,4)) = 2.0
        _Speed          ("Rain speed", Float) = 1.0
        _Brightness     ("Brightness / Intensity", Float) = 1.2
        _HeadSize       ("Head size (0..1)", Range(0,0.8)) = 0.18
        _HeadBoost      ("Head brightness boost", Float) = 1.2
        _Seed           ("Seed", Float) = 0.0
        _GlyphAlphaCutoff("Glyph alpha cutoff", Range(0,0.2)) = 0.02

        _OverlayColor   ("Overlay Color", Color) = (0,1,0,1)
        _OverlayStrength("Overlay Strength", Range(0,1)) = 0.3

        _EffectBlend    ("Effect Blend (0=Sprite, 1=Glyph)", Range(0,1)) = 1.0
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Cull Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4    _MainTex_TexelSize;

            sampler2D _GlyphTex;
            float4    _GlyphTex_TexelSize;

            float _AtlasGlyphPixelSize;
            float _GlyphDisplaySize;
            float _GlyphDensity;
            float _Speed;
            float _Brightness;
            float _HeadSize;
            float _HeadBoost;
            float _Seed;
            float _GlyphAlphaCutoff;

            float4 _OverlayColor;
            float _OverlayStrength;
            float _EffectBlend;

            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; float4 color : COLOR; };
            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv  : TEXCOORD0;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            float hash21(float2 p)
            {
                p = frac(p * float2(123.34, 456.21) + _Seed);
                p += dot(p, p + 34.345);
                return frac(p.x * p.y);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 mainTexSize = float2(_MainTex_TexelSize.z, _MainTex_TexelSize.w);
                float2 pixelPos = i.uv * mainTexSize;

                // Normal sprite color
                fixed4 spriteColor = tex2D(_MainTex, i.uv);
                if (spriteColor.a <= 0.001)
                    return fixed4(0,0,0,0);

                // overlay color blend
                spriteColor.rgb = lerp(spriteColor.rgb, _OverlayColor.rgb, _OverlayStrength * _OverlayColor.a);

                // === Glyph Rain Effect ===
                float glyphSize = max(0.0001, _GlyphDisplaySize / _GlyphDensity);

                float2 cellIndex = floor(pixelPos / glyphSize);
                float2 localInCell = frac(pixelPos / glyphSize);

                float2 uvCenter = (cellIndex + 0.5) * glyphSize / mainTexSize;
                fixed4 baseColor = tex2D(_MainTex, uvCenter);

                float2 atlasSize = float2(_GlyphTex_TexelSize.z, _GlyphTex_TexelSize.w);
                float glyphCols = max(1.0, floor(atlasSize.x / max(1.0, _AtlasGlyphPixelSize)));
                float glyphRows = max(1.0, floor(atlasSize.y / max(1.0, _AtlasGlyphPixelSize)));
                float glyphCount = glyphCols * glyphRows;

                // animation
                float t = _Time.y * _Speed;
                float colSeed = hash21(float2(cellIndex.x, 17.0));
                float movingRow = floor(cellIndex.y + t + colSeed * 4.0);

                float glyphRand = hash21(float2(cellIndex.x, movingRow));
                float glyphIndexF = floor(glyphRand * glyphCount + 0.0001);
                float gx = fmod(glyphIndexF, glyphCols);
                float gy = floor(glyphIndexF / glyphCols);

                float animLocalY = frac(localInCell.y + t + colSeed * 0.37);
                float2 glyphLocalUV = float2(localInCell.x, animLocalY);
                float2 atlasUV = (float2(gx, gy) + glyphLocalUV) / float2(glyphCols, glyphRows);

                fixed4 glyphSample = tex2D(_GlyphTex, atlasUV);
                float glyphA = glyphSample.a;

                // skip if transparent glyph
                if (glyphA <= _GlyphAlphaCutoff)
                    glyphA = 0.0;

                // head highlight
                float headPos = frac(localInCell.y + t + colSeed * 0.37);
                float head = smoothstep(0.0, _HeadSize, 1.0 - headPos);

                // effect color
                float3 glyphColor = baseColor.rgb * (_Brightness * (1.0 + head * _HeadBoost)) * glyphA;

                fixed4 effectColor = fixed4(glyphColor, glyphA);

                // === Blend between original sprite and glyph rain ===
                fixed4 finalColor = lerp(spriteColor, effectColor, _EffectBlend);

                return finalColor;
            }
            ENDHLSL
        }
    }
    FallBack "Sprites/Default"
}
