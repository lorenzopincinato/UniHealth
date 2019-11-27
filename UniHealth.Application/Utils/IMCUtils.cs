namespace UniHealth.Application.Utils
{
    public static class IMCUtils
    {
        public static string GetFaixaDeIMC(double imc)
        {
            if (imc < 18.5)
                return "Peso Baixo";

            if (imc < 25)
                return "Peso Normal";

            if (imc < 30)
                return "Sobrepeso";

            if (imc < 35)
                return "Obesidade";

            if (imc < 40)
                return "Obesidade Severa";

            return "Obesidade Mórbida";
        }
    }
}
