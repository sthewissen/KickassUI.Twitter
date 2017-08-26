using NControl.Abstractions;
using NControl.Controls;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;

namespace KickassUI.Twitter.Controls
{
    /// <summary>
    /// Implements a floating action button with a font awesome label as
    /// the icon. An action button is part of Google Material Design and
    /// therefore has a few attributes that should be set correctly.
    ///
    /// http://www.google.com/design/spec/components/buttons.html
    ///
    ///
    /// </summary>
    public class ImageActionButton : NControlView
    {
        //private double _originalY, _originalX;
        public ListView AttachedScroll { get; set; }

        #region Protected Members

        /// <summary>
        /// The button shadow element.
        /// </summary>
        protected readonly NControlView ButtonShadowElement;

        /// <summary>
        /// The button element.
        /// </summary>
        protected readonly NControlView ButtonElement;

        /// <summary>
        /// The button icon label.
        /// </summary>
        protected readonly Image ButtonIconImage;

        #endregion Protected Members

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ExpenseClaimApp.Controls.ImageActionButton"/> class.
        /// </summary>
        public ImageActionButton()
        {
            var layout = new Grid { Padding = 0, ColumnSpacing = 0, RowSpacing = 0 };

            ButtonShadowElement = new NControlView
            {
                DrawingFunction = (canvas, rect) =>
                {
                    // Draw shadow
                    rect.Inflate(new NGraphics.Size(-4));
                    rect.Y += 4;

                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        //iOS
                        canvas.DrawEllipse(rect, null, new NGraphics.RadialGradientBrush(new NGraphics.Color(0, 0, 0, 200), NGraphics.Colors.Clear));
                    }
                    else if (Device.RuntimePlatform == Device.Android)
                    {
                        // Android
                        canvas.DrawEllipse(rect, null, new NGraphics.RadialGradientBrush(new NGraphics.Point(rect.Width / 2, (rect.Height / 2) + 2),
                            new NGraphics.Size(rect.Width, rect.Height), new NGraphics.Color(0, 0, 0, 200), NGraphics.Colors.Clear));
                    }
                }
            };

            ButtonElement = new NControlView
            {
                DrawingFunction = (canvas, rect) =>
                {
                    // Draw button circle
                    rect.Inflate(new NGraphics.Size(-8));
                    canvas.DrawEllipse(rect, null, new NGraphics.SolidBrush(ButtonColor.ToNColor()));
                }
            };

            ButtonIconImage = new Image { Scale = 0.4 };

            var imageWrapper = new Grid { Padding = 5 };
            imageWrapper.Children.Add(ButtonIconImage);

            layout.Children.Add(ButtonShadowElement);
            layout.Children.Add(ButtonElement);
            layout.Children.Add(imageWrapper);

