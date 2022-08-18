using SkiaSharp;
using SkiaSharp.Views.Blazor;

namespace SkiaSharpBlazorApp.Pages
{
    public partial class Index
    {
        private void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            // below is a sample from:
            // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/effects/image-filters

            float dx = 5;
            float dy = 5;
            float sigmaX = 3.5f;
            float sigmaY = 3.5f;

            using (SKPaint paint = new SKPaint())
            {
                // Set SKPaint properties
                paint.TextSize = 100;
                paint.Color = SKColors.Blue;

                // ImageFilter leads to a "memory access out of bounds" exception
                // while the application is running
                paint.ImageFilter = SKImageFilter.CreateDropShadow(dx,dy,sigmaX,sigmaY,SKColors.Red);

                float xText = 0;
                float yText = 100;

                canvas.DrawText("SKIA", xText, yText, paint);
            }
        }
    }
}
