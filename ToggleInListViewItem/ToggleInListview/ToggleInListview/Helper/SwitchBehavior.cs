using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GettingStarted
{
   public class SwitchBehavior :Behavior<Switch>
    {
        #region Fields

        Switch ToggleSwitch;
        private Random random = new Random();

        #endregion

        protected override void OnAttachedTo(Switch bindable)
        {
            ToggleSwitch = bindable;
            ToggleSwitch.Toggled += ToggleSwitch_Toggled;
            base.OnAttachedTo(bindable);
        }

        private async void ToggleSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            var model = ((sender as Switch).BindingContext as ContactInfo);
            if (model.IsChecked == true)
            {
                model.ContactNo = random.Next(100, 400).ToString() + "-" + random.Next(500, 800).ToString() + "-" + random.Next(1000, 2000).ToString();
                model.IsDescriptionVisible = false;
                model.IsIndicatorVisible = true;
                await Task.Delay(2000);
                model.IsDescriptionVisible = true;
                model.IsIndicatorVisible = false;
                model.IsChecked = false;
            }
            else
            {
                model.IsIndicatorVisible = false;
            }
        }
    }
}