            Content = layout;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(AttachedScroll))
            {
                if (AttachedScroll != null)
                {
                    AttachedScroll.ItemDisappearing += (o, e) =>
                   {
                       var listViewEnumerator = AttachedScroll.ItemsSource.GetEnumerator();
                       var firstItem = listViewEnumerator.MoveNext();
                       if (firstItem && e.Item == listViewEnumerator.Current)
                           this.TranslateTo(0, 100, 200);
                   };

                    AttachedScroll.ItemAppearing += (o, e) =>
                   {
                       var listViewEnumerator = AttachedScroll.ItemsSource.GetEnumerator();
                       var firstItem = listViewEnumerator.MoveNext();
                       if (firstItem && e.Item == listViewEnumerator.Current)
                           this.TranslateTo(0, 0, 200);
                   };
                }
            }
        }

        #region Properties

        /// <summary>
        /// The command property.
        /// </summary>
        public static BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ImageActionButton), null,
                BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
                {
                    var ctrl = (ImageActionButton)bindable;
                    ctrl.Command = (ICommand)newValue;
                });

        /// <summary>
        /// Gets or sets the color of the buton.
        /// </summary>
        /// <value>The color of the buton.</value>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set
            {
                if (Command != null)
                    Command.CanExecuteChanged -= HandleCanExecuteChanged;

                SetValue(CommandProperty, value);

                if (Command != null)
                    Command.CanExecuteChanged += HandleCanExecuteChanged;
            }
        }

        /// <summary>
        /// The command parameter property.
        /// </summary>
        public static BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ImageActionButton), null,
                BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
                {
                    var ctrl = (ImageActionButton)bindable;
                    ctrl.CommandParameter = newValue;
                });

        /// <summary>
        /// Gets or sets the color of the buton.
        /// </summary>
        /// <value>The color of the buton.</value>
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// The button color property.
        /// </summary>
        public static BindableProperty ButtonColorProperty =
            BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(ImageActionButton), Color.Gray,
                BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
                {
                    var ctrl = (ImageActionButton)bindable;
                    ctrl.ButtonColor = (Color)newValue;
                });

        /// <summary>
        /// Gets or sets the color of the buton.
        /// </summary>
        /// <value>The color of the buton.</value>
        public Color ButtonColor
        {
            get { return (Color)GetValue(ButtonColorProperty); }
            set
            {
                SetValue(ButtonColorProperty, value);
                ButtonElement.Invalidate();
            }
        }

        /// <summary>
        /// The button icon property.
        /// </summary>
        public static BindableProperty ButtonIconProperty =
            BindableProperty.Create(nameof(ButtonIcon), typeof(string), typeof(ImageActionButton), FontAwesomeLabel.FAPlus,
                BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
                {
                    var ctrl = (ImageActionButton)bindable;
                    ctrl.ButtonIcon = (string)newValue;
                });

        /// <summary>
        /// Gets or sets the button icon.
        /// </summary>
        /// <value>The button icon.</value>
        public ImageSource ButtonIcon
        {
            get { return (string)GetValue(ButtonIconProperty); }
            set
            {
                SetValue(ButtonIconProperty, value);
                ButtonIconImage.Source = value;
            }
        }

        /// <summary>
        /// The button icon property.
        /// </summary>
        public static BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(ImageActionButton), true,
                BindingMode.TwoWay, null, (bindable, oldValue, newValue) =>
                {
                    var ctrl = (ImageActionButton)bindable;
                    ctrl.HasShadow = (bool)newValue;
                });

        /// <summary>
        /// Gets or sets a value indicating whether this instance has shadow.
        /// </summary>
        /// <value><c>true</c> if this instance has shadow; otherwise, <c>false</c>.</value>
        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set
            {
                SetValue(HasShadowProperty, value);

                if (value)
                    ButtonShadowElement.FadeTo(1.0);
                else
                    ButtonShadowElement.FadeTo(0.0);
            }
        }

        #endregion Properties

        #region Private Members

        /// <summary>
        /// Handles the can execute changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        private void HandleCanExecuteChanged(object sender, EventArgs args)
        {
            IsEnabled = Command.CanExecute(CommandParameter);
        }

        #endregion Private Members

        #region Touch Events

        /// <summary>
        /// Toucheses the began.
        /// </summary>
        /// <param name="points">Points.</param>
        public override bool TouchesBegan(System.Collections.Generic.IEnumerable<NGraphics.Point> points)
        {
            base.TouchesBegan(points);

            if (!IsEnabled)
                return false;

            ButtonElement.ScaleTo(1.15, 140, Easing.CubicInOut);

            if (HasShadow)
            {
                ButtonShadowElement.TranslateTo(0.0, 3, 140, Easing.CubicInOut);
                ButtonShadowElement.ScaleTo(1.2, 140, Easing.CubicInOut);
                ButtonShadowElement.FadeTo(0.44, 140, Easing.CubicInOut);
            }

            return true;
        }

        /// <summary>
        /// Toucheses the cancelled.
        /// </summary>
        /// <param name="points">Points.</param>
        public override bool TouchesCancelled(System.Collections.Generic.IEnumerable<NGraphics.Point> points)
        {
            base.TouchesCancelled(points);

            if (!IsEnabled)
                return false;

            ButtonElement.ScaleTo(1.0, 140, Easing.CubicInOut);

            if (HasShadow)
            {
                ButtonShadowElement.TranslateTo(0.0, 0.0, 140, Easing.CubicInOut);
                ButtonShadowElement.ScaleTo(1.0, 140, Easing.CubicInOut);
                ButtonShadowElement.FadeTo(1.0, 140, Easing.CubicInOut);
            }

            return true;
        }

        /// <summary>
        /// Toucheses the ended.
        /// </summary>
        /// <param name="points">Points.</param>
        public override bool TouchesEnded(System.Collections.Generic.IEnumerable<NGraphics.Point> points)
        {
            base.TouchesEnded(points);

            if (!IsEnabled)
                return false;

            if (Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);

            ButtonElement.ScaleTo(1.0, 140, Easing.CubicInOut);

            if (HasShadow)
            {
                ButtonShadowElement.TranslateTo(0.0, 0.0, 140, Easing.CubicInOut);
                ButtonShadowElement.ScaleTo(1.0, 140, Easing.CubicInOut);
                ButtonShadowElement.FadeTo(1.0, 140, Easing.CubicInOut);
            }

            return true;
        }

        #endregion Touch Events

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            var retVal = base.OnMeasure(widthConstraint, heightConstraint);

            if (retVal.Request.Width > retVal.Request.Height)
                retVal.Request = new Size(retVal.Request.Width, retVal.Request.Width);
            else if (retVal.Request.Height > retVal.Request.Width)
                retVal.Request = new Size(retVal.Request.Height, retVal.Request.Height);

            retVal.Minimum = retVal.Request;
            return retVal;
        }
    }
}