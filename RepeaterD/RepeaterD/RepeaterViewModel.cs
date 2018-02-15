
namespace RepeaterD
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class RepeaterViewModel
    {
        public List<string> Empleados { get; set; }

        public List<string> Estudiantes { get; set; }

        public ICommand EstudiantesCommand = new Command(item => 
        {

            
        });

        public RepeaterViewModel()
        {
            Empleados = new List<string>
            {
                "Eleazar",
                "Roger",
                "Nestor",
                "Francisco",
                "Ivan",
                "Abel",
                "Cristofer"
            };

            Estudiantes = new List<string>
            {
                "Eleazar Padre",
                "Delavlle",
                "Jose",
                "Yessica",
                "Eleazar",
                "Mimi",
                "Wallace",
                "Milka"
            };
        }

    }
}
