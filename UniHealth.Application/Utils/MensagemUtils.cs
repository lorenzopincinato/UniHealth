using System.Windows;

namespace UniHealth.Application.Utils
{
    public static class MensagemUtils
    {
        public static void MostrarMensagemAlerta(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void MostrarMensagemErro(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MostrarMensagemSucesso(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
