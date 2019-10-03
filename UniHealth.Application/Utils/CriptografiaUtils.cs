using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHealth.Application.Utils
{
    public static class CriptografiaUtils
    {
        public enum ModoCriptografia
        {
            Encriptando,
            Decriptando
        }

        static private char[] vetorCriptografiaEmCifra = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                                              'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                                              'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '0', '1', '2',
                                                              '3', '4', '5', '6', '7', '8', '9'};

        static private int chaveCriptografiaEmCifra = 4;

        static public string CriptografiaEmCifra(string senha)
        {
            string senhaCriptografadaEmCifra = "";
            senha = senha.ToUpper();

            for (int i = 0; i < senha.Length; i++)
            {
                senhaCriptografadaEmCifra += getCifraEquivalente(senha[i], ModoCriptografia.Encriptando);
            }

            return senhaCriptografadaEmCifra;
        }

        static public string DecriptografiaEmCifra(string senha)
        {
            string senhaDecriptografadaEmCifra = "";
            senha = senha.ToUpper();

            for (int i = 0; i < senha.Length; i++)
            {
                senhaDecriptografadaEmCifra += getCifraEquivalente(senha[i], ModoCriptografia.Decriptando);
            }

            return senhaDecriptografadaEmCifra;
        }

        static public char getCifraEquivalente(char caracterInicial, ModoCriptografia modoCriptografia)
        {
            char caracterFinal = ' ';
            int posicaoEquivalente;

            for (int i = 0; i < vetorCriptografiaEmCifra.Length - 1; i++)
            {
                if (caracterInicial == vetorCriptografiaEmCifra[i])
                {
                    if (modoCriptografia == ModoCriptografia.Encriptando)
                        posicaoEquivalente = (i + chaveCriptografiaEmCifra) % vetorCriptografiaEmCifra.Length;    // mod (%) para posicao não passar de vetor.length
                    else
                    {
                        posicaoEquivalente = i - chaveCriptografiaEmCifra;
                        if (posicaoEquivalente < 0)                                                             // if para posicao não ser menor que 0
                            posicaoEquivalente = (vetorCriptografiaEmCifra.Length) + posicaoEquivalente;      // arrumar aqui
                    }

                    caracterFinal = vetorCriptografiaEmCifra[posicaoEquivalente];
                    break;
                }
            }

            return caracterFinal;
        }

        static public string CriptografaEmCodigo(string senha)
        {
            string senhaCriptografadaEmCodigo = "";

            for (int i = 0; i < senha.Length; i++)
            {
                switch (senha.ToUpper()[i])
                {
                    case 'A':
                        senhaCriptografadaEmCodigo += '*';
                        break;
                    case 'E':
                        senhaCriptografadaEmCodigo += '#';
                        break;
                    case 'I':
                        senhaCriptografadaEmCodigo += '+';
                        break;
                    case 'O':
                        senhaCriptografadaEmCodigo += '-';
                        break;
                    case 'U':
                        senhaCriptografadaEmCodigo += '$';
                        break;
                    default:
                        senhaCriptografadaEmCodigo += senha[i];
                        break;
                }
            }

            return senhaCriptografadaEmCodigo;
        }

        static public string DecriptografiaEmCodigo(string senha)
        {
            string senhaDecriptografadaEmCodigo = "";

            for (int i = 0; i < senha.Length; i++)
            {
                switch (senha.ToUpper()[i])
                {
                    case '*':
                        senhaDecriptografadaEmCodigo += 'A';
                        break;
                    case '#':
                        senhaDecriptografadaEmCodigo += 'E';
                        break;
                    case '+':
                        senhaDecriptografadaEmCodigo += 'I';
                        break;
                    case '-':
                        senhaDecriptografadaEmCodigo += 'O';
                        break;
                    case '$':
                        senhaDecriptografadaEmCodigo += 'U';
                        break;
                    default:
                        senhaDecriptografadaEmCodigo += senha[i];
                        break;
                }
            }

            return senhaDecriptografadaEmCodigo;
        }
    }
}
