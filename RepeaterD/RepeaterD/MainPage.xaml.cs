
namespace RepeaterD
{
    using System;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void EmpleadosTap(object sender, EventArgs e)
        {
            var view = sender as View;

            var empleado = view?.BindingContext as string;

            DisplayAlert(
                "Evento Tap",
                "Tu has seleccionado "+empleado,
                "Ok");
        }
        private void EstudiantesTap(object sender, EventArgs e)
        {
            var view = sender as View;

            var estudiante = view?.BindingContext as string;

            var vm = BindingContext as RepeaterViewModel;

            //vm.EstudiantesCommand.Execute(estudiante);

            DisplayAlert(
                "Evento Tap",
                "Tu has seleccionado " + estudiante,
                "Ok");
        }
    }
}
