using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace CircularImageView
{
    [Activity(Label = "CircularImageView", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //int strokeWidth = 8;
            int strokeColor = Color.ParseColor("#ff0000ff");
            int fillColor = Color.ParseColor("#ffff0000");
            GradientDrawable gD = new GradientDrawable();
            //gD.SetColor(fillColor);
            gD.SetShape(ShapeType.Oval);
            gD.SetStroke(1,Color.DarkBlue, 180, 90);
            TextView textView = FindViewById<TextView>(Resource.Id.circle1);
            TextView textView2 = FindViewById<TextView>(Resource.Id.circle2);
            TextView textView3 = FindViewById<TextView>(Resource.Id.circle3);
            TextView textView4 = FindViewById<TextView>(Resource.Id.circle4);
            TextView textView5 = FindViewById<TextView>(Resource.Id.circle5);
            TextView textView6 = FindViewById<TextView>(Resource.Id.circle6);
            //textView.Background = new CustomDrawable();

            //LayerDrawable layerDrawable = (LayerDrawable)Resources.GetDrawable(Resource.Drawable.circular_shape_blue);
            //GradientDrawable gradientDrawable = (GradientDrawable)layerDrawable.FindDrawableByLayerId(Resource.Id.itemId);
            ////int px = (int)TypedValue.ApplyDimension(TypedValue.C, 1.5f, getResources().getDisplayMetrics());
            //int strokeWidth = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 8f, Resources.DisplayMetrics);
            //gradientDrawable.SetStroke(strokeWidth, Color.DarkGoldenrod, 150, 60);

            //GradientDrawable gradientDrawable2 = (GradientDrawable)layerDrawable.FindDrawableByLayerId(Resource.Id.itemId2);
            //int strokeWidth2 = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 8f, Resources.DisplayMetrics);
            //gradientDrawable2.SetStroke(strokeWidth, Color.Gray, 120, 60);
            //textView.SetBackgroundDrawable(layerDrawable);

            // View view = (View)FindViewById(Resource.Id.view);
            textView.Background = new CustomDrawable(this, Color.ParseColor("#cdcdcd"), Color.ParseColor("#ff0099cc"), 20, true);
            textView2.Background = new CustomDrawable(this, Color.ParseColor("#cdcdcd"), Color.ParseColor("#ffffbb33"), 100, false);
            textView3.Background = new CustomDrawable(this, Color.ParseColor("#cdcdcd"),Color.ParseColor("#ff99cc00"), 40, true);
            textView4.Background = new CustomDrawable(this, Color.ParseColor("#cdcdcd"),Color.ParseColor("#ff0099cc"), 70, true);
            textView5.Background = new CustomDrawable(this, Color.ParseColor("#cdcdcd"),Color.ParseColor("#ff99cc00"), 85, false);
            textView6.Background = new CustomDrawable(this, Color.ParseColor("#cdcdcd"),Color.ParseColor("#ff99cc00"), 97, false);

        }
    }
}

