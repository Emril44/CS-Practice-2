using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
