using System.Collections;
using Xamarin.Forms;

namespace RepeaterD
{
    public class RepeaterView : StackLayout
    {
        public ICollection ItemsSource
        {
            get => (ICollection)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        //obtiene la data que sera mostrada dentro de
        //la listview
        public static readonly BindableProperty
            ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(ICollection),
                typeof(RepeaterView),
                null,
                BindingMode.OneWay,
                propertyChanged: ItemsChanged);

        //propiedades bindables 
        //usamos para especificar el Template 
        //que implementaremos en el ViewRepeater
        public static readonly BindableProperty
            ItemTemplateProperty =
            BindableProperty.Create(
            nameof(ItemTemplate),
            typeof(DataTemplate),
            typeof(RepeaterView),
            default(DataTemplate));

        public RepeaterView()
        {
            Spacing = 0;
        }

        protected virtual Xamarin.Forms.View ViewFor(object item)
        {
            Xamarin.Forms.View view = null;

            if (ItemTemplate != null)
            {
                var content = ItemTemplate.CreateContent();

                view = content is Xamarin.Forms.View ? content as Xamarin.Forms.View :
                    ((ViewCell)content).View;

                view.BindingContext = item;
            }
            return view;
        }

        //notifica si la repeaterView tiene cambio y se refresca
        private static void ItemsChanged(BindableObject bindable,
            object oldValue, object newValue)
        {
            var control = bindable as RepeaterView;

            if (control == null) return;

            control.Children.Clear();

            var items = (ICollection)newValue;

            if (items == null) return;

            foreach (var item in items)
            {
                control.Children.Add(control.ViewFor(item));
            }
        }
    }
}
