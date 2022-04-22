using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenWeather.Behavior
{
    public class SelectAllTextOnEnterKeyPressBehavior : Behavior<TextBox>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyUp += AssociatedObject_PreviewKeyUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewKeyUp -= AssociatedObject_PreviewKeyUp;
        }

        private void AssociatedObject_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AssociatedObject.SelectAll();
            }
        }
    }
}
