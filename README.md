# How to show busy indicator on ListViewItem using toggle switch

The SfListView allows to display `ActivityIndicator` for an item when loading its data in the background. To do this, load both `ActivityIndicator` and a `toggle` switch in the same row of a `Grid` element inside the `ItemTemplate` of SfListView. The busy indicator and toggle switch can be enabled and disabled by using the IsButtonVisible and IsIndicatorVisible properties respectively in the model class. The `ActivityIndicator` remains visible when the toggle switch is enabled.

```
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms">
    <ContentPage.BindingContext>
        <local:ContactInfoRepository x:Name="ViewModel" />
    </ContentPage.BindingContext>
    <syncfusion:SfListView x:Name="listView" AutoFitMode="Height" BackgroundColor="#d3d3d3" SelectionMode="None" ItemsSource="{Binding NewContactInfo}">
        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                <Frame HasShadow="True" Margin="5,5,5,0">
                <Grid Padding="5">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>
                    <Label Text="{Binding ContactName}" FontAttributes="Bold" FontSize="19" />
                  <Switch Grid.Row="1" Grid.Column="1" IsVisible="{Binding IsButtonVisible}" IsToggled="{Binding IsChecked}" Toggled="Switch_Toggled"/>

                  <Label Grid.Row="1" Text="{Binding ContactNo}" FontSize="15" IsVisible="{Binding IsDescriptionVisible}" />
                    <ActivityIndicator Grid.Row="1" IsEnabled="True" IsRunning="True" IsVisible="{Binding IsIndicatorVisible}" />
                </Grid>
                </Frame>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>
    </syncfusion:SfListView>
</ContentPage>
```
In the Toggled event of the switch, get the row data from its BindingContext and alter the Bool values accordingly.

```
public partial class MainPage : ContentPage
{
  private Random random = new Random();
  public MainPage()
  {
     InitializeComponent();
  }

  private async void Switch_Toggled(object sender, ToggledEventArgs e)
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
```

To know more about showing busy indicator on listview items usig toggle switch, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/viewappearance?cs-save-lang=1&cs-lang=csharp#show-busy-indicator-on-list-view-items-using-toggle-switch).