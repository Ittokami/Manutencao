using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Manutenção.Cell
{
    public class ClienteCell : ViewCell
    {
        public ClienteCell()
        {
            var IDCliente = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
            };
            IDCliente.SetBinding(Label.TextProperty, new Binding("ID"));

            var Nome = new Label
            {
                FontSize = 20,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
                Margin = 2
            };
            Nome.SetBinding(Label.TextProperty, new Binding("Nome"));

            var Servico = new Label
            {
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.None,
                HorizontalOptions = LayoutOptions.Start,
                Margin = 2,
            };
            Servico.SetBinding(Label.TextProperty, new Binding("Servico", stringFormat: "Função : {0}"));

            var Image = new CircleImage
            {
                BorderColor = Color.White,
                BorderThickness = 3,
                HeightRequest = 70,
                WidthRequest = 70,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                Margin = 1,
                Source = "Icon2"
                
            };
            Image.SetBinding(Label.TextProperty, new Binding("Image"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                     Image,Nome
                },
            };
            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                     Servico
                },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    line1,line2
                },
            };
        }
    }
}
