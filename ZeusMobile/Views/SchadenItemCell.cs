// <copyright company="ZHAW">
// Copyright (c) 2015 All Right Reserved
// </copyright>
// <author>Daniel Widmer</author>
// <date>30.06.2015</date>

using Xamarin.Forms;

namespace ZeusMobile.Views
{
	public class SchadenItemCell : ViewCell
	{
		public SchadenItemCell ()
		{
			var label = new Label {
				YAlign = TextAlignment.Center
			};
			label.SetBinding (Label.TextProperty, "SchadenListeText");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {label}
			};
			View = layout;
		}

		protected override void OnBindingContextChanged ()
		{
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged ();
		}
	}
}

