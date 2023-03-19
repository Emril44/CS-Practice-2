using System.Windows;
using System.Windows.Controls;

namespace CS_Practice_2.Tools.Controls
{
    /// <summary>
    /// Interaction logic for CaptionedTextBox.xaml
    /// </summary>
    public partial class CaptionedTextBox : UserControl
    {
        public string Caption
        {
            get { return TbCaption.Text; }
            set { TbCaption.Text = value; }
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CaptionedTextBox), new PropertyMetadata(null));

        public CaptionedTextBox()
        {
            InitializeComponent();
        }
    }
}
