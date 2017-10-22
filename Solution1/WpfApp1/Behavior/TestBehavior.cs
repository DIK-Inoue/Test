using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace WpfApp1.Behavior
{
    class TestBehavior : Behavior<TextBox>
    {
        private string prev;

        public TestBehavior()
        {

        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += GotFocusEvent;
            AssociatedObject.LostFocus += LostFocusEvent;
            AssociatedObject.TextChanged += TextChangedEvent;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= GotFocusEvent;
            AssociatedObject.LostFocus -= LostFocusEvent;
            AssociatedObject.TextChanged -= TextChangedEvent;
        }

        private void GotFocusEvent(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("GotFocusEvent" + AssociatedObject.Text);
        }

        private void LostFocusEvent(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("LostFocusEvent" + AssociatedObject.Text);
        }

        private void TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("TextChangedEvent" + AssociatedObject.Text);
            if (string.IsNullOrEmpty(AssociatedObject.Text?.ToString()))
            {
                Console.WriteLine("  -> null");
                prev = null;
                AssociatedObject.Text = null;
                return;
            }
            if (decimal.TryParse(AssociatedObject.Text.ToString(), out decimal ret))
            {
                Console.WriteLine("  -> decimal value");
                prev = AssociatedObject.Text;
                return;
            }
            Console.WriteLine("  -> fail");
            var index = AssociatedObject.CaretIndex;
            AssociatedObject.Text = prev;
            AssociatedObject.CaretIndex = index - 1;
        }
    }
}
