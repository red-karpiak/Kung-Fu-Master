using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Models
{
    public class ImageCircle : Image
    {
        public string Name;
        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(
            PropertyName: nameof(BorderThickness),
            returnType: typeof(int),
            declaringType: typeof(ImageCircle),
            defaultValue: 0
        );
        public int BorderThickness
        {
            get { return (int)Get.Value(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
            
        }
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            PropertyName: nameof(BorderColor),
            returnType: typeof(Color),
            declaringType: typeof(ImageCircle),
            defaultValue: 0
        );
        public Color BorderColor
        {
            get { return (Color)Get.Value(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }

        }
        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
            PropertyName: nameof(FillColor),
            returnType: typeof(Color),
            declaringType: typeof(ImageCircle),
            defaultValue: 0
        );
        public Color FillColor
        {
            get { return (Color)Get.Value(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }

        }

    }
}
