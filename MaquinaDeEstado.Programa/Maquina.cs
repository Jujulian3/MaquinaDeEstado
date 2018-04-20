using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MaquinaDeEstado.Programa
{
    public class Maquina
    {
        private Estado Estado = Estado.Espera;
        private string validador = "*";
        private bool executarProcesso = true;

        public string Verificar(string palavra)             
        {
            foreach (var c in palavra)
            {
                if (executarProcesso) Processar(c);
                else break;
            }

            if (palavra.Length == 0) Estado = Estado.NaoAceitacao;

            if (Estado == Estado.Espera || Estado == Estado.NaoAceitacao) return "Esta string NÃO é aceita";
            else return "Esta string é aceita";
        }

        private void Processar(char c)
        {
            switch (Estado)
            {
                case Estado.Espera:
                    Espera(c);
                    executarProcesso = true;
                    break;

                case Estado.Aceitacao:
                    Aceitacao(c);
                    executarProcesso = true;
                    break;

                case Estado.NaoAceitacao:
                    NaoAceitacao(c);
                    executarProcesso = false;
                    break;
            }
        }

        private void NaoAceitacao(char c)
        {
            Estado = Estado.Espera;
        }

        private void Aceitacao(char c)
        {
            var verificador = Regex.Replace(c.ToString(), @"[^0-9a-zA-Z_]+", validador);

            if (verificador.Contains(validador) || verificador.Length == 0) Estado = Estado.NaoAceitacao;
            else Estado = Estado.Aceitacao;
        }

        private void Espera(char c)
        {           
            var verificador = Regex.Replace(c.ToString(), @"[^a-zA-Z_]+", validador);

            if (verificador.Contains(validador) || verificador.Length == 0) Estado = Estado.NaoAceitacao;
            else Estado = Estado.Aceitacao;
        }
    }
}
