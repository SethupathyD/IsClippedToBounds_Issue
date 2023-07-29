namespace AbsoluteLayoutDemo
{
    public class CustomRowLayout : AbsoluteLayout
    {
        CustomCellLayout content;

        public CustomRowLayout()
        {
            content = new CustomCellLayout();
            WidthRequest = 300;
            HeightRequest = 50;
            this.Add(content);
            this.BackgroundColor = Colors.Green;

            this.IsClippedToBounds = false;
        }

        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            (this.content as IView).Measure(300, 50);
            return base.MeasureOverride(300, 50);
        }

        protected override Size ArrangeOverride(Rect bounds)
        {
            AbsoluteLayout.SetLayoutBounds(this.content, new Rect(0, 0, 300, 50));
            return base.ArrangeOverride(bounds);
        }
    }

    public class CustomCellLayout : ContentView
    {
        public CustomCellLayout()
        {
            Label label = new Label();
            label.Text = ".NET Multi-platform App UI (.NET MAUI) lets you build native apps";
            label.BackgroundColor = Colors.Red;
            this.Content = label;
        }

        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            (this.Content as IView).Measure(300, 100);
            return base.MeasureOverride(widthConstraint, heightConstraint);
        }

        protected override Size ArrangeOverride(Rect bounds)
        {
            var rect = new Rect(0, 0, 300, 100);
            (this.Content as IView).Arrange(rect);
            return base.ArrangeOverride(bounds);
        }
    }
}