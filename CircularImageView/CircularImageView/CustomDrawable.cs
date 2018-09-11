
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CircularImageView
{
    public class CustomDrawable : Drawable
    {
        Paint paint = new Paint();
        public Context context;
        public Color selectedColor;
        public int progress;
        public Boolean enableSteps = false;
        public Color defaultColor;
        public override int Opacity
        {
            get { return 255; }
        }

        public CustomDrawable(Context context)
        {
            this.context = context;
        }

        public CustomDrawable(Context context, Color defaultColor, Color selectedColor, int progress, Boolean enableSteps)
        {
            this.context = context;
            this.selectedColor = selectedColor;
            this.progress = progress;
            this.defaultColor = defaultColor;
            this.enableSteps = enableSteps;
        }

        public override void Draw(Canvas canvas)
        {
            int width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 100f, context.Resources.DisplayMetrics);
            int height = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 100f, context.Resources.DisplayMetrics);
            float size = Math.Min(width, height);
            int stroke = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 8f, context.Resources.DisplayMetrics);
            paint.StrokeWidth = stroke;
            paint.SetStyle(Paint.Style.Stroke);
            RectF oval = new RectF(0, 0, width, height);
            oval.Inset(size / 8, size / 8);

            paint.Color = defaultColor;
            Path redPath = new Path();
            redPath.ArcTo(oval, 0, 120, true);
            canvas.DrawPath(redPath, paint);

            paint.Color = defaultColor;
            Path greenPath = new Path();
            greenPath.ArcTo(oval, 120, 240, true);
            canvas.DrawPath(greenPath, paint);

            paint.Color = selectedColor;
            Path bluePath = new Path();
            if (progress != 0)
            {
                if (progress <= 20)
                {
                    bluePath.ArcTo(oval, 240, 120, true);
                }
                else if (progress <= 40)
                {
                    bluePath.ArcTo(oval, 240, 150, true);
                }
                else if (progress <= 60)
                {
                    bluePath.ArcTo(oval, 240, 180, true);
                }
                else if (progress <= 80)
                {
                    bluePath.ArcTo(oval, 240, 210, true);
                }
                else if (progress <= 95)
                {
                    bluePath.ArcTo(oval, 240, 300, true);
                }
                else if (progress < 100)
                {
                    bluePath.ArcTo(oval, 240, 330, true);
                }
                else if (progress == 100)
                {
                    bluePath.ArcTo(oval, 240, 360, true);
                }
            }
            else
            {
                bluePath.ArcTo(oval, 240, 0, true);
            }
            canvas.DrawPath(bluePath, paint);

            int strkWidth = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 8f, context.Resources.DisplayMetrics);
            paint.StrokeWidth = 2;
            paint.Color = Color.ParseColor("#ffffff");
            canvas.Save();
            for (int i = 0; i < 360; i += 60)
            {
                canvas.Rotate(60, size / 2, size / 2);
                if (enableSteps)
                {
                    canvas.DrawLine(size * 3 / 4, size / 2, size, size / 2, paint);
                }
                canvas.Restore();

                RectF ovalOuter = new RectF(0, 0, width, height);
                ovalOuter.Inset(1, 1);
                canvas.DrawOval(ovalOuter, paint);

                RectF ovalInner = new RectF(size / 8, size / 8, size / 8, size / 8);
                canvas.DrawOval(ovalInner, paint);
            }
        }

        public override void SetAlpha(int alpha)
        {
            paint.Alpha = alpha;
        }

        public override void SetColorFilter(ColorFilter colorFilter)
        {
            //paint.ColorFilter = colorFilter;
        }
    }
}
