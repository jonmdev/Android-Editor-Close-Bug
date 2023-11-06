using System.Diagnostics;

namespace Android_Editor_Close_Bug {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            //MainPage = new ContentPage();
            MainPage = TestPage.Instance;
            

        }

        
    }

    public class TestPage : ContentPage {

        private static readonly Lazy<TestPage> lazy = new Lazy<TestPage>(() => new TestPage());
        public static TestPage Instance { get { return lazy.Value; } }

        public Editor editor;

        private TestPage() {
            VerticalStackLayout vert = new();
            this.Content = vert;

            Border border = new();
            border.StrokeThickness = 4;
            border.BackgroundColor = Colors.DarkBlue;
            border.Stroke = Colors.Red;
            border.Padding = 10;
            vert.Children.Add(border);

            editor = new();
            editor.BackgroundColor = Colors.White;
            editor.AutoSize = EditorAutoSizeOption.TextChanges;
            editor.MaximumHeightRequest = 200;
            border.Content = editor;

            editor.Focused += delegate {
                Debug.WriteLine("======= EDITOR FOCUSED");
            };

            editor.Unfocused += delegate {
                Debug.WriteLine("======= EDITOR UN-FOCUSED"); //no way to trigger this when closing soft keyboard as back buton event not invoked by this in MauiProgram
            };
        }
    }

}