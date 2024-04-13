using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JuegoAdivinarNumero
{
    public class AdivinaNumero:INotifyPropertyChanged
    {
        private ushort NumeroGenerado { get; set; }
        private int op;
        public int Oportunidades
        {
            get { return op; }
        }
        public ushort NumeroJugador { get; set; }
        public string Pista = "Presione el bóton Iniciar para comenzar con el juego.";
        Random azar = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand IniciarCommand { get; set; }
        public ICommand JugarCommand { get; set; }

        public void Iniciar()
        {
            NumeroGenerado = (ushort)azar.Next(1, 5001);
            op = 20;
            Pista = "Ingresa un número que creas posible y correcto.";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public void Jugar()
        {
            if (NumeroJugador == NumeroGenerado)
            {
                Pista = "FELICIDADES. HAS ACERTADO EL NÚMERO.";
            }
            else
            {
                op--;
                if (op == 0)
                {
                    Pista = $"Lo siento has perdido. El número era {NumeroGenerado}. Sigue intentandólo.";
                }
                else
                {
                    Pista = NumeroJugador > NumeroGenerado ? "El número que debes adivinar es Menor" : "El número que debes adivinar es Mayor";
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            return;
        }
        public AdivinaNumero()
        {
            IniciarCommand = new RelayCommand(Iniciar);
            JugarCommand = new RelayCommand(Jugar);
        }
    }
}
