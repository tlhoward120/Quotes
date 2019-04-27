using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Quotes.Effects;
using System.Linq;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]


namespace Android.Widget
{
    public class LabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var control = Control as Android.Widget.TextView;
                var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                if (effect != null)
                {
                    float radius = effect.Radius;
                    float distanceX = effect.DistanceX;
                    float distanceY = effect.DistanceY;
                    Android.Graphics.Color color = effect.Color.ToAndroid();
                    control.SetShadowLayer(radius, distanceX, distanceY, color);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot set property on attached control. Error: {ex.Message}");
            }
        }
        protected override void OnDetached()
        {
            
        }
    }
}
